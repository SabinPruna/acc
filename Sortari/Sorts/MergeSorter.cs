namespace Sortari.Sorts {
    internal class MergeSorter {
        public static void MainMerge(int[] numbers, int left, int middle, int right) {
            int[] temp = new int[numbers.Length];

            int i;

            int eol = middle - 1;
            int position = left;
            int number = right - left + 1;

            while (left <= eol && middle <= right) {
                if (numbers[left] <= numbers[middle]) {
                    temp[position++] = numbers[left++];
                }
                else {
                    temp[position++] = numbers[middle++];
                }
            }

            while (left <= eol) {
                temp[position++] = numbers[left++];
            }

            while (middle <= right) {
                temp[position++] = numbers[middle++];
            }

            for (i = 0; i < number; i++) {
                numbers[right] = temp[right];
                right--;
            }
        }
        public static void Sort(int[] numbers, int left, int right) {
            if (right > left) {
                int middle = (right + left) / 2;

                Sort(numbers, left, middle);
                Sort(numbers, middle + 1, right);

                MainMerge(numbers, left, middle + 1, right);
            }
        }
    }
}