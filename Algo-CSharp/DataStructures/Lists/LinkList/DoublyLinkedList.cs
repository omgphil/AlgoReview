using System;

namespace Interview_Review.DataStructures.Lists.LinkList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }
        public DoublyLinkedNode<T> Tail { get; private set; }
        public bool IsEmpty => Count == 0;
        public int Count { get; set; }

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            // Save off the Head
            DoublyLinkedNode<T> temp = Head;

            // Point head to node
            Head = node;

            // insert the rest of the list behind head
            Head.Next = temp;

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedNode<T>(value));
        }

        private void AddLast(DoublyLinkedNode<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            } else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            Head = Head.Next;
            Count--;
            if (IsEmpty)
            {
                Tail = null;
            } else
            {
                Head.Previous = null;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            if(Count == 1)
            {
                Head = null;
                Tail = null;
            } else
            {
                Tail.Previous.Next = null; // Null Last Node
                Tail = Tail.Previous; // Shift the Tail
            }

            Count--;
        }
    }
}
