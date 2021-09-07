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
    public partial class uyariPopup : Form
    {
        public uyariPopup()
        {
            InitializeComponent();
        }

        public string uyarimetni;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uyariPopup_Load(object sender, EventArgs e)
        {
            label1.Text = uyarimetni;
        }
    }
}
