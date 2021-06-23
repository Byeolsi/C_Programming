
namespace Nemo_s_ImageShop
{
    partial class ConvertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertForm));
            this.ImageForm_comboBox = new System.Windows.Forms.ComboBox();
            this.ImageForm_label = new System.Windows.Forms.Label();
            this.Convert_button = new System.Windows.Forms.Button();
            this.Resize_groupBox = new System.Windows.Forms.GroupBox();
            this.Ratio_label = new System.Windows.Forms.Label();
            this.Ratio_textBox = new System.Windows.Forms.TextBox();
            this.Resize_checkBox = new System.Windows.Forms.CheckBox();
            this.Effect_groupBox = new System.Windows.Forms.GroupBox();
            this.Gamma_label = new System.Windows.Forms.Label();
            this.Value_textBox = new System.Windows.Forms.TextBox();
            this.Gamma_checkBox = new System.Windows.Forms.CheckBox();
            this.Stretch_checkBox = new System.Windows.Forms.CheckBox();
            this.Levels_label = new System.Windows.Forms.Label();
            this.Levels_textBox = new System.Windows.Forms.TextBox();
            this.Posturize_checkBox = new System.Windows.Forms.CheckBox();
            this.Threshold_checkBox = new System.Windows.Forms.CheckBox();
            this.GrayScale_checkBox = new System.Windows.Forms.CheckBox();
            this.Negative_checkBox = new System.Windows.Forms.CheckBox();
            this.Resize_groupBox.SuspendLayout();
            this.Effect_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageForm_comboBox
            // 
            this.ImageForm_comboBox.FormattingEnabled = true;
            this.ImageForm_comboBox.Items.AddRange(new object[] {
            "original format",
            "*.jpg",
            "*.jpeg",
            "*.png",
            "*.bmp"});
            this.ImageForm_comboBox.Location = new System.Drawing.Point(97, 286);
            this.ImageForm_comboBox.Name = "ImageForm_comboBox";
            this.ImageForm_comboBox.Size = new System.Drawing.Size(121, 23);
            this.ImageForm_comboBox.TabIndex = 0;
            this.ImageForm_comboBox.Text = "original format";
            // 
            // ImageForm_label
            // 
            this.ImageForm_label.AutoSize = true;
            this.ImageForm_label.Location = new System.Drawing.Point(12, 289);
            this.ImageForm_label.Name = "ImageForm_label";
            this.ImageForm_label.Size = new System.Drawing.Size(77, 15);
            this.ImageForm_label.TabIndex = 1;
            this.ImageForm_label.Text = "Image form :";
            // 
            // Convert_button
            // 
            this.Convert_button.Location = new System.Drawing.Point(377, 286);
            this.Convert_button.Name = "Convert_button";
            this.Convert_button.Size = new System.Drawing.Size(75, 23);
            this.Convert_button.TabIndex = 2;
            this.Convert_button.Text = "Convert";
            this.Convert_button.UseVisualStyleBackColor = true;
            this.Convert_button.Click += new System.EventHandler(this.Convert_button_Click);
            // 
            // Resize_groupBox
            // 
            this.Resize_groupBox.Controls.Add(this.Ratio_label);
            this.Resize_groupBox.Controls.Add(this.Ratio_textBox);
            this.Resize_groupBox.Controls.Add(this.Resize_checkBox);
            this.Resize_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Resize_groupBox.Name = "Resize_groupBox";
            this.Resize_groupBox.Size = new System.Drawing.Size(440, 85);
            this.Resize_groupBox.TabIndex = 3;
            this.Resize_groupBox.TabStop = false;
            this.Resize_groupBox.Text = "Resize";
            // 
            // Ratio_label
            // 
            this.Ratio_label.AutoSize = true;
            this.Ratio_label.Location = new System.Drawing.Point(148, 40);
            this.Ratio_label.Name = "Ratio_label";
            this.Ratio_label.Size = new System.Drawing.Size(41, 15);
            this.Ratio_label.TabIndex = 2;
            this.Ratio_label.Text = "Ratio :";
            // 
            // Ratio_textBox
            // 
            this.Ratio_textBox.Enabled = false;
            this.Ratio_textBox.Location = new System.Drawing.Point(195, 36);
            this.Ratio_textBox.Name = "Ratio_textBox";
            this.Ratio_textBox.Size = new System.Drawing.Size(100, 23);
            this.Ratio_textBox.TabIndex = 1;
            // 
            // Resize_checkBox
            // 
            this.Resize_checkBox.AutoSize = true;
            this.Resize_checkBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Resize_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Resize_checkBox.Location = new System.Drawing.Point(42, 40);
            this.Resize_checkBox.Name = "Resize_checkBox";
            this.Resize_checkBox.Size = new System.Drawing.Size(66, 19);
            this.Resize_checkBox.TabIndex = 0;
            this.Resize_checkBox.Text = "Resize :";
            this.Resize_checkBox.UseVisualStyleBackColor = true;
            this.Resize_checkBox.CheckedChanged += new System.EventHandler(this.Resize_checkBox_CheckedChanged);
            // 
            // Effect_groupBox
            // 
            this.Effect_groupBox.Controls.Add(this.Gamma_label);
            this.Effect_groupBox.Controls.Add(this.Value_textBox);
            this.Effect_groupBox.Controls.Add(this.Gamma_checkBox);
            this.Effect_groupBox.Controls.Add(this.Stretch_checkBox);
            this.Effect_groupBox.Controls.Add(this.Levels_label);
            this.Effect_groupBox.Controls.Add(this.Levels_textBox);
            this.Effect_groupBox.Controls.Add(this.Posturize_checkBox);
            this.Effect_groupBox.Controls.Add(this.Threshold_checkBox);
            this.Effect_groupBox.Controls.Add(this.GrayScale_checkBox);
            this.Effect_groupBox.Controls.Add(this.Negative_checkBox);
            this.Effect_groupBox.Location = new System.Drawing.Point(12, 103);
            this.Effect_groupBox.Name = "Effect_groupBox";
            this.Effect_groupBox.Size = new System.Drawing.Size(440, 177);
            this.Effect_groupBox.TabIndex = 4;
            this.Effect_groupBox.TabStop = false;
            this.Effect_groupBox.Text = "Effect";
            // 
            // Gamma_label
            // 
            this.Gamma_label.AutoSize = true;
            this.Gamma_label.Location = new System.Drawing.Point(145, 104);
            this.Gamma_label.Name = "Gamma_label";
            this.Gamma_label.Size = new System.Drawing.Size(44, 15);
            this.Gamma_label.TabIndex = 9;
            this.Gamma_label.Text = "Value :";
            // 
            // Value_textBox
            // 
            this.Value_textBox.Enabled = false;
            this.Value_textBox.Location = new System.Drawing.Point(195, 101);
            this.Value_textBox.Name = "Value_textBox";
            this.Value_textBox.Size = new System.Drawing.Size(100, 23);
            this.Value_textBox.TabIndex = 8;
            this.Value_textBox.Text = "0.1 ~ 25.0";
            this.Value_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Value_textBox_MouseClick);
            // 
            // Gamma_checkBox
            // 
            this.Gamma_checkBox.AutoSize = true;
            this.Gamma_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Gamma_checkBox.Location = new System.Drawing.Point(33, 103);
            this.Gamma_checkBox.Name = "Gamma_checkBox";
            this.Gamma_checkBox.Size = new System.Drawing.Size(75, 19);
            this.Gamma_checkBox.TabIndex = 7;
            this.Gamma_checkBox.Text = "Gamma :";
            this.Gamma_checkBox.UseVisualStyleBackColor = true;
            this.Gamma_checkBox.CheckedChanged += new System.EventHandler(this.Gamma_checkBox_CheckedChanged);
            // 
            // Stretch_checkBox
            // 
            this.Stretch_checkBox.AutoSize = true;
            this.Stretch_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Stretch_checkBox.Location = new System.Drawing.Point(37, 138);
            this.Stretch_checkBox.Name = "Stretch_checkBox";
            this.Stretch_checkBox.Size = new System.Drawing.Size(71, 19);
            this.Stretch_checkBox.TabIndex = 6;
            this.Stretch_checkBox.Text = "Stretch :";
            this.Stretch_checkBox.UseVisualStyleBackColor = true;
            this.Stretch_checkBox.CheckedChanged += new System.EventHandler(this.Stretch_checkBox_CheckedChanged);
            // 
            // Levels_label
            // 
            this.Levels_label.AutoSize = true;
            this.Levels_label.Location = new System.Drawing.Point(143, 69);
            this.Levels_label.Name = "Levels_label";
            this.Levels_label.Size = new System.Drawing.Size(46, 15);
            this.Levels_label.TabIndex = 5;
            this.Levels_label.Text = "Levels :";
            // 
            // Levels_textBox
            // 
            this.Levels_textBox.Enabled = false;
            this.Levels_textBox.Location = new System.Drawing.Point(195, 66);
            this.Levels_textBox.Name = "Levels_textBox";
            this.Levels_textBox.Size = new System.Drawing.Size(100, 23);
            this.Levels_textBox.TabIndex = 4;
            this.Levels_textBox.Text = "2 ~ 128";
            this.Levels_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Levels_textBox_MouseClick);
            // 
            // Posturize_checkBox
            // 
            this.Posturize_checkBox.AutoSize = true;
            this.Posturize_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Posturize_checkBox.Location = new System.Drawing.Point(26, 68);
            this.Posturize_checkBox.Name = "Posturize_checkBox";
            this.Posturize_checkBox.Size = new System.Drawing.Size(82, 19);
            this.Posturize_checkBox.TabIndex = 3;
            this.Posturize_checkBox.Text = "Posturize :";
            this.Posturize_checkBox.UseVisualStyleBackColor = true;
            this.Posturize_checkBox.CheckedChanged += new System.EventHandler(this.Posturize_checkBox_CheckedChanged);
            // 
            // Threshold_checkBox
            // 
            this.Threshold_checkBox.AutoSize = true;
            this.Threshold_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Threshold_checkBox.Location = new System.Drawing.Point(320, 31);
            this.Threshold_checkBox.Name = "Threshold_checkBox";
            this.Threshold_checkBox.Size = new System.Drawing.Size(85, 19);
            this.Threshold_checkBox.TabIndex = 2;
            this.Threshold_checkBox.Text = "Threshold :";
            this.Threshold_checkBox.UseVisualStyleBackColor = true;
            this.Threshold_checkBox.CheckedChanged += new System.EventHandler(this.Threshold_checkBox_CheckedChanged);
            // 
            // GrayScale_checkBox
            // 
            this.GrayScale_checkBox.AutoSize = true;
            this.GrayScale_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GrayScale_checkBox.Location = new System.Drawing.Point(172, 31);
            this.GrayScale_checkBox.Name = "GrayScale_checkBox";
            this.GrayScale_checkBox.Size = new System.Drawing.Size(88, 19);
            this.GrayScale_checkBox.TabIndex = 1;
            this.GrayScale_checkBox.Text = "Gray-scale :";
            this.GrayScale_checkBox.UseVisualStyleBackColor = true;
            this.GrayScale_checkBox.CheckedChanged += new System.EventHandler(this.GrayScale_checkBox_CheckedChanged);
            // 
            // Negative_checkBox
            // 
            this.Negative_checkBox.AutoSize = true;
            this.Negative_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Negative_checkBox.Location = new System.Drawing.Point(28, 31);
            this.Negative_checkBox.Name = "Negative_checkBox";
            this.Negative_checkBox.Size = new System.Drawing.Size(80, 19);
            this.Negative_checkBox.TabIndex = 0;
            this.Negative_checkBox.Text = "Negative :";
            this.Negative_checkBox.UseVisualStyleBackColor = true;
            this.Negative_checkBox.CheckedChanged += new System.EventHandler(this.Negative_checkBox_CheckedChanged);
            // 
            // ConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.Effect_groupBox);
            this.Controls.Add(this.Resize_groupBox);
            this.Controls.Add(this.Convert_button);
            this.Controls.Add(this.ImageForm_label);
            this.Controls.Add(this.ImageForm_comboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertForm";
            this.Text = "Convert options";
            this.Resize_groupBox.ResumeLayout(false);
            this.Resize_groupBox.PerformLayout();
            this.Effect_groupBox.ResumeLayout(false);
            this.Effect_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ImageForm_comboBox;
        private System.Windows.Forms.Label ImageForm_label;
        private System.Windows.Forms.Button Convert_button;
        private System.Windows.Forms.GroupBox Resize_groupBox;
        private System.Windows.Forms.Label Ratio_label;
        private System.Windows.Forms.TextBox Ratio_textBox;
        private System.Windows.Forms.CheckBox Resize_checkBox;
        private System.Windows.Forms.GroupBox Effect_groupBox;
        private System.Windows.Forms.Label Levels_label;
        private System.Windows.Forms.TextBox Levels_textBox;
        private System.Windows.Forms.CheckBox Posturize_checkBox;
        private System.Windows.Forms.CheckBox Threshold_checkBox;
        private System.Windows.Forms.CheckBox GrayScale_checkBox;
        private System.Windows.Forms.CheckBox Negative_checkBox;
        private System.Windows.Forms.Label Gamma_label;
        private System.Windows.Forms.TextBox Value_textBox;
        private System.Windows.Forms.CheckBox Gamma_checkBox;
        private System.Windows.Forms.CheckBox Stretch_checkBox;
    }
}