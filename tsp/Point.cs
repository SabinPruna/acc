using System;

namespace tsp {
    public class Point {
        private static readonly Random Rand = new Random();

        #region Properties

        public int Value { get; set; }

        public int X { get; set; } = Rand.Next(1000);
        public int Y { get; set; } = Rand.Next(1000);

        public bool IsVisited { get; set; } = false;
        public Point Parent { get; set; }
        public int Rank { get; set; } = 0;

        #endregion
    }
}