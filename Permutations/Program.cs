using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(',').Select(it => int.Parse(it)).ToArray();

            var result = Permute(nums);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            foreach (var item in result)
            {
                foreach (var digit in item)
                    sb.Append(digit + " ");
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length == 1)
            {
                int[][] p = new int[1][];
                p[0] = new int[] { nums[0] };
                return p;
            }
            else if (nums.Length == 2)
            {
                int[][] p = new int[2][];
                p[0] = new int[] { nums[0], nums[1] };
                p[1] = new int[] { nums[1], nums[0] };

                return p;
            }
            else
            {
                List<List<int>> list = new List<List<int>>();
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        IList<IList<int>> permBefore = null;
                        if (j > 0)
                        {
                            int[] numsBefore = new int[j];
                            Array.Copy(nums, 0, numsBefore, 0, j);
                            permBefore = Permute(numsBefore);
                        }

                        IList<IList<int>> permAfter = null;
                        if (j < nums.Length - 1)
                        {
                            int[] numsAfter = new int[nums.Length - j - 1];
                            Array.Copy(nums, j + 1, numsAfter, 0, nums.Length - j - 1);
                            permAfter = Permute(numsAfter);
                        }
                        if (permBefore == null)
                        {
                            foreach (var permAfterItem in permAfter)
                            {
                                List<int> perm = new List<int>(nums.Length);
                                perm.Add(nums[i]);
                                perm.AddRange(permAfterItem);
                                list.Add(perm);
                            }
                        }
                        else
                        {
                            foreach (var permBeforeItem in permBefore)
                            {
                                if (permAfter == null)
                                {
                                    List<int> perm = new List<int>(nums.Length);
                                    perm.AddRange(permBeforeItem);
                                    perm.Add(nums[i]);
                                    list.Add(perm);
                                }
                                else
                                    foreach (var permAfterItem in permAfter)
                                    {
                                        List<int> perm = new List<int>(nums.Length);
                                        perm.AddRange(permBeforeItem);
                                        perm.Add(nums[i]);
                                        perm.AddRange(permAfterItem);
                                        list.Add(perm);
                                    }
                            }
                        }
                    }
                }
                return list.ToArray();
            }
        }
    }
}
