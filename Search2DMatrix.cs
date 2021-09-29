using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class Search2DMatrix
    {
        public static bool SearchMatrix2(int[][] matrix, int target)
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
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            if (target > matrix[rows - 1][cols - 1])
            {
                return false;
            }

            int rowMax = 0, colMax = 0;
            while (true)
            {
                if (matrix[rowMax][colMax] == target)
                {
                    return true;
                }

                rowMax = rowMax == rows - 1 ? rows - 1 : rowMax + 1;
                colMax = colMax == cols - 1 ? cols - 1 : colMax + 1;
                if (matrix[rowMax][colMax] == target)
                {
                    return true;
                }
                if (matrix[rowMax][colMax] > target)
                {
                    break;
                }

                if (rowMax == rows - 1 && colMax == cols - 1)
                {
                    break;
                }
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i >= rowMax && j >= colMax)
                    {
                        break;
                    }
                    if (matrix[i][j] == target)
                    {
                        return true;
                    } 
                }
            }
            return false;
        }
    }
}
