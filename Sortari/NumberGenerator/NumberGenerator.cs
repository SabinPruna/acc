using System;

namespace Sortari.NumberGenerator {
    public static class NumberGenerator {
        public static int[] ArrayGenerator(int size) {
            int[] array = new int[size];

            Random randNumber = new Random();
            for (int i = 0; i < array.Length; i++) {
                array[i] = randNumber.Next(0, 100);
            }

            return array;
        }
    }
}