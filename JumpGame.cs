using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class JumpGame
    {
        public static bool CanJump(int[] nums)
        {
            int length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j <= nums[i] && j < length; j++)
                {
                    if ((nums[j] + j) >= length - 1)
                    {
                        if ((i == length - 1) && (j == length - 1))
                        {
                            if ((nums[j] + j == length))
                            {
                                return true;
                            }
                            return false;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
