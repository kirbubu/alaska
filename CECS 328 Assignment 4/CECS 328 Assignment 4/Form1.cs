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
    public partial class Form1 : Form
    {

        /**
         * Constructor
         **/
        public Form1()
        {
            InitializeComponent();
        }


        /**
         * Part 1 Button Transferrer
         * Sends the user to Part 1 of the program
         **/
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Tag = this;
            form2.Show(this);
            Hide();
        }
    }
}
