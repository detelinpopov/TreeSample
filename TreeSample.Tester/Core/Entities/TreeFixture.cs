using System;

using NUnit.Framework;

using TreeSample.Core.Entities;

namespace TreeSample.Tester.Core.Entities
{
	[TestFixture]
	public class TreeFixture
	{
		[Test]
		public void Root_ReturnsCorrectValue()
		{
			// Arrange
			int rootValue = 1;
			Tree<int> tree = new Tree<int>(rootValue);

			// Act
			TreeNode<int> root = tree.Root;

			// Assert
			Assert.IsNotNull(root);
			Assert.AreEqual(rootValue, root.Value);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Tree_ThrowsException_WhenTheValueIsNull()
		{
			// Arrange
			Tree<object> tree = new Tree<object>(null);
		}
	}
}
