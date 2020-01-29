using System;
using System.Linq;
using ConvNetSharp.Core;
using ConvNetSharp.Core.Training;
using ConvNetSharp.Volume;
using ConvNetSharp.Volume.Double;
using ConvNetSharp.Core.Serialization;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConvolutionalNeuralNetwork
{
    public class ConvolutionalNeuralNetwork
    {
        internal int image_x, image_y;
        private Net<double> _net;
        private SgdTrainer<double> _trainer;

        public ConvolutionalNeuralNetwork(string json)
        {
            JObject data = JsonConvert.DeserializeObject<JObject>(json);
            this.image_x = (int)data["Layers"][0]["InputWidth"];
            this.image_y = (int)data["Layers"][0]["InputHeight"];
            if (this.image_x == 0 || this.image_y == 0)
            {
                throw new Exception("InputWidth or InputHeight is equal to zero");
            }
            this._net = SerializationExtensions.FromJson<double>(data);
            this._trainer = new SgdTrainer<double>(this._net)
            {
                LearningRate = 0.01,
                BatchSize = 20,
                Momentum = 0.9
            };
        }

        public int[] GetPredictionFromBitmaps(Bitmap[] bitmaps)
        {
            Shape shape = new Shape(image_x, image_y, 1, bitmaps.Length);
            Volume<double> dataVolume = BuilderInstance.Volume.From(new double[shape.TotalLength], shape);

            for (int i = 0; i < bitmaps.Length; i++)
            {
                Bitmap resizedBitmap = Reader.ResizeBitmap(bitmaps[i], image_x, image_y);
                byte[] byteArray = Reader.ToGrayscaleByte(resizedBitmap);
                int j = 0;

                for (int y = 0; y < image_y; y++)
                {
                    for (int x = 0; x < image_x; x++)
                    {
                        dataVolume.Set(x, y, 0, i, byteArray[j++] / 255.0);
                    }
                }
            }

            this._net.Forward(dataVolume);

            return this._net.GetPrediction();
        }
    }
}