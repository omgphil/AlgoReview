using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.DataStructures.Arrays
{
    public class Arrays
    {
         /*
         * Arrays are the simplest structure and they are used to store a list of items. 
         * These Items get stores sequencially in memory. Looking by index is fast because you go straight to the memory address
         * Arrays are static, the size cannot change once declared.
         * 
         * Lookup O(1)
         * Insert O(n)
         * Delete O(n)
         * 
         * Arrays belong to ref types by default
         */
        public void ArrayDemo()
        {
            int[] a1; //null reference
            // Pre allocates space in memory and points to the first elements arrays are not dynamic
            // Arrays are by default base of 0, the end of the arrays is length - 1

            // All array types come from System.Array

            // Initialize the arrays
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 2, 3, 4, 5 };

            int[] a4 = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < a3.Length ; i++)
            {
                Console.Write($"{a3[i]}");
            }
            Console.WriteLine();

            foreach (var item in a4)
            {
                Console.Write($"{item}");
            }

            // you can use the system defini

            Array myarray = new int[5];

            // The above Translates too
            // Array type Exposes Important methods like Binary search and Copy

            Array myArray2 = Array.CreateInstance(typeof(int), 5);
            myArray2.SetValue(1, 0);

            Console.WriteLine();

            
        }

        // Iterate over unsafe Code
        private unsafe void IterateOver(int[] array)
        {
            // Fixed is to pin object in a location tells(garbage collector)
            fixed(int* b = array)
            {
                int* p = b;

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(*p);
                    p++; // Shifts pointer to next address
                }
            }
        }

        public void MultiDimArrays()
        {
            int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            // To iterate you can use nested loops           
        }

        public void JaggedArray()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];
        }

        // You can create non 0 based arrays / Are slower than 0 based
        // This isnt Good Practice and not recomended
        private void Non0BaseArray()
        {
            Array myArray = Array.CreateInstance(typeof(int), new int[] { 4 }, new[] { 1 });
            myArray.SetValue(1, 1);
            myArray.SetValue(1, 2);
            myArray.SetValue(1, 3);
            myArray.SetValue(1, 4);

            // These are special Methods that let you get Starting Index and Ending Indexs
            Console.WriteLine($"Starting Index: {myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending Index: {myArray.GetUpperBound(0)}");

            // These Functions are useful if you want to get the indexs dynamically
            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {

            }
        }

        public void ArrayTimeComplexity(object[] array)
        {
            // Access By Index O(1)
            Console.WriteLine(array[0]);

            int length = array.Length;
            object elment = new object();

            // Searching for an Element O(n)
            for (int i = 0; i < length; i++)
            {
                if(array[i] == elment)
                {
                    Console.WriteLine("found");
                }
            }

            // Add to full array O(n)
            var bigArray = new int[length * 2];
            Array.Copy(array, bigArray, length);
            bigArray[length + 1] = 10;

            // Add to the end, when there is some space O(1)
            array[length - 1] = 10;

            // Inserting into an Array O(n) -> you need to find the "Empty slot"

            // Removing an Element by null if you know the index is constant time O(1)

            // if you dont knwo the index you need a for loop and O(n);
            // for the remove you reallocate the array
        }
    }


}
