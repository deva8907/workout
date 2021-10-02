using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace workout.tests
{
    public class IslandTestFixture
    {
        [Theory]
        [ClassData(typeof(IslandTestData))]
        public void IslandTest(int[][] grid, int expected)
        {
            var actual = MaxAreaIsland.MaxAreaOfIsland(grid);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [ClassData(typeof(IslandCountTestData))]
        public void TestNumberOfIslands(char[][] grid, int expected)
        {
            Assert.Equal(expected, NumberOfIslands.NumIslands(grid));
        }
    }

    public class IslandCountTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {
                    new char[][]
                    {
                        new char[]{'1','1','1','1','0'},
                        new char[]{'1', '1', '0', '1', '0'},
                        new char[]{'1','1','0','0','0'},
                        new char[]{'0','0','0','0','0'}
                    }, 1
                };
            yield return new object[]
                {
                    new char[][]
                    {
                        new char[]{'1', '1', '0', '0', '0'},
                        new char[]{'1', '1', '0', '0', '0'},
                        new char[]{'0', '0', '1', '0', '0'},
                        new char[]{'0', '0', '0', '1', '1'}
                    }, 3
                };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class IslandTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {
                    new int[][]
                    {
                        new int[]{1, 1, 0, 1, 1},
                        new int[]{1, 0, 0, 0, 0},
                        new int[]{0, 0, 0, 0, 1},
                        new int[]{1, 1, 0, 1, 1}
                    },3
                };
            yield return new object[]
                {
                    new int[][]{new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
                                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                                new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
                                new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
                                new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
                                new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
                                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                                new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
                }, 6
                };
            yield return new object[]
                {
                    new int[][]
                    {
                        new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 }
                    }, 0
                };
            yield return new object[]
                {
                    new int[][]
                    {
                        new int[]{ 1, 1, 0, 1}
                    }, 2
                };
            yield return new object[]
                {
                    new int[][]
                    {
                        new int[]{ 1},
                        new int[]{ 1},
                        new int[]{ 1},
                        new int[]{ 1},
                    }, 4
                };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
