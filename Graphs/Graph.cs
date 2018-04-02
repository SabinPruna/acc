using System;
using System.Collections.Generic;
using System.Linq;
using Graphs.GraphUtils;

namespace Graphs {
    internal class Graph {
        /// <summary>
        ///     Gets or sets the number of nodes.
        /// </summary>
        /// <value>
        ///     The number of nodes.
        /// </value>
        public int NumberOfNodes { get; set; }

        /// <summary>
        ///     Gets or sets the adjacency lists.
        /// </summary>
        /// <value>
        ///     The adjacency lists.
        /// </value>
        public List<List<int>> AdjacencyLists { get; set; }

        public Graph(GraphTypeEnum graphTypeEnum, int numberOfNodes) {
            NumberOfNodes = numberOfNodes;
            Random random = new Random();
            int count = 0;

            switch (graphTypeEnum) {
                case GraphTypeEnum.Empty:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<int>()).ToList();
                    break;
                case GraphTypeEnum.Complete:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<int>()).ToList();

                    foreach (List<int> adjacencyList in AdjacencyLists) {
                        for (int i = 0; i < NumberOfNodes; i++) {
                            adjacencyList.Add(i);
                        }

                        adjacencyList.Remove(count++);
                    }

                    break;
                case GraphTypeEnum.Random:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<int>()).ToList();
                    foreach (List<int> adjacencyList in AdjacencyLists) {
                        int length = random.Next(NumberOfNodes);
                        for (int i = 0; i < length; i++) {
                            adjacencyList.Add(random.Next(NumberOfNodes));
                        }

                        if (adjacencyList.Contains(count)) {
                            adjacencyList.Remove(count);
                        }

                        count++;
                    }

                    break;
                default:
                    AdjacencyLists = Enumerable.Range(0, NumberOfNodes).Select(l => new List<int>()).ToList();
                    break;
            }
        }
    }
}