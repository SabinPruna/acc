using System;
using System.Collections.Generic;
using System.Linq;
using Graphs.GraphElements;
using Graphs.GraphUtils;

namespace Graphs {
    public class Graph {
        #region Properties

        /// <summary>
        ///     Gets or sets the adjacency lists.
        /// </summary>
        /// <value>
        ///     The adjacency lists.
        /// </value>
        public List<List<Node>> AdjacencyLists { get; set; }

        public List<Edge> Bridges { get; set; } = new List<Edge>();

        public List<List<Node>> ConnectedComponents { get; set; } = new List<List<Node>>();

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has cycles.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has cycles; otherwise, <c>false</c>.
        /// </value>
        public bool HasCycles { get; set; } = false;

        public List<Node> Nodes { get; set; } = new List<Node>();

        /// <summary>
        ///     Gets or sets the number of nodes.
        /// </summary>
        /// <value>
        ///     The number of nodes.
        /// </value>
        public int NumberOfNodes { get; set; }

        public List<string> Cycles { get; set; } = new List<string>();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Graph" /> class.
        /// </summary>
        /// <param name="graphTypeEnum">The graph type enum.</param>
        /// <param name="numberOfNodes">The number of nodes.</param>
        public Graph(GraphTypeEnum graphTypeEnum, int numberOfNodes) {
            NumberOfNodes = numberOfNodes;
            Random random = new Random();
            int count = 0;

            for (int i = 0; i < numberOfNodes; i++) {
                Nodes.Add(new Node(i));
            }


            switch (graphTypeEnum) {
                case GraphTypeEnum.Empty:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<Node>()).ToList();
                    break;
                case GraphTypeEnum.Complete:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<Node>()).ToList();

                    foreach (List<Node> adjacencyList in AdjacencyLists) {
                        for (int i = 0; i < NumberOfNodes; i++) {
                            adjacencyList.Add(Nodes.GetNodeByValue(i));
                        }

                        adjacencyList.RemoveAll(n => n.Value == count);
                        count++;
                    }

                    break;
                case GraphTypeEnum.Random:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<Node>()).ToList();
                    List<List<Node>> auxiliarAdjacencyLists = new List<List<Node>>();
                    foreach (List<Node> adjacencyList in AdjacencyLists) {
                        int length = random.Next(NumberOfNodes);
                        for (int i = 0; i < length; i++) {
                            adjacencyList.Add(Nodes.GetNodeByValue(random.Next(NumberOfNodes)));
                        }

                        adjacencyList.RemoveAll(n => n.Value == count);

                        auxiliarAdjacencyLists.Add(adjacencyList.GroupBy(node => node.Value)
                                                                .Select(group => group.First())
                                                                .ToList()); //Distinct().ToList());

                        count++;
                    }

                    AdjacencyLists = auxiliarAdjacencyLists;

                    count = 0;
                    foreach (List<Node> adjacencyList in AdjacencyLists) {
                        foreach (Node node in adjacencyList) {
                            if (!AdjacencyLists[node.Value].Contains(Nodes.GetNodeByValue(count))) {
                                AdjacencyLists[node.Value].Add(Nodes.GetNodeByValue(count));
                            }
                        }

                        count++;
                    }

                    List<List<Node>> finalLists = new List<List<Node>>();
                    foreach (List<Node> adjacencyList in AdjacencyLists) {
                        finalLists.Add(adjacencyList.OrderBy(node => node.Value).ToList());
                    }

                    AdjacencyLists = finalLists;

                    break;
                default:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<Node>()).ToList();
                    break;
            }
        }

        #endregion

        /// <summary>
        ///     Gets the number of edges.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfEdges() {
            return AdjacencyLists.Select(list => list.Count).Sum() / 2;
        }

        /// <summary>
        ///     Gets the adjacent matrix.
        /// </summary>
        /// <returns></returns>
        public int[,] GetAdjacentyMatrix() {
            int[,] adjacencyMatrix = new int[NumberOfNodes, NumberOfNodes];
            int count = 0;
            foreach (List<Node> adjacencyList in AdjacencyLists) {
                foreach (Node i in adjacencyList) {
                    adjacencyMatrix[count, i.Value] = 1;
                }

                count++;
            }

            return adjacencyMatrix;
        }
    }
}