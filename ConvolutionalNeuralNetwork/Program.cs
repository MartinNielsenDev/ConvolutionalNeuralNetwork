using System;
using System.Linq;
using ConvNetSharp.Core;
using ConvNetSharp.Core.Layers.Double;
using ConvNetSharp.Core.Training;
using ConvNetSharp.Volume;
using ConvNetSharp.Volume.Double;
//using ConvNetSharp.Volume.GPU.Double;
using ConvNetSharp.Core.Serialization;
using System.IO;
using System.Drawing;

namespace ConvolutionalNeuralNetwork
{
    public class ConvolutionalNeuralNetwork
    {
        private readonly CircularBuffer<double> _testAccWindow = new CircularBuffer<double>(100);
        private readonly CircularBuffer<double> _trainAccWindow = new CircularBuffer<double>(100);
        private Net<double> _net;
        private int _stepCount;
        private SgdTrainer<double> _trainer;

        public ConvolutionalNeuralNetwork(string json)
        {
            this._net = SerializationExtensions.FromJson<double>(json);
        }
        private void Main()
        {
            LoadNetwork(@"C:\test\ratings_network");
            TrainNetwork(@"C:\test\ratings_network");
        }
        public string GetPredictionFromBitmaps(Bitmap[] bitmaps)
        {
            Shape shape = new Shape(28, 28, 1, bitmaps.Length);
            Volume<double> dataVolume = BuilderInstance.Volume.From(new double[shape.TotalLength], shape);

            for (int i = 0; i < bitmaps.Length; i++)
            {
                Bitmap resizedBitmap = MnistReader.ResizeBitmap(bitmaps[i], 28, 28);
                byte[] byteArray = MnistReader.ToGrayscaleByte(resizedBitmap);
                int j = 0;

                for (int y = 0; y < 28; y++)
                {
                    for (int x = 0; x < 28; x++)
                    {
                        dataVolume.Set(x, y, 0, i, byteArray[j++] / 255.0);
                    }
                }
            }

            this._net.Forward(dataVolume);

            return string.Join("", this._net.GetPrediction().Select(x => x.ToString()).ToArray());
        }
        private void TrainNetwork(string path)
        {
            var datasets = new DataSets();
            if (!datasets.Load2(path))
            {
                return;
            }
            CreateNetwork();
            Tuple<Volume<double>, Volume<double>, int[]> trainData;
            Tuple<Volume<double>, Volume<double>, int[]> testData;

            Console.WriteLine("Convolutional neural network learning...[Press any key to stop]");
            do
            {
                trainData = datasets.Train.NextBatch(this._trainer.BatchSize);
                Train(trainData.Item1, trainData.Item2, trainData.Item3);

                testData = datasets.Test.NextBatch(this._trainer.BatchSize);
                Test(testData.Item1, testData.Item3, this._testAccWindow);

                Console.WriteLine("Loss: {0} Train accuracy: {1}% Test accuracy: {2}%", this._trainer.Loss,
                    Math.Round(this._trainAccWindow.Items.Average() * 100.0, 2),
                    Math.Round(this._testAccWindow.Items.Average() * 100.0, 2));

                Console.WriteLine("Example seen: {0} Fwd: {1}ms Bckw: {2}ms", this._stepCount,
                    Math.Round(this._trainer.ForwardTimeMs, 2),
                    Math.Round(this._trainer.BackwardTimeMs, 2));
            } while (!Console.KeyAvailable);

            var json = this._net.ToJson();

            File.WriteAllText(Path.Combine(path, "network.json"), json);
        }

        private void CreateNetwork()
        {
            this._trainer = new SgdTrainer<double>(this._net)
            {
                LearningRate = 0.01,
                BatchSize = 20,
                Momentum = 0.9
            };
            if (this._net != null)
            {
                return;
            }
            // Create network
            this._net = new Net<double>();
            this._net.AddLayer(new InputLayer(28, 28, 1));
            this._net.AddLayer(new ConvLayer(5, 5, 8) { Stride = 1, Pad = 2 });
            this._net.AddLayer(new ReluLayer());
            this._net.AddLayer(new PoolLayer(2, 2) { Stride = 2 });
            this._net.AddLayer(new ConvLayer(5, 5, 16) { Stride = 1, Pad = 2 });
            this._net.AddLayer(new ReluLayer());
            this._net.AddLayer(new PoolLayer(3, 3) { Stride = 3 });
            this._net.AddLayer(new FullyConnLayer(10));
            this._net.AddLayer(new SoftmaxLayer(10));
        }

        private void Test(Volume<double> x, int[] labels, CircularBuffer<double> accuracy, bool forward = true)
        {
            if (forward)
            {
                this._net.Forward(x);
            }

            var prediction = this._net.GetPrediction();

            for (var i = 0; i < labels.Length; i++)
            {
                accuracy.Add(labels[i] == prediction[i] ? 1.0 : 0.0);
            }
        }

        private void Train(Volume<double> x, Volume<double> y, int[] labels)
        {
            this._trainer.Train(x, y);

            Test(x, labels, this._trainAccWindow, false);

            this._stepCount += labels.Length;
        }
    }
}