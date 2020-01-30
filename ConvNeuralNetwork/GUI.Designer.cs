using System.Windows.Forms;

namespace ConvNeuralNetwork
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
            this.trainerTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.trainerProgressBar = new System.Windows.Forms.ProgressBar();
            this.trainerProgressBarLabel = new System.Windows.Forms.Label();
            this.createNetworkButton = new System.Windows.Forms.Button();
            this.saveNetworkButton = new System.Windows.Forms.Button();
            this.importNetworkButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.trainerPage = new System.Windows.Forms.TabPage();
            this.trainerTextBoxPanel = new System.Windows.Forms.Panel();
            this.trainerLoadingPanel = new System.Windows.Forms.Panel();
            this.trainerNavTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataPage = new System.Windows.Forms.TabPage();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataProgressBar = new System.Windows.Forms.ProgressBar();
            this.dataProgressBarLabel = new System.Windows.Forms.Label();
            this.dataNavLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.testImagesButton = new System.Windows.Forms.Button();
            this.generatePersonalizedDataButton = new System.Windows.Forms.Button();
            this.generateDataButton = new System.Windows.Forms.Button();
            this.imagesToCreateTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.browseButton = new System.Windows.Forms.Button();
            this.networkPathTextBox = new System.Windows.Forms.TextBox();
            this.networkPathLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.trainerPage.SuspendLayout();
            this.trainerTextBoxPanel.SuspendLayout();
            this.trainerLoadingPanel.SuspendLayout();
            this.trainerNavTableLayoutPanel.SuspendLayout();
            this.dataPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.dataNavLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trainButton
            // 
            this.trainButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.trainButton.Location = new System.Drawing.Point(110, 3);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(101, 35);
            this.trainButton.TabIndex = 0;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // trainerTextBox
            // 
            this.trainerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainerTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trainerTextBox.Location = new System.Drawing.Point(3, 3);
            this.trainerTextBox.Multiline = true;
            this.trainerTextBox.Name = "trainerTextBox";
            this.trainerTextBox.ReadOnly = true;
            this.trainerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.trainerTextBox.Size = new System.Drawing.Size(424, 146);
            this.trainerTextBox.TabIndex = 1;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // trainerProgressBar
            // 
            this.trainerProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainerProgressBar.Location = new System.Drawing.Point(3, 3);
            this.trainerProgressBar.MarqueeAnimationSpeed = 50;
            this.trainerProgressBar.Name = "trainerProgressBar";
            this.trainerProgressBar.Size = new System.Drawing.Size(369, 33);
            this.trainerProgressBar.TabIndex = 5;
            // 
            // trainerProgressBarLabel
            // 
            this.trainerProgressBarLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.trainerProgressBarLabel.Location = new System.Drawing.Point(372, 3);
            this.trainerProgressBarLabel.Name = "trainerProgressBarLabel";
            this.trainerProgressBarLabel.Size = new System.Drawing.Size(55, 33);
            this.trainerProgressBarLabel.TabIndex = 6;
            this.trainerProgressBarLabel.Text = "0.0%";
            this.trainerProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createNetworkButton
            // 
            this.createNetworkButton.AutoSize = true;
            this.createNetworkButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.createNetworkButton.Location = new System.Drawing.Point(3, 3);
            this.createNetworkButton.Name = "createNetworkButton";
            this.createNetworkButton.Size = new System.Drawing.Size(101, 35);
            this.createNetworkButton.TabIndex = 7;
            this.createNetworkButton.Text = "Create Network";
            this.createNetworkButton.UseVisualStyleBackColor = true;
            this.createNetworkButton.Click += new System.EventHandler(this.newNetworkButton_Click);
            // 
            // saveNetworkButton
            // 
            this.saveNetworkButton.AutoSize = true;
            this.saveNetworkButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveNetworkButton.Location = new System.Drawing.Point(217, 3);
            this.saveNetworkButton.Name = "saveNetworkButton";
            this.saveNetworkButton.Size = new System.Drawing.Size(101, 35);
            this.saveNetworkButton.TabIndex = 8;
            this.saveNetworkButton.Text = "Save Network";
            this.saveNetworkButton.UseVisualStyleBackColor = true;
            this.saveNetworkButton.Click += new System.EventHandler(this.saveNetworkButton_Click);
            // 
            // importNetworkButton
            // 
            this.importNetworkButton.AutoSize = true;
            this.importNetworkButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.importNetworkButton.Location = new System.Drawing.Point(324, 3);
            this.importNetworkButton.Name = "importNetworkButton";
            this.importNetworkButton.Size = new System.Drawing.Size(103, 35);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.trainerPage);
            this.tabControl.Controls.Add(this.dataPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 36);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(444, 265);
            this.tabControl.TabIndex = 10;
            // 
            // trainerPage
            // 
            this.trainerPage.Controls.Add(this.trainerTextBoxPanel);
            this.trainerPage.Controls.Add(this.trainerLoadingPanel);
            this.trainerPage.Controls.Add(this.trainerNavTableLayoutPanel);
            this.trainerPage.Location = new System.Drawing.Point(4, 22);
            this.trainerPage.Name = "trainerPage";
            this.trainerPage.Padding = new System.Windows.Forms.Padding(3);
            this.trainerPage.Size = new System.Drawing.Size(436, 239);
            this.trainerPage.TabIndex = 0;
            this.trainerPage.Text = "Trainer";
            this.trainerPage.UseVisualStyleBackColor = true;
            // 
            // trainerTextBoxPanel
            // 
            this.trainerTextBoxPanel.Controls.Add(this.trainerTextBox);
            this.trainerTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainerTextBoxPanel.Location = new System.Drawing.Point(3, 84);
            this.trainerTextBoxPanel.Name = "trainerTextBoxPanel";
            this.trainerTextBoxPanel.Padding = new System.Windows.Forms.Padding(3);
            this.trainerTextBoxPanel.Size = new System.Drawing.Size(430, 152);
            this.trainerTextBoxPanel.TabIndex = 15;
            // 
            // trainerLoadingPanel
            // 
            this.trainerLoadingPanel.Controls.Add(this.trainerProgressBar);
            this.trainerLoadingPanel.Controls.Add(this.trainerProgressBarLabel);
            this.trainerLoadingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.trainerLoadingPanel.Location = new System.Drawing.Point(3, 45);
            this.trainerLoadingPanel.Name = "trainerLoadingPanel";
            this.trainerLoadingPanel.Padding = new System.Windows.Forms.Padding(3);
            this.trainerLoadingPanel.Size = new System.Drawing.Size(430, 39);
            this.trainerLoadingPanel.TabIndex = 13;
            // 
            // trainerNavTableLayoutPanel
            // 
            this.trainerNavTableLayoutPanel.ColumnCount = 4;
            this.trainerNavTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.trainerNavTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.trainerNavTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.trainerNavTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.trainerNavTableLayoutPanel.Controls.Add(this.importNetworkButton, 3, 0);
            this.trainerNavTableLayoutPanel.Controls.Add(this.saveNetworkButton, 2, 0);
            this.trainerNavTableLayoutPanel.Controls.Add(this.createNetworkButton, 0, 0);
            this.trainerNavTableLayoutPanel.Controls.Add(this.trainButton, 1, 0);
            this.trainerNavTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.trainerNavTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.trainerNavTableLayoutPanel.Name = "trainerNavTableLayoutPanel";
            this.trainerNavTableLayoutPanel.RowCount = 1;
            this.trainerNavTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trainerNavTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.trainerNavTableLayoutPanel.Size = new System.Drawing.Size(430, 42);
            this.trainerNavTableLayoutPanel.TabIndex = 12;
            // 
            // dataPage
            // 
            this.dataPage.Controls.Add(this.dataTextBox);
            this.dataPage.Controls.Add(this.panel2);
            this.dataPage.Controls.Add(this.dataNavLayoutPanel);
            this.dataPage.Location = new System.Drawing.Point(4, 22);
            this.dataPage.Name = "dataPage";
            this.dataPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataPage.Size = new System.Drawing.Size(436, 239);
            this.dataPage.TabIndex = 1;
            this.dataPage.Text = "Data";
            this.dataPage.UseVisualStyleBackColor = true;
            // 
            // dataTextBox
            // 
            this.dataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataTextBox.Location = new System.Drawing.Point(3, 84);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox.Size = new System.Drawing.Size(430, 152);
            this.dataTextBox.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataProgressBar);
            this.panel2.Controls.Add(this.dataProgressBarLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(430, 39);
            this.panel2.TabIndex = 15;
            // 
            // dataProgressBar
            // 
            this.dataProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProgressBar.Location = new System.Drawing.Point(3, 3);
            this.dataProgressBar.MarqueeAnimationSpeed = 50;
            this.dataProgressBar.Name = "dataProgressBar";
            this.dataProgressBar.Size = new System.Drawing.Size(369, 33);
            this.dataProgressBar.TabIndex = 5;
            // 
            // dataProgressBarLabel
            // 
            this.dataProgressBarLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataProgressBarLabel.Location = new System.Drawing.Point(372, 3);
            this.dataProgressBarLabel.Name = "dataProgressBarLabel";
            this.dataProgressBarLabel.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.dataProgressBarLabel.Size = new System.Drawing.Size(55, 33);
            this.dataProgressBarLabel.TabIndex = 6;
            this.dataProgressBarLabel.Text = "0.0%";
            this.dataProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataNavLayoutPanel
            // 
            this.dataNavLayoutPanel.ColumnCount = 4;
            this.dataNavLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.dataNavLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.dataNavLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.dataNavLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.dataNavLayoutPanel.Controls.Add(this.testImagesButton, 2, 0);
            this.dataNavLayoutPanel.Controls.Add(this.generatePersonalizedDataButton, 1, 0);
            this.dataNavLayoutPanel.Controls.Add(this.generateDataButton, 0, 0);
            this.dataNavLayoutPanel.Controls.Add(this.imagesToCreateTextBox, 3, 0);
            this.dataNavLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataNavLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.dataNavLayoutPanel.Name = "dataNavLayoutPanel";
            this.dataNavLayoutPanel.RowCount = 1;
            this.dataNavLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataNavLayoutPanel.Size = new System.Drawing.Size(430, 42);
            this.dataNavLayoutPanel.TabIndex = 14;
            // 
            // testImagesButton
            // 
            this.testImagesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.testImagesButton.Location = new System.Drawing.Point(217, 3);
            this.testImagesButton.Name = "testImagesButton";
            this.testImagesButton.Size = new System.Drawing.Size(101, 35);
            this.testImagesButton.TabIndex = 17;
            this.testImagesButton.Text = "Test Images";
            this.testImagesButton.UseVisualStyleBackColor = true;
            this.testImagesButton.Click += new System.EventHandler(this.testImagesButton_Click);
            // 
            // generatePersonalizedDataButton
            // 
            this.generatePersonalizedDataButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.generatePersonalizedDataButton.Location = new System.Drawing.Point(110, 3);
            this.generatePersonalizedDataButton.Name = "generatePersonalizedDataButton";
            this.generatePersonalizedDataButton.Size = new System.Drawing.Size(101, 35);
            this.generatePersonalizedDataButton.TabIndex = 0;
            this.generatePersonalizedDataButton.Text = "Generate V2";
            this.generatePersonalizedDataButton.UseVisualStyleBackColor = true;
            this.generatePersonalizedDataButton.Click += new System.EventHandler(this.generatePersonalizedDataButton_Click);
            // 
            // generateDataButton
            // 
            this.generateDataButton.AutoSize = true;
            this.generateDataButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.generateDataButton.Location = new System.Drawing.Point(3, 3);
            this.generateDataButton.Name = "generateDataButton";
            this.generateDataButton.Size = new System.Drawing.Size(101, 35);
            this.generateDataButton.TabIndex = 7;
            this.generateDataButton.Text = "Generate Data";
            this.generateDataButton.UseVisualStyleBackColor = true;
            this.generateDataButton.Click += new System.EventHandler(this.generateDataButton_Click);
            // 
            // imagesToCreateTextBox
            // 
            this.imagesToCreateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagesToCreateTextBox.Location = new System.Drawing.Point(324, 8);
            this.imagesToCreateTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.imagesToCreateTextBox.Name = "imagesToCreateTextBox";
            this.imagesToCreateTextBox.Size = new System.Drawing.Size(103, 20);
            this.imagesToCreateTextBox.TabIndex = 18;
            this.imagesToCreateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imagesToCreateTextBox_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.browseButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.networkPathTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.networkPathLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(444, 36);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // browseButton
            // 
            this.browseButton.AutoSize = true;
            this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseButton.Location = new System.Drawing.Point(379, 3);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(62, 30);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // networkPathTextBox
            // 
            this.networkPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.networkPathTextBox.Location = new System.Drawing.Point(69, 7);
            this.networkPathTextBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 5);
            this.networkPathTextBox.Name = "networkPathTextBox";
            this.networkPathTextBox.Size = new System.Drawing.Size(304, 21);
            this.networkPathTextBox.TabIndex = 0;
            this.networkPathTextBox.Text = "C:\\test\\maps_network";
            // 
            // networkPathLabel
            // 
            this.networkPathLabel.AutoSize = true;
            this.networkPathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkPathLabel.Location = new System.Drawing.Point(3, 0);
            this.networkPathLabel.Name = "networkPathLabel";
            this.networkPathLabel.Size = new System.Drawing.Size(60, 36);
            this.networkPathLabel.TabIndex = 3;
            this.networkPathLabel.Text = "Location";
            this.networkPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 301);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(460, 340);
            this.Name = "GUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConvNeuralNetwork.Trainer";
            this.tabControl.ResumeLayout(false);
            this.trainerPage.ResumeLayout(false);
            this.trainerTextBoxPanel.ResumeLayout(false);
            this.trainerTextBoxPanel.PerformLayout();
            this.trainerLoadingPanel.ResumeLayout(false);
            this.trainerNavTableLayoutPanel.ResumeLayout(false);
            this.trainerNavTableLayoutPanel.PerformLayout();
            this.dataPage.ResumeLayout(false);
            this.dataPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.dataNavLayoutPanel.ResumeLayout(false);
            this.dataNavLayoutPanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button trainButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private ProgressBar trainerProgressBar;
        private Label trainerProgressBarLabel;
        private Button createNetworkButton;
        private Button saveNetworkButton;
        private Button importNetworkButton;
        private OpenFileDialog openFileDialog1;
        private TabControl tabControl;
        private TabPage trainerPage;
        private TabPage dataPage;
        private TextBox trainerTextBox;
        private TableLayoutPanel trainerNavTableLayoutPanel;
        private Panel trainerLoadingPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox networkPathTextBox;
        private Panel trainerTextBoxPanel;
        private Button browseButton;
        private Label networkPathLabel;
        private TextBox dataTextBox;
        private Panel panel2;
        private ProgressBar dataProgressBar;
        private Label dataProgressBarLabel;
        private TableLayoutPanel dataNavLayoutPanel;
        private Button generateDataButton;
        private Button generatePersonalizedDataButton;
        private Button testImagesButton;
        private TextBox imagesToCreateTextBox;
    }
}