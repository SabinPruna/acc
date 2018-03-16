namespace Sortari.Sorts {
    internal class BitonicSorter {
        private const bool ASCENDING = true;
        private const bool DESCENDING = false;
        private int[] _array;

        public void Sort(int[] array) {
            _array = array;
            BitonicSort(0, array.Length, ASCENDING);
        }

        private void BitonicSort(int low, int numberOfElements, bool direction) {
            if (numberOfElements > 1) {
                int middle = numberOfElements / 2;
                BitonicSort(low, middle, ASCENDING);
                BitonicSort(low + middle, middle, DESCENDING);

                BitonicMerge(low, numberOfElements, direction);
            }
        }

        private void BitonicMerge(int low, int numberOfElemets, bool direction) {
            if (numberOfElemets > 1) {
                int m = numberOfElemets / 2;
                for (int i = low; i < low + m; i++) {
                    Compare(i, i + m, direction);
                }

                BitonicMerge(low, m, direction);
                BitonicMerge(low + m, m, direction);
            }
        }

        private void Compare(int i, int j, bool direction) {
            if (direction == _array[i] > _array[j]) {
                Exchange(i, j);
            }
        }

        private void Exchange(int i, int j) {
            int t = _array[i];
            _array[i] = _array[j];
            _array[j] = t;
        }
    }
}