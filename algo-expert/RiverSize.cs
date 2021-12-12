using System;
using System.Collections.Generic;
using System.Text;

namespace workout.algo_expert
{
    public class RiverSize
    {
        public static List<int> Solve(int[,] matrix)
        {
            if (matrix == null)
            {
                return new List<int>();
            }
            var result = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        result.Add(Traverse(matrix, i, j));
                    }
                }
            }
            return result;
        }

        private static int Traverse(int[,] matrix, int i, int j)
        {
            if (i < 0 || j < 0 || i == matrix.GetLength(0) || j == matrix.GetLength(1) || matrix[i, j] == 0)
            {
                return 0;
            }
            int size = 1;
            matrix[i, j] = 0;
            size += Traverse(matrix, i - 1, j);
            size += Traverse(matrix, i, j - 1);
            size += Traverse(matrix, i + 1, j);
            size += Traverse(matrix, i, j + 1);
            return size;
        }
    }
}
