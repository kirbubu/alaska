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
    public partial class Form5 : Form
    {
        public Form5()
        {
         
            InitializeComponent();
            GraphVertex<int> A = new GraphVertex<int>(1, "A");
            GraphVertex<int> B = new GraphVertex<int>(2, "B");
            GraphVertex<int> C = new GraphVertex<int>(3, "C");
            GraphVertex<int> D = new GraphVertex<int>(4, "D");
            GraphVertex<int> E = new GraphVertex<int>(5, "E");
            GraphVertex<int> F = new GraphVertex<int>(6, "F");
            GraphVertex<int> G = new GraphVertex<int>(7, "G");
            GraphVertex<int> H = new GraphVertex<int>(8, "H");
            GraphVertex<int> I = new GraphVertex<int>(9, "I");
            GraphVertex<int> J = new GraphVertex<int>(10, "J");
            GraphVertex<int> K = new GraphVertex<int>(11, "K");
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
            List<Edge<int>> edges = alaska.Edges();
            Graph<int> alaskaoriginal = alaska;
            textBox1.Text = alaskaoriginal.ToString();


            //Added pipes
            //alaska.AddDirectedEdge(K, J);
            //alaska.AddDirectedEdge(M, I);
            //alaska.AddDirectedEdge(J, B);
            //alaska.AddDirectedEdge(E, M);
            //alaska.AddDirectedEdge(H, L);
            //alaska.AddDirectedEdge(J, K);
            //alaska.AddDirectedEdge(J, I);
            //alaska.AddDirectedEdge(I, D);
            //alaska.AddDirectedEdge(E, A);
            //alaska.AddDirectedEdge(H, C);
            //alaska.AddDirectedEdge(I, M);
            //alaska.AddDirectedEdge(D, I);
            //alaska.AddDirectedEdge(G, C);
            //alaska.AddDirectedEdge(K, L);
            //alaska.AddDirectedEdge(F, D);
            //alaska.AddDirectedEdge(A, B);
            //alaska.AddDirectedEdge(H, K);
            //alaska.AddDirectedEdge(E, F);
            //alaska.AddDirectedEdge(G, H);
            //alaska.AddDirectedEdge(H, G);
            //alaska.AddDirectedEdge(E, H);
            //alaska.AddDirectedEdge(L, M);
            //alaska.AddDirectedEdge(I, B);
            //alaska.AddDirectedEdge(H, J);
            //alaska.AddDirectedEdge(E, D);
            //alaska.AddDirectedEdge(E, B);
            //alaska.AddDirectedEdge(A, C);
            //alaska.AddDirectedEdge(A, H);
            //alaska.AddDirectedEdge(G, D);
            //alaska.AddDirectedEdge(C, J);
            //alaska.AddDirectedEdge(J, L);
            //alaska.AddDirectedEdge(H, M);
            //alaska.AddDirectedEdge(E, L);
            //alaska.AddDirectedEdge(E, J);
            //alaska.AddDirectedEdge(G, J);


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

            List<List<Edge<int>>> Edge_Combinations = new List<List<Edge<int>>>();
            List<KeyValuePair<GraphVertex<int>, int>> B_Graph = alaska.BFT(B);
            List<GraphVertex<int>> B_Vertices = new List<GraphVertex<int>>();
            foreach (var vertex in B_Graph)
                B_Vertices.Add(vertex.Key);
            
            List<KeyValuePair<GraphVertex<int>, int>> E_Graph = alaska.BFT2(E);
            List<GraphVertex<int>> E_Vertices = new List<GraphVertex<int>>();
            foreach(var vertex in E_Graph)
            {
                E_Vertices.Add(vertex.Key);
            }
            //Debugger.Break();
            List<int> Number_Edges_Added = new List<int>();
            List<int> Number_Edges = new List<int>();
            List<List<Edge<int>>> Min_Edges = new List<List<Edge<int>>>();
            List<List<GraphVertex<int>>> paths = new List<List<GraphVertex<int>>>();
            for (int i =1; i<=5;i++)
                Edge_Combinations.AddRange(Combinations.ReturnCombinations(added_pipes,i));
            //foreach(var edge in Edge_Combinations)
            //{
              //  try
              //  {
              //      if (edge.Exists(y => B_Vertices.Contains(y.from)) && edge.Exists(y => E_Vertices.Contains(y.to))) ;
              //          //Console.WriteLine(true);
              //  }
              //  catch (NullReferenceException) { }
            //}
            List<List<Edge<int>>> reduced_edges = Edge_Combinations.Where(edge => edge.Exists(y => B_Vertices.Contains(y.from)) && edge.Exists(y => E_Vertices.Contains(y.to))).ToList();
            Debugger.Break();
            foreach (List<Edge<int>> set in reduced_edges)
            {
                Graph<int> temp = alaska;
                foreach(Edge<int> edge in set)
                {
                    temp.AddDirectedEdge(edge.from,edge.to);
                }
                List<Edge<int>> minimum_added_edges = new List<Edge<int>>();
                List<GraphVertex<int>> path = temp.FindShortestPath(B, E);
                paths.Add(path);
                List<Edge<int>> path_edges = new List<Edge<int>>();
                for (int i = 0; i < path.Count; i++)
                {
                    if (i != path.Count - 1)
                        path_edges.Add(new Edge<int>(path[i], path[i + 1]));
                    
                }
                foreach (var pathedge in path_edges)
                {
                    if (added_pipes.Contains(pathedge))
                    {
                        minimum_added_edges.Add(pathedge);                       
                    }
                }
                Min_Edges.Add(minimum_added_edges);
                Number_Edges_Added.Add(minimum_added_edges.Count);
                Number_Edges.Add(path.Count);

            }
            int min = 0;
            for (int i = 0; i < Number_Edges.Count; i++)
            {

                if ((Number_Edges_Added[i] < Number_Edges_Added[min]  && Number_Edges_Added[i] != 0) ||
                    Number_Edges_Added[min] == 0 && Number_Edges_Added[i] > 0)
                    min = i;
                else if (Number_Edges_Added[i] == Number_Edges_Added[min])
                    if (Number_Edges[i] == Number_Edges[min])
                        min = i;
            }
            List<Edge<int>> n1 = Min_Edges[min];
            foreach(Edge<int> edge in Min_Edges[min])
            {
                textBox3.Text += "\r\n" + edge;
            }
            List<GraphVertex<int>> n2 = paths[min];
            foreach(GraphVertex<int> vertex in paths[min])
            {
                textBox4.Text += "\r\n" + vertex.symbol;
            }

            foreach(var pipe in added_pipes)
            {
                textBox2.Text += "\r\n" + pipe.ToString();
            }

            foreach(var edge in alaskaoriginal.Edges())
            {
                textBox5.Text += "\r\n" + edge.ToString();
            }

            //Console.WriteLine(added_pipes[7].Equals(path_edges[2]));
            Debugger.Break();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }
    }
}
