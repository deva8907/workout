using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class MergeSortedList
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            return MergeList(lists, 0, lists.Length - 1);
        }

        private ListNode MergeList(ListNode[] lists, int start, int end)
        {
            if (end == start)
            {
                return lists[start];
            }
            int middle = ((end - start) / 2) + start;
            var leftList = MergeList(lists, start, middle);
            var rightList = MergeList(lists, middle + 1, end);
            return Merge(leftList, rightList);
        }

        private ListNode Merge(ListNode leftList, ListNode rightList)
        {
            if (leftList == null && rightList == null)
            {
                return null;
            }
            ListNode left = leftList, right = rightList, result = new ListNode();
            ListNode first = result;
            while (true)
            {
                if (left != null && right != null)
                {
                    if (left.val <= right.val)
                    {
                        result.val = left.val;
                        left = left.next;
                    }
                    else
                    {
                        result.val = right.val;
                        right = right.next;
                    }
                }
                else if (left == null && right != null)
                {
                    result.val = right.val;
                    right = right.next;
                }
                else if (right == null && left != null)
                {
                    result.val = left.val;
                    left = left.next;
                }
                if (left == null && right == null)
                {
                    break;
                }
                else
                {
                    result.next = new ListNode();
                    result = result.next;
                }
            }
            return first;
        }
    }
}