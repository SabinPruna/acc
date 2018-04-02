using Graphs.GraphUtils;

namespace Graphs {
    internal class Program {
        private static void Main(string[] args) {



            Graph graph = new Graph(GraphTypeEnum.Empty, 10);

            Graph graph2 = new Graph(GraphTypeEnum.Complete, 10);

            Graph graph3 = new Graph(GraphTypeEnum.Random, 10);



        }
    }
}