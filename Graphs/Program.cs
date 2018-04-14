using System;
using System.Linq;
using Graphs.GraphElements;
using Graphs.GraphUtils;

namespace Graphs {
    internal class Program {
        private static void Main(string[] args) {
            GraphHelper graphHelper = new GraphHelper();

            Graph graph = new Graph(GraphTypeEnum.Empty, 10);
            Graph graph2 = new Graph(GraphTypeEnum.Complete, 10);
            Graph graph3 = new Graph(GraphTypeEnum.Random, 100);

            Graph graph4 = new Graph(GraphTypeEnum.Empty, 4);
            graph4.AdjacencyLists[0].Add(graph4.Nodes[1]);
            graph4.AdjacencyLists[1].Add(graph4.Nodes[0]);
            graph4.AdjacencyLists[1].Add(graph4.Nodes[2]);
            graph4.AdjacencyLists[2].Add(graph4.Nodes[1]);
            graph4.AdjacencyLists[2].Add(graph4.Nodes[3]);
            graph4.AdjacencyLists[3].Add(graph4.Nodes[2]);

            graphHelper.DepthFirstSearch(graph4);

            Graph graph5 = new Graph(GraphTypeEnum.Empty, 4);
            graph5.AdjacencyLists[0].Add(graph5.Nodes[1]);
            graph5.AdjacencyLists[1].Add(graph5.Nodes[0]);
            graph5.AdjacencyLists[1].Add(graph5.Nodes[2]);
            graph5.AdjacencyLists[2].Add(graph5.Nodes[1]);
            graph5.AdjacencyLists[2].Add(graph5.Nodes[3]);
            graph5.AdjacencyLists[3].Add(graph5.Nodes[2]);
            graph5.AdjacencyLists[3].Add(graph5.Nodes[0]);

            graphHelper.DepthFirstSearch(graph5);

            graph3.GetNumberOfEdges();

            graph3.GetAdjacentyMatrix();

            graphHelper.DepthFirstSearch(graph3);

            graph3.ConnectedComponents = graphHelper.GetConnectedComponents(graph3);

            foreach (Edge graph3Bridge in graph3.Bridges) {
                Console.WriteLine(
                graph3Bridge.ToString());
            }
        }
    }
}