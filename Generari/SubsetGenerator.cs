using System.Collections.Generic;

namespace Generari {
    public class SubsetGenerator {
        public IEnumerable<int[]> LexicalGeneration(int[] array) {
            while (true) {
                yield return array;
                int j = array.Length - 2;
                while (j >= 0 && array[j] >= array[j + 1]) {
                    j--;
                }

                if (j < 0) {
                    break;
                }

                int l = array.Length - 1;
                while (array[j] >= array[l]) {
                    l--;
                }

                int tmp = array[l];
                array[l] = array[j];
                array[j] = tmp;

                int k = j + 1;
                l = array.Length - 1;
                while (k < l) {
                    int t = array[k];
                    array[k] = array[l];
                    array[l] = t;
                    k++;
                    l--;
                }
            }
        }



    }
}