using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.DataStructures.Lists
{
    public class ListDemo
    {
        /*
         * List<T>.Sort() eventually calls Array.Sort<T>()
         * if T is primative the CLR uses a build in QuickSort
         * ref type:
         *  .NetCore && plat >= .net 4.5 IntroSort mix of Insertion, heap or Quick sorts
         *  Else DepthLimitedQuickSort. Qsort 32 max reccursion calls, then switches to Heap
         *  
         *  Recap
         *  Backed Up by an internal array
         *  add - O(1) if enough space,  O(n) if it needs to add space
         *  Remove O(n) - searching
         *  RemoveAt O(n) - shifting
         *  Reverse O(n)
         *  ToArray O(n) based on Array.Copy
         *  Contains, IndexOf etc.. O(n)
         *  
         *  DO NOT USE ArrayList. Use List<object> instead
         */


        public class Customer
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }

        }
        // Built in lists / collections
        public static void Run()
        {
            // These are genric lists, and <> <- defines the type
            List<int> list = new List<int>();
            LogCountAndCapacity(list);

            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }

            for (int i = 10; i > 0; i--)
            {
                list.RemoveAt(i);
                LogCountAndCapacity(list);
            }

            list.TrimExcess(); // works if less than 90% is used
            LogCountAndCapacity(list);
            list.Add(1);
            LogCountAndCapacity(list);


        }

        public static void ApiMembers()
        {
            var list = new List<int>() { 1, 0, 5, 3, 4 };

            list.Sort(); // to sort reference you pass a lambda expression

            var listCustomers = new List<Customer>
            {
                new Customer { BirthDate = new DateTime(1988, 08, 12), Name="Elias"},
                new Customer { BirthDate = new DateTime(1990, 06, 09), Name="Marina"},
                new Customer { BirthDate = new DateTime(2015, 06, 09), Name="Ann"},
            };

            listCustomers.Sort((left, right) =>
            {
                if(left.BirthDate > right.BirthDate)
                {
                    return 1;
                }

                if (left.BirthDate < right.BirthDate)
                {
                    return -1;
                }

                return 0;
            });

            // Binary Search API, Fastest search but colletion needs to be sorted

            int indexBinSearch = list.BinarySearch(3);

            // reverse current order of elements (this does not sort)
            list.Reverse();

            // Nothing can be changed in this instance
            IReadOnlyCollection<int> readOnlyList = list.AsReadOnly();

            var array = list.ToArray();
        }

        private static void LogCountAndCapacity(List<int> list)
        {
            // Count is the number of elements in the list
            // Capacity is the Max elements before the next resize
            Console.WriteLine($"Count={list.Count}. Capacity{list.Capacity}");
        }
    }
}
