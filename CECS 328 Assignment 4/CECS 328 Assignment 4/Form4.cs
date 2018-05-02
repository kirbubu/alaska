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
    public partial class Form4 : Form
    {

        int n, k, i, start;

        private void button3_Click(object sender, EventArgs e)
        {
            start = Convert.ToInt32(numericUpDown3.Value);
            numericUpDown4.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(numericUpDown4.Value);
            numericUpDown3.Value = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //Combinations.counter = 1;
            //Combinations.printCombination2(n, k, i, start);
            textBox1.Text = Combinations.holdIt;
        }

        private void button5_Click(object sender, EventArgs e)
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

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            numericUpDown1.Value = 0;
        }
    }
}
