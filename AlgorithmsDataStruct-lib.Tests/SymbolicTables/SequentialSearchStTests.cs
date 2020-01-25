using Algorithms_DataStruct_Lib.SymbolicTables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStruct_lib.Tests
{
    [TestFixture]
    public class SequentialSearchStTests
    {
        private SequentialSearchSt<string, int> _st;

        [SetUp]
        public void Init()
        {
            _st = new SequentialSearchSt<string, int>();
        }

        [Test]
        public void Count_PutSingleItem_ReturnsOne()
        {
            _st.Add("a", 1);

            Assert.AreEqual(1, _st.Count);
        }

        [Test]
        public void Add_PassNullAsKey_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _st.Add(null, 0));
        }

        [Test]
        public void Remove_PassNullAsKey_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _st.Remove(null));
        }

        [Test]
        public void Ctor_PassNullAsComparer_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new SequentialSearchSt<string, int>(null);
            });
        }

        [Test]
        public void Contains_PutSingeItem_ContainsThatItem()
        {
            _st.Add("a", 1);

            Assert.IsTrue(_st.Contains("a"));
            Assert.IsFalse(_st.Contains("b"));
        }


        [Test]
        public void Get_PutSingleItem_ReturnsTrueAndValue()
        {
            _st.Add("a", 1);

            bool exists = _st.TryGet("a", out int result);

            Assert.AreEqual(1, result);
            Assert.IsTrue(exists);
        }

        [Test]
        public void GetByInexistentKey_PutSingleItem_ReturnsFalseAndDefaultValue()
        {
            _st.Add("a", 1);

            bool exists = _st.TryGet("b", out int result);

            Assert.AreEqual(default(int), result);
            Assert.IsFalse(exists);
        }

        [Test]
        public void UpdateValueByKey_ValueGetsRewritten()
        {
            _st.Add("a", 1);
            _st.Add("a", 2);

            _st.TryGet("a", out int result);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void Remove_AddOneOrSeveralItems_CorrectState()
        {
            _st.Add("a", 1);
            Assert.IsFalse(_st.Remove("b"));

            _st.Remove("a");
            Assert.AreEqual(0, _st.Count);

            _st.Add("a", 1);
            _st.Add("b", 2);

            _st.Remove("a");
            Assert.AreEqual(1, _st.Count);

            _st.TryGet("b", out int result);
            Assert.AreEqual(2, result);

            _st.Add("a", 1);
            _st.Remove("a");

            Assert.AreEqual(1, _st.Count);

            _st.TryGet("b", out result);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Keys_SeveralKeys_CorrectSequence()
        {
            _st.Add("a", 1);
            _st.Add("b", 2);
            _st.Add("c", 3);

            var expected = new List<string> { "c", "b", "a" };
            Assert.AreEqual(expected, _st.Keys());
        }
    }
}
