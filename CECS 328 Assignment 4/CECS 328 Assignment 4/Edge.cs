using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4
{
    class Edge<T>
    {
        GraphVertex<T> to;
        GraphVertex<T> from;
        
        public Edge(){

        }

        public Edge(GraphVertex<T> from, GraphVertex<T> to)
        {
            this.to = to;
            this.from = from;
        }

        public override bool Equals(object obj)
        {
            Edge<T> edge = (Edge<T>)obj;
            return this.to.Equals(edge.to) && this.from.Equals(edge.from);
        }

        public override string ToString()
        {
            return "From: [" + from.value + "," + from.symbol + "]| To: [" + to.value + "," + to.symbol + "]";
        }
    }
}
