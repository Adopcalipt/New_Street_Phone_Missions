using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSPMSettings
{
    public partial class Form2 : Form
    {
        public bool bisReady = false;
        public string sNamed = "";

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                bisReady = true;
                sNamed = textBox1.Text;
                Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bisReady = true;
            sNamed = textBox1.Text;
            Close();
        }
    }
}
