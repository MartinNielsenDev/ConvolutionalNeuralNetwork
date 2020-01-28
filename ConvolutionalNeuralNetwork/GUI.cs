using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvolutionalNeuralNetwork
{
    public partial class GUI : Form
    {
        private ConvolutionalNeuralNetwork network;
        private Thread networkRunnerThread;
        public GUI()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                networkPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void newNetworkButton_Click(object sender, EventArgs e)
        {
            createNetworkButton.Enabled = false;
            trainButton.Enabled = false;
            saveNetworkButton.Enabled = false;
            importNetworkButton.Enabled = false;
            Log($"[INFO] creating new network on {networkPathTextBox.Text}");

            try
            {
                network = new ConvolutionalNeuralNetwork(28, 28, networkPathTextBox.Text);
                Log("[OK] success");
            }
            catch (Exception err)
            {
                Log("[INFO] failed to create network");
                Log($"[ERROR] {err.Message}");
            }
            createNetworkButton.Enabled = true;
            trainButton.Enabled = true;
            saveNetworkButton.Enabled = true;
            importNetworkButton.Enabled = true;
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            if (network == null)
            {
                Log("[ERROR] no network created");
                return;
            }
            if (trainButton.Text == "Train")
            {
                trainButton.Text = "Pause";
                createNetworkButton.Enabled = false;
                saveNetworkButton.Enabled = false;
                importNetworkButton.Enabled = false;

                networkRunnerThread = new Thread(new ThreadStart(trainRunner))
                {
                    IsBackground = true
                };
                networkRunnerThread.Start();
                Log("[INFO] started");
                trainButton.Enabled = true;
                trainerProgressBar.Style = ProgressBarStyle.Marquee;
            }
            else if (trainButton.Text == "Pause")
            {
                Log("[INFO] stopped training");
                trainButton.Text = "Train";
                network.Abort = true;

                networkRunnerThread.Abort();

                createNetworkButton.Enabled = true;
                saveNetworkButton.Enabled = true;
                importNetworkButton.Enabled = true;
                trainerProgressBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void importNetworkButton_Click(object sender, EventArgs e)
        {
            if (networkPathTextBox.Text == "")
            {
                Log("[ERROR] no train location");
                return;
            }
            openFileDialog1.InitialDirectory = networkPathTextBox.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Log("[INFO] importing network from file");
                string json = File.ReadAllText(openFileDialog1.FileName);
                try
                {
                    network = new ConvolutionalNeuralNetwork(28, 28, networkPathTextBox.Text, json);
                    Log("[OK] success");
                }
                catch
                {
                    Log("[ERROR] failed to import");
                }
            }
        }

        private void saveNetworkButton_Click(object sender, EventArgs e)
        {
            if (network == null)
            {
                Log("[ERROR] no network created");
                return;
            }
            Log("[INFO] saving network");
            string json = network.ExportNetwork();
            File.WriteAllText(Path.Combine(networkPathTextBox.Text, "network.json"), json);
            Log("[OK] success");
        }


        private async void generateDataButton_Click(object sender, EventArgs e)
        {
            AllowInput(false);
            int trainImages = 100;
            int validationImages = 100;
            int testImages = 100;
            double maxNoise = 0.35;
            string[] files = Directory.GetFiles(Path.Combine(networkPathTextBox.Text, "original"), "*", SearchOption.TopDirectoryOnly);

            Random r = new Random();
            dataProgressBar.Value = 0;
            dataProgressBar.Maximum = (trainImages + validationImages + testImages) * files.Length;

            foreach (string file in files)
            {
                Bitmap bitmap = new Bitmap(file);
                string filename = Path.GetFileNameWithoutExtension(file);
                string extension = Path.GetExtension(file);
                Directory.CreateDirectory(Path.Combine(networkPathTextBox.Text, "train", filename));
                Directory.CreateDirectory(Path.Combine(networkPathTextBox.Text, "validation", filename));
                Directory.CreateDirectory(Path.Combine(networkPathTextBox.Text, "test", filename));

                await Task.Run(() =>
                {
                    for (int i = 0; i < trainImages; i++)
                    {
                        GenerateNoise(bitmap, r.NextDouble() * maxNoise).Save(Path.Combine(networkPathTextBox.Text, "train", filename, (i + extension)));
                        IncrementDataProgressBar();
                    }
                });
                await Task.Run(() =>
                {
                    for (int i = 0; i < validationImages; i++)
                    {
                        GenerateNoise(bitmap, r.NextDouble() * maxNoise).Save(Path.Combine(networkPathTextBox.Text, "validation", filename, (i + extension)));
                        IncrementDataProgressBar();
                    }
                });
                await Task.Run(() =>
                {
                    for (int i = 0; i < testImages; i++)
                    {

                        GenerateNoise(bitmap, r.NextDouble() * maxNoise).Save(Path.Combine(networkPathTextBox.Text, "test", filename, (i + extension)));
                        IncrementDataProgressBar();
                    }
                });
            }
            AllowInput(true);
        }

        private void generatePersonalizedDataButton_Click(object sender, EventArgs e)
        {

        }

        private void trainRunner()
        {
            do
            {
                double[] output = network.TrainNetwork();
                if (output.Length < 3)
                {
                    network.Abort = true;
                    Log("Network Training failed...");
                    break;
                }
                Log($"Train Accuracy: {output[0]}% Test Accuracy: {output[1]}% Steps: {output[2]}");
            } while (!network.Abort);
        }

        private void AllowInput(bool allow)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                tab.Enabled = allow;
            }
        }

        private void IncrementDataProgressBar()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(IncrementDataProgressBar));
            }
            else
            {
                dataProgressBar.Value++;
                double percent = (dataProgressBar.Value / (double)dataProgressBar.Maximum) * 100;

                dataProgressBarLabel.Text = $"{Math.Round(percent, 1)}%";
            }
        }

        public Bitmap GenerateNoise(Bitmap original, double percent)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Random r = new Random();
            using (Graphics graphicsHandle = Graphics.FromImage(newBitmap))
            {
                //graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(original, 0, 0, original.Width, original.Height);
            }
            for (int x = 1; x < newBitmap.Width - 1; x++)
            {
                for (int y = 1; y < newBitmap.Height - 1; y++)
                {
                    double random = r.NextDouble();
                    if (random <= percent)
                    {
                        if (newBitmap.GetPixel(x + 1, y).R == 255 || // right side
                            newBitmap.GetPixel(x, y + 1).R == 255 || // bottom
                            newBitmap.GetPixel(x - 1, y).R == 255 || // left
                            newBitmap.GetPixel(x, y - 1).R == 255 // top
                            )
                        {
                            newBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                        }
                    }
                }
            }
            return newBitmap;
        }

        private void Log(string msg)
        {
            if (trainerTextBox.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new[] { msg });
            }
            else
            {
                trainerTextBox.AppendText(msg + Environment.NewLine);
            }
        }
    }
}
