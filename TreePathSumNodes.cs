using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workout
{
    public class TreePathSumNodes
    {
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }
            Stack<Tuple<TreeNode, List<int>>> treeNodes = new Stack<Tuple<TreeNode, List<int>>>();
            IList<IList<int>> output = new List<IList<int>>();
            treeNodes.Push(new Tuple<TreeNode, List<int>>(root, new List<int>() { root.val }));
            TreeNode topNode;
            IList<int> path;
            while (treeNodes.TryPop(out Tuple<TreeNode, List<int>> element))
            {
                topNode = element.Item1;
                path = element.Item2;
                if (topNode.left == null && topNode.right == null && path.Sum() == targetSum)
                {
                    output.Add(path);
                }
                if (topNode.left != null)
                {
                    var leftPath = new List<int>(path)
                    {
                        topNode.left.val
                    };
                    treeNodes.Push(new Tuple<TreeNode, List<int>>(topNode.left, leftPath));
                }
                if (topNode.right != null)
                {
                    var rightPath = new List<int>(path)
                    {
                        topNode.right.val
                    };
                    treeNodes.Push(new Tuple<TreeNode, List<int>>(topNode.right, rightPath));
                }
            }
            return output;
        }
        private static List<IList<int>> output;
        public IList<IList<int>> PathSumRecursive(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }
            output = new List<IList<int>>();
            Traverse(root, targetSum, new List<int> { root.val });
            return output;
        }
        private void Traverse(TreeNode node, int targetSum, List<int> path)
        {
            if (path.Sum() == targetSum && node.left == null && node.right == null)
            {
                output.Add(path);
            }
            if (node.left != null)
            {
                var leftPath = new List<int>(path);
                leftPath.Add(node.left.val);
                Traverse(node.left, targetSum, leftPath);
            }
            if (node.right != null)
            {
                var rightPath = new List<int>(path);
                rightPath.Add(node.right.val);
                Traverse(node.right, targetSum, rightPath);
            }
        }
    }
}
