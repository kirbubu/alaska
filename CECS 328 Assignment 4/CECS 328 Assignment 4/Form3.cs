using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECS_328_Assignment_4
{
    public partial class Form3 : Form
    {

        int n, k;
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = Convert.ToInt32(numericUpDown2.Value);
            numericUpDown2.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = Combinations.printCombination(n, k).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            numericUpDown1.Value = 0;
        }

    }
}
