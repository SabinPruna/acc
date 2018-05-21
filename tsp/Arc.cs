using System;

namespace tsp {
    public class Arc {
        #region Properties

        public int Distance { get; set; }

        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }

        #endregion

        #region Constructors

        public Arc(Point firstPoint, Point secondPoint) {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            Distance = (int) Math.Sqrt((FirstPoint.X - SecondPoint.X) * (FirstPoint.X - SecondPoint.X) +
                                       (FirstPoint.Y - SecondPoint.Y) * (FirstPoint.Y - SecondPoint.Y));
        }

        #endregion

        public bool Equals(Arc otherArc) {
            return FirstPoint.X == otherArc.FirstPoint.X && SecondPoint.X == otherArc.SecondPoint.X &&
                   FirstPoint.Y == otherArc.FirstPoint.Y && SecondPoint.Y == otherArc.SecondPoint.Y ||
                   FirstPoint.X == otherArc.SecondPoint.X && SecondPoint.X == otherArc.FirstPoint.X &&
                   FirstPoint.Y == otherArc.SecondPoint.Y && SecondPoint.Y == otherArc.FirstPoint.Y;
        }
    }
}