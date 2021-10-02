using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace workout.tests
{
    public class MatrixFixture
    {
        //240. Search a 2D Matrix II
        [Theory]
        [ClassData(typeof(MatrixTestData))]
        public void MatrixSearch(int[][] matrix, int target, bool expected)
        {
            var actual = Search2DMatrix.SearchMatrixBottomUp(matrix, target);
            Assert.Equal(expected, actual);
        }
        public class MatrixTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
        {
                    new int[][]
                    {
                        new int[]{ -1},
                        new int[]{ 3}
                    },
                    3, true
        };
                yield return new object[]
                    {
                    new int[][]
                    {
                        new int[]{ -1,3}
                    },
                    3, true
                    };
                yield return new object[]
                    {
                    new int[][]
                    {
                        new int[] {3,3,8,13,13,18 },
                        new int[] {4, 5, 11, 13, 18, 20 },
                        new int[] {9,9,14,15,23,23 },
                        new int[] {13,18,22,22,25,27 },
                        new int[] {18,22,23,28,30,33 },
                        new int[] {21,25,28,30,35,35 },
                        new int[] {24,25,33,36,37,40 },
                    },
                    21, true
                    };
                yield return new object[]
                    {
                    new int[][]
                    {
                        new int[] {1,2,3,4,5 },
                        new int[] {6, 7, 8, 9, 10 },
                        new int[] {11,12,13,14,15 },
                        new int[] {16,17,18,19,20 },
                        new int[] {21,22,23,24,25 }
                    },
                    15, true
                    };
                yield return new object[]
                {

                    new int[][]
                    {
                        new int[] { 1, 4, 7, 11, 15 },
                        new int[] { 2, 5, 8, 12, 19 },
                        new int[] { 3, 6, 9, 16, 22 },
                        new int[] { 10, 13, 14, 17, 24 },
                        new int[] { 18, 21, 23, 26, 30 }
                    },
                    16, true

                };
                yield return new object[]
                    {
                    new int[][]
                    {
                        new int[]{ 1, 2, 3, 4},
                        new int[]{ 2, 3, 4, 5}
                    },
                    4, true
                    };
                yield return new object[]
                    {
                    new int[][]
                    {
                        new int[]{ 1, 2},
                        new int[]{ 2, 3},
                        new int[]{ 4, 5}
                    },
                    2, true

                    };
            }



            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
