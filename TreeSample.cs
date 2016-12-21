using System;

using TreeSample.Core.Entities;

namespace TreeSample
{
	internal class TreeSample
	{
		private static void Main(string[] args)
		{
			Tree<int> tree = new Tree<int>(1);

			TreeNode<int> rootChild1 = new TreeNode<int>(2);
			TreeNode<int> rootChild2 = new TreeNode<int>(3);

			tree.Root.AddChild(rootChild1);
			tree.Root.AddChild(rootChild2);

			TreeNode<int> child3 = new TreeNode<int>(4);
			rootChild1.AddChild(child3);

			PrintTree(tree.Root, string.Empty);
		}

		private static void PrintTree(TreeNode<int> root, string spaces)
		{
			if (root == null)
			{
				return;
			}

			Console.WriteLine(spaces + root.Value);

			for (int i = 0; i < root.ChildrenCount; i++)
			{
				TreeNode<int> child = root.GetChild(i);
				PrintTree(child, spaces + " ");
			}
		}
	}
}
