using System;
using System.IO;

namespace ConvNeuralNetwork
{
    internal class DataSets
    {
        public DataSet Train { get; set; }

        public DataSet Validation { get; set; }

        public DataSet Test { get; set; }

        public bool Load2(string path)
        {
            Console.WriteLine("Loading the datasets...");
            var train_images = Reader.Load(Path.Combine(path, "train"));
            var validation_images = Reader.Load(Path.Combine(path, "validation"));
            var test_images = Reader.Load(Path.Combine(path, "test"));

            if (train_images.Count == 0 || validation_images.Count == 0 || test_images.Count == 0)
            {
                Console.WriteLine("Missing training/testing files.");
                Console.ReadKey();
                return false;
            }

            this.Train = new DataSet(train_images);
            this.Validation = new DataSet(validation_images);
            this.Test = new DataSet(test_images);

            return true;
        }
        public bool Load(int validationSize = 1000)
        {
            //Directory.CreateDirectory(mnistFolder);

            //var trainingLabelFilePath = Path.Combine(mnistFolder, trainingLabelFile);
            //var trainingImageFilePath = Path.Combine(mnistFolder, trainingImageFile);
            //var testingLabelFilePath = Path.Combine(mnistFolder, testingLabelFile);
            //var testingImageFilePath = Path.Combine(mnistFolder, testingImageFile);

            //// Download Mnist files if needed
            //Console.WriteLine("Downloading Mnist training files...");
            //DownloadFile(urlMnist + trainingLabelFile, trainingLabelFilePath);
            //DownloadFile(urlMnist + trainingImageFile, trainingImageFilePath);
            //Console.WriteLine("Downloading Mnist testing files...");
            //DownloadFile(urlMnist + testingLabelFile, testingLabelFilePath);
            //DownloadFile(urlMnist + testingImageFile, testingImageFilePath);

            //// Load data
            //Console.WriteLine("Loading the datasets...");
            //var train_images = MnistReader.Load(trainingLabelFilePath, trainingImageFilePath);
            //var testing_images = MnistReader.Load(testingLabelFilePath, testingImageFilePath);

            //var valiation_images = train_images.GetRange(train_images.Count - validationSize, validationSize);
            //train_images = train_images.GetRange(0, train_images.Count - validationSize);

            //if (train_images.Count == 0 || valiation_images.Count == 0 || testing_images.Count == 0)
            //{
            //    Console.WriteLine("Missing Mnist training/testing files.");
            //    Console.ReadKey();
            //    return false;
            //}

            //this.Train = new DataSet(train_images);
            //this.Validation = new DataSet(valiation_images);
            //this.Test = new DataSet(testing_images);

            return true;
        }
    }
}