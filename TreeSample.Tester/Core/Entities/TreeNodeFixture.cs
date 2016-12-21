using System;

using NUnit.Framework;

using TreeSample.Core.Entities;

namespace TreeSample.Tester.Core.Entities
{
	[TestFixture]
	public class TreeNodeFixture
	{
		[TestCase(1)]
		[TestCase(5)]
		public void ChildrenCount_ReturnsCorrectNumber_WhenTheNodeHasChildren(int numerOfChildNodes)
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);

			for (int i = 0; i < numerOfChildNodes; i++)
			{
				treeNode.AddChild(new TreeNode<int>(i + 1));
			}

			// Act
			int childrenCount = treeNode.ChildrenCount;

			// Assert
			Assert.AreEqual(numerOfChildNodes, childrenCount);
		}

		[Test]
		public void AddChild_AddsChildSuccessfully()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);
			int childNodeValue = 10;
			treeNode.AddChild(new TreeNode<int>(childNodeValue));

			// Act
			TreeNode<int> addedChild = treeNode.GetChild(0);

			// Assert
			Assert.IsNotNull(addedChild);
			Assert.AreEqual(childNodeValue, addedChild.Value);
			Assert.IsTrue(addedChild.HasParent);
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void AddChild_ThrowsException_WhenTheChildHasParent()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);
			TreeNode<int> child = new TreeNode<int>(6);
			child.HasParent = true;

			// Act
			treeNode.AddChild(child);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void AddChild_ThrowsException_WhenTheChildNodeIsNull()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);

			// Act
			treeNode.AddChild(null);
		}

		[Test]
		public void ChildrenCount_Returns0_WhenNoChildrenForTheNode()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);

			// Act
			int childrenCount = treeNode.ChildrenCount;

			// Assert
			Assert.AreEqual(0, childrenCount);
		}

		[Test]
		public void GetChild_ReturnsCorrectNode_WhenThereIsExistingChild()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);
			int childNodeValue = 7;
			treeNode.AddChild(new TreeNode<int>(childNodeValue));

			// Act
			TreeNode<int> child = treeNode.GetChild(0);

			// Assert
			Assert.IsNotNull(child);
			Assert.AreEqual(childNodeValue, child.Value);
		}

		[Test]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void GetChild_ThrowsException_WhenTheIndexIsNotCorrect()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);
			int childNodeValue = 7;
			treeNode.AddChild(new TreeNode<int>(childNodeValue));

			// Act
			treeNode.GetChild(1);
		}

		[Test]
		public void HasParent_ReturnsFalse_WhenTheNodeDoesNotHaveAParent()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);

			// Act
			bool hasParent = treeNode.HasParent;

			// Assert
			Assert.IsFalse(hasParent);
		}

		[Test]
		public void HasParent_ReturnsTrue_WhenTheNodeHasParent()
		{
			// Arrange
			TreeNode<int> treeNode = new TreeNode<int>(5);
			TreeNode<int> child = new TreeNode<int>(6);

			// Act
			treeNode.AddChild(child);

			// Assert
			bool hasParent = child.HasParent;
			Assert.IsTrue(hasParent);
		}
	}
}
