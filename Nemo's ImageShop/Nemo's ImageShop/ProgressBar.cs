using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Automation;

namespace Nemo_s_ImageShop
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        public void ShowProgress(double value)
        {
            if (value >= 100)
            {
                this.Close();
            }

            this.Process_progressBar.Value = (int)value;
        }
    }
}
