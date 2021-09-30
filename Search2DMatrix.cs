using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class Search2DMatrix
    {
        public static bool SearchMatrixTopDown(int[][] matrix, int target)
        {
            int i = 0;
            int j = matrix[i].Length - 1;
            int n = matrix.Length;
            while (i < n && j >= 0)
            {
                if (matrix[i][j] == target)
                    return true;
                else if (target < matrix[i][j])
                    j--;
                else
                    i++;
            }
            return false;
        }

        public static bool SearchMatrixBottomUp(int[][] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }
            int i = matrix.Length - 1, j = 0;
            while (i >= 0 && j < matrix[0].Length)
            {
                if (matrix[i][j] == target)
                {
                    return true;
                }
                if (matrix[i][j] > target)
                {
                    i--;
                }
                else if (matrix[i][j] < target)
                {
                    j++;
                }
            }
            return false;
        }
    }
}
