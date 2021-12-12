using System;
using System.Collections.Generic;
using System.Text;

namespace workout.algo_expert
{
	public class BinaryTree
	{
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value)
		{
			this.value = value;
		}
	}
	public class InvertBinaryTree
    {
		public static void Solve(BinaryTree tree)
		{
            if (tree == null)
            {
				return;
            }
			var temp = tree.left;
			tree.left = tree.right;
			tree.right = temp;
			Solve(tree.left);
			Solve(tree.right);
		}
		public static void SolveIteratively(BinaryTree tree)
		{
            if (tree == null)
            {
				return;
            }
			Stack<BinaryTree> stack = new Stack<BinaryTree>();
			stack.Push(tree);
            while (stack.TryPop(out BinaryTree lastNode))
            {
				var temp = lastNode.left;
				lastNode.left = lastNode.right;
				lastNode.right = temp;

                if (lastNode.left != null)
                {
					stack.Push(lastNode.left);
                }
                else if (lastNode.right != null)
                {
					stack.Push(lastNode.right);
                }
            }
		}
	}
}
