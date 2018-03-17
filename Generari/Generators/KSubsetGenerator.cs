using System.Collections.Generic;
using System.Linq;

namespace Generari.Generators {
    public class KSubsetGenerator {
        public IEnumerable<List<int>> BacktrackingGenerator(
            int numberOfElements, List<int> set, List<int> subSet, List<int> subSetIndex) {
            if (numberOfElements == 0) {
                List<List<int>> result = new List<List<int>> {subSetIndex};
                return result;
            }

            if (numberOfElements > 0) {
                List<List<int>> result = set.Select((x, i) => {
                                                        List<int> newSubset = subSet.Select(y => y).ToList();
                                                        newSubset.Add(x);

                                                        List<int> newSubsetIndex = subSetIndex.Select(y => y).ToList();
                                                        newSubsetIndex.Add(i);

                                                        List<int> newSet = set.Skip(i).ToList();
                                                        return BacktrackingGenerator(
                                                            numberOfElements - 1, newSet, newSubset,
                                                            newSubsetIndex).ToList();
                                                    }
                ).SelectMany(x => x).ToList();
                return result;
            }

            return new List<List<int>>();
        }
    }


}