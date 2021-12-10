namespace lab2
{
    public class Search
    {
        // Binary search
        public static int BinarySearch(int[] array, int searchedValue)
        {
            return BinarySearch(array, searchedValue, 0, array.Length - 1);
        }
        
        public static int BinarySearch(int[] array, int searchedValue, int left, int right)
        {
            if (left > right) return -1;
            
            var middle = (left + right) / 2;
            var middleValue = array[middle];

            if (middleValue == searchedValue) return middle;
            if (middleValue > searchedValue) return BinarySearch(array, searchedValue, left, middle - 1);
            return BinarySearch(array, searchedValue, middle + 1, right);
        }
        
        // Interpolation search
        public static int InterpolationSearch(int[] array, int searchedValue)
        {
            return InterpolationSearch(array, searchedValue, 0, array.Length - 1);
        }
        
        public static int InterpolationSearch(int[] array, int searchedValue, int left, int right)
        {
            if (left > right) return -1;
            
            var middle = left + (searchedValue - array[left]) / (array[right] - array[left]) * (right - left);
            var middleValue = array[middle];

            if (middleValue == searchedValue) return middle;
            if (middleValue > searchedValue) return BinarySearch(array, searchedValue, left, middle - 1);
            return BinarySearch(array, searchedValue, middle + 1, right);
        }
    }
}