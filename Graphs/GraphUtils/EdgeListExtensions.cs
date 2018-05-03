using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.GraphElements;

namespace Graphs.GraphUtils
{
    public static class EdgeListExtensions
    {
        public static UndirectedEdge GetEdge(this List<UndirectedEdge> list, Node node1, Node node2)
        {

            return list.First(edge => edge.Equals(new UndirectedEdge(node1, node2)));
        }
    }
}
