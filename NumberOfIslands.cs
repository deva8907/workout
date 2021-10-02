using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class NumberOfIslands
    {
        public static int NumIslands(char[][] grid)
        {
            int numberOfIslands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (IsIsland(grid, i, j))
                    {
                        numberOfIslands++;
                    }
                }
            }
            return numberOfIslands;
        }

        private static bool IsIsland(char[][] grid, int i, int j)
        {
            if (!(i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length) ||
                grid[i][j] == '0')
            {
                return false;
            }
            grid[i][j] = '0';
            IsIsland(grid, i - 1, j);
            IsIsland(grid, i, j + 1);
            IsIsland(grid, i + 1, j);
            IsIsland(grid, i, j - 1);
            return true;
        }
    }
}
