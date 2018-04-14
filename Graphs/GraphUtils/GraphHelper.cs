using System;
using System.Collections.Generic;
using System.Linq;
using Graphs.GraphElements;

namespace Graphs.GraphUtils {
    public class GraphHelper {
        private static string _components = string.Empty;
        private int _time;
        private string _cycle = string.Empty;

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
                    if (v.Value != node.Parent.Value) {
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
            if (start.Value == end.Value) {
                _cycle += start.Value + " ";
            }
            else {
                _cycle += end.Value + " ";
                PrintCycles(start, end.Parent);
            }
        }
    }
}