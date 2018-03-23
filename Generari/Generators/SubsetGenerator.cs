using System;
using System.Collections.Generic;
using System.Linq;

namespace Generari.Generators {
    public class SubsetGenerator {
        public static List<List<int>> BacktrackingGenerator(List<int> set, int index) {

            List<List<int>> powerset;
            if (index == set.Count) {
                powerset = new List<List<int>> {new List<int>()};
            }
            else {
                powerset = BacktrackingGenerator(set, index + 1);
                int item = set[index];
                List<List<int>> currentSet = new List<List<int>>();
                foreach (List<int> subset in powerset) {
                    List<int> newSet = new List<int>();
                    newSet.AddRange(subset);
                    newSet.Add(item);
                    currentSet.Add(newSet);
                }

                powerset.AddRange(currentSet);
            }

            return powerset;
        }

        public static IEnumerable<IEnumerable<T>> LexicalGenerator<T>(IEnumerable<T> source) {
            List<T> list = source.ToList();
            int length = list.Count;
            int max = (int) Math.Pow(2, list.Count);

            for (int count = 0; count < max; count++) {
                List<T> subset = new List<T>();
                uint rs = 0;
                while (rs < length) {
                    if ((count & (1u << (int) rs)) > 0) {
                        subset.Add(list[(int) rs]);
                    }

                    rs++;
                }

                yield return subset;
            }
        }
    }
}