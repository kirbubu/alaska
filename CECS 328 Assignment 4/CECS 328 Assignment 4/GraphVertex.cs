using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4
{
    class GraphVertex<T>
    {
        //If undirected, implemente Neighbors list instead of parents/children
        //public List<GraphVertex<T>> neighbors;

        //If directed, implement parents and children list isntead of neighbors (you could still implement neighbors
        //which would be a Join between parents and children
        public VertexList<GraphVertex<T>> parents;
        public VertexList<GraphVertex<T>> children;
        //Generic Type T, that allows the Graph Vertex to be used for any value!
        public T value;
        //Symbol String, that names the GraphVertex. Not needed
        public String symbol; 
        
        /**
         * Default Constructor
         * Value: Default null value for the given T type.
         * Symbol: Empty String
         * Parents: Initialized empty
         * Children: Initialized empty
         **/
        public GraphVertex() {
            value = default(T);
            parents = new VertexList<GraphVertex<T>>();
            children = new VertexList<GraphVertex<T>>();
            symbol = "";
        }

        /**
         * Constructor
         * Value: Generic type to be stored
         * Symbol: Name representing the GraphVertex
         * Parents: Initialized empty
         * Children: Initialized empty
         **/
        public GraphVertex(T value, String symbol)
        {
            this.value = value;
            this.symbol = symbol;
            parents = new VertexList<GraphVertex<T>>();
            children = new VertexList<GraphVertex<T>>();
        }

        /**
         * Constructor
         * Value: generic type to be stored
         * Symbol: Name representing the GraphVertex
         * Parents: List of GraphVertices that are connected as parents
         * Children: List of GraphVertices that are connected as children
         **/
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


        /**
         * Connects the current object to another Graph Vertex as a child.
         * Returns the child vertex. It's recommended you set the parameter equal to the
         * reference of itself returned to update the parameter.
         * ex. Cvertex = Avertex.ConnectAsParent(Cvertex);
         **/
        public GraphVertex<T> ConnectAsChild(GraphVertex<T> parent)
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
            return parent;
        }
        
        /**
         * Connects the current object to another Graph Vertex as a parent.
         * Returns the child vertex. It's recommended you set the parameter equal to the
         * reference of itself returned to update the parameter.
         * ex. Cvertex = Avertex.ConnectAsParent(Cvertex);
         **/
        public GraphVertex<T> ConnectAsParent(GraphVertex<T> child)
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
            return child;
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


        /**
         * Overriden Equals
         **/
        public override bool Equals(object obj)
        {
            GraphVertex<T> vertex = (GraphVertex<T>)obj;
            if (Equals(vertex.value, this.value) && vertex.symbol == this.symbol)
                return true;
            else
                return false;
            
        }

        
       
    }
}
