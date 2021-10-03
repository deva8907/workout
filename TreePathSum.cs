using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class TreePathSum
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return Traverse(root, 0, targetSum);
        }

        private bool Traverse(TreeNode node, int sumSoFar, int targetSum)
        {
            if (node == null)
            {
                return false;
            }
            if (sumSoFar + node.val == targetSum && node.left == null && node.right == null)
            {
                return true;
            }
            bool result = Traverse(node.left, sumSoFar + node.val, targetSum);
            if (!result)
            {
                result = Traverse(node.right, sumSoFar + node.val, targetSum);
            }
            return result;
        }
    }
}
