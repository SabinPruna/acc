using System;
using Graphs.GraphUtils;

namespace Graphs {
    public class Node {
        #region Properties

        public NodeColorEnum Color { get; set; } = NodeColorEnum.WHITE;

        public int DiscoveryTime { get; set; }

        public int FinishTime { get; set; }

        public bool IsVisitedForComponents { get; set; } = false;

        public int Low { get; set; } = int.MaxValue;

        public Node Parent { get; set; } = null;

        public int Value { get; set; }

        #endregion

        #region Constructors

        public Node(int value) {
            Value = value;
        }

        #endregion
    }
}