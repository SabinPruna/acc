using System;
using System.Collections.Generic;

namespace Generari {
    public class PermutationGenerator {
        private int _elementLevel = -1;
        private int _numberOfElements;
        private readonly int[] _permutationValue = new int[0];

        public char[] InputSet { get; set; }

        public int PermutationCount { get; set; }

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

        public void BacktrackingGeneration(int k) {

            _elementLevel++;
            _permutationValue.SetValue(_elementLevel, k);

            if (_elementLevel == _numberOfElements) {
                OutputPermutation(_permutationValue);
            }
            else {
                for (int i = 0; i < _numberOfElements; i++) {
                    if (_permutationValue[i] == 0) {
                        BacktrackingGeneration(i);
                    }
                }
            }

            _elementLevel--;
            _permutationValue.SetValue(0, k);
        }

        private void OutputPermutation(IEnumerable<int> value) {
            foreach (int i in value) {
                Console.Write(InputSet.GetValue(i - 1));
            }

            Console.WriteLine();
            PermutationCount++;
        }
    }
}