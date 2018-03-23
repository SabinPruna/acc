using System;
using System.Collections.Generic;

namespace Generari.Generators {
    public class PermutationGenerator {
        public void BacktrackingGeneration(int[] list, int counter, int size) {
            int i;
            if (counter == size) {
                for (i = 0; i <= size; i++) {
                    Console.Write($"{list[i]}");
                }

                Console.WriteLine();
            }
            else {
                for (i = counter; i <= size; i++) {
                    SwapNumbers(ref list[counter], ref list[i]);
                    BacktrackingGeneration(list, counter + 1, size);
                    SwapNumbers(ref list[counter], ref list[i]);
                }
            }
        }

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

        public void SwapNumbers(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }


        public static bool NextPermutation<T>(T[] elements) where T : IComparable<T> {
            int count = elements.Length;

            bool done = true;

            for (int i = count - 1; i > 0; i--) {
                T curr = elements[i];

                if (curr.CompareTo(elements[i - 1]) < 0) {
                    continue;
                }

                done = false;
                T prev = elements[i - 1];

                int currIndex = i;

                for (int j = i + 1; j < count; j++) {
                    T tmp = elements[j];

                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0) {
                        curr = tmp;
                        currIndex = j;
                    }
                }

                elements[currIndex] = prev;
                elements[i - 1] = curr;

                for (int j = count - 1; j > i; j--, i++) {
                    T tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                break;
            }

            return done;
        }
    }
}