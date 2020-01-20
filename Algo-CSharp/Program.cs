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

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);

            q.Peek();

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
