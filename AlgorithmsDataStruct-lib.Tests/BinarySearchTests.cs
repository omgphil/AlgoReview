using Algorithms_DataStruct_Lib.Search;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStruct_lib.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = { 0, 3, 4, 7, 8, 12, 15, 22 };

            const int notFound = -1;
            Assert.AreEqual(notFound, Search.BinarySearch(input, 10));

            Assert.AreEqual(2, Search.BinarySearch(input, 4));
            Assert.AreEqual(4, Search.BinarySearch(input, 8));
            Assert.AreEqual(6, Search.BinarySearch(input, 15));
            Assert.AreEqual(7, Search.BinarySearch(input, 22));

            Assert.AreEqual(notFound, Search.RecursiveBinarySearch(input, 10));
            Assert.AreEqual(2, Search.RecursiveBinarySearch(input, 4));
            Assert.AreEqual(4, Search.RecursiveBinarySearch(input, 8));
            Assert.AreEqual(6, Search.RecursiveBinarySearch(input, 15));
            Assert.AreEqual(7, Search.RecursiveBinarySearch(input, 22));
        }
    }
}
