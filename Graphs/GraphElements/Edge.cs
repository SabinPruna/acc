namespace Graphs.GraphElements {
    public class Edge {
        #region Properties

        public Node FromNode { get; set; }

        public Node ToNode { get; set; }

        #endregion

        #region Constructors

        public Edge(Node fromNode, Node toNode) {
            FromNode = fromNode;
            ToNode = toNode;
        }

        #endregion

        public override string ToString() {
            return $"[{FromNode.Value} , {ToNode.Value}]";
        }
    }
}