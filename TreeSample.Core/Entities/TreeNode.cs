using System;
using System.Collections.Generic;

namespace TreeSample.Core.Entities
{
	public class TreeNode<T>
	{
		private readonly IList<TreeNode<T>> children = new List<TreeNode<T>>();

		public TreeNode(T value)
		{
			if (value == null)
			{
				throw new ArgumentException("Tree node value cannot be null.");
			}

			Value = value;
		}

		public IEnumerable<TreeNode<T>> Children => children;

		public int ChildrenCount => children.Count;

		public bool HasParent { get; set; }

		public T Value { get; set; }

		public void AddChild(TreeNode<T> child)
		{
			if (child == null)
			{
				throw new ArgumentException("Child tree node value cannot be null.");
			}

			if (child.HasParent)
			{
				throw new InvalidOperationException("The child already has a parent.");
			}

			child.HasParent = true;
			children.Add(child);
		}

		public TreeNode<T> GetChild(int index)
		{
			if (children.Count <= index)
			{
				throw new IndexOutOfRangeException("Child node index is out of range.");
			}

			return children[index];
		}
	}
}
