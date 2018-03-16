namespace Sortari.Sorts {
    public class BubbleSorter {
        public void Sort(int[] array) {
            for (int p = 0; p <= array.Length - 2; p++)
            for (int i = 0; i <= array.Length - 2; i++) {
                if (array[i] > array[i + 1]) {
                    int temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}