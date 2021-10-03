using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace workout.tests
{
    public class TreeTestFixture
    {
        [Theory]
        [ClassData(typeof(TreePathTestData))]
        public void TreePathSumWorks(TreeNode root, int targetSum, bool expected)
        {
            Assert.Equal(expected, new TreePathSum().HasPathSum(root, targetSum));
        }
    }

    public class TreePathTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            TreeNode root = new TreeNode(-2, null, new TreeNode(-3));
            yield return new object[]
                {
                    root, -5, true
                };
            //root = new TreeNode(1, new TreeNode(2));
            //yield return new object[]
            //    {
            //        root, 1, false
            //    };
            
        }

        private TreeNode ConstructTree(TreeNode node, int?[] input, int i)
        {
            if (i < input.Length && input[i].HasValue)
            {
                node.val = input[i].Value;
                node.left = ConstructTree(new TreeNode(), input, 2 * i + 1);
                node.right = ConstructTree(new TreeNode(), input, 2 * i + 2);
                return node;
            }
            return null;
        }

        public TreeNode insertLevelOrder(TreeNode root, int?[] input, int i)
        {
            // Base case for recursion
            if (i < input.Length && input[i].HasValue)
            {
                TreeNode temp = new TreeNode(input[i].Value);
                root = temp;

                // insert left child
                root.left = insertLevelOrder(
                                root.left, input, 2 * i + 1);

                // insert right child
                root.right = insertLevelOrder(
                                root.right, input, 2 * i + 2);
            }
            return root;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
