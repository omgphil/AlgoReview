using System;
using System.Collections.Generic;

namespace Algorithms_DataStruct_Lib.SymbolicTables
{
    // Generic Arguments
    public class SequentialSearchSt<TKey, TValue>
    {
        private class Node
        {
            
            public TKey Key { get; }
            public TValue Value { get; set; }

            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                this.Key = key;
                this.Value = value;
                this.Next = next;
            }
        }

        private Node _first;

        // Need to make quality comparer cause a client can use a custom type
        private readonly IEqualityComparer<TKey> _comparer;

        public int Count { get; private set; }

        public SequentialSearchSt()
        {
            _comparer = EqualityComparer<TKey>.Default;
        }

        public SequentialSearchSt(IEqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey key, out TValue val)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x: key, y: x.Key))
                {
                    val = x.Value;
                    return true;
                }
            }
            val = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key Cannot be null");
            }

            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x: key, y: x.Key))
                {
                    x.Value = val;
                    return;
                }
            }
            _first = new Node(key, val, _first);
            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x: key, y: x.Key))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            // Null key is not allowed. 
            // Counter should be adjusted properly.
            // It should remove a key - value pair entirely. 
            // It should return false if the requested key was not found, otherwise true.

            if (key == null)
                throw new ArgumentNullException("Key can't be null.");

            if (Count == 1 && _comparer.Equals(_first.Key, key))
            {
                _first = null;
                Count--;
                return true;
            }

            Node prev = null;
            Node current = _first;

            while (current != null)
            {
                if (_comparer.Equals(current.Key, key))
                {
                    if (prev == null)
                    {
                        _first = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    Count--;
                    return true;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }
    }
}
