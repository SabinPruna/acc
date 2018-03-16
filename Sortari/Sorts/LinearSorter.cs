using System;

namespace Sortari.Sorts {
    public class LinearSorter {
        public void Sort(int[] array) {
            int[] counter = new int[short.MaxValue];

            for (int i = 0 ; i < short.MaxValue - 1; i++) {
                counter[i] = 0;
            }

            foreach (int t in array) {
                counter[t]++;
            }

            int k = 0;

            for (int i = 0; i < short.MaxValue - 1; i++) {
                for (int j = 0; j < counter[i]; j++) {
                    array[k++] = i;
                }
            }
        }
    }
}