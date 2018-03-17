using System;
using System.Collections.Generic;
using Generari.Generators;

namespace Generari {
    public class Program {
        private static void Main() {


            SubsetGenerator sg = new SubsetGenerator();
            foreach (IEnumerable<int> enumerable in sg.SubSetsOf(new List<int> {0, 1})) {
                foreach (int i in enumerable) {
                    Console.Write(i+ " ");
                }

                Console.WriteLine();
            }



            KSubsetGenerator ksg = new KSubsetGenerator();
            IEnumerable<List<int>> res = ksg.BacktrackingGenerator(3, new List<int>{1,2,3,4}, new List<int>(), new List<int>());
            foreach (List<int> ints in res) {
                foreach (int i in ints) {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }

            PermutationGenerator pg = new PermutationGenerator {InputSet = new[] {'1', '2', '3', '4'}};
            pg.BacktrackingGeneration(0);

            foreach (int[] subset in pg.LexicalGeneration(new[] {0, 1, 2, 3, 4})) {
                foreach (int element in subset) {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }
    }
}