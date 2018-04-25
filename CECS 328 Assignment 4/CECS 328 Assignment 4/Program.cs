using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECS_328_Assignment_4
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GraphVertex<List<int>> neighbor1 = new GraphVertex<List<int>>(new List<int>(){ 1, 2 },"B");
            GraphVertex<List<int>> testvertex = new GraphVertex<List<int>>(new List<int>() { 1, 2, 3, 4 },"A",null,new List<GraphVertex<List<int>>>() { neighbor1 });
            Console.WriteLine(testvertex.value[3]);
            Console.WriteLine(testvertex.children[0].value[0]);
            VertexList<GraphVertex<List<int>>> vertices = new VertexList<GraphVertex<List<int>>>() { neighbor1, testvertex };
            Graph<List<int>> graphtest = new Graph<List<int>>(vertices);
            Debugger.Break();
            Console.WriteLine(new List<int>() { 1, 2 } == new List<int>() { 1, 2 });
            graphtest.Remove(new List<int>() { 1, 2 }, "B");
            Debugger.Break();
            Console.WriteLine(testvertex.children[0].parents[0].symbol); //Checking to see who A's first child is and what the child's first parent is 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
