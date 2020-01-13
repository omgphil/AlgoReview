using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.DataStructures.Lists.LinkList
{
    /*
     * Node  is a basic building block for a lot of datastructer
     * 2 functions
     *  - Data Container
     *  - Pointer Reference
     */
     
    // Node first = new Node() { Value = 3 };
    // Node second = new Node() { Value = 1 };

    // first.Next = second;

    // Node third = new Node() { Value = 1 };
    // second.Next = third;
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }


}
