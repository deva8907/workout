using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace workout.tests
{
    public class WorkoutTests
    {
        [Theory]
        [InlineData(new int[] { 2, 3, 1, 1, 4 }, true)]
        [InlineData(new int[] { 3, 2, 1, 0, 4 }, false)]
        [InlineData(new int[] { 0, 2, 3 }, false)]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 1 }, true)]
        [InlineData(new int[] { 0, 1 }, false)]
        [InlineData(new int[] { 3, 0, 8, 2, 0, 0, 1 }, true)]
        public void JumpGameWorks(int[] nums, bool expected)
        {
            bool result = JumpGame.CanJump(nums);
            Assert.Equal(result, expected);
        }
        [Theory]
        [InlineData(new int[] { 2, 3, 1, 1, 4 }, 2)]
        [InlineData(new int[] { 2, 3, 0, 1, 4 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 1, 1 }, 3)]
        [InlineData(new int[] { 1, 2, 2, 1, 1 }, 3)]
        [InlineData(new int[] { 2, 3, 1 }, 1)]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, 4)]
        [InlineData(new int[] { 2, 1, 1, 1, 1 }, 3)]
        [InlineData(new int[] { 7, 0, 9, 6, 9, 6, 1, 7, 9, 0, 1, 2, 9, 0, 3 }, 2)]
        [InlineData(new int[] { 2, 0, 2, 4, 6, 0, 0, 3 }, 3)]
        [InlineData(new int[] { 9, 7, 9, 4, 8, 1, 6, 1, 5, 6, 2, 1, 7, 9, 0 }, 2)]
        public void MinJumps(int[] nums, int expected)
        {
            Assert.Equal(expected, JumpGame.MinJumpAlt(nums));
        }

        [Theory]
        [InlineData("00:00", "00:00")]
        [InlineData("?0:49", "20:49")]
        [InlineData("0?:49", "09:49")]
        [InlineData("09:?9", "09:59")]
        [InlineData("09:5?", "09:59")]
        [InlineData("1?:1?", "19:19")]
        [InlineData("??:??", "23:59")]
        [InlineData("12:??", "12:59")]
        [InlineData("??:30", "23:30")]
        [InlineData("?4:?0", "14:50")]
        public void RecentTime(string time, string expected)
        {
            var actual = ReplaceLatestTime.MaximumTime2(time);
            Assert.Equal(actual, expected);
        }   
    }
}
