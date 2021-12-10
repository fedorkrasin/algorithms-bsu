using System;
using System.Diagnostics;
using lab2.BinaryTreeModel;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1();
            Task2();
            // Task3();
        }

        private static void Task1()
        {
            Console.WriteLine("Task 1");
            
            Console.Write("Input length of array: ");
            var N = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Input max possible number in array: ");
            var M = Convert.ToInt32(Console.ReadLine());
            
            var array = RandomArray(N, M);
            
            Sorts.QuickSort(ref array);
            Console.WriteLine("Sorted array: " + string.Join(',', array));
            
            Console.Write("Element to be found: ");
            var element = Convert.ToInt32(Console.ReadLine());
            
            var binarySearchResult = Search.BinarySearch(array, element);
            Console.WriteLine($"Index of element: {binarySearchResult}");

            var interpolationSearchResult = Search.InterpolationSearch(array, element);
            Console.WriteLine($"Index of element: {interpolationSearchResult}");
        }

        private static void Task2()
        {
            var binaryTree = new BinaryTree(4);
            binaryTree.Add(5, 16, 27, 9, 27, 1, 23, 15, 40, 7, 10, 4, 34, 25, 28);

            binaryTree.Print(2, 43);
            Console.WriteLine('\n');
            
            Console.WriteLine("Pre-Order: " + binaryTree.PreOrder());
            Console.WriteLine("Left In-Order: " + binaryTree.InOrderLeft());
            Console.WriteLine("Right In-Order: " + binaryTree.InOrderRight());
            Console.WriteLine("Out-Order: " + binaryTree.OutOrder() + "\n\n");

            Console.Write("Enter the index of smallest element in binary tree should be find: ");
            var k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The " + k + "th smallest element: " + binaryTree.KthSmallestElement(k) + "\n\n");

            // binaryTree.BalanceBinaryTree();
            binaryTree.RotateRight(binaryTree.Root.RightNode);
            binaryTree.Print(2, 43);
            Console.WriteLine('\n');
        }

        private static void Task3()
        {
            Console.Write("Enter table size: ");
            var tableSize = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter max value of element: ");
            var maxRangeValue = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter values length: ");
            var valuesLength = Convert.ToInt32(Console.ReadLine());
            
            var values = RandomArray(valuesLength, maxRangeValue);
            
            var hashTable1 = new Hashing(tableSize);
            var hashTable2 = new Hashing(tableSize);

            for (var i = 0; i < values.Length; i += 1)
            {
                hashTable1.Insert(values[i]);
            }
            
            hashTable1.DisplayHash();
            
            Console.WriteLine("\nMy Knuth const:");
            
            for (var i = 0; i < values.Length; i += 1)
            {
                hashTable2.Insert(values[i], true);
            }
            
            hashTable2.DisplayHash();
        }
        
        private static int[] RandomArray(int length, int maxNumber)
        {
            var array = new int[length];
            var rand = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, maxNumber + 1);
            }

            return array;
        }
    }
}