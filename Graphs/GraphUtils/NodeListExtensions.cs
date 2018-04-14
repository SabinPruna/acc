using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GraphUtils
{
    public static class NodeListExtensions
    {
        public static Node GetNodeByValue(this List<Node> list, int item) {

            return list.First(node => node.Value == item);
        }

        private static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
