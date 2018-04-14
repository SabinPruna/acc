using System;
using System.Collections.Generic;

namespace akCyclesInUndirectedGraphs {
    internal class Program {
        //  Graph modelled as list of edges
        private static readonly int[,] Graph = {
                                                   {1, 2}, {1, 3}, {1, 4}, {2, 3},
                                                   {3, 4}, {2, 6}, {4, 6}, {7, 8},
                                                   {8, 9}, {9, 7}
                                               };

        private static readonly List<int[]> Cycles = new List<int[]>();

        private static void main(string[] args) {
            for (int i = 0; i < Graph.GetLength(0); i++)
            for (int j = 0; j < Graph.GetLength(1); j++) {
                FindNewCycles(new[] {Graph[i, j]});
            }

            foreach (int[] cy in Cycles) {
                string s = "" + cy[0];

                for (int i = 1; i < cy.Length; i++) {
                    s += "," + cy[i];
                }

                Console.WriteLine(s);
            }
        }

        private static void FindNewCycles(int[] path) {
            int n = path[0];
            int x;
            int[] sub = new int[path.Length + 1];

            for (int i = 0; i < Graph.GetLength(0); i++)
            for (int y = 0; y <= 1; y++) {
                if (Graph[i, y] == n)
                    //  edge referes to our current node
                {
                    x = Graph[i, (y + 1) % 2];
                    if (!Visited(x, path))
                        //  neighbor node not on path yet
                    {
                        sub[0] = x;
                        Array.Copy(path, 0, sub, 1, path.Length);
                        //  explore extended path
                        FindNewCycles(sub);
                    }
                    else if (path.Length > 2 && x == path[path.Length - 1])
                        //  cycle found
                    {
                        int[] p = Normalize(path);
                        int[] inv = Invert(p);
                        if (IsNew(p) && IsNew(inv)) {
                            Cycles.Add(p);
                        }
                    }
                }
            }
        }

        private static bool Equals(int[] a, int[] b) {
            bool ret = a[0] == b[0] && a.Length == b.Length;

            for (int i = 1; ret && i < a.Length; i++) {
                if (a[i] != b[i]) {
                    ret = false;
                }
            }

            return ret;
        }

        private static int[] Invert(int[] path) {
            int[] p = new int[path.Length];

            for (int i = 0; i < path.Length; i++) {
                p[i] = path[path.Length - 1 - i];
            }

            return Normalize(p);
        }

        //  rotate cycle path such that it begins with the smallest node
        private static int[] Normalize(int[] path) {
            int[] p = new int[path.Length];
            int x = Smallest(path);
            int n;

            Array.Copy(path, 0, p, 0, path.Length);

            while (p[0] != x) {
                n = p[0];
                Array.Copy(p, 1, p, 0, p.Length - 1);
                p[p.Length - 1] = n;
            }

            return p;
        }

        private static bool IsNew(int[] path) {
            bool ret = true;

            foreach (int[] p in Cycles) {
                if (Equals(p, path)) {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

        private static int Smallest(int[] path) {
            int min = path[0];

            foreach (int p in path) {
                if (p < min) {
                    min = p;
                }
            }

            return min;
        }

        private static bool Visited(int n, int[] path) {
            bool ret = false;

            foreach (int p in path) {
                if (p == n) {
                    ret = true;
                    break;
                }
            }

            return ret;
        }
    }
}