using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.DataStructures.Queue
{
    // ALways use Generics
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head;
        private int _tail;

        // You can technically set a default value in your 
        public ArrayQueue()
        {
            _queue = new T[4];
        }

        public ArrayQueue(int defaultCapacity)
        {
            _queue = new T[defaultCapacity];
        }

        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;

        public double Capacity => _queue.Length;

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _queue[_head];
        }

        public void Enqueue(T item)
        {
            // if array is blocked the standard is create a double of the Array
            if(_queue.Length == _tail) {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_queue, largerArray, Count);
                _queue = largerArray;
            }

            _queue[_tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            _queue[_head++] = default(T);

            if (IsEmpty)
            {
                _head = _tail = 0;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
            {
                yield return _queue[1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
