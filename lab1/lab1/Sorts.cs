using System;

namespace lab1
{
    public class Sorts
    {
        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
        
        // Quick Sort
        public static void QuickSort(ref int[] array)
        {
            QuickSort(ref array, 0, array.Length - 1);
        }
        
        private static void QuickSort(ref int[] array, int left, int right)
        {
            if (left < right)
            {
                var separator = FindSeparator(ref array, left, right);
                QuickSort(ref array, left, separator - 1);
                QuickSort(ref array, separator + 1, right);
            }
        }

        private static int FindSeparator(ref int[] array, int left, int right)
        {
            var pivot = left - 1;
            for (int i = left; i < right; i++)
            {
                if (array[i] < array[right])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[right]);
            return pivot;
        }

        public static void QuickSortCheck(int[] array)
        {
            int optimalK = 0;
            TimeSpan optimalTime = new TimeSpan();
            
            for (var k = array.Length; k > 0; k--)
            {
                var start = DateTime.Now;
                var arr = array;
                HybridQuickSort(ref arr, k);
                var end = DateTime.Now;
                
                // Console.WriteLine($"{k}: {end - start}");

                if (k == array.Length)
                {
                    optimalTime = end - start;
                }
                else
                {
                    if (end - start < optimalTime)
                    {
                        optimalTime = end - start;
                        optimalK = k;
                    }
                }
            }
            
            Console.WriteLine($"{optimalK}: {optimalTime}");
        }
        
        // Insertion Sort
        public static void InsertionSort(ref int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while (j > 0 && array[j - 1] > key)
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = key;
            }
        }
        
        public static void InsertionSortOperationsCount(ref int[] array)
        {
            var k = 0;
            
            for (int i = 1; i < array.Length; i++, k++)
            {
                var key = array[i];
                k++;
                var j = i;
                k++;
                while (j > 0 && array[j - 1] > key)
                {
                    k += 2;
                    array[j] = array[j - 1];
                    k++;
                    j--;
                    k++;
                }

                array[j] = key;
                k++;
            }

            Console.WriteLine($"Operations number: {k}");
        }
        
        // Merge Sort
        public static void MergeSort(ref int[] array)
        {
            MergeSort(ref array, 0, array.Length - 1);
        }

        private static void MergeSort(ref int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(ref array, lowIndex, middleIndex);
                MergeSort(ref array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
        }
        
        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while (left <= middleIndex && right <= highIndex)
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        
        public static void MergeSortCheck(int[] array)
        {
            int optimalK = 0;
            TimeSpan optimalTime = new TimeSpan();
            
            for (var k = array.Length; k > 0; k--)
            {
                var start = DateTime.Now;
                var arr = array;
                
                HybridMergeSort(ref arr, k);
                var end = DateTime.Now;
                
                if (k == array.Length)
                {
                    optimalTime = end - start;
                }
                else
                {
                    if (end - start < optimalTime)
                    {
                        optimalTime = end - start;
                        optimalK = k;
                    }
                }
            }
            
            Console.WriteLine($"{optimalK}: {optimalTime}");
        }
        
        // Hybrid Quick Sort
        public static void HybridQuickSort(ref int[] array, int k)
        {
            HybridQuickSort(ref array, 0, array.Length - 1, k);
        }
        
        private static void HybridQuickSort(ref int[] array, int left, int right, int k)
        {
            if (left < right)
            {
                var separator = FindSeparator(ref array, left, right);

                if (separator - left >= k)
                {
                    QuickSort(ref array, left, separator - 1);
                }
                else
                {
                    InsertionSort(ref array);
                }
                
                if (right - separator >= k)
                {
                    QuickSort(ref array, separator + 1, right);
                }
                else
                {
                    InsertionSort(ref array);
                }
            }
        }
        
        // Hybrid Merge Sort
        public static void HybridMergeSort(ref int[] array, int k)
        {
            HybridMergeSort(ref array, 0, array.Length - 1, k);
        }

        private static void HybridMergeSort(ref int[] array, int lowIndex, int highIndex, int k)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                
                if (middleIndex - lowIndex + 1 >= k)
                {
                    MergeSort(ref array, lowIndex, middleIndex);
                }
                else
                {
                    InsertionSort(ref array); 
                }
                
                if (highIndex - middleIndex >= k)
                {
                    MergeSort(ref array, middleIndex + 1, highIndex);
                }
                else
                {
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }
        }
    }
}