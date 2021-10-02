using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class MaxAreaIsland
    {
        public static int MaxAreaOfIslandRecursive(int[][] grid)
        {
            if (grid == null)
            {
                return 0;
            }
            int maxCluster = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        maxCluster = Math.Max(DfsRecursive(grid, i, j), maxCluster);
                    } 
                }
            }
            return maxCluster;
        }

        private static int DfsRecursive(int[][] grid, int i, int j)
        {
            if (!(i >= 0 && i < grid.Length && j >=0 && j < grid[i].Length) || 
                grid[i][j] == 0)
            {
                return 0;
            }
            grid[i][j] = 0;
            int result = 1;
            return result + DFSAlt(grid, i - 1, j) +//top
            DFSAlt(grid, i, j + 1) +//right
            DFSAlt(grid, i + 1, j) +//bottom
            DFSAlt(grid, i, j - 1);//left
        }
    }
}
