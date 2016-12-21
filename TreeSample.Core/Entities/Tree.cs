using System;

namespace TreeSample.Core.Entities
{
	public class Tree<T>
	{
		public Tree(T value)
		{
			if (value == null)
			{
				throw new ArgumentException("Value cannot be null.");
			}

			Root = new TreeNode<T>(value);
		}

		public TreeNode<T> Root { get; set; }
	}
}
