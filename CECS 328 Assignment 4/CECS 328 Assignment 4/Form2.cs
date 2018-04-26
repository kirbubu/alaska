using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECS_328_Assignment_4
{
    public partial class Form2 : Form
    {
        //Values for the start and end vertex
        int StartValue, EndValue;
        //String names for the start and end vertex
        String StartName, EndName;
        //Instantiate a graph of ints
        Graph<int> graph = new Graph<int>();
        //List of all the vertices
        List<GraphVertex<int>> vertices = new List<GraphVertex<int>>();

        /**
         * Back Button
         * Closes the Form and goes back to the main menu
         **/
        private void button2_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        /**
         * Perform Breadth Traversal Button
         * Takes the vertices and starting from the first vertex, performs a breadth first traversal,
         * finding the minimum paths from A to every other vertex. Then displays this information in
         * the textBox to the left of the Button
         **/
        private void button3_Click(object sender, EventArgs e)
        {
            //Retrieve the list of key/value pairs from the Breadth First Traversal
            List<KeyValuePair<GraphVertex<int>, int>> distances = graph.BFT(vertices[0]);
            //Reset TestBox for new data
            textBox6.Text = "";
            
            //Print all the distances from the first vertex
            foreach(var pair in distances)
            {
                textBox6.Text+=("Vertex: " + pair.Key.symbol + "\tDistance from " + distances[0].Key.symbol + ": " + pair.Value+"\r\n");
            }
        }

        /**
         * Constructor
         **/
        public Form2()
        {
            InitializeComponent();
        }

        /**
         * Add Edge Button
         * Takes the values and names for the vertices and creates or updates the graph based on those two.
         * If a vertex input doesn't exist, its created. If it does exist, it is updated.
         * Uses the AddDirectedEdge to add to the graph.
         **/
        private void button1_Click(object sender, EventArgs e)
        {
            //Reset the Vertices display textBox
            textBox5.Text = "";
            //Convert the string value to an integer
            StartValue = Convert.ToInt32(textBox1.Text);
            //Convert the end value to an integer
            EndValue = Convert.ToInt32(textBox4.Text);
            //Retrieve the names for the vertices
            StartName = textBox2.Text;
            EndName = textBox3.Text;
            //Add or update the vertices to the graph. If one or both already exist, they are updated with
            //the new connections. If they don't exist in the graph already, they are then added to the graph.
            graph.AddDirectedEdge(new GraphVertex<int>(StartValue, StartName), new GraphVertex<int>(EndValue, EndName));
            //Set the vertices equal to the graph's vertices
            vertices = graph.Vertices();
            //For each vertex in the verticecs, print out the [Value,Name] tuples in the Vertices textbox.
            foreach(var ver in vertices)
            {
                textBox5.Text += "["+ver.value + "," +ver.symbol + "], ";
            }
            //Reset all the text boxes.
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
        }
    }
}
