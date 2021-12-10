using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }

        private static void Task1()
        {
            Console.WriteLine("Task 1");
            
            Console.Write("Input number of arrays: ");
            var R = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Input length of arrays: ");
            var N = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Input max possible number in array: ");
            var M = Convert.ToInt32(Console.ReadLine());

            for (int count = 0; count < R; count++)
            {
                var array = RandomArray(N, M);
                var arr = array;
                
                Sorts.HybridQuickSort(ref array, 4);

                Console.WriteLine("Array: " + string.Join(", ", array));
                
                Sorts.QuickSortCheck(arr);
            }
            
            Console.WriteLine();
        }

        private static void Task2()
        {
            Console.WriteLine("Task 2");
            
            Console.Write("Input number of arrays: ");
            var R = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Input length of arrays: ");
            var N = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Input max possible number in array: ");
            var M = Convert.ToInt32(Console.ReadLine());

            for (int count = 0; count < R; count++)
            {
                var array = RandomArray(N, M);
                
                Sorts.HybridMergeSort(ref array, 4);

                Console.WriteLine("Array: " + string.Join(", ", array));
                
                Sorts.MergeSortCheck(array);
            }

            Console.WriteLine();
        }

        private static void Task3()
        {
            Console.WriteLine("Task 3");
            
            Console.Write("Input length of array: ");
            var N = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Input max possible number in array: ");
            var M = Convert.ToInt32(Console.ReadLine());
            
            var array = RandomArray(N, M);
            
            Sorts.InsertionSortOperationsCount(ref array);
            Console.WriteLine(string.Join(", ", array));
        }

        private static int[] RandomArray(int length, int maxNumber)
        {
            var array = new int[length];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, maxNumber);
            }

            return array;
        }
    }
}