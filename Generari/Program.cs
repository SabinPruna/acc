using System;

namespace Generari {
    public class Program {
        private static void Main() {
            SubsetGenerator sg = new SubsetGenerator();
            foreach (int[] subset in sg.LexicalGeneration(new[] {0, 1, 2, 3, 4})) {
                foreach (int element in subset) {
                    Console.Write(element + " ");
                }

                Console.WriteLine();
            }
        }
    }
}