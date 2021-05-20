using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Prediction
{
    public partial class Form1 : Form
    {
        private string input = null;
        private int predictionNumber = 0;
        private byte[] antet;
        private int[,] MatriceEroare;
        private byte[,] MatriceEroareByte;
        private byte[,] MatriceOriginalaDecodare;
        private byte[,] MatriceOriginala;
        private byte[,] MatriceDePredictie;
        private byte[,] MatriceDePredictieDecodare;
        private byte[,] MatriceEroareDisplay;
        private BitReader bitReader;
        private string inputOriginal = null;
        
        public Form1()
        {
            InitializeComponent();
            input = null;
            predictionNumber = 0;
            antet = new byte[1078];
            MatriceOriginala = new byte[256, 256];
            MatriceEroare = new int[256, 256];
            MatriceEroareByte = new byte[256, 256];
            MatriceOriginalaDecodare = new byte[256, 256];
            MatriceDePredictie = new byte[256, 256];
            MatriceEroareDisplay = new byte[256, 256];
            MatriceDePredictieDecodare = new byte[256, 256];

        }

        private void CitireImagine()
        {
            bitReader = new BitReader(input);

            for (int i = 0; i < 1078; i++)
            {
                antet[i] = (byte)bitReader.ReadNBits(8);
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    int pixel = bitReader.ReadNBits(8);
                    MatriceOriginala[i, j] = (byte)pixel;
                }
            }
        } 

        private void loadGrayscaleBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input = openFileDialog1.FileName;
            }

            FileStream fs = new System.IO.FileStream(input, FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();

            inputOriginal=input;
            CitireImagine();

            
        }

        private void calculMatriceEroareByte()
        {
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    if (MatriceEroare[i, j] < 0)
                    {
                        MatriceEroareByte[i, j] = 0;
                    }

                    else if (MatriceEroare[i, j] > 256)
                    {
                        MatriceEroareByte[i, j] = 255;
                    }

                    else MatriceEroareByte[i, j] = (byte)MatriceEroare[i, j];
                }
            }
        }

        private void storeFisier()
        {
            BitWriter bitWriter = new BitWriter(input);

            for (int i = 0; i < 1078; i++)
            {
                bitWriter.WriteNBits(antet[i], 8);
            }

            string comboSelectat = predictieComboBox.SelectedItem.ToString();

            if (comboSelectat == "128")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
            }

            if (comboSelectat == "A")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
            }

            if (comboSelectat == "B")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(0);
            }

            if (comboSelectat == "C")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(1);
            }

            if (comboSelectat == "A+B-C")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
            }

            if (comboSelectat == "B+(A-C)/2")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
            }

            if (comboSelectat == "(A+B)/2")
            {
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(1);
            }

            if (comboSelectat == "jpegLS")
            {
                bitWriter.WriteBit(1);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
                bitWriter.WriteBit(0);
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    if (MatriceEroare[i, j] < 0)
                    {
                        bitWriter.WriteBit(0);
                    }
                    else
                    {
                        bitWriter.WriteBit(1);
                    }

                    bitWriter.WriteNBits(Math.Abs(MatriceEroare[i, j]), 8);
                }
            }

            calculMatriceEroareByte();
            
        }

        private void storeBtn_Click(object sender, EventArgs e)
        {
            input = input + "[" + predictionNumber + "]" + ".pre";
            var myFile = File.Create(input);
            myFile.Close();

            storeFisier();
        }

        private void salvareSiAfisareImagineDecodata()
        {
            BitWriter bitWriter = new BitWriter(input);
            Bitmap bmp2 = new Bitmap(256, 256);

            for (int i = 0; i < 1078; i++)
            {
                bitWriter.WriteNBits(antet[i], 8);
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    bitWriter.WriteNBits(MatriceOriginalaDecodare[i, j], 8);
                    var color = Color.FromArgb(MatriceOriginalaDecodare[i, j], MatriceOriginalaDecodare[i, j], MatriceOriginalaDecodare[i, j]);
                    bmp2.SetPixel(i, j, color);
                }
            }

            //bmp2.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox3.Image = bmp2;

            input = inputOriginal;
        }

        private void saveDecodedBtn_Click(object sender, EventArgs e)
        {
            input = input + ".decoded";
            predictionNumber++;
            var myFile = File.Create(input);
            myFile.Close();

            salvareSiAfisareImagineDecodata();

        }

        private void loadEncodedBtn_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "pre files (*.pre)|*.pre|All files (*.*)|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                input = openFileDialog2.FileName;
            }

        }

        private void predictionare()
        {
            
            string comboSelectat = predictieComboBox.SelectedItem.ToString();
            int regula = 0;

            chart1.Series["frecventa"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        MatriceDePredictie[i, j] = 128;
                    }

                    if (i == 0 && j != 0)
                    {
                        MatriceDePredictie[0, j] = MatriceOriginala[0, j - 1];
                    }

                    if (i != 0 && j == 0)
                    {
                        MatriceDePredictie[i, 0] = MatriceOriginala[i - 1, 0];
                    }

                    if (i != 0 && j != 0)
                    {
                        var A = MatriceOriginala[i, j - 1];
                        var B = MatriceOriginala[i - 1, j];
                        var C = MatriceOriginala[i - 1, j - 1];



                        if (comboSelectat == "128")
                        {
                            regula = 128;

                        }

                        if (comboSelectat == "A")
                        {
                            regula = A;
                        }

                        if (comboSelectat == "B")
                        {
                            regula = B;
                        }

                        if (comboSelectat == "C")
                        {
                            regula = C;
                        }

                        if (comboSelectat == "A+B-C")
                        {
                            regula = (int)(A + B - C);
                        }

                        if (comboSelectat == "A+(B-C)/2")
                        {
                            regula = (int)(A + (B - C) / 2);
                        }

                        if (comboSelectat == "B+(A-C)/2")
                        {
                            regula = (int)(B + (A - C) / 2);
                        }

                        if (comboSelectat == "(A+B)/2")
                        {
                            regula = (int)((A + B) / 2);
                        }

                        if (comboSelectat == "jpegLS")
                        {
                            byte max = Math.Max(A, B);
                            byte min = Math.Min(A, B);

                            if (C >= max)
                            {
                                regula = min;
                            }

                            else if (C <= min)
                            {
                                regula = max;
                            }

                            else
                            {
                                regula = (int)(A + B - C);
                            }

                        }

                        if (regula > 255)
                        {
                            MatriceDePredictie[i, j] = 255;
                        }

                        if (regula < 0)
                        {
                            MatriceDePredictie[i, j] = 0;
                        }


                        MatriceDePredictie[i, j] = (byte)regula;


                    }
                }
            }

            
        }

        void calculMatriceEroare()
        {
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    int pixelMatriceEroare = (int)(MatriceOriginala[i, j] - MatriceDePredictie[i, j]);
                    MatriceEroare[i, j] = pixelMatriceEroare;
                }
            }
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            predictionare();
            calculMatriceEroare();

        }

        private void afisareMatriceEroare()
        {
            double scale = double.Parse(scaleTextBox.Text);
            Bitmap bmp = new Bitmap(256, 256);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    MatriceEroareDisplay[i, j] = (byte)(128 + MatriceEroare[i, j] * scale);
                    var color = Color.FromArgb(MatriceEroareDisplay[i, j], MatriceEroareDisplay[i, j], MatriceEroareDisplay[i, j]);
                    bmp.SetPixel(i, j, color);

                }
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox2.Image = bmp;
        }

        private void showErrorMatrixBtn_Click(object sender, EventArgs e)
        {
            afisareMatriceEroare();
        }

        private void predictionareDecodare()
        {
            string comboSelectat = predictieComboBox.SelectedItem.ToString();

            int regula = 0;

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        MatriceDePredictieDecodare[i, j] = 128;
                    }

                    if (i == 0 && j != 0)
                    {
                        MatriceDePredictieDecodare[0, j] = MatriceOriginalaDecodare[0, j - 1];
                    }

                    if (i != 0 && j == 0)
                    {
                        MatriceDePredictieDecodare[i, 0] = MatriceOriginalaDecodare[i - 1, 0];
                    }

                    if (i != 0 && j != 0)
                    {
                        var A = MatriceOriginalaDecodare[i, j - 1];
                        var B = MatriceOriginalaDecodare[i - 1, j];
                        var C = MatriceOriginalaDecodare[i - 1, j - 1];



                        if (comboSelectat == "128")
                        {
                            regula = 128;

                        }

                        if (comboSelectat == "A")
                        {
                            regula = A;
                        }

                        if (comboSelectat == "B")
                        {
                            regula = B;
                        }

                        if (comboSelectat == "C")
                        {
                            regula = C;
                        }

                        if (comboSelectat == "A+B-C")
                        {
                            regula = (int)(A + B - C);
                        }

                        if (comboSelectat == "A+(B-C)/2")
                        {
                            regula = (int)(A + (B - C) / 2);
                        }

                        if (comboSelectat == "B+(A-C)/2")
                        {
                            regula = (int)(B + (A - C) / 2);
                        }

                        if (comboSelectat == "(A+B)/2")
                        {
                            regula = (int)((A + B) / 2);
                        }

                        if (comboSelectat == "jpegLS")
                        {
                            byte max = Math.Max(A, B);
                            byte min = Math.Min(A, B);

                            if (C >= max)
                            {
                                regula = min;
                            }

                            else if (C <= min)
                            {
                                regula = max;
                            }

                            else
                            {
                                regula = (int)(A + B - C);
                            }

                        }

                        if (regula > 255)
                        {
                            MatriceDePredictieDecodare[i, j] = 255;
                        }

                        if (regula < 0)
                        {
                            MatriceDePredictieDecodare[i, j] = 0;
                        }



                        MatriceDePredictieDecodare[i, j] = (byte)regula;



                    }

                    int pixelMatriceOriginalaDecodare = (int)(MatriceEroare[i, j] + MatriceDePredictieDecodare[i, j]);
                    if (pixelMatriceOriginalaDecodare > 255)
                    {
                        MatriceOriginalaDecodare[i, j] = 255;
                    }

                    else if (pixelMatriceOriginalaDecodare < 0)
                    {
                        MatriceOriginalaDecodare[i, j] = 0;
                    }

                    else
                    {
                        MatriceOriginalaDecodare[i, j] = (byte)pixelMatriceOriginalaDecodare;
                    }

                }
            }
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            
            predictionareDecodare();
            
        }

        private void histogramaAfisare()
        {
            int[] frecventa = new int[256];
            int pixel = 0;
            string comboShowSelectat = comboBox2.SelectedItem.ToString();

            chart1.Series["frecventa"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    if (comboShowSelectat == "Original")
                    {
                        pixel = MatriceOriginalaDecodare[i, j];
                    }

                    if (comboShowSelectat == "Error")
                    {
                        pixel = MatriceEroareByte[i, j];
                    }

                    if (comboShowSelectat == "Decoded")
                    {
                        pixel = MatriceOriginalaDecodare[i, j];
                    }

                    frecventa[pixel]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                chart1.Series["frecventa"].Points.AddXY(i, frecventa[i]);
            }
        }

        private void showHistogramBtn_Click(object sender, EventArgs e)
        {

            histogramaAfisare();

        }
    }
}
