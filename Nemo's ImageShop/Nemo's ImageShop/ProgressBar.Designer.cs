
namespace Nemo_s_ImageShop
{
    partial class ProgressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBar));
            this.Process_progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Process_progressBar
            // 
            this.Process_progressBar.Location = new System.Drawing.Point(12, 12);
            this.Process_progressBar.Name = "Process_progressBar";
            this.Process_progressBar.Size = new System.Drawing.Size(260, 23);
            this.Process_progressBar.Step = 1;
            this.Process_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Process_progressBar.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 61);
            this.Controls.Add(this.Process_progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgressBar";
            this.Text = "Processing...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Process_progressBar;
    }
}