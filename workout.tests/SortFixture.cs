using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace workout.tests
{
    public class SortFixture
    {
        [Theory]
        [ClassData(typeof(MergeArrayTestData))]
        public void TestMergeNArrays(string[] input)
        {
            MergeSortedArray.Solve(input);
        }
    }

    public class MergeArrayTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {
                    new string[]
                    {
                        "3 4",
                    "4 5 7 8",
                    "15 32 65 87",
                    "1 2 78 91"
                    }
                };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
