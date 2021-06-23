using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemo_s_ImageShop
{
    public partial class MainForm : Form
    {
        ImageManager IM;

        public MainForm()
        {
            InitializeComponent();
            IM = new ImageManager();
        }

        private void Convert_button_Click(object sender, EventArgs e)
        {
            ConvertForm CForm = new ConvertForm(this);
            CForm.ShowDialog();
        }

        private void Load_button_Click(object sender, EventArgs e)
        {
            string filePath, fileName;
            Image image;

            if (Image_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Load_textBox.Clear();
                Save_textBox.Clear();
                Original_pictureBox.Image = null;
                Converted_pictureBox.Image = null;

                filePath = Image_openFileDialog.FileName;
                fileName = filePath.Split('\\')[filePath.Split('\\').Length - 1];
                image = Image.FromFile(filePath);
                IM.InitializeImage(image, filePath, fileName);
                ShowMessage($"이미지를 불러오는데 성공했습니다!\r\n이미지 이름 : {fileName}\r\n");

                Load_textBox.Text = fileName;

                Original_pictureBox.Image = image;
            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if (CheckImage())
            {
                string filePath = IM.filePath, fileName = Save_textBox.Text;

                filePath = IM.filePath.Remove(IM.filePath.LastIndexOf('\\') + 1, IM.fileName.Length);

                switch (IM.convertedForm)
                {
                    case ".jpg":
                        fileName += ".jpg";
                        Image_saveFileDialog.Filter = ".jpg 이미지 파일 (*.jpg)|*.jpg";
                        break;
                    case ".jpeg":
                        fileName += ".jpeg";
                        Image_saveFileDialog.Filter = ".jpeg 이미지 파일 (*.jpeg)|*.jpeg";
                        break;
                    case ".png":
                        fileName += ".png";
                        Image_saveFileDialog.Filter = ".png 이미지 파일 (*.png)|*.png";
                        break;
                    case ".bmp":
                        fileName += ".bmp";
                        Image_saveFileDialog.Filter = ".bmp 이미지 파일 (*.bmp)|*.bmp";
                        break;
                    default:
                        break;
                }

                Image_saveFileDialog.FileName = fileName;

                if (Image_saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void Image_saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (CheckImage())
            {
                string filePath, fileName;

                filePath = Image_saveFileDialog.FileName;
                fileName = filePath.Split('\\')[filePath.Split('\\').Length - 1];

                switch (IM.convertedForm)
                {
                    case ".jpg":
                        IM.bmpFile.Save(Image_saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case ".jpeg":
                        IM.bmpFile.Save(Image_saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        IM.bmpFile.Save(Image_saveFileDialog.FileName, ImageFormat.Png);
                        break;
                    case ".bmp":
                        IM.bmpFile.Save(Image_saveFileDialog.FileName, ImageFormat.Bmp);
                        break;
                    default:
                        break;
                }

                ShowMessage($"이미지가 성공적으로 저장되었습니다!\r\n이미지 이름 : {fileName}\r\n");
            }
        }

        public bool CheckImage()
        {
            if (IM.originalImage == null)
            {
                Log_textBox.Text += "원본 이미지 파일이 존재하지 않습니다.\r\n";
                
                return false;
            }

            return true;
        }

        public void ConvertResize(float ratio)
        {
            if (CheckImage())
                IM.ResizeImage(ratio);
        }

        public void ConvertNegative()
        {
            if (CheckImage())
                IM.NegativeTransform();
        }

        public void ConvertGrayScale()
        {
            if (CheckImage())
                IM.GrayScaleTransform();
        }

        public void ConvertThreshold()
        {
            if (CheckImage())
                IM.ThresholdTransform();
        }

        public void ConvertPosturize(byte level)
        {
            if (CheckImage())
                IM.PosturizeTransform(level);
        }

        public void ConvertGamma(double value)
        {
            if (CheckImage())
                IM.GammaTransform(value);
        }

        public void ConvertStretch()
        {
            if (CheckImage())
                IM.StretchTransform();
        }

        public void ShowConvertedImage(string format)
        {
            IM.ConvertImage(format);
            ShowMessage("이미지 변환 완료.\r\n");
            Converted_pictureBox.Image = IM.bmpFile as Image;
        }

        public void ShowMessage(string Msg)
        {
            Log_textBox.Text += Msg;
        }
    }
}
