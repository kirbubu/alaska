using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4
{
    class GraphVertex<T>
    {
        //Undirected
        //public List<GraphVertex<T>> neighbors;
        public VertexList<GraphVertex<T>> parents;
        public VertexList<GraphVertex<T>> children;
        public T value;
        public String symbol; 
        public GraphVertex() {
            value = default(T);
            parents = new VertexList<GraphVertex<T>>();
            children = new VertexList<GraphVertex<T>>();
            symbol = "";
        }

        public GraphVertex(T value, String symbol)
        {
            this.value = value;
            this.symbol = symbol;
            parents = new VertexList<GraphVertex<T>>();
            children = new VertexList<GraphVertex<T>>();
        }

        public GraphVertex(T value, String symbol, List<GraphVertex<T>> Parents, List<GraphVertex<T>> Children)
        {
            this.value = value;
            this.parents = new VertexList<GraphVertex<T>>();
            this.children = new VertexList<GraphVertex<T>>();
            this.symbol = symbol;
            if(!Equals(Parents,null))
                foreach(GraphVertex<T> parent in Parents)
                {
                    //If the parent already has this vertex as a child
                    if (parent.children.Contains(this))
                        this.parents.Add(parent);
                    //If the parent doesn't already have this vertex as a child
                    else
                    {
                        parent.children.Add(this);
                        this.parents.Add(parent);
                    }
                
                }
            if(!Equals(Children,null))
                foreach(GraphVertex<T> child in Children)
                {
                    //If the child already has this vertex as a parent
                    if (child.parents.Contains(this))
                        this.children.Add(child);
                    //If the child doesn't already have this vertex as a child
                    else
                    {
                        child.parents.Add(this);
                        this.children.Add(child);
                    }
                }
            
        }

        //Checks to see if the vertex is connected
        //i.e. is a parent or child of THIS vertex.
        public bool IsConneceted(GraphVertex<T> Vertex)
        {
            if (this.parents.Contains(Vertex) || this.children.Contains(Vertex))
                return true;
            else
                return false;
        }

    }
}
