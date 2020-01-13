using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.DataStructures.Lists.LinkList
{
    public class DoublyLinkedNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
        public DoublyLinkedNode<T> Previous { get; set; }

        public DoublyLinkedNode(T value)
        {
            this.Value = value;
        }
    }
}
