using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms_DataStruct_Lib.Stacks
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] _items;


        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }
        public int Capacity => _items.Length;

        public ArrayStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public ArrayStack(int capacity)
        {
            _items = new T[capacity];
        }



        public void Push(T item)
        {
            // This creates a new Array if the stack is full
            // By standard strat you double the size

            if (_items.Length == Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_items, largerArray, Count);

                _items = largerArray;
            }
            _items[Count++] = item; //adds item to the count index then increments
        }

        public void Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = default(T); // special keyword that returns default value for any type
        }

        // Can implement a method called trim to shrink the stack

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            return _items[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--) // reverse forloop
            {
                yield return _items[i]; // yield gets all the values and sends it at once
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}