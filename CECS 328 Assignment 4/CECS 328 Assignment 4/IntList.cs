using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4
{
    class SList<T> : List<T>
    {
        public override bool Equals(object obj)
        {
            List<T> list = (List<T>)obj;
            bool samecontents = this.All(list.Contains);
            bool samesize = this.Count == list.Count;
            return samecontents && samesize;
        }
    }
}
