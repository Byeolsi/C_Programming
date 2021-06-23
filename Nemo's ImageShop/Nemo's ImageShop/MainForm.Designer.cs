
namespace Nemo_s_ImageShop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Original_pictureBox = new System.Windows.Forms.PictureBox();
            this.Converted_pictureBox = new System.Windows.Forms.PictureBox();
            this.Convert_button = new System.Windows.Forms.Button();
            this.Image_groupBox = new System.Windows.Forms.GroupBox();
            this.Save_textBox = new System.Windows.Forms.TextBox();
            this.Load_textBox = new System.Windows.Forms.TextBox();
            this.Output_label = new System.Windows.Forms.Label();
            this.Input_label = new System.Windows.Forms.Label();
            this.Save_button = new System.Windows.Forms.Button();
            this.RightArrow_label = new System.Windows.Forms.Label();
            this.Load_button = new System.Windows.Forms.Button();
            this.Log_groupBox = new System.Windows.Forms.GroupBox();
            this.Log_textBox = new System.Windows.Forms.TextBox();
            this.Image_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Image_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.Original_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Converted_pictureBox)).BeginInit();
            this.Image_groupBox.SuspendLayout();
            this.Log_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_pictureBox
            // 
            this.Original_pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Original_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Original_pictureBox.Location = new System.Drawing.Point(6, 22);
            this.Original_pictureBox.Name = "Original_pictureBox";
            this.Original_pictureBox.Size = new System.Drawing.Size(250, 250);
            this.Original_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Original_pictureBox.TabIndex = 0;
            this.Original_pictureBox.TabStop = false;
            // 
            // Converted_pictureBox
            // 
            this.Converted_pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Converted_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Converted_pictureBox.Location = new System.Drawing.Point(344, 22);
            this.Converted_pictureBox.Name = "Converted_pictureBox";
            this.Converted_pictureBox.Size = new System.Drawing.Size(250, 250);
            this.Converted_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Converted_pictureBox.TabIndex = 1;
            this.Converted_pictureBox.TabStop = false;
            // 
            // Convert_button
            // 
            this.Convert_button.Location = new System.Drawing.Point(263, 132);
            this.Convert_button.Name = "Convert_button";
            this.Convert_button.Size = new System.Drawing.Size(75, 23);
            this.Convert_button.TabIndex = 2;
            this.Convert_button.Text = "Convert";
            this.Convert_button.UseVisualStyleBackColor = true;
            this.Convert_button.Click += new System.EventHandler(this.Convert_button_Click);
            // 
            // Image_groupBox
            // 
            this.Image_groupBox.Controls.Add(this.Save_textBox);
            this.Image_groupBox.Controls.Add(this.Load_textBox);
            this.Image_groupBox.Controls.Add(this.Output_label);
            this.Image_groupBox.Controls.Add(this.Input_label);
            this.Image_groupBox.Controls.Add(this.Save_button);
            this.Image_groupBox.Controls.Add(this.RightArrow_label);
            this.Image_groupBox.Controls.Add(this.Load_button);
            this.Image_groupBox.Controls.Add(this.Convert_button);
            this.Image_groupBox.Controls.Add(this.Converted_pictureBox);
            this.Image_groupBox.Controls.Add(this.Original_pictureBox);
            this.Image_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Image_groupBox.Name = "Image_groupBox";
            this.Image_groupBox.Size = new System.Drawing.Size(600, 310);
            this.Image_groupBox.TabIndex = 3;
            this.Image_groupBox.TabStop = false;
            this.Image_groupBox.Text = "Image";
            // 
            // Save_textBox
            // 
            this.Save_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Save_textBox.Location = new System.Drawing.Point(398, 278);
            this.Save_textBox.Name = "Save_textBox";
            this.Save_textBox.Size = new System.Drawing.Size(140, 23);
            this.Save_textBox.TabIndex = 10;
            // 
            // Load_textBox
            // 
            this.Load_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Load_textBox.Location = new System.Drawing.Point(60, 278);
            this.Load_textBox.Name = "Load_textBox";
            this.Load_textBox.ReadOnly = true;
            this.Load_textBox.Size = new System.Drawing.Size(140, 23);
            this.Load_textBox.TabIndex = 9;
            // 
            // Output_label
            // 
            this.Output_label.AutoSize = true;
            this.Output_label.Location = new System.Drawing.Point(344, 282);
            this.Output_label.Name = "Output_label";
            this.Output_label.Size = new System.Drawing.Size(52, 15);
            this.Output_label.TabIndex = 8;
            this.Output_label.Text = "Output :";
            // 
            // Input_label
            // 
            this.Input_label.AutoSize = true;
            this.Input_label.Location = new System.Drawing.Point(12, 281);
            this.Input_label.Name = "Input_label";
            this.Input_label.Size = new System.Drawing.Size(42, 15);
            this.Input_label.TabIndex = 7;
            this.Input_label.Text = "Input :";
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(544, 278);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(50, 23);
            this.Save_button.TabIndex = 6;
            this.Save_button.Text = "Save";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // RightArrow_label
            // 
            this.RightArrow_label.AutoSize = true;
            this.RightArrow_label.Location = new System.Drawing.Point(288, 158);
            this.RightArrow_label.Name = "RightArrow_label";
            this.RightArrow_label.Size = new System.Drawing.Size(27, 15);
            this.RightArrow_label.TabIndex = 5;
            this.RightArrow_label.Text = "= >";
            // 
            // Load_button
            // 
            this.Load_button.Location = new System.Drawing.Point(206, 278);
            this.Load_button.Name = "Load_button";
            this.Load_button.Size = new System.Drawing.Size(50, 23);
            this.Load_button.TabIndex = 3;
            this.Load_button.Text = "Load";
            this.Load_button.UseVisualStyleBackColor = true;
            this.Load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // Log_groupBox
            // 
            this.Log_groupBox.Controls.Add(this.Log_textBox);
            this.Log_groupBox.Location = new System.Drawing.Point(12, 329);
            this.Log_groupBox.Name = "Log_groupBox";
            this.Log_groupBox.Size = new System.Drawing.Size(600, 100);
            this.Log_groupBox.TabIndex = 4;
            this.Log_groupBox.TabStop = false;
            this.Log_groupBox.Text = "Log";
            // 
            // Log_textBox
            // 
            this.Log_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Log_textBox.Location = new System.Drawing.Point(6, 22);
            this.Log_textBox.Multiline = true;
            this.Log_textBox.Name = "Log_textBox";
            this.Log_textBox.ReadOnly = true;
            this.Log_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log_textBox.Size = new System.Drawing.Size(588, 72);
            this.Log_textBox.TabIndex = 0;
            // 
            // Image_openFileDialog
            // 
            this.Image_openFileDialog.FileName = "Image_openFileDialog";
            this.Image_openFileDialog.Filter = "이미지 파일 (*.jpg, *.jpeg, *.png, *.bmp) | *jpg; *.jpeg; *.png; *.bmp;";
            this.Image_openFileDialog.InitialDirectory = "C\\";
            this.Image_openFileDialog.Title = "이미지 불러오기";
            // 
            // Image_saveFileDialog
            // 
            this.Image_saveFileDialog.FileName = "Image_saveFileDialog";
            this.Image_saveFileDialog.InitialDirectory = "C\\";
            this.Image_saveFileDialog.Title = "이미지 저장하기";
            this.Image_saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.Image_saveFileDialog_FileOk);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.Log_groupBox);
            this.Controls.Add(this.Image_groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Nemo\'s Imageshop";
            ((System.ComponentModel.ISupportInitialize)(this.Original_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Converted_pictureBox)).EndInit();
            this.Image_groupBox.ResumeLayout(false);
            this.Image_groupBox.PerformLayout();
            this.Log_groupBox.ResumeLayout(false);
            this.Log_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Original_pictureBox;
        private System.Windows.Forms.PictureBox Converted_pictureBox;
        private System.Windows.Forms.Button Convert_button;
        private System.Windows.Forms.GroupBox Image_groupBox;
        private System.Windows.Forms.Label RightArrow_label;
        private System.Windows.Forms.Button Load_button;
        private System.Windows.Forms.TextBox Save_textBox;
        private System.Windows.Forms.TextBox Load_textBox;
        private System.Windows.Forms.Label Output_label;
        private System.Windows.Forms.Label Input_label;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.GroupBox Log_groupBox;
        private System.Windows.Forms.TextBox Log_textBox;
        private System.Windows.Forms.OpenFileDialog Image_openFileDialog;
        private System.Windows.Forms.SaveFileDialog Image_saveFileDialog;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

