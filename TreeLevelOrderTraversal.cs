using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace workout
{
    //https://leetcode.com/problems/binary-tree-level-order-traversal/description/
    public class TreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var output = new List<IList<int>>();
            if (root == null)
            {
                return output;
            }
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            treeNodes.Enqueue(root);
            while (treeNodes.Count > 0)
            {
                int qSize = treeNodes.Count;
                var rowWiseList = new List<int>();
                for (int i = 0; i < qSize; i++)
                {
                    var result = treeNodes.Dequeue();
                    rowWiseList.Add(result.val);
                    if (result.left != null)
                    {
                        treeNodes.Enqueue(result.left);
                    }
                    if (result.right != null)
                    {
                        treeNodes.Enqueue(result.right);
                    }
                }
                output.Add(rowWiseList);
            }
            return output;
        }
    }
}
