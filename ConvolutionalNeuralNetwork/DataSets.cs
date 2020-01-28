using System;
using System.IO;
using System.Net;

namespace ConvolutionalNeuralNetwork
{
    internal class DataSets
    {
        public DataSet Train { get; set; }

        public DataSet Validation { get; set; }

        public DataSet Test { get; set; }

        public void Load(string path)
        {
            var train_images = Reader.Load(Path.Combine(path, "train"));
            var validation_images = Reader.Load(Path.Combine(path, "validation"));
            var test_images = Reader.Load(Path.Combine(path, "test"));

            if (train_images.Count == 0 || validation_images.Count == 0 || test_images.Count == 0)
            {
                return;
            }

            this.Train = new DataSet(train_images);
            this.Validation = new DataSet(validation_images);
            this.Test = new DataSet(test_images);
        }
    }
}