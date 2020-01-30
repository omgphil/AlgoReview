using Algorithms_DataStruct_Lib;
using Interview_Review.DataStructures.Lists;
using Interview_Review.DataStructures.Lists.LinkList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PhoneNumber number1 = new PhoneNumber("141804", "27","90319334" );
            PhoneNumber number2 = new PhoneNumber("141804", "27", "90319334");
            //PhoneNumber number3 = new PhoneNumber() { AreaCode = "141804", Exchange = "27", Number = "90319334" };

            Console.WriteLine(number1.GetHashCode());
            Console.WriteLine(number2.GetHashCode());
            Console.WriteLine(number1 == number2);
            Console.WriteLine(number1.Equals(number2));

            Dictionary<PhoneNumber, Person> customers = new Dictionary<PhoneNumber, Person>();
            customers.Add(number1, new Person());
            //customers.Add(number2, new Person());

            //var c = customers[number3]; // Will return an error

            Console.WriteLine(customers.ContainsKey(number1));

            number1.AreaCode = "141805";
            Console.WriteLine(customers.ContainsKey(number1));

            Console.WriteLine("After Adding Phone Numbers");

            //Dictionary<int, string> books = new Dictionary<int, string>();
            //books.Add(1, "The Lord of the Rings");
            //books.Add(2, "A Tale of Two Cities");

            //// query to get book
            //string bookName = books[1];

            //Console.WriteLine(bookName);

            Console.ReadKey();

            /*Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);

            q.Peek();*/

        }

        // Recursion
        private static int InterativeFactorial(int number)
        {
            if(number == 0)
            {
                return 1;
            }
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        // n! = n * (n-1)!
        private static int RecursiveFactorial(int n)
        {
            if(n == 0)
            {
                return 1;
            }

            return n * RecursiveFactorial(n - 1);
        }
    }
}
