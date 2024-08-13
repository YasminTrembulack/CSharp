namespace BigIntImplementY
{

    public class MergeSortY
    {

        // List<BigInt> getRandom(List<BigInt> array)
        // {

        // }

        
        public static BigInt[] Sort(BigInt[] array)
        {
            int length = array.Length;

            int startIndex = 0;
            int middleIndex = length / 2 ;
            int endIndex = length;

            var leftSide = array[startIndex..middleIndex];
            var rightSide = array[middleIndex..endIndex];
            
            leftSide = Order(leftSide);
            rightSide = Order(rightSide);

            if(leftSide.Length > 3)
            {
                leftSide = Sort(leftSide);
            }

            if(rightSide.Length > 3)
            {
                rightSide = Sort(rightSide);
            }
            

            return Order([..leftSide, ..rightSide]);
        }

        public static BigInt[] Order(BigInt[] array)
        {
            int elements = array.Length;

            int leftIndex = 0;
            int rightIndex = elements / 2;

            BigInt[] helper = new BigInt[elements];

            for (int i = 0; i < elements; i++)
            {
                if(rightIndex > elements - 1)
                {
                    helper[i] = array[leftIndex];
                    leftIndex++;
                    continue;
                }
                if(leftIndex == elements / 2)
                {
                    helper[i] = array[rightIndex];
                    rightIndex++;
                    continue;
                }

                if(array[leftIndex] < array[rightIndex])
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
    }
}