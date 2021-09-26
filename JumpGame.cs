using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class JumpGame
    {
        public static bool CanJump(int[] nums)
        {
            int length = nums.Length - 1;
            int furthest = 0;
            if (nums.Length == 1)
            {
                return true;
            }
            for (int i = 0; i < length; i++)
            {
                if (nums[i] == 0 && i == furthest)
                {
                    return false;
                }
                furthest = Math.Max(nums[i] + i, furthest);
                if (nums[i] + i >= length)
                {
                    return true;
                }
            }
            return false;
        }
        public static int MinJumpAlt(int[] nums)
        {
            int x = 0, y = 0;
            int ans = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                y = Math.Max(y, i + nums[i]);
                if (x == i)
                {
                    ans++;
                    x = y;
                }
            }
            return ans;
        }
    }
}
