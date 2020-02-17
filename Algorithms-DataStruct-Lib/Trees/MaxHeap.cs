using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.Trees
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] _heap;

        public int Count { get; private set; }
        public bool isFull => Count == _heap.Length;
        public bool isEmpty => Count == 0;

        public MaxHeap() : this(DefaultCapacity)
        {

        }

        public MaxHeap(int defaultCapacity)
        {
            _heap = new T[defaultCapacity];
        }

        public T Peek()
        {
            if (isEmpty)
            {
                throw new InvalidOperationException();
            }

            return _heap[0];
        }

        public T Remove()
        {
            return Remove(0);
        }

        private T Remove(int index)
        {
            if (isEmpty)
            {
                throw new InvalidOperationException();
            }

            T removedValue = _heap[index];
            
            _heap[index] = _heap[Count - 1];

            if(index==0 || _heap[index].CompareTo(GetParent(index)) <0)
            {
                Sink(index, Count -1);
            } else
            {
                Swim(index);
            }

            Count--;
            return removedValue;
        }

        public void Sort()
        {
            int lastHeapIndex = Count - 1;
            for (int i = 0; i < lastHeapIndex; i++)
            {
                Exchange(0, lastHeapIndex - i);
                Sink(0, lastHeapIndex - i - 1);
            }
        }

        private void Exchange(int leftIndex, int rightIndex)
        {
            T tmp = _heap[leftIndex];
            _heap[leftIndex] = _heap[rightIndex];
            _heap[rightIndex] = tmp;
        }

        private void Sink(int indexOfSinkingItem, int lastHeapIndex)
        {
            while (indexOfSinkingItem <= lastHeapIndex)
            {
                int leftChildIndex = LeftChildIndex(indexOfSinkingItem);
                int rightChildIndex = RightChildIndex(indexOfSinkingItem);

                if(leftChildIndex > lastHeapIndex)
                {
                    break;
                }

                int childIndextoSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

                if (SinkingIsLessThan(childIndextoSwap))
                {
                    Exchange(indexOfSinkingItem, childIndextoSwap);
                } else
                {
                    break;
                }

                indexOfSinkingItem = childIndextoSwap;
            }

            bool SinkingIsLessThan(int childToSwap)
            {
                return _heap[indexOfSinkingItem].CompareTo(_heap[childToSwap]) > 0;
            }

            int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
            {
                int childToSwap;
                if(rightChildIndex > lastHeapIndex)
                {
                    childToSwap = leftChildIndex;
                } else
                {
                    int compareTo = _heap[leftChildIndex].CompareTo(_heap[rightChildIndex]);
                    childToSwap = (compareTo > 0) ? leftChildIndex : rightChildIndex;
                }

                return childToSwap;
            }
        }

        private int RightChildIndex(int parentIndex) => (2 * parentIndex) + 2;

        private int LeftChildIndex(int parentIndex) => (2 * parentIndex) + 1;

        public void Insert(T value)
        {
            if (isFull)
            {
                var newHeap = new T[_heap.Length * 2];
                Array.Copy(_heap, 0, newHeap, 0, _heap.Length);
                _heap = newHeap;
            }
            _heap[Count] = value;
            Swim(Count);
            Count++;
        }

        public IEnumerable<T> Values()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _heap[i];
            }
        }

        private void Swim(int indexOfSwimmingItem)
        {
            T newValue = _heap[indexOfSwimmingItem];
            while (indexOfSwimmingItem > 0 && isParentLess(indexOfSwimmingItem))
            {
                _heap[indexOfSwimmingItem] = GetParent(indexOfSwimmingItem);
                indexOfSwimmingItem = ParentIndex(indexOfSwimmingItem);
            }

            _heap[indexOfSwimmingItem] = newValue;

            bool isParentLess(int swimmingItem) {
                return newValue.CompareTo(GetParent(swimmingItem)) >0;
            }
        }

        private T GetParent(int index)
        {
            return _heap[ParentIndex(index)];
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
