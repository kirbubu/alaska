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
             
            //Avertex = Cvertex.ConnectAsChild(Avertex);
           
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
            
            //Graph<int> graph2 = new Graph<int>();
            //graph2.AddDirectedEdge(new GraphVertex<int>(5, "A", null, null), new GraphVertex<int>(6, "B", null, null));
            //Debugger.Break();
          

            GraphVertex<int> A = new GraphVertex<int>(1, "A");
            GraphVertex<int> B = new GraphVertex<int>(2, "B");
            GraphVertex<int> C = new GraphVertex<int>(3, "C");
            GraphVertex<int> D = new GraphVertex<int>(4, "D");
            GraphVertex<int> E = new GraphVertex<int>(5, "E");
            GraphVertex<int> F = new GraphVertex<int>(6, "F");
            GraphVertex<int> G = new GraphVertex<int>(7, "G");
            GraphVertex<int> H = new GraphVertex<int>(8, "H");
            GraphVertex<int> I = new GraphVertex<int>(9 ,"I");
            GraphVertex<int> J = new GraphVertex<int>(10, "J");
            GraphVertex<int> K = new GraphVertex<int>(11 ,"K");
            GraphVertex<int> L = new GraphVertex<int>(12, "L");
            GraphVertex<int> M = new GraphVertex<int>(13, "M");
            VertexList<GraphVertex<int>> verticeslist = new VertexList<GraphVertex<int>>() { A, B, C, D, E, F, G, H, I, J, K, L, M };
            Graph<int> alaska = new Graph<int>(verticeslist);
            alaska.AddDirectedEdge(A, F);
            alaska.AddDirectedEdge(A, H);
            alaska.AddDirectedEdge(B, M);
            alaska.AddDirectedEdge(D, L);
            alaska.AddDirectedEdge(F, E);
            alaska.AddDirectedEdge(F, G);
            alaska.AddDirectedEdge(G, A);
            alaska.AddDirectedEdge(G, J);
            alaska.AddDirectedEdge(G, L);
            alaska.AddDirectedEdge(H, C);
            alaska.AddDirectedEdge(H, I);
            alaska.AddDirectedEdge(J, B);
            alaska.AddDirectedEdge(J, D);
            alaska.AddDirectedEdge(J, M);
            alaska.AddDirectedEdge(K, C);
            alaska.AddDirectedEdge(K, D);
            alaska.AddDirectedEdge(K, H);
            alaska.AddDirectedEdge(K, J);
            alaska.AddDirectedEdge(K, M);
            alaska.AddDirectedEdge(L, C);
            alaska.AddDirectedEdge(L, I);

            //Added pipes
            alaska.AddDirectedEdge(K, J);
            alaska.AddDirectedEdge(M, I);
            alaska.AddDirectedEdge(J, B);
            alaska.AddDirectedEdge(E, M);
            alaska.AddDirectedEdge(H, L);
            alaska.AddDirectedEdge(J, K);
            alaska.AddDirectedEdge(J, I);
            alaska.AddDirectedEdge(I, D);
            alaska.AddDirectedEdge(E, A);
            alaska.AddDirectedEdge(H, C);
            alaska.AddDirectedEdge(I, M);
            alaska.AddDirectedEdge(D, I);
            alaska.AddDirectedEdge(G, C);
            alaska.AddDirectedEdge(K, L);
            alaska.AddDirectedEdge(F, D);
            alaska.AddDirectedEdge(A, B);
            alaska.AddDirectedEdge(H, K);
            alaska.AddDirectedEdge(E, F);
            alaska.AddDirectedEdge(G, H);
            alaska.AddDirectedEdge(H, G);
            alaska.AddDirectedEdge(E, H);
            alaska.AddDirectedEdge(L, M);
            alaska.AddDirectedEdge(I, B);
            alaska.AddDirectedEdge(H, J);
            alaska.AddDirectedEdge(E, D);
            alaska.AddDirectedEdge(E, B);
            alaska.AddDirectedEdge(A, C);
            alaska.AddDirectedEdge(A, H);
            alaska.AddDirectedEdge(G, D);
            alaska.AddDirectedEdge(C, J);
            alaska.AddDirectedEdge(J, L);
            alaska.AddDirectedEdge(H, M);
            alaska.AddDirectedEdge(E, L);
            alaska.AddDirectedEdge(E, J);
            alaska.AddDirectedEdge(G, J);

            List<Edge<int>> added_pipes = new List<Edge<int>>();
            added_pipes.Add(new Edge<int>(K, J));
            added_pipes.Add(new Edge<int>(M, I));
            added_pipes.Add(new Edge<int>(J, B));
            added_pipes.Add(new Edge<int>(E, M));
            added_pipes.Add(new Edge<int>(H, L));
            added_pipes.Add(new Edge<int>(J, K));
            added_pipes.Add(new Edge<int>(J, I));
            added_pipes.Add(new Edge<int>(I, D));
            added_pipes.Add(new Edge<int>(E, A));
            added_pipes.Add(new Edge<int>(H, C));
            added_pipes.Add(new Edge<int>(I, M));
            added_pipes.Add(new Edge<int>(D, I));
            added_pipes.Add(new Edge<int>(G, C));
            added_pipes.Add(new Edge<int>(K, L));
            added_pipes.Add(new Edge<int>(F, D));
            added_pipes.Add(new Edge<int>(A, B));
            added_pipes.Add(new Edge<int>(H, K));
            added_pipes.Add(new Edge<int>(E, F));
            added_pipes.Add(new Edge<int>(G, H));
            added_pipes.Add(new Edge<int>(H, G));
            added_pipes.Add(new Edge<int>(E, H));
            added_pipes.Add(new Edge<int>(L, M));
            added_pipes.Add(new Edge<int>(I, B));
            added_pipes.Add(new Edge<int>(H, J));
            added_pipes.Add(new Edge<int>(E, D));
            added_pipes.Add(new Edge<int>(E, B));
            added_pipes.Add(new Edge<int>(A, C));
            added_pipes.Add(new Edge<int>(A, H));
            added_pipes.Add(new Edge<int>(G, D));
            added_pipes.Add(new Edge<int>(C, J));
            added_pipes.Add(new Edge<int>(J, L));
            added_pipes.Add(new Edge<int>(H, M));
            added_pipes.Add(new Edge<int>(E, L));
            added_pipes.Add(new Edge<int>(E, J));
            added_pipes.Add(new Edge<int>(G, J));
            List<List<Edge<int>>> edge_combinations = Combinations.ReturnCombinations(added_pipes, 3);
            List<GraphVertex<int>> path = alaska.FindShortestPath(B, E);
            List<Edge<int>> path_edges = new List<Edge<int>>();
            for(int i = 0; i< path.Count; i++)
            {
                if(i!=path.Count-1)
                    path_edges.Add(new Edge<int>(path[i], path[i+1]));
                Console.WriteLine(path[i].symbol);
            }
            //Console.WriteLine(added_pipes[7].Equals(path_edges[2]));
            List<Edge<int>> minimum_added_edges = new List<Edge<int>>();
            foreach(var pathedge in path_edges)
            {
                if (added_pipes.Contains(pathedge))
                {
                    minimum_added_edges.Add(pathedge);
                    Console.WriteLine(pathedge);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
