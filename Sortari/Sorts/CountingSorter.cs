using System;
using System.Collections.Generic;
using System.Linq;

namespace Sortari.Sorts {
    internal class CountingSorter {
        public int[] Sort(int[] array) {

            //Dictionary<int, int> rankings = array.Distinct()
            //                   .OrderByDescending(x => x)
            //                   .Select((g, i) => new { Key = g, Rank = i + 1 })
            //                   .ToDictionary(x => x.Key, x => x.Rank);

            //return array.Select(x => new { Col1 = x, Rank = rankings[x] }).ToList();



            int[] sortedArray = new int[array.Length];

            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++) {
                if (array[i] < minVal) {
                    minVal = array[i];
                }
                else if (array[i] > maxVal) {
                    maxVal = array[i];
                }
            }

            int[] counts = new int[maxVal - minVal + 1];

            foreach (int t in array) {
                counts[t - minVal]++;
            }

            counts[0]--;
            for (int i = 1; i < counts.Length; i++) {
                counts[i] = counts[i] + counts[i - 1];
            }

            for (int i = array.Length - 1; i >= 0; i--) {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return sortedArray;
        }
    }
}