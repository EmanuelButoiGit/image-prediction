namespace Image_Prediction
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadGrayscaleBtn = new System.Windows.Forms.Button();
            this.predictBtn = new System.Windows.Forms.Button();
            this.storeBtn = new System.Windows.Forms.Button();
            this.showErrorMatrixBtn = new System.Windows.Forms.Button();
            this.loadEncodedBtn = new System.Windows.Forms.Button();
            this.decodeBtn = new System.Windows.Forms.Button();
            this.saveDecodedBtn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.predictieComboBox = new System.Windows.Forms.ComboBox();
            this.showHistogramBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.scaleTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 350);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // loadGrayscaleBtn
            // 
            this.loadGrayscaleBtn.Location = new System.Drawing.Point(132, 368);
            this.loadGrayscaleBtn.Name = "loadGrayscaleBtn";
            this.loadGrayscaleBtn.Size = new System.Drawing.Size(152, 29);
            this.loadGrayscaleBtn.TabIndex = 3;
            this.loadGrayscaleBtn.Text = "load image grayscale";
            this.loadGrayscaleBtn.UseVisualStyleBackColor = true;
            this.loadGrayscaleBtn.Click += new System.EventHandler(this.loadGrayscaleBtn_Click);
            // 
            // predictBtn
            // 
            this.predictBtn.Location = new System.Drawing.Point(170, 402);
            this.predictBtn.Name = "predictBtn";
            this.predictBtn.Size = new System.Drawing.Size(75, 23);
            this.predictBtn.TabIndex = 4;
            this.predictBtn.Text = "predict";
            this.predictBtn.UseVisualStyleBackColor = true;
            this.predictBtn.Click += new System.EventHandler(this.predictBtn_Click);
            // 
            // storeBtn
            // 
            this.storeBtn.Location = new System.Drawing.Point(170, 432);
            this.storeBtn.Name = "storeBtn";
            this.storeBtn.Size = new System.Drawing.Size(75, 23);
            this.storeBtn.TabIndex = 5;
            this.storeBtn.Text = "store";
            this.storeBtn.UseVisualStyleBackColor = true;
            this.storeBtn.Click += new System.EventHandler(this.storeBtn_Click);
            // 
            // showErrorMatrixBtn
            // 
            this.showErrorMatrixBtn.Location = new System.Drawing.Point(545, 398);
            this.showErrorMatrixBtn.Name = "showErrorMatrixBtn";
            this.showErrorMatrixBtn.Size = new System.Drawing.Size(127, 23);
            this.showErrorMatrixBtn.TabIndex = 7;
            this.showErrorMatrixBtn.Text = "show error matrix";
            this.showErrorMatrixBtn.UseVisualStyleBackColor = true;
            this.showErrorMatrixBtn.Click += new System.EventHandler(this.showErrorMatrixBtn_Click);
            // 
            // loadEncodedBtn
            // 
            this.loadEncodedBtn.Location = new System.Drawing.Point(945, 368);
            this.loadEncodedBtn.Name = "loadEncodedBtn";
            this.loadEncodedBtn.Size = new System.Drawing.Size(111, 23);
            this.loadEncodedBtn.TabIndex = 8;
            this.loadEncodedBtn.Text = "load encoded";
            this.loadEncodedBtn.UseVisualStyleBackColor = true;
            this.loadEncodedBtn.Click += new System.EventHandler(this.loadEncodedBtn_Click);
            // 
            // decodeBtn
            // 
            this.decodeBtn.Location = new System.Drawing.Point(964, 397);
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(71, 26);
            this.decodeBtn.TabIndex = 9;
            this.decodeBtn.Text = "decode";
            this.decodeBtn.UseVisualStyleBackColor = true;
            this.decodeBtn.Click += new System.EventHandler(this.decodeBtn_Click);
            // 
            // saveDecodedBtn
            // 
            this.saveDecodedBtn.Location = new System.Drawing.Point(950, 429);
            this.saveDecodedBtn.Name = "saveDecodedBtn";
            this.saveDecodedBtn.Size = new System.Drawing.Size(106, 23);
            this.saveDecodedBtn.TabIndex = 10;
            this.saveDecodedBtn.Text = "save decoded";
            this.saveDecodedBtn.UseVisualStyleBackColor = true;
            this.saveDecodedBtn.Click += new System.EventHandler(this.saveDecodedBtn_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(57, 536);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "frecventa";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(795, 393);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Original",
            "Error",
            "Decoded"});
            this.comboBox2.Location = new System.Drawing.Point(886, 622);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 24);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.Text = "original";
            // 
            // predictieComboBox
            // 
            this.predictieComboBox.FormattingEnabled = true;
            this.predictieComboBox.Items.AddRange(new object[] {
            "128",
            "A",
            "B",
            "C",
            "A+B-C",
            "A+(B-C)/2",
            "B+(A-C)/2",
            "(A+B)/2",
            "jpegLS"});
            this.predictieComboBox.Location = new System.Drawing.Point(160, 461);
            this.predictieComboBox.Name = "predictieComboBox";
            this.predictieComboBox.Size = new System.Drawing.Size(100, 24);
            this.predictieComboBox.TabIndex = 13;
            this.predictieComboBox.Text = "128";
            // 
            // showHistogramBtn
            // 
            this.showHistogramBtn.Location = new System.Drawing.Point(900, 686);
            this.showHistogramBtn.Name = "showHistogramBtn";
            this.showHistogramBtn.Size = new System.Drawing.Size(75, 23);
            this.showHistogramBtn.TabIndex = 14;
            this.showHistogramBtn.Text = "show histogram";
            this.showHistogramBtn.UseVisualStyleBackColor = true;
            this.showHistogramBtn.Click += new System.EventHandler(this.showHistogramBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(416, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(387, 350);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(809, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(387, 350);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // scaleTextBox
            // 
            this.scaleTextBox.Location = new System.Drawing.Point(558, 368);
            this.scaleTextBox.Name = "scaleTextBox";
            this.scaleTextBox.Size = new System.Drawing.Size(100, 22);
            this.scaleTextBox.TabIndex = 17;
            this.scaleTextBox.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 977);
            this.Controls.Add(this.scaleTextBox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.showHistogramBtn);
            this.Controls.Add(this.predictieComboBox);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.saveDecodedBtn);
            this.Controls.Add(this.decodeBtn);
            this.Controls.Add(this.loadEncodedBtn);
            this.Controls.Add(this.showErrorMatrixBtn);
            this.Controls.Add(this.storeBtn);
            this.Controls.Add(this.predictBtn);
            this.Controls.Add(this.loadGrayscaleBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Image Prediction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadGrayscaleBtn;
        private System.Windows.Forms.Button predictBtn;
        private System.Windows.Forms.Button storeBtn;
        private System.Windows.Forms.Button showErrorMatrixBtn;
        private System.Windows.Forms.Button loadEncodedBtn;
        private System.Windows.Forms.Button decodeBtn;
        private System.Windows.Forms.Button saveDecodedBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox predictieComboBox;
        private System.Windows.Forms.Button showHistogramBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox scaleTextBox;
    }
}

