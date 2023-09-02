using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using workout.algo_expert;
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
        [Theory]
        [ClassData(typeof(TreePathSumNodesTestData))]
        public void TreePathNodeWorks(TreeNode root, int targetSum, List<List<int>> expected)
        {
            new TreePathSumNodes().PathSumRecursive(root, targetSum);
        }
        [Theory]
        [MemberData(nameof(InvertBinaryTreeTestData))]
        public void InvertingBSTWorks(BinaryTree tree)
        {
            InvertBinaryTree.Solve(tree);
            InvertBinaryTree.SolveIteratively(tree);
        }

        [Fact]
        public void TreeLevelOrderTraversal()
        {
            //new TreeLevelOrderTraversal().LevelOrder(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
            new TreeLevelOrderTraversal().LevelOrder(new TreeNode(1));
            new TreeLevelOrderTraversal().LevelOrder(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
        }
        public static IEnumerable<object[]> InvertBinaryTreeTestData
        {
            get
            {
                yield return new object[]
                    {
                        CreateBinaryTree(new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9}, null, 0)
                    };
            }
        }
        static BinaryTree CreateBinaryTree(int[] arr,
                            BinaryTree root, int i)
        {
            // Base case for recursion
            if (i < arr.Length)
            {
                BinaryTree temp = new BinaryTree(arr[i]);
                root = temp;

                // insert left child
                root.left = CreateBinaryTree(arr,
                                root.left, 2 * i + 1);

                // insert right child
                root.right = CreateBinaryTree(arr,
                                root.right, 2 * i + 2);
            }
            return root;
        }
    }

    public class TreePathSumNodesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            TreeNode root = CreateTree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 });
            yield return new object[]
                {
                    root, 22, new List<List<int>>()
                    {
                        new List<int>(){ 5, 4, 11, 2 },
                        new List<int>(){ 5, 8, 4, 5 }
                    }
                };
            root = CreateTree(new int?[] { 1, 2, 3 });
            yield return new object[]
                {
                    root, 5, new List<List<int>>()
                };
            root = CreateTree(new int?[] { 1, 2 });
            yield return new object[]
                {
                    root, 0, new List<List<int>>()
                };


            yield return new object[]
                {
                    CreateTree(new int?[] { }), 1, new List<List<int>>()
                };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public static TreeNode CreateTree(int?[] array)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }

            Queue<TreeNode> treeNodeQueue = new Queue<TreeNode>();
            Queue<int?> integerQueue = new Queue<int?>();
            for (int i = 1; i < array.Length; i++)
            {
                integerQueue.Enqueue(array[i]);
            }

            TreeNode treeNode = new TreeNode(array[0].Value);
            treeNodeQueue.Enqueue(treeNode);

            while (integerQueue.Any())
            {
                int? leftVal = !integerQueue.Any() ? null : integerQueue.Dequeue();
                int? rightVal = !integerQueue.Any() ? null : integerQueue.Dequeue();
                TreeNode current = treeNodeQueue.Dequeue();
                if (leftVal.HasValue)
                {
                    TreeNode left = new TreeNode(leftVal.Value);
                    current.left = left;
                    treeNodeQueue.Enqueue(left);
                }
                if (rightVal.HasValue)
                {
                    TreeNode right = new TreeNode(rightVal.Value);
                    current.right = right;
                    treeNodeQueue.Enqueue(right);
                }
            }
            return treeNode;
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
