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
        //Vertices:List of Vertices that the graph holds
        private VertexList<GraphVertex<T>> vertices;
        private List<Edge<T>> edges;
        /**
         * Default Constructor
         * Verticecs: initialized empty
         **/
        public Graph()
        {
            vertices = new VertexList<GraphVertex<T>>();
            edges = new List<Edge<T>>();
        }

        /**
         * Constructor
         * Vertices: if parameter null, initialized empty; else initialized
         **/
        public Graph(VertexList<GraphVertex<T>> vertices)
        {
            edges = new List<Edge<T>>();
            if (Equals(vertices, null))
                this.vertices = new VertexList<GraphVertex<T>>();
            else
                this.vertices = vertices;
            foreach(var vertex in vertices)
            {
                edges.AddRange(vertex.edges);
            }
            edges = edges.Distinct().ToList();
        }

        /**
         * Adds a vertex to the list of vertices, VertexList
         * Vertex: The vertex to be added to the list
         **/
        public void AddVertex(GraphVertex<T> vertex) {
            vertices.Add(vertex);
        }

        /**
         * Adds a vertex to the list of vertices, VertexList, by ceating a new vertex based on the value and the symbol
         * Value: the value for the GraphVertex
         * Symbol: the string name representing the GraphVertex
         **/
        public void AddVertex(T value,String symbol)
        {
            vertices.Add(new GraphVertex<T>(value,symbol));
        }
        
        /**
         * Adds a directed edge to the graph given a start GraphVertex (parent) and end GraphVertex (child)
         * Both Vertices are then updated (if on the graph already) or added onto the graph (if not on the graph already)
         * Start: Parent Vertex to be added or updated on the graph
         * End: Child Vertex to be added or updated on the graph
         **/
        public void AddDirectedEdge(GraphVertex<T> start, GraphVertex<T> end)
        {
            if (this.Contains(start.value, start.symbol))
                start = vertices[FindVertexIndex(start)];
            if (this.Contains(end.value, end.symbol))
                end = vertices[FindVertexIndex(end)];
            //Debugger.Break();
            //Adding to their respective lists
            start.children.Add(end);
            start.edges.Add(new Edge<T>(start, end));
            end.parents.Add(start);
            end.edges.Add(new Edge<T>(start, end));
            //If already in the graph, update
            if (this.Contains(start.value,start.symbol))
                vertices[FindVertexIndex(start.value,start.symbol)] = start;
            //Otherwise add to the graph
            else
                vertices.Add(start);
            //If already in the graph, update
            if (this.Contains(end.value,end.symbol))
                vertices[FindVertexIndex(end.value,end.symbol)] = end;
            //Otherwise add to the graph
            else
                vertices.Add(end);
            Edge<T> edge = new Edge<T>(start, end);
            if (edges.Contains(edge))
                return;
            else
                edges.Add(edge);
        }

        /**
         * Searches if any GraphVertex in the graph contains the given T value
         * Value: a generic type to be searched for
         **/
        public bool Contains(T value, String symbol)
        {
            foreach(GraphVertex<T> vertex in vertices)
            {
                if (Equals(vertex.value, value) && Equals(vertex.symbol,symbol))
                    return true;
            }
            return false;
        }

        /**
         * Searches if a GraphVertex parameter is located inside the Graph
         * Vertex: the vertex being searched for within the graph
         **/
        public bool Contains(GraphVertex<T> vertex)
        {
            foreach (GraphVertex<T> ver in vertices)
                if (ver.Equals(vertex))
                    return true;
            return false;
        }

        /**
         * Finds the First vertex within the graph that has a given value and symbol associated with it.
         * Value: generic type of the vertex being searched for
         * Symbol: String name of the vertex being searched for
         **/
        public GraphVertex<T> FindVertex(T value, String symbol)
        {
            foreach(GraphVertex<T> vertex in vertices)
            {
                bool vertexequal = vertex.value.Equals(value);
                bool symbolequal = Equals(vertex.symbol, symbol);
                if(vertexequal && symbolequal)
                {
                    return vertex;
                }
            }
            return null;
        }

        /**
         * Finds the index within the List of vertices of a vertex with a certain "value" and "symbol"
         * Value: the generic type value of the vertex being searched for
         * Symbol: The String name of the vertex being searched for
         **/
        public int FindVertexIndex(T value, String symbol)
        {
            for(int i = 0; i<vertices.Count; i++)
            {
                bool vertexequal = vertices[i].value.Equals(value);
                bool symbolequal = Equals(vertices[i].symbol, symbol);
                if (vertexequal && symbolequal)
                    return i;
                    
            }
            return -1;
        }
        
        /**
         * Finds the index within the List of vertices of a given Vertex
         * Vertex: The GraphVertex whose index you're trying to find
         **/
        public int FindVertexIndex(GraphVertex<T> vertex)
        {
            for(int i =0; i<vertices.Count; i++)
            {
                bool equal = (vertices[i].Equals(vertex));
                if (equal)
                    return i;
            }
            return -1;

        }
        
        
        /**
         * Removes the first Vertex the contains the given "value" and "symbol"
         * Also removes all edges and traces of this vertex from other vertices' children and parents lists
         * Value: generic type value of the vertex you want to remove
         * Symbol: string name of the vertex you want to remove
         **/
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

            //Remove all traces of the vertex from other vertices' children and parents lists
            //aka Removing all the edges
            foreach(GraphVertex<T> vertex in vertices)
            {
                int parentIndex = vertex.parents.IndexOf(removedVertex);
                int childIndex = vertex.children.IndexOf(removedVertex);
                //If the removed vertex is in the parents list
                if(parentIndex != -1)
                {
                    vertex.parents.RemoveAt(parentIndex);
                }
                //Or if the removed vertex is in the children list
                else if(childIndex != -1)
                {
                    vertex.children.RemoveAt(childIndex);
                }

            }
            return true;
        }
        
        /**
         * Return the list of vertices
         **/
        public List<GraphVertex<T>> Vertices()
        {
            return vertices;
        }

        public List<Edge<T>> Edges()
        {
            return edges;
        }
        /**
         * Return the Count of the list of vertices
         **/
        public int Count()
        {
            return vertices.Count;
        }


        public List<GraphVertex<T>> FindShortestPath(GraphVertex<T> start,GraphVertex<T> end)
        {
            Dictionary<GraphVertex<T>,GraphVertex<T>> visited = new Dictionary<GraphVertex<T>, GraphVertex<T>>();
            Queue<GraphVertex<T>> queue = new Queue<GraphVertex<T>>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                GraphVertex<T> currentVertex = queue.Dequeue();
                foreach (GraphVertex<T> child in currentVertex.children)
                {
                    if (!visited.ContainsKey(child))
                    {
                        visited[child] = currentVertex;
                        queue.Enqueue(child);
                    }
                }
            }

                List<GraphVertex<T>> path = new List<GraphVertex<T>>();
                GraphVertex<T> current = end;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    try
                    {
                        current = visited[current];
                    }
                    catch(KeyNotFoundException)
                    {
                        return new List<GraphVertex<T>>();
                    }
                }
                path.Add(start);
                path.Reverse();

                return path;

        }
        /**
         * Breadth First Traversal
         * Returns a KeyValuePair of the vertex and it's distance from a given starting vertex.
         * Start: The starting Vertex where the Breadth First Traversal will start from
         **/
        public List<KeyValuePair<GraphVertex<T>,int>> BFT(GraphVertex<T> start)
        {
            Dictionary<GraphVertex<T>, int> pairs = new Dictionary<GraphVertex<T>, int>();
            int distance = 0;
            //Initialize the list and the queue
            List<GraphVertex<T>> visited = new List<GraphVertex<T>>();
            Queue<GraphVertex<T>> queue = new Queue<GraphVertex<T>>();
            //Add the starting vertex to the visited list and the queue
            visited.Add(start);
            queue.Enqueue(start);
            //Add the starting vertex to the pairs, distance will always be zero
            pairs.Add(start, distance);
            distance++;
            //While the queue isn't empty
            while (queue.Count != 0)
            {
                //Remove the vertex at the start of the queue
                GraphVertex<T> current = queue.Dequeue();
            


                foreach (GraphVertex<T> child in current.children)
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                        //Debugger.Break();
                        //Find the first vertex of the child whose parent is already in the pairs. 
                        int dist = pairs.FirstOrDefault(t => child.parents.Contains(t.Key)).Value;
                        pairs.Add(child, dist+1);
                    }
                }
               
               
            }
            return pairs.ToList() ;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("Graph Vertices: ");
            foreach(var vertex in vertices)
            {
                str.Append("\r\n" + vertex);
            }
            return str.ToString();
        }
    }
}
