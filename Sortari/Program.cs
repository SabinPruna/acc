using System;
using Sortari.Sorts;

namespace Sortari
{
    public class Program
    {
        private static void Main()
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = NumberGenerator.NumberGenerator.ArrayGenerator(size);

            //foreach (int i in array) {
            //    Console.Write(i + " ");
            //}

            //Console.WriteLine();

            //BubbleSorter bs = new BubbleSorter();
            //bs.Sort(array);

            //CountingSorter cs = new CountingSorter();
            //array = cs.Sort(array);

            //MergeSorter.Sort(array, 0, array.Length - 1);

            //BitonicSorter bs = new BitonicSorter();
            //bs.Sort(array);

            //LinearSorter ls = new LinearSorter();
            //ls.Sort(array);

            //foreach (int i in array)
            //{
            //    Console.Write(i + " ");
            //}
        }
    }
}
