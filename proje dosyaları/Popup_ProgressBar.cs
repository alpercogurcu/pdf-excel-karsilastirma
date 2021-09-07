using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimakPDFReader
{
    public partial class Popup_ProgressBar : Form
    {
        public Popup_ProgressBar()
        {
            InitializeComponent();
        }

  

        public void ProgressBarPercent(int yuzde, string islenenoge)
        {
            progressBar1.Value = yuzde;
            label1.Text = islenenoge;
            label2.Text = "%" + yuzde.ToString();
        }
        private void Popup_ProgressBar_Load(object sender, EventArgs e)
        {

        }
    }
}
