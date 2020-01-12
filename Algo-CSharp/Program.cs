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
