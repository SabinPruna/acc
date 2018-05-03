using Graphs.GraphUtils;

namespace Graphs.GraphElements {
    public class UndirectedEdge {
        #region Properties

        public NodeColorEnum Color { get; set; } = NodeColorEnum.WHITE;

        public Node FirstNode { get; set; }

        public Node SecondNode { get; set; }

        #endregion

        #region Constructors

        public UndirectedEdge(Node fromNode, Node toNode) {
            FirstNode = fromNode;
            SecondNode = toNode;
        }

        #endregion

        public bool Equals(UndirectedEdge edge) {
            return FirstNode.Value == edge.FirstNode.Value && SecondNode.Value == edge.SecondNode.Value ||
                   FirstNode.Value == edge.SecondNode.Value && SecondNode.Value == edge.FirstNode.Value;
        }

        public override string ToString() {
            return $"[{FirstNode.Value} , {SecondNode.Value}]";
        }
    }
}