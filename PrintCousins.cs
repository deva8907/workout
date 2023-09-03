using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace workout
{
    //https://www.geeksforgeeks.org/print-cousins-of-a-given-node-in-binary-tree-single-traversal/
    public class PrintCousins
    {
        public IList<int> Print(TreeNode root, int targetValue)
        {
            var empty = new List<int>();
            if (root == null)
            {
                return empty;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool found = false;
            while (queue.Count > 0 && !found) 
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var item = queue.Dequeue();
                    if (item.left.val == targetValue ||
                        item.right.val == targetValue)
                    {
                        found = true;
                        continue;
                    }
                    if (item.left != null)
                    {
                        queue.Enqueue(item.left);
                    }
                    if (item.right != null)
                    {
                        queue.Enqueue(item.right);
                    }
                }
            }
            if (found)
            {
                return queue.Select(q => q.val).ToList();
            }
            return empty;
        }
    }
}
