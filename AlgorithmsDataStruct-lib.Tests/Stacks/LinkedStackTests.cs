using System;
using System.Collections.Generic;
using Algorithms_DataStruct_Lib.Stacks;
using NUnit.Framework;

namespace AlgorithmsDataStruct_lib.Tests
{
    [TestFixture]
    public class LinkedStackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new LinkedStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new LinkedStack<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void Peek_EmptyStack_ThrowsException()
        {
            var stack = new LinkedStack<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Peek();
            });
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.AreEqual(1, stack.Peek());
        }

        [Test]
        public void IterateOver_SeveralItems_ExpectedSequence()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var q = new List<int>();

            foreach (var cur in stack)
                q.Add(cur);

            CollectionAssert.AreEqual(new List<int> { 3, 2, 1 }, q);
        }
    }
}
