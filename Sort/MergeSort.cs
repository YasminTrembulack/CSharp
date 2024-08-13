namespace BigIntImplement
{
    public enum SortType
    {
        ASC,
        DESC
    }

    public static class MergeSort
    {
        public static T[] Sort<T>(T[] array, SortType type = SortType.ASC)
            where T : IComparable
        {
            int length = array.Length;

            int startIndex = 0;
            int middleIndex = length / 2 - 1;
            int endIndex = length - 1;

            var leftSlice = array[startIndex..middleIndex];
            var rightSlice = array[(middleIndex + 1)..endIndex];

            if (leftSlice.Length <= 3)
                leftSlice = Order(leftSlice, type);
            else
                leftSlice = Sort(leftSlice, type);

            if (rightSlice.Length <= 3)
                rightSlice = Order(rightSlice, type);
            else
                rightSlice = Sort(rightSlice, type);
            
            return Order([..leftSlice, ..rightSlice], type);
        }

        private static T[] Order<T>(T[] array, SortType type)
            where T : IComparable
        {
            int elements = array.Length;

            int leftIndex = 0;
            int rightIndex = elements / 2;

            T[] helper = new T[elements];

            for (int i = 0; i < elements; i++)
            {
                if (rightIndex > elements - 1)
                {
                    helper[i] = array[leftIndex];
                    leftIndex++;
                    continue;
                }

                if (leftIndex == elements / 2)
                {
                    helper[i] = array[rightIndex];
                    rightIndex++;
                    continue;
                }

                if (Compare(array[leftIndex], array[rightIndex], type))
                {
                    helper[i] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    helper[i] = array[rightIndex];
                    rightIndex++;
                }
            }

            return helper;
        }

        private static bool Compare<T>(T a, T b, SortType type)
            where T : IComparable
        {
            return type == SortType.ASC
                ? a.CompareTo(b) <= 0
                : a.CompareTo(b) >= 0;
        }
    }
}
