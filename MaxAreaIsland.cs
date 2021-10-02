using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class MaxAreaIsland
    {
        public static int MaxAreaOfIsland(int[][] grid)
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
                    maxCluster = Math.Max(DfsIterative(grid, i, j), maxCluster);
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
            return result + DfsRecursive(grid, i - 1, j) +//top
            DfsRecursive(grid, i, j + 1) +//right
            DfsRecursive(grid, i + 1, j) +//bottom
            DfsRecursive(grid, i, j - 1);//left
        }

        private static int DfsIterative(int[][] grid, int i, int j)
        {
            if (grid[i][j] == 0)
            {
                return 0;
            }
            int result = 0;
            Stack<Tuple<int, int>> elementStack = new Stack<Tuple<int, int>>();
            elementStack.Push(new Tuple<int, int>(i, j));
            while (elementStack.TryPop(out Tuple<int, int> popElement))
            {
                i = popElement.Item1;
                j = popElement.Item2;
                if ((i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length) &&
                    grid[i][j] == 1)
                {
                    result += 1;
                    grid[i][j] = 0;
                    elementStack.Push(new Tuple<int, int>(i - 1, j));//top
                    elementStack.Push(new Tuple<int, int>(i, j + 1));//right
                    elementStack.Push(new Tuple<int, int>(i + 1, j));//bottom
                    elementStack.Push(new Tuple<int, int>(i, j - 1));//left
                }
            }
            return result;
        }
    }
}
