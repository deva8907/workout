using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    class Kadane
    {
        public static int Solve(int[] nums)
        {
            int actualSum = 0, maxSum = Int32.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                actualSum += nums[i];
                if (actualSum > maxSum)
                {
                    maxSum = actualSum;
                }
                if (actualSum < 0)
                {
                    actualSum = 0;
                }
            }
            return maxSum;
        }
    }
}
