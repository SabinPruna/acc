using System;
using System.Collections.Generic;
using System.Linq;
using Generari.Generators;

namespace Generari
{
    public class Program
    {
        private static void Main()
        {

            foreach (List<int> ints in SubsetGenerator.BacktrackingGenerator(new List<int> { 1, 2, 3, 4 }, 0))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }

            foreach (IEnumerable<int> enumerable in SubsetGenerator.LexicalGenerator(new List<int> { 4,3,2,1 }))
            {
                foreach (int i in enumerable)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("---------");


            foreach (int[] ints in KSubsetGenerator.BacktrackingGenerator(5, 4))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }

            KSubsetGenerator.LexicalGenerator(5, 4);

            Console.WriteLine("---------");

            new PermutationGenerator().BacktrackingGeneration(new[] { 1, 2, 3, 4 }.ToArray(), 0, 3);

            Console.WriteLine("---------");

            //foreach (int[] subset in new PermutationGenerator().LexicalGeneration(new[] { 1, 2, 3, 4 }))
            //{
            //    foreach (int element in subset)
            //    {
            //        Console.Write(element + " ");
            //    }
            //    Console.WriteLine();
            //}

            var arr = new[] { 1, 2, 3, 4 };

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            
            while (!PermutationGenerator.NextPermutation(arr))
            {
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();


            }


        }
    }
}