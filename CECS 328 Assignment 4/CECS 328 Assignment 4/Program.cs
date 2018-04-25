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
            GraphVertex<List<int>> Bvertex = new GraphVertex<List<int>>(new SList<int>(){ 1, 2 },"B");
            GraphVertex<List<int>> Avertex = new GraphVertex<List<int>>(new SList<int>() { 1, 2, 3, 4 },"A",null,new List<GraphVertex<List<int>>>() { Bvertex });
            GraphVertex<List<int>> Cvertex = new GraphVertex<List<int>>(new SList<int>() { 1, 2, 3 }, "C",  new List<GraphVertex<List<int>>>() { Bvertex}, new List<GraphVertex<List<int>>>(){ Bvertex,Avertex});
            GraphVertex<List<int>> Dvertex = new GraphVertex<List<int>>(new SList<int>() { 1, 4, 5 }, "D", new List<GraphVertex<List<int>>>() { Avertex }, null);
            Avertex = Cvertex.ConnectAsChild(Avertex);
           
            //Console.WriteLine(testvertex.value[3]);
            //Console.WriteLine(testvertex.children[0].value[0]);
            VertexList<GraphVertex<List<int>>> vertices = new VertexList<GraphVertex<List<int>>>() { Avertex,Bvertex,Cvertex,Dvertex };
            Graph<List<int>> graphtest = new Graph<List<int>>(vertices);
           
            
            //Console.WriteLine(testvertex.children[0].parents[0].symbol); //Checking to see who A's first child is and what the child's first parent is 
            //graphtest.Remove(new List<int>() { 1, 2 }, "B");
            //Debugger.Break();
            List<KeyValuePair<GraphVertex<List<int>>,int>> list = graphtest.BFT(Avertex);
            foreach (var pair in list)
                Console.WriteLine("Vertex: " + pair.Key.symbol + "\tDistance from " + list[0].Key.symbol + ": " + pair.Value);

            Graph<int> graph2 = new Graph<int>();
            graph2.AddDirectedEdge(new GraphVertex<int>(5, "A", null, null), new GraphVertex<int>(6, "B", null, null));
            Debugger.Break();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
