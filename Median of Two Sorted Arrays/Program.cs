using System;
using System.Linq;

namespace Median_of_Two_Sorted_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var nums1 = Console.ReadLine().Split(",").Select(v => int.Parse(v)).ToArray();
            //var nums2 = Console.ReadLine().Split(",").Select(v => int.Parse(v)).ToArray();

            var nums1 = new int[] { 1,2 };
            var nums2 = new int[] { 3,4 };
            Console.WriteLine(string.Concat(nums1.Select(v => v.ToString() + " ")));
            Console.WriteLine(string.Concat(nums2.Select(v => v.ToString() + " ")));

            var result = FindMedianSortedArrays2(nums1, nums2);
            Console.WriteLine(result.ToString());
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var unionNums = nums1.Concat(nums2).OrderBy(v => v).ToArray();
            int medianIndex = unionNums.Length / 2 - 1;

            if (IsEven(unionNums.Length))
                return (unionNums[medianIndex] + unionNums[medianIndex + 1]) / 2d;
            else
                return unionNums[medianIndex + 1];
        }
        public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int length = nums1.Length + nums2.Length;
            int nums1Index, nums2Index;
            int medianIndex = length / 2;
            int[] unionNums = new int[medianIndex+1];

            if (nums1.Length > 0 & nums2.Length > 0)
            {
                if (nums1[0] < nums2[0])
                {
                    unionNums[0] = nums1[0];
                    nums1Index = 1;
                    nums2Index = 0;
                }
                else
                {
                    unionNums[0] = nums2[0];
                    nums1Index = 0;
                    nums2Index = 1;
                }
            }
            else if (nums1.Length > 0)
            {
                unionNums[0] = nums1[0];
                nums1Index = 1;
                nums2Index = 0;
            }
            else
            {
                unionNums[0] = nums2[0];
                nums1Index = 0;
                nums2Index = 1;
            }

            int index = 1;
            while (index <= medianIndex)
            {
                if (nums1Index < nums1.Length & nums2Index < nums2.Length)
                {
                    if (nums1[nums1Index] < nums2[nums2Index])
                    {
                        unionNums[index] = nums1[nums1Index];
                        nums1Index++;
                    }
                    else
                    {
                        unionNums[index] = nums2[nums2Index];
                        nums2Index++;
                    }
                }
                else if (nums1Index < nums1.Length)
                {
                    unionNums[index] = nums1[nums1Index];
                    nums1Index++;
                }
                else
                {
                    unionNums[index] = nums2[nums2Index];
                    nums2Index++;
                }
                index++;
            }

            if (IsEven(length))
                return (unionNums[medianIndex - 1] + unionNums[medianIndex]) / 2d;
            else
                return unionNums[medianIndex];
        }
        public static bool IsEven(int num)
        {
            return num % 2 ==0;
        }
    }
}
