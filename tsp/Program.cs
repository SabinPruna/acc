using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsp
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(4);

            graph.BruteForceApproach();

            graph.Greedy();

            graph.Kruskal();
        }
    }
}
