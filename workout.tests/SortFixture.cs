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
        [Theory]
        [ClassData(typeof(MergeSortedListTestData))]
        public void TestMergeLists(ListNode[] listNodes)
        {
            new MergeSortedList().MergeKLists(listNodes);
        }
    }

    internal class MergeSortedListTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            int[][] input = new int[][]
            {
                new int[] { 1, 4, 5 },
                new int[] { 1, 3, 4},
                new int[]{ 2, 6}
            };
            ListNode[] listNode;
            //listNode = ToListNode(input);
            //yield return new object[] { listNode };
            
            yield return new object[] { new ListNode[] { null, null } };
        }

        private ListNode[] ToListNode(int[][] input)
        {
            ListNode[] nodeArray = new ListNode[input[0].Length];
            ListNode listNode;
            ListNode first;
            for (int j = 0; j < input.Length; j++)
            {
                listNode = new ListNode();
                first = listNode;
                var array = input[j];
                for (int i = 0; i < array.Length; i++)
                {
                    listNode.val = array[i];
                    if (i != array.Length - 1)
                    {
                        listNode.next = new ListNode();
                        listNode = listNode.next;
                    }
                }
                nodeArray[j] = first;
            }
            return nodeArray;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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
