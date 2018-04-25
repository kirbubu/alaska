using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4
{
    class Graph<T> 
    {
        private VertexList<GraphVertex<T>> vertices;
        public Graph()
        {}
        public Graph(VertexList<GraphVertex<T>> vertices)
        {
            if (Equals(vertices, null))
                this.vertices = new VertexList<GraphVertex<T>>();
            else
                this.vertices = vertices;
        }

        public void AddVertex(GraphVertex<T> vertex) {
            vertices.Add(vertex);
        }

        public void AddVertex(T value,String symbol)
        {
            vertices.Add(new GraphVertex<T>(value,symbol));
        }
        
        public void AddDirectedEdge(GraphVertex<T> start, GraphVertex<T> end)
        {
            start.children.Add(end);
            end.parents.Add(start);
        }
        public bool Contains(T value)
        {
            foreach(GraphVertex<T> vertex in vertices)
            {
                if (Equals(vertex.value, value))
                    return true;
            }
            return false;
        }

        public GraphVertex<T> FindVertex(T value, String symbol)
        {
            foreach(GraphVertex<T> vertex in vertices)
            {
                bool vertexequal=true;
                bool symbolequal = Equals(vertex.symbol, symbol);
                //Debugger.Break();
                if(Equals(vertex.value,value) && vertex.symbol == symbol)
                {
                    return vertex;
                }
            }
            return null;
        }
        
     
        public bool Remove(T value,String symbol)
        {
            //Find the Vertex to remove
            GraphVertex<T> removedVertex = FindVertex(value, symbol);
            if(removedVertex == null)
            {
                //Vertex wasn't removed
                return false;
            }
            //Vertex was found so remove from vertices list
            vertices.Remove(removedVertex);

            foreach(GraphVertex<T> vertex in vertices)
            {
                int parentIndex = vertex.parents.IndexOf(removedVertex);
                int childIndex = vertex.children.IndexOf(removedVertex);
                if(parentIndex != -1)
                {
                    vertex.parents.RemoveAt(parentIndex);
                }
                else if(childIndex != -1)
                {
                    vertex.children.RemoveAt(childIndex);
                }

            }
            return true;
        }
        
        public List<GraphVertex<T>> Vertices()
        {
            return vertices;
        }

        public int Count()
        {
            return vertices.Count;
        }
    }
}
