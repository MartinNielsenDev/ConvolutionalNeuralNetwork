using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
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
            newNetworkButton.Enabled = false;
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
                Log("[INFO] Failed to create network");
                Log($"[ERROR] {err.Message}");
            }
            newNetworkButton.Enabled = true;
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
                trainButton.Text = "Abort";
                newNetworkButton.Enabled = false;
                saveNetworkButton.Enabled = false;
                importNetworkButton.Enabled = false;

                networkRunnerThread = new Thread(new ThreadStart(trainRunner))
                {
                    IsBackground = true
                };
                networkRunnerThread.Start();
                Log("[INFO] started");
                trainButton.Enabled = true;
            }
            else if (trainButton.Text == "Abort")
            {
                Log("[INFO] Stopped training");
                trainButton.Text = "Train";
                network.Abort = true;

                networkRunnerThread.Abort();

                newNetworkButton.Enabled = true;
                saveNetworkButton.Enabled = true;
                importNetworkButton.Enabled = true;
            }
        }

        private void importNetworkButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = networkPathTextBox.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Log("[INFO] importing network from file");
                string json = File.ReadAllText(openFileDialog1.FileName);
                try
                {
                    network = new ConvolutionalNeuralNetwork(28, 28, Path.GetDirectoryName(openFileDialog1.FileName), json);
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

        private void Log(string msg)
        {
            if (outputTextBox.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new[] { msg });
            }
            else
            {
                outputTextBox.AppendText(msg + Environment.NewLine);
            }
        }
    }
}
