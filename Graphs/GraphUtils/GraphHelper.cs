using System;
using System.Collections.Generic;
using System.Linq;
using Generari.Generators;
using Graphs.GraphElements;

namespace Graphs.GraphUtils {
    public class GraphHelper {
        private static string _components = string.Empty;
        private string _cycle = string.Empty;
        private int _time;

        public void DepthFirstSearch(Graph graph) {
            foreach (Node node in graph.Nodes) {
                node.Color = NodeColorEnum.WHITE;
                node.Parent = null;
            }

            _time = 0;
            foreach (Node node in graph.Nodes) {
                if (node.Color == NodeColorEnum.WHITE) {
                    DepthFirstSearchVisit(graph, node);
                }
            }
        }

        public List<List<Node>> GetConnectedComponents(Graph graph) {
            List<List<Node>> connectedComponents = new List<List<Node>>();
            FindConnectedComponents(graph);
            foreach (string values in _components.Split('|')) {
                connectedComponents.Add(
                    graph.Nodes.Where(node => values.Split(',')
                                                    .Contains(node.Value.ToString()))
                         .ToList()
                );
            }

            return connectedComponents;
        }

        private void FindConnectedComponents(Graph graph) {
            foreach (Node graphNode in graph.Nodes) {
                graphNode.IsVisitedForComponents = false;
            }

            foreach (Node graphNode in graph.Nodes) {
                if (graphNode.IsVisitedForComponents == false) {
                    CCUtil(graph, graphNode);
                    _components += "|";
                }
            }

            _components = _components.Substring(0, _components.Length - 2);
        }

        // ReSharper disable once InconsistentNaming
        private static void CCUtil(Graph graph, Node graphNode) {
            graphNode.IsVisitedForComponents = true;
            _components += graphNode.Value + ",";
            foreach (Node node in graph.AdjacencyLists[graphNode.Value]) {
                if (node.IsVisitedForComponents == false) {
                    CCUtil(graph, node);
                }
            }
        }

        private void DepthFirstSearchVisit(Graph graph, Node node) {
            _time++;
            node.DiscoveryTime = _time;
            node.Low = _time;
            node.Color = NodeColorEnum.GRAY;
            foreach (Node v in graph.AdjacencyLists[node.Value]) {
                if (v.Color == NodeColorEnum.WHITE) {
                    v.Parent = node;
                    DepthFirstSearchVisit(graph, v);

                    //find bridges
                    node.Low = Math.Min(node.Low, v.Low);
                    if (v.Low > node.DiscoveryTime) {
                        graph.Bridges.Add(new Edge(node, v));
                    }
                }
                else {
                    //find bridges
                    if (null != node.Parent && v.Value != node.Parent.Value) {
                        node.Low = Math.Min(node.Low, v.DiscoveryTime);

                        //find if it has cycles
                        graph.HasCycles = true;
                        PrintCycles(v, node);
                        graph.Cycles.Add(_cycle);
                        _cycle = string.Empty;
                    }
                }
            }

            node.Color = NodeColorEnum.BLACK;
            _time++;
            node.FinishTime = _time;
        }

        private void PrintCycles(Node start, Node end) {
            if (null == end || start.Value == end.Value) {
                _cycle += start.Value + " ";
            }
            else {
                _cycle += end.Value + " ";
                PrintCycles(start, end.Parent);
            }
        }

        public List<Node> Euler(Graph graph) {
            List<Node> eulerCycleNodes = new List<Node>();


            foreach (Node node in graph.Nodes) {
                if (graph.AdjacencyLists[node.Value].Count % 2 != 0) {
                    return null;
                }
            }

            eulerCycleNodes.Add(graph.Nodes.First());

            bool found = true;

            while (found) {
                found = false;
                Node v = eulerCycleNodes.Last();

                foreach (Node w in graph.AdjacencyLists[v.Value]) {
                    if (graph.IsBridge(v, w)) { }
                    else {
                        if (graph.Edges.GetEdge(v, w).Color != NodeColorEnum.BLACK) {
                            eulerCycleNodes.Add(w);
                            graph.Edges.GetEdge(v, w).Color = NodeColorEnum.BLACK;
                            found = true;
                            break;
                        }
                    }
                }
            }

            return eulerCycleNodes;
        }

        public List<List<Node>> Hamilton(Graph graph) {
            List<List<Node>> hamiltonianCycles = new List<List<Node>>();

            int[] nodesValues = graph.Nodes.Select(n => n.Value).ToArray();
            List<int> list = nodesValues.ToList();

            List<Node> nodes = graph.Nodes.OrderBy(n => list.IndexOf(n.Value)).ToList();

            if (graph.IsHamiltonCycle(nodes))
            {
                hamiltonianCycles.Add(nodes);
            }

            while (!PermutationGenerator.NextPermutation(nodesValues)) {
                list = nodesValues.ToList();

                nodes = graph.Nodes.OrderBy(n => list.IndexOf(n.Value)).ToList();

                if (graph.IsHamiltonCycle(nodes)) {
                    hamiltonianCycles.Add(nodes);
                }
            }


            return hamiltonianCycles;
        }

        //public List<List<Node>> HamiltonBacktracking(Graph graph) {

        //    List<List<Node>> hamiltonianCycles = new List<List<Node>>();
        //    int[] nodesValues = graph.Nodes.Select(n => n.Value).ToArray();
        //    int count = 1;

        //    while (count > 0) {
        //        if (count == graph.Nodes.Count) {
        //            hamiltonianCycles.Add(graph.Nodes.OrderBy(n => nodesValues.ToList().IndexOf(n.Value)).ToList());
        //        }

        //        foreach (Node node in graph.AdjacencyLists[nodesValues.Last()]) {
        //            if (!node.Tested) {
        //                node.Tested = true;
        //                nodesValues.Append(node.Value);
        //            }
        //        }
        //    }


        //    List<int> list = nodesValues.ToList();

        //    List<Node> nodes = graph.Nodes.OrderBy(n => list.IndexOf(n.Value)).ToList();

        //    if (graph.IsHamiltonCycle(nodes))
        //    {
        //        hamiltonianCycles.Add(nodes);
        //    }

        //    while (!PermutationGenerator.NextPermutation(nodesValues))
        //    {
        //        list = nodesValues.ToList();

        //        nodes = graph.Nodes.OrderBy(n => list.IndexOf(n.Value)).ToList();

        //        if (graph.IsHamiltonCycle(nodes))
        //        {
        //            hamiltonianCycles.Add(nodes);
        //        }
        //    }


        //    return hamiltonianCycles;
        //}

    }
}