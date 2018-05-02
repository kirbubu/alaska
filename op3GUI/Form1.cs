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
    public partial class OP3Form : Form
    {
        public OP3Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(userN.Text);
            int startNumber = Convert.ToInt32(startNumberBox.Text);
            int subsetSize = Convert.ToInt32(subsetSizeBox.Text);
            int userIth = Convert.ToInt32(userIthBox.Text);
            int difference = n - startNumber;
            difference++;
            int[] stuff;
            stuff = new int[difference];
            for (int i = 0; i < difference; i++)
            {
                stuff[i] = startNumber;
                startNumber++;
                 Console.Write(stuff[i]);
            }
           
            int x = stuff.Length;
          //  int subsetSize = 2;
        //    Combinations c = new Combinations();
            // c.printCombination(arr, x, subsetSize);
            Combinations.printCombination2(stuff, x, subsetSize,userIth);


            //   outputLabel.Text =Combinations.holdIt.ToString() ;
            result.Text = Combinations.holdIt;
             tbo.Text = Combinations.holdIt;
           // outputLabel.Text = "hi";
          
        }

        private void userN_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            op3Output.Text = "Hello";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
