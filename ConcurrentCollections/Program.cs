using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    public class RemoteBookStock
    {
        public static readonly List<string> Books = new List<string> { "Clean Code", "C# in Depth", "C++ for Beginers",
            "Design Patterns in C#", "marvel Heroes"};
    }

    public class StockController
    {
        readonly ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();

        public void BuyBook(string item, int quantity)
        {
            _stock.AddOrUpdate(item, quantity, (key, oldvalue) => oldvalue + quantity);
        }

        public bool TryRemoveBookFromStock(string item)
        {
            if(_stock.TryRemove(item, out int val))
            {
                Console.WriteLine($"How much was removed:{val}");
                return true;
            }

            return false;
        }

        public bool TrySellBook(string item)
        {
            bool success = false;

            _stock.AddOrUpdate(item,
                itemName => { success = false; return 0; },
                (itemName, oldValue) =>
                {
                    if (oldValue == 0)
                    {
                        success = false;
                        return 0;
                    }
                    else
                    {
                        success = true;
                        return oldValue - 1;
                    }
                });
            return success;
        }

        public void DisplayStatus()
        {
            foreach (var pair in _stock)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }

    public class SalesManager
    {
        public string Name { get; }
        public SalesManager(string id)
        {
            Name = id;
        }
    }

    class Program
    {
        private static readonly List<int> largeList = new List<int>(10000);

        private static void GenerateList()
        {
            for (int i = 0; i < 100000; i++)
            {
                largeList.Add(i);
            }
        }


        static void Main(string[] args)
        {
            //StackDemo();
            //QueueDemo();
            //ListDemo();
            //DictionaryDemo()

            Console.Read();


        }

        static void ConcurrentBagDemo()
        {
            var names = new ConcurrentBag<string>();
            names.Add("Bob");
            names.Add("Alice");
            names.Add("Rob");

            Console.WriteLine($"After enqueueing, count = {names.Count}");

            // you need to use the tryDequeue because of thread safety
            string item1; // names.Dequeue();
            bool success = names.TryTake(out item1);
            if (success)
            {
                Console.WriteLine("\nRemoving " + item1);
            }
            else
            {
                Console.WriteLine("Queue was empty");
            }

            string item2; // Names.Peek

            success = names.TryPeek(out item2);
            if (success)
            {
                Console.WriteLine("Peeking " + item2);
            }
            else
            {
                Console.WriteLine("Queue was empty");
            }

            Console.WriteLine("Enumerating");
            PrintOutCollection(names);

            Console.WriteLine($"After Enumerating, count = {names.Count}");
        }

        static void ConcurrentStackDemo()
        {
            var names = new ConcurrentStack<string>();
            names.Push("Bob");
            names.Push("Alice");
            names.Push("Rob");

            Console.WriteLine($"After enqueueing, count = {names.Count}");

            // you need to use the tryDequeue because of thread safety
            string item1; // names.Dequeue();
            bool success = names.TryPop(out item1);
            if (success)
            {
                Console.WriteLine("\nRemoving " + item1);
            }
            else
            {
                Console.WriteLine("Queue was empty");
            }

            string item2; // Names.Peek

            success = names.TryPeek(out item2);
            if (success)
            {
                Console.WriteLine("Peeking " + item2);
            }
            else
            {
                Console.WriteLine("Queue was empty");
            }

            Console.WriteLine("Enumerating");
            PrintOutCollection(names);

            Console.WriteLine($"After Enumerating, count = {names.Count}");
        }

        static void ConcurrentQueueDemo()
        {
            var names = new ConcurrentQueue<string>();
            names.Enqueue("Bob");
            names.Enqueue("Alice");
            names.Enqueue("Rob");

            Console.WriteLine($"After enqueueing, count = {names.Count}");

            // you need to use the tryDequeue because of thread safety
            string item1; // names.Dequeue();
            bool success = names.TryDequeue(out item1);
            if (success)
            {
                Console.WriteLine("\nRemoving " + item1);
            } else
            {
                Console.WriteLine("Queue was empty");
            }

            string item2; // Names.Peek

            success = names.TryPeek(out item2);
            if (success)
            {
                Console.WriteLine("Peeking " + item2);
            }
            else
            {
                Console.WriteLine("Queue was empty");
            }

            Console.WriteLine("Enumerating");
            PrintOutCollection(names);

            Console.WriteLine($"After Enumerating, count = {names.Count}");
        }

        static void ImmutableCollectionDemo()
        {
            var builder = ImmutableList.CreateBuilder<int>();

            foreach (var item in largeList)
            {
                builder.Add(item);
            }

            //builder.AddRange(largeList);

            ImmutableList<int> immutableList = builder.ToImmutable();
        }

        static void DictionaryDemo()
        {
            var dictionary = ImmutableDictionary<int, string>.Empty;
            dictionary = dictionary.Add(1, "john");
            dictionary = dictionary.Add(2, "Alex");
            dictionary = dictionary.Add(3, "April");
            IterateOverDictionary(dictionary);

            Console.WriteLine("Changing Value of Key 2 to Bob");
            dictionary = dictionary.SetItem(2, "Bob");

            IterateOverDictionary(dictionary);

            var april = dictionary[3];
            Console.WriteLine($"Who is at key 3={april}");

            Console.WriteLine("Remove Record where key equals 2");
            dictionary = dictionary.Remove(2);

            IterateOverDictionary(dictionary);
        }

        private static void IterateOverDictionary(ImmutableDictionary<int, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }
        }

        static void SetsDemo()
        {
            var hashSet = ImmutableHashSet<int>.Empty;

            hashSet = hashSet.Add(5);
            hashSet = hashSet.Add(10);

            // In multi Threaded it will display items in unpredictible order
            PrintOutCollection(hashSet);

            Console.WriteLine("Remove 5");
            hashSet = hashSet.Remove(5);

            PrintOutCollection(hashSet);

            Console.WriteLine("--- ImmutableSortedSet Demo ---");
            var sortedSet = ImmutableSortedSet<int>.Empty;
            sortedSet = sortedSet.Add(10);
            sortedSet = sortedSet.Add(5);

            PrintOutCollection(sortedSet);

            var smallest = sortedSet[0];
            Console.WriteLine($"smallest item {smallest}");

            Console.WriteLine("Remove 5");
            sortedSet = sortedSet.Remove(5);

            PrintOutCollection(sortedSet);
        }

        static void ListDemo()
        {
            var list = ImmutableList<int>.Empty;
            list = list.Add(2);
            list = list.Add(3);
            list = list.Add(4);
            list = list.Add(5);

            PrintOutCollection(list);

            Console.WriteLine("Remove 4 and tehn removeat index 2");

            list = list.Remove(4);
            list = list.RemoveAt(2);

            PrintOutCollection(list);
            Console.WriteLine("Inser 1 at 0 and 4 at 3");
            list = list.Insert(0, 1);
            list = list.Insert(3, 4);

            PrintOutCollection(list);

        }

        static void QueueDemo()
        {
            var queue = ImmutableQueue<int>.Empty;
            queue = queue.Enqueue(1);
            queue = queue.Enqueue(2);

            PrintOutCollection(queue);

            int first = queue.Peek();
            Console.WriteLine($"Last Item:{first}");

            queue = queue.Dequeue(out first);
            Console.WriteLine($"Last Item:{first}l Last After pop {queue.Peek()}");

        }

        static void StackDemo()
        {
            var stack = ImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);

            int last = stack.Peek();
            Console.WriteLine($"Last Item:{last}");

            stack = stack.Pop();
            Console.WriteLine($"Last Item:{last}; Last after Pop: {stack.Peek()}");
        }

        private static void PrintOutCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
