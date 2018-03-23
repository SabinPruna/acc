using System;
using System.Collections.Generic;
using System.Linq;

namespace Generari.Generators {
    public class KSubsetGenerator {

        public static IEnumerable<int[]> FindCombinationsRecursively(int[] buffer, int currentIndex, int start, int finish)
        {
            for (int i = start; i < finish; i++)
            {
                buffer[currentIndex] = i;

                if (currentIndex == buffer.Length - 1) {
                    yield return buffer;
                }
                else {
                    foreach (int[] array in FindCombinationsRecursively(buffer, currentIndex + 1, i + 1, finish)) {
                        yield return array;
                    }
                }
            }
        }

        public static IEnumerable<int[]> BacktrackingGenerator(int lenght, int sizeOfCombination)
        {
            return FindCombinationsRecursively(new int[sizeOfCombination], 0, 0, lenght);
        }

        private static IEnumerable<IEnumerable<int>> GetSubsets(int n, int subsetSize) {
            IEnumerable<int> sequence = Enumerable.Range(0, n);

            List<int[]> singleElements = sequence.Select(x => new[] {x}).ToList();

            List<List<int>> result = new List<List<int>> {new List<int>()};

            foreach (int[] singleElement in singleElements) {
                int length = result.Count;

                for (int i = 0; i < length; i++) {
                    if (result[i].Count >= subsetSize) {
                        continue;
                    }

                    result.Add(result[i].Concat(singleElement).ToList());
                }
            }

            return result.Where(x => x.Count == subsetSize);
        }

        public static void LexicalGenerator(int n, int subsetSize) {
            Console.WriteLine("----------");
            foreach (IEnumerable<int> subset in GetSubsets(n, subsetSize)) {
                Console.WriteLine("{0}", string.Join(" ", subset.Select(x => x.ToString())));
            }
        }
    }
}