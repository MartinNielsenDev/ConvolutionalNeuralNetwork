using System;
using System.Linq;
using ConvNetSharp.Core;
using ConvNetSharp.Core.Layers.Double;
using ConvNetSharp.Core.Training;
using ConvNetSharp.Volume;
using ConvNetSharp.Volume.Double;
using ConvNetSharp.Core.Serialization;
using System.Drawing;
using System.IO;

namespace ConvolutionalNeuralNetwork
{
    public class ConvolutionalNeuralNetwork
    {
        internal static int _image_x, _image_y;
        private readonly CircularBuffer<double> _testAccWindow = new CircularBuffer<double>(100);
        private readonly CircularBuffer<double> _trainAccWindow = new CircularBuffer<double>(100);
        private Net<double> _net;
        private int _stepCount;
        private int _classes;
        private SgdTrainer<double> _trainer;
        private double _trainAccuracy, _testAccuracy;
        private DataSets _datasets;
        private Tuple<Volume<double>, Volume<double>, int[]> _trainData;
        private Tuple<Volume<double>, Volume<double>, int[]> _testData;
        public bool Abort = false;

        public ConvolutionalNeuralNetwork(int x, int y, string path, string json = null)
        {
            _image_x = x;
            _image_y = y;

            if (json != null)
            {
                _net = SerializationExtensions.FromJson<double>(json);
            }
            else
            {
                _classes = Directory.GetDirectories(Path.Combine(path, "train"), "*").Length;
                _net = new Net<double>();
                _net.AddLayer(new InputLayer(_image_x, _image_y, 1));
                _net.AddLayer(new ConvLayer(5, 5, 8) { Stride = 1, Pad = 2 });
                _net.AddLayer(new ReluLayer());
                _net.AddLayer(new PoolLayer(2, 2) { Stride = 2 });
                _net.AddLayer(new ConvLayer(5, 5, 16) { Stride = 1, Pad = 2 });
                _net.AddLayer(new ReluLayer());
                _net.AddLayer(new PoolLayer(3, 3) { Stride = 3 });
                _net.AddLayer(new FullyConnLayer(_classes));
                _net.AddLayer(new SoftmaxLayer(_classes));
            }
            _trainer = new SgdTrainer<double>(_net)
            {
                LearningRate = 0.01,
                BatchSize = 20,
                Momentum = 0.9
            };

            _datasets = new DataSets();
            _datasets.Load(path);
        }
        public int[] GetPredictionFromBitmaps(Bitmap[] bitmaps)
        {
            Shape shape = new Shape(_image_x, _image_y, 1, bitmaps.Length);
            Volume<double> dataVolume = BuilderInstance.Volume.From(new double[shape.TotalLength], shape);

            for (int i = 0; i < bitmaps.Length; i++)
            {
                Bitmap resizedBitmap = Reader.ResizeBitmap(bitmaps[i], _image_x, _image_y);
                byte[] byteArray = Reader.ToGrayscaleByte(resizedBitmap);
                int j = 0;

                for (int y = 0; y < _image_y; y++)
                {
                    for (int x = 0; x < _image_x; x++)
                    {
                        dataVolume.Set(x, y, 0, i, byteArray[j++] / 255.0);
                    }
                }
            }
            _net.Forward(dataVolume);

            return _net.GetPrediction();
        }
        public double[] TrainNetwork()
        {
            if (_datasets == null)
            {
                return new double[0];
            }
            _trainData = _datasets.Train.NextBatch(_trainer.BatchSize, _classes);
            Train(_trainData.Item1, _trainData.Item2, _trainData.Item3);

            _testData = _datasets.Test.NextBatch(_trainer.BatchSize, _classes);
            Test(_testData.Item1, _testData.Item3, _testAccWindow);

            _trainAccuracy = Math.Round(_trainAccWindow.Items.Average() * 100.0, 2);
            _testAccuracy = Math.Round(_testAccWindow.Items.Average() * 100.0, 2);

            return new double[3] { _trainAccuracy, _testAccuracy, _stepCount };
        }

        public string ExportNetwork()
        {
            return _net.ToJson();
        }

        private void Test(Volume<double> x, int[] labels, CircularBuffer<double> accuracy, bool forward = true)
        {
            if (forward)
            {
                _net.Forward(x);
            }

            var prediction = _net.GetPrediction();

            for (var i = 0; i < labels.Length; i++)
            {
                accuracy.Add(labels[i] == prediction[i] ? 1.0 : 0.0);
            }
        }

        private void Train(Volume<double> x, Volume<double> y, int[] labels)
        {
            _trainer.Train(x, y);

            Test(x, labels, _trainAccWindow, false);

            _stepCount += labels.Length;
        }
    }
}