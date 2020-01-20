using Interview_Review.DataStructures.Queue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStruct_lib.Tests
{
    [TestFixture]
    public class CircularQueueTests
    {
        [Test]
        public void Capacity_EnqueueManyItems_DoubledCapacity()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Dequeue();

            queue.Enqueue(2);
            queue.Dequeue();

            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Assert.AreEqual(8, queue.Capacity);
        }

        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new CircularQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Ctor_PassCapacity_CorrectCapacity()
        {
            const int capacity = 8;

            var queue = new CircularQueue<int>(capacity);
            Assert.AreEqual(capacity, queue.Capacity);
        }

        [Test]
        public void Count_EnqueueOneItem_ReturnsOne()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            var queue = new CircularQueue<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }

        [Test]
        public void Peek_EmptyQueue_ThrowsException()
        {
            var queue = new CircularQueue<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Peek();
            });
        }

        [Test]
        public void Peek_EnqueueTwoItems_ReturnsHeadItem()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_EnqueueTwoItemsAndDequeue_ReturnsHeadElement()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }

        [Test]
        public void Dequeue_WrappedQueue_HeadGoesToZeroIndex()
        {
            var cq = new CircularQueue<int>();
            cq.Enqueue(1);
            cq.Enqueue(2);
            cq.Enqueue(3);

            cq.Dequeue();

            //wrap
            cq.Enqueue(4);

            cq.Dequeue();
            cq.Dequeue();

            Assert.AreEqual(4, cq.Peek());
        }
    }
}
