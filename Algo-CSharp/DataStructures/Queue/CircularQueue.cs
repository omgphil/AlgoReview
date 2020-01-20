using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.DataStructures.Queue
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head;
        private int _tail;

        public int Count => _head <= _tail ? _tail - _head : _tail - _head + _queue.Length;
        public bool IsEmpty => Count == 0;

        public int Capacity => _queue.Length;

        public CircularQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        public CircularQueue()
        {
            _queue = new T[4];
        }

        public void Enqueue(T item)
        {
            // This unwrap the queue when doubling its size
            if(Count ==_queue.Length-1)
            {
                int countPriorResize = Count;
                T[] newArray = new T[2 * _queue.Length];

                // copy the data in 2 parts
                Array.Copy(_queue, _head, newArray, 0, _queue.Length - _head);
                Array.Copy(_queue, 0, newArray, _queue.Length - _head, _tail);

                _queue = newArray;

                _head = 0;
                _tail = countPriorResize;
            }

            _queue[_tail] = item;
            
            if(_tail < _queue.Length - 1)
            {
                _tail++;
            } else
            {
                _tail = 0;
            }
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
            } else if(_head == _queue.Length)
            {
                _head = 0;
            }
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return _queue[_head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            // queue is unwrapped
            if(_head <= _tail)
            {
                for(int i = _head; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            } else
            {
                for (int i = _head; i < _queue.Length; i++)
                {
                    yield return _queue[i];
                }
                for (int i = 0; i < _tail; i++)
                {
                    yield return _queue[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
