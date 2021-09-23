using System;
using System.Collections.Generic;

namespace Amazon_Number_Game
{
    class Program
    {
        static Dictionary<int, int> memo;

        static void Main(string[] args)
        {
            int[] arr = new int[] { 2,3, 4, 6 };
            //MaxScore(arr);
            Console.WriteLine(MaxScore(arr));
        }

       
        static int MaxScore(int[] nums)
        {

            memo = new Dictionary<int, int>();
            return dfs(nums, 1, 0);
        }

        static int dfs(int[] nums, int start, int mask)
        {
            if (start > nums.Length / 2)
                return 0;

            if (memo.ContainsKey(mask))
                return memo[mask];

            int n = nums.Length;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                    continue;
                for (int j = i + 1; j < n; j++)
                {
                    if ((mask & (1 << j)) != 0)
                        continue;
                    int nextmask = mask; //can't modify existing mask, as we need to store in memo
                    nextmask = nextmask | (1 << i);
                    nextmask = nextmask | (1 << j);

                    max = Math.Max(max, start * GCD(nums[i], nums[j]) + dfs(nums, start + 1, nextmask));
                }
            }
            memo[mask] = max;
            return max;
        }

        static int GCD(int a, int b) // Euclidean algorithm
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
