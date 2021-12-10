namespace lab2
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
    }
}