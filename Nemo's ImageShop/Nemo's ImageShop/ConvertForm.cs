using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemo_s_ImageShop
{
    public partial class ConvertForm : Form
    {
        MainForm MForm;

        public ConvertForm(MainForm MForm)
        {
            this.MForm = MForm;
            InitializeComponent();
        }

        private void Convert_button_Click(object sender, EventArgs e)
        {
            if (!MForm.CheckImage())
            {
                this.Close();
                return;
            }

            bool checkConvert = false;

            if (Resize_checkBox.Checked)
            {
                try
                {
                    float ratio = float.Parse(Ratio_textBox.Text);

                    MForm.ConvertResize(ratio);
                    MForm.ShowMessage($"Resize 작업 수행. ratio : {ratio}\r\n");
                    checkConvert = true;

                }
                catch (FormatException ex)
                {
                    MForm.ShowMessage(ex.Message);

                    return;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MForm.ShowMessage(ex.Message);

                    return;
                }
            }

            if (Negative_checkBox.Checked)
            {
                MForm.ConvertNegative();
                MForm.ShowMessage("Negative 작업 수행.\r\n");
                checkConvert = true;
            }
            else if (GrayScale_checkBox.Checked)
            {
                MForm.ConvertGrayScale();
                MForm.ShowMessage("Gray-scale 작업 수행.\r\n");
                checkConvert = true;
            }
            else if (Threshold_checkBox.Checked)
            {
                MForm.ConvertThreshold();
                MForm.ShowMessage("Threshold 작업 수행.\r\n");
                checkConvert = true;
            }
            else if (Posturize_checkBox.Checked)
            {
                try
                {
                    byte level = byte.Parse(Levels_textBox.Text);

                    if (2 <= level && level <= 128)
                    {
                        MForm.ConvertPosturize(level);
                        MForm.ShowMessage("Posturize 작업 수행.\r\n");
                        checkConvert = true;
                    }
                    else
                    {
                        MForm.ShowMessage("범위를 벗어난 값입니다.\r\n");

                        return;
                    }
                }
                catch (FormatException ex)
                {
                    MForm.ShowMessage(ex.Message);

                    return;
                }
            }
            else if (Gamma_checkBox.Checked)
            {
                try
                {
                    double value = double.Parse(Value_textBox.Text);

                    if (0.1 <= value && value <= 25.0)
                    {
                        MForm.ConvertGamma(value);
                        MForm.ShowMessage($"Gamma 작업 수행. value : {value}\r\n");
                        checkConvert = true;
                    }
                    else
                    {
                        MForm.ShowMessage("범위를 벗어난 값입니다.\r\n");

                        return;
                    }
                }
                catch (FormatException ex)
                {
                    MForm.ShowMessage(ex.Message);

                    return;
                }
            }
            else if (Stretch_checkBox.Checked)
            {
                MForm.ConvertStretch();
                MForm.ShowMessage("Stretch 작업 수행.\r\n");
                checkConvert = true;
            }

            if (checkConvert)
                MForm.ShowConvertedImage(ImageForm_comboBox.Text);
            this.Close();
        }

        private void Resize_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Resize_checkBox.Checked)
                Ratio_textBox.Enabled = true;
            else
                Ratio_textBox.Enabled = false;
        }

        private void Levels_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Levels_textBox.Text == "2 ~ 128")
                Levels_textBox.Clear();
        }

        private void Value_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Value_textBox.Text == "0.1 ~ 25.0")
                Value_textBox.Clear();
        }

        private void Posturize_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Posturize_checkBox.Checked)
            {
                Levels_textBox.Enabled = true;

                Negative_checkBox.Checked = false;
                GrayScale_checkBox.Checked = false;
                Threshold_checkBox.Checked = false;
                Gamma_checkBox.Checked = false;
                Stretch_checkBox.Checked = false;
            }
            else
                Levels_textBox.Enabled = false;
        }

        private void Negative_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Negative_checkBox.Checked)
            {
                GrayScale_checkBox.Checked = false;
                Threshold_checkBox.Checked = false;
                Posturize_checkBox.Checked = false;
                Gamma_checkBox.Checked = false;
                Stretch_checkBox.Checked = false;
            }
        }

        private void GrayScale_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GrayScale_checkBox.Checked)
            {
                Negative_checkBox.Checked = false;
                Threshold_checkBox.Checked = false;
                Posturize_checkBox.Checked = false;
                Gamma_checkBox.Checked = false;
                Stretch_checkBox.Checked = false;
            }
        }

        private void Threshold_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Threshold_checkBox.Checked)
            {
                Negative_checkBox.Checked = false;
                GrayScale_checkBox.Checked = false;
                Posturize_checkBox.Checked = false;
                Gamma_checkBox.Checked = false;
                Stretch_checkBox.Checked = false;
            }
        }

        private void Gamma_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Gamma_checkBox.Checked)
            {
                Value_textBox.Enabled = true;

                Negative_checkBox.Checked = false;
                GrayScale_checkBox.Checked = false;
                Posturize_checkBox.Checked = false;
                Threshold_checkBox.Checked = false;
                Stretch_checkBox.Checked = false;
            }
            else
            {
                Value_textBox.Enabled = false;
            }
        }

        private void Stretch_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Stretch_checkBox.Checked)
            {
                Negative_checkBox.Checked = false;
                GrayScale_checkBox.Checked = false;
                Posturize_checkBox.Checked = false;
                Threshold_checkBox.Checked = false;
                Gamma_checkBox.Checked = false;
            }
        }
    }
}
