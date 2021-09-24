
using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    class SpiralOne
    {
        public static IList<int> Solve(int[][] matrix)
        {
            List<int> result = new List<int>();
            int iteration = 1;
            int traversal, nthTraversal;
            while (true)
            {
                traversal = iteration % 4;
                nthTraversal = iteration / 4;
                if (traversal == 1 && nthTraversal < matrix[0].Length)
                {
                    int i = nthTraversal, j = nthTraversal;
                    for (; j <= matrix[0].Length - (traversal + nthTraversal); j++)
                    {
                        result.Add(matrix[i][j]);
                    }
                }
                else if (traversal == 2 && nthTraversal < matrix.Length)
                {
                    int i = 0, j = matrix[0].Length - 1 - nthTraversal;
                    for (i = nthTraversal + 1; i <= matrix.Length - 1 - nthTraversal; i++)
                    {
                        result.Add(matrix[i][j]);
                    }
                }
                else if (traversal == 3 && nthTraversal < matrix[0].Length)
                {
                    int i = matrix.Length - 1 - nthTraversal, j;
                    j = matrix[0].Length - 2 - nthTraversal;

                    for (; j >= nthTraversal; j--)
                    {
                        result.Add(matrix[i][j]);
                    }
                }
                else if (traversal == 0 && nthTraversal < matrix[0].Length)
                {
                    int i = matrix.Length - nthTraversal - 1; ;
                    int j = nthTraversal - 1;
                    for (; i >= nthTraversal; i--)
                    {
                        result.Add(matrix[i][j]);
                    }
                }
                if (result.Count == matrix.Length * matrix[0].Length)
                {
                    break;
                }
                iteration++;
            }
            return result;
        }
    }
}
