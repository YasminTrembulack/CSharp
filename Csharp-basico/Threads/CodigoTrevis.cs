// using System;
// using System.Threading.Tasks;
// using System.Collections.Generic;

// serialTest();
// parallelTest();
// var list = await GetSortedListAsync();

// async Task<BigInt[]> GetSortedListAsync()
// {
//     return await Task<BigInt[]>.Factory.StartNew(() => 
//     {
//         var array = getRandom(1024 * 1024).ToArray();
//         parallelMergesort(array);
//         return array;
//     });
// }

// void parallelTest()
// {
//     double total = 0;
//     for (int i = 0; i < 10; i++)
//     {
//         Console.WriteLine($"Test {i + 1}...");
//         var array = getRandom(1024 * 1024).ToArray();
//         DateTime start = DateTime.Now;
//         parallelMergesort(array);
//         var timePassed = DateTime.Now - start;
//         total += timePassed.TotalSeconds;
//     }
//     Console.WriteLine(total / 10);
// }

// void serialTest()
// {
//     double total = 0;
//     for (int i = 0; i < 10; i++)
//     {
//         Console.WriteLine($"Test {i + 1}...");
//         var array = getRandom(1024 * 1024).ToArray();
//         DateTime start = DateTime.Now;
//         mergesort(array, 0, 1024 * 1024);
//         DateTime end = DateTime.Now;
//         var timePassed = end - start;
//         total += timePassed.TotalSeconds;
//     }
//     Console.WriteLine(total / 10);
// }

// void verify(BigInt[] array)
// {
//     for (int j = 0; j < array.Length - 1; j++)
//         if (array[j] > array[j + 1])
//         {
//             Console.WriteLine("wrong!");
//             break;
//         }
// }

// void parallelMergesort(BigInt[] array)
// {
//     if (array.Length < 32)
//     {
//         bublesort(array, 0, array.Length);
//         return;
//     }

//     if (array.Length < 1024)
//     {
//         mergesort(array, 0, array.Length);
//         return;
//     }

//     var blockSize = array.Length / 4;
//     Parallel.For(0, 4, i =>
//         mergesort(array, i * blockSize, (i + 1) * blockSize)
//     );
//     merge(array, 0, blockSize, 2 * blockSize);
//     merge(array, 2 * blockSize, 3 * blockSize, 4 * blockSize);
//     merge(array, 0, 2 * blockSize, 4 * blockSize);
// }

// void mergesort(BigInt[] array, int i, int k)
// {
//     if (k - i < 32)
//     {
//         bublesort(array, i, k);
//         return;
//     }
//     int j = i + (k - i) / 2;
//     mergesort(array, i, j);
//     mergesort(array, j, k);
//     merge(array, i, j, k);
// }

// void bublesort(BigInt[] array, int i, int j)
// {
//     bool sorted = false;
//     while (!sorted)
//     {
//         sorted = true;
//         for (int k = i; k < j - 1; k++)
//         {
//             if (array[k] > array[k + 1])
//                 continue;
            
//             sorted = false;
//             (array[k + 1], array[k]) = (array[k], array[k + 1]);
//         }
//     }
// }

// void merge(BigInt[] array, int i, int j, int k)
// {
//     BigInt[] merged = new BigInt[k - i];

//     int d = 0;
//     int n = i;
//     int m = j;
//     while (n < j && m < k)
//         merged[d++] = array[n] < array[m] ? array[n++] : array[m++];

//     while (n < j)
//         merged[d++] = array[n++];

//     while (m < k)
//         merged[d++] = array[m++];

//     Array.Copy(merged, 0, array, i, merged.Length);
// }

// List<BigInt> getRandom(int size)
// {
//     List<BigInt> list = [];
//     var random = new Random();
//     for (int i = 0; i < size; i++)
//     {
//         var nums = new byte[1024];
//         random.NextBytes(nums);
//         list.Add(new(nums));
//     }
//     return list;
// }

// public class BigInt(byte[] array)
// {
//     List<byte> nums = [ ..array ];
//     public static BigInt operator +(BigInt a, BigInt b)
//     {
//         var (shorter, longer) = 
//             a.nums.Count < b.nums.Count ? 
//             (a.nums, b.nums) : 
//             (b.nums, a.nums);
//         var min = shorter.Count;
//         var len = longer.Count;

//         var result = new byte[len + 1];
//         for (int i = 0; i < min; i++)
//         {
//             var sum = shorter[i] + longer[i] + result[i];
//             int carry = sum / 256;
//             int mod = sum % 256;
//             result[i] = (byte)mod;
//             result[i + 1] = (byte)carry;
//         }
        
//         for (int i = min; i < len; i++)
//         {
//             var res = longer[i] + result[i];
//             int carry = res / 256;
//             int mod = res % 256;
//             result[i] = (byte)mod;
//             result[i + 1] = (byte)carry;
//         }

//         return new(result);
//     }

//     public static bool operator >(BigInt a, BigInt b)
//     {
//         var (shorter, longer) = 
//             a.nums.Count < b.nums.Count ? 
//             (a.nums, b.nums) : 
//             (b.nums, a.nums);
//         var min = shorter.Count;
//         var len = longer.Count;

//         for (int i = min; i < len; i++)
//         {
//             if (longer[i] != 0)
//                 return a.nums == longer;
//         }

//         for (int i = min - 1; i > -1; i--)
//         {
//             if (longer[i] > shorter[i])
//                 return a.nums == longer;
                
//             if (longer[i] < shorter[i])
//                 return a.nums == shorter;
//         }

//         return false;
//     }

//     public static bool operator <(BigInt a, BigInt b)
//         => b > a;

//     public static bool operator <=(BigInt a, BigInt b)
//         => a < b || a == b;

//     public static bool operator >=(BigInt a, BigInt b)
//         => a > b || a == b;

//     public static bool operator ==(BigInt a, BigInt b)
//         => !(a > b) && !(b > a);

//     public static bool operator !=(BigInt a, BigInt b)
//         => !(a == b);
// }
