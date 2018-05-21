using System.Collections.Generic;
using System.Linq;
using Generari.Generators;

namespace tsp {
    public class Graph {
        #region Properties

        public List<Arc> Arcs { get; set; } = new List<Arc>();
        public List<Point> Points { get; set; }

        #endregion

        #region Constructors

        public Graph(int count) {
            int number = 0;
            Points = Enumerable.Range(0, count).Select(i => new Point {Value = number++}).ToList();

            for (int i = 0; i < Points.Count; i++) {
                for (int j = i + 1; j < Points.Count; j++) {
                    if (!IsAlreadyArc(new Arc(Points[i], Points[j]))) {
                        Arcs.Add(new Arc(Points[i], Points[j]));
                    }
                }
            }
        }

        #endregion

        public List<Point> BruteForceApproach() {
            List<List<Point>> cycles = new List<List<Point>>();

            int[] pointsValues = Points.Select(n => n.Value).ToArray();
            List<int> list = pointsValues.ToList();

            List<Point> points = Points.OrderBy(n => list.IndexOf(n.Value)).ToList();

            if (IsCycle(points)) {
                cycles.Add(points);
            }

            while (!PermutationGenerator.NextPermutation(pointsValues)) {
                list = pointsValues.ToList();
                points = Points.OrderBy(n => list.IndexOf(n.Value)).ToList();

                if (IsCycle(points)) {
                    cycles.Add(points);
                }
            }


            return FindShortestCycle(cycles);
        }

        public List<Point> Greedy() {
            List<List<Point>> cycles = new List<List<Point>>();


            foreach (Point point in Points) {
                cycles.Add(Greedy(point));
            }

            return FindShortestCycle(cycles);
        }

        public List<Point> Cristofides() {
            Kruskal();

            //todo: parcurgere anti clockwise? 
            return null;
        }


        //-----------------------------------------

        private List<Point> Greedy(Point x) {
            List<Point> cycleFromX = new List<Point>();

            Arc arc;
            while ((arc = FindMinimumCostArc(x)) != null) {
                cycleFromX.Add(arc.FirstPoint);
                x = arc.SecondPoint;
            }


            return cycleFromX;
        }

        private Arc FindMinimumCostArc(Point point) {
            int shortestDistance = int.MaxValue;
            Arc shortestArc = null;

            foreach (Point point1 in Points) {
                if (!(point1.X == point.X && point1.Y == point.Y) && !point1.IsVisited) {
                    int distance = new Arc(point, point1).Distance;
                    if (distance < shortestDistance) {
                        shortestDistance = distance;
                        shortestArc = new Arc(point, point1);
                    }
                }
            }

            point.IsVisited = true;
            return shortestArc;
        }

        private List<Point> FindShortestCycle(List<List<Point>> cycles) {
            List<Point> shortestCycle = new List<Point>();
            int cost = 0;
            int minimumCost = int.MaxValue;

            foreach (List<Point> points in cycles) {
                for (int i = 0; i < points.Count - 1; i++) {
                    cost += new Arc(points[i], points[i + 1]).Distance;
                }

                cost += new Arc(points.Last(), points.First()).Distance;

                if (cost < minimumCost) {
                    minimumCost = cost;
                    shortestCycle = points;
                }

                cost = 0;
            }

            return shortestCycle;
        }

        private bool IsCycle(List<Point> points) {
            for (int i = 0; i < points.Count - 1; i++) {
                if (!IsAlreadyArc(new Arc(points[i], points[i + 1]))) {
                    return false;
                }
            }

            return true;
        }

        private bool IsAlreadyArc(Arc arc) {
            foreach (Arc arc1 in Arcs) {
                if (arc1.Equals(arc)) {
                    return true;
                }
            }

            return false;
        }

        public List<Arc> Kruskal() {
            List<Arc> A = new List<Arc>();
            foreach (Point v in Points) {
                MakeSet(v);
            }

            List<Arc> orderedArcs = Arcs.OrderBy(a => a.Distance).ToList();
            foreach (Arc orderedArc in orderedArcs) {
                if (FindSet(orderedArc.FirstPoint) != FindSet(orderedArc.SecondPoint)) {
                    A.Add(orderedArc);
                    Union(orderedArc.FirstPoint, orderedArc.SecondPoint);
                }
            }

            return A;
        }

        private void Union(Point orderedArcFirstPoint, Point orderedArcSecondPoint) {
            Link(FindSet(orderedArcFirstPoint), FindSet(orderedArcSecondPoint));
        }

        private void Link(Point x, Point y) {
            if (x.Rank > y.Rank) {
                x.Parent = x;
            }
            else {
                x.Parent = y;
                if (x.Rank == y.Rank) {
                    y.Rank++;
                }
            }
        }

        private Point FindSet(Point x) {
            if (x.Value != x.Parent.Value) {
                x.Parent = FindSet(x.Parent);
            }

            return x.Parent;
        }

        private void MakeSet(Point point) {
            point.Parent = point;
            point.Rank = 0;
        }
    }
}