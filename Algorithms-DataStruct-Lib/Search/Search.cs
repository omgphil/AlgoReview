using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Algorithms_DataStruct_Lib.Search
{
    public class Customer
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

    }
    public class Search
    {
        List<Customer> customerList = new List<Customer>();
        List<int> intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };


        public Search()
        {
            customerList.Add(new Customer { Age = 3, Name = "Ann" });
            customerList.Add(new Customer { Age = 16, Name = "Bill" });
            customerList.Add(new Customer { Age = 20, Name = "Rose" });
            customerList.Add(new Customer { Age = 14, Name = "Rob" });
            customerList.Add(new Customer { Age = 28, Name = "Bill" });
            customerList.Add(new Customer { Age = 14, Name = "John" });
        }

        // the bottom 2 are Linear Search
        public bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return true;
                }
            }

            return false;
        }

        // Binary Search
        public static int BinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length;

            while (low < high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == value)
                {
                    return mid;
                }
                if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }

            }

            return -1;
        }

        public static int RecursiveBinarySearch(int[] array, int value)
        {
            return InternalRecursiveBinarySearch(0, array.Length);
            // Local Function by C#
            int InternalRecursiveBinarySearch(int low, int high)
            {
                if (low >= high)
                {
                    return -1;
                }

                int mid = (low + high) / 2;

                if (array[mid] == value)
                {
                    return mid;
                }

                if (array[mid] < value)
                {
                    return InternalRecursiveBinarySearch(mid + 1, high);
                }
                return InternalRecursiveBinarySearch(low, mid);
            }
        }

        public int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return i;
                }
            }

            return -1;
        }

        // build in list functions
        public void ListSearches()
        {
            bool Contains = intList.Contains(3);
            bool objectContains = customerList.Contains(new Customer { Age = 3, Name = "Ann" }, new CustomersComparer());

            bool exists = customerList.Exists(customer => customer.Age == 28);

            int min = intList.Min();
            int max = intList.Max();

            int youngestCustAge = customerList.Min(c => c.Age);

            Customer bill = customerList.Find(c => c.Name == "Bill");
            Customer lastbill = customerList.FindLast(c => c.Name == "Bill"); // provided by list<>
            Customer lastbill2 = customerList.Last(c => c.Name == "Bill"); // Provided by Linq

            List<Customer> customers = customerList.FindAll(c => c.Age > 18);
            IEnumerable<Customer> whereAge = customerList.Where(c => c.Age > 18);

            int index1 = customerList.FindIndex(customer => customer.Age == 14);
            int lastIndex = customerList.FindLastIndex(customer => customer.Age > 18);

            int indexOf = intList.IndexOf(2);
            int lastIndexOf = intList.LastIndexOf(2);

            //from list
            bool isTrueForAll = customerList.TrueForAll(customer => customer.Age > 10);

            //from linq
            bool all = customerList.All(customer => customer.Age > 18);

            bool areThereAny = customerList.Any(customer => customer.Age == 3);

            int count = customerList.Count(customer => customer.Age > 18);

            Customer firstBill = customerList.First(customer => customer.Name == "Bill");

            Customer singleAnn = customerList.Single(customer => customer.Name == "Ann");

        }
    }

    internal class CustomersComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            return x.Age == y.Age && x.Name == y.Name;
        }

        public int GetHashCode(Customer obj) => obj.GetHashCode();

    }
}
