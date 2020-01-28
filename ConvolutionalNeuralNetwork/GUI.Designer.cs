namespace ConvolutionalNeuralNetwork
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trainButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.networkPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.newNetworkButton = new System.Windows.Forms.Button();
            this.saveNetworkButton = new System.Windows.Forms.Button();
            this.importNetworkButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(128, 37);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(95, 35);
            this.trainButton.TabIndex = 0;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(12, 107);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(430, 224);
            this.outputTextBox.TabIndex = 1;
            // 
            // networkPathTextBox
            // 
            this.networkPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.networkPathTextBox.Location = new System.Drawing.Point(94, 10);
            this.networkPathTextBox.Name = "networkPathTextBox";
            this.networkPathTextBox.Size = new System.Drawing.Size(286, 21);
            this.networkPathTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Train Location";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(386, 9);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(56, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 78);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(365, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(386, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "0%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newNetworkButton
            // 
            this.newNetworkButton.Location = new System.Drawing.Point(15, 37);
            this.newNetworkButton.Name = "newNetworkButton";
            this.newNetworkButton.Size = new System.Drawing.Size(95, 35);
            this.newNetworkButton.TabIndex = 7;
            this.newNetworkButton.Text = "Create Network";
            this.newNetworkButton.UseVisualStyleBackColor = true;
            this.newNetworkButton.Click += new System.EventHandler(this.newNetworkButton_Click);
            // 
            // saveNetworkButton
            // 
            this.saveNetworkButton.Location = new System.Drawing.Point(238, 37);
            this.saveNetworkButton.Name = "saveNetworkButton";
            this.saveNetworkButton.Size = new System.Drawing.Size(95, 35);
            this.saveNetworkButton.TabIndex = 8;
            this.saveNetworkButton.Text = "Save Network";
            this.saveNetworkButton.UseVisualStyleBackColor = true;
            this.saveNetworkButton.Click += new System.EventHandler(this.saveNetworkButton_Click);
            // 
            // importNetworkButton
            // 
            this.importNetworkButton.Location = new System.Drawing.Point(347, 37);
            this.importNetworkButton.Name = "importNetworkButton";
            this.importNetworkButton.Size = new System.Drawing.Size(95, 35);
            this.importNetworkButton.TabIndex = 9;
            this.importNetworkButton.Text = "Import network";
            this.importNetworkButton.UseVisualStyleBackColor = true;
            this.importNetworkButton.Click += new System.EventHandler(this.importNetworkButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All files|*.json";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 343);
            this.Controls.Add(this.importNetworkButton);
            this.Controls.Add(this.saveNetworkButton);
            this.Controls.Add(this.newNetworkButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.networkPathTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.trainButton);
            this.Name = "GUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConvolutionalNeuralNetwork.Trainer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox networkPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newNetworkButton;
        private System.Windows.Forms.Button saveNetworkButton;
        private System.Windows.Forms.Button importNetworkButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}