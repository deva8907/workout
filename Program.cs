using System;
using System.Collections;
using System.Collections.Generic;

namespace workout
{
    class Program
    {
        static void Main(string[] args)
        {
            //spiral(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } });
            //spiral(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 }, new int[] { 13, 14, 15, 16 } });
            SpiralOne.(new int[][] {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 6, 7, 8, 9, 10 },
                new int[] { 11, 12, 13, 14, 15 },
                new int[] { 16, 17, 18, 19, 20 },
                new int[] { 21, 22, 23, 24, 25 }
            });
            //spiral(new int[][] { new int[] { 1, 2, 3, 4 }});
            //spiral(new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { 3 }, new int[] { 4 } });
            //Console.WriteLine(maxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
       
    }
}
