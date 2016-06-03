using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glab.Base.Collection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Glab.Test.Base
{
    [TestClass]
    public class CollectionTest
    {
        [TestMethod]
        public void DynamicEnumerableTest()
        {
            List<string> source = new List<string> { "One", "Two", "Three" };
            DynamicEnumerable<string> array = new DynamicEnumerable<string>(source);

            int counter = 0;
            var enumerator = array.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    Assert.AreEqual(enumerator.Current, source[counter++], $"DynamicEnumerableTest. Elements are not equal");
            }
            finally
            {
                enumerator.Dispose();
            }

            Assert.AreEqual<int>(source.Count, counter, "DynamicEnumerableTest. Size of input source and result array is different");
        }

        [TestMethod]
        public void DynamicEnumerableTest2()
        {
            IEnumerable<Tuple<object>> array = new DynamicEnumerable<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicEnumerableTest2. Empty array can not be iterrate (IEnumerable<>)");

            IEnumerable array2 = new DynamicEnumerable<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicEnumerableTest2. Empty array can not be iterrate (IEnumerable)");



            List<Tuple<object>> source = new List<Tuple<object>> { new Tuple<object>("str1"), new Tuple<object>("str2") };
            array = new DynamicEnumerable<Tuple<object>>(source);
            array2 = new DynamicEnumerable<Tuple<object>>(source);

            var counter = 0;
            foreach (var item in array)
                Assert.AreSame(item, source[counter++], "DynamicEnumerableTest. The input source and result array' element are different (IEnumerable<>)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicEnumerableTest. Size of input source and result array is different (IEnumerable<>)");

            counter = 0;
            foreach (var item in array2)
                Assert.AreSame(item, source[counter++], "DynamicEnumerableTest. The input source and result array' element are different (IEnumerable)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicEnumerableTest. Size of input source and result array is different (IEnumerable)");
        }



        [TestMethod]
        public void DynamicEnumerableManualTest()
        {
            List<string> source = new List<string> { "One", "Two", "Three" };
            DynamicEnumerableManual<string> array = new DynamicEnumerableManual<string>(source);

            int counter = 0;
            var enumerator = array.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    Assert.AreEqual(enumerator.Current, source[counter++], $"DynamicEnumerableManualTest. Elements are not equal");
            }
            finally
            {
                enumerator.Dispose();
            }
            Assert.AreEqual<int>(source.Count, counter, "DynamicEnumerableManualTest. Size of input source and result array is different");



            array = new DynamicEnumerableManual<string>();
            try
            {
                while (enumerator.MoveNext())
                    Assert.Fail("DynamicEnumerableManualTest. Empty array can not be iterrate (IEnumerable<>)");
            }
            finally
            {
                enumerator.Dispose();
            }
        }

        [TestMethod]
        public void DynamicEnumerableManualTest2()
        {
            IEnumerable<Tuple<object>> array = new DynamicEnumerableManual<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicEnumerableManualTest2. Empty array can not be iterrate (IEnumerable<>)");

            IEnumerable array2 = new DynamicEnumerableManual<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicEnumerableManualTest2. Empty array can not be iterrate (IEnumerable)");



            List<Tuple<object>> source = new List<Tuple<object>> { new Tuple<object>("str1"), new Tuple<object>("str2") };
            array = new DynamicEnumerableManual<Tuple<object>>(source);
            array2 = new DynamicEnumerableManual<Tuple<object>>(source);

            var counter = 0;
            foreach (var item in array)
                Assert.AreSame(item, source[counter++], "DynamicEnumerableManualTest2. The input source and result array' element are different (IEnumerable<>)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicEnumerableManualTest2. Size of input source and result array is different (IEnumerable<>)");

            counter = 0;
            foreach (var item in array2)
                Assert.AreSame(item, source[counter++], "DynamicEnumerableManualTest2. The input source and result array' element are different (IEnumerable)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicEnumerableManualTest2. Size of input source and result array is different (IEnumerable)");
        }

        [TestMethod]
        public void DynamicListTest()
        {
            IList<string> array = new DynamicList<string>();
            foreach (var item in array)
                Assert.Fail("DynamicListTest. Empty array can not be iterrate (IList<>)");

            array.Add("one");
            array.Add("two");
            Assert.AreEqual(array.Count, 2, "DynamicListTest. Items count must be equal 1");
            Assert.AreEqual(array[0], "one", "DynamicListTest. First element must be equal 'one'");
            Assert.AreEqual(array[1], "two", "DynamicListTest. First element must be equal 'two'");

            Assert.AreEqual(array.Contains("one"), true, "DynamicListTest. Array must contain element 'one'");
            Assert.AreEqual(array.Contains("three"), false, "DynamicListTest. Array must not contain element 'three'");

            string[] dest = null;
            array.CopyTo(dest, 0);
            Assert.IsNotNull(dest, "DynamicListTest. Destination arrays must not be null");
            Assert.AreEqual(array.Count, dest.Length, "DynamicListTest. Source and destination arrays must be equal");
            Assert.AreEqual(array[0], dest[0], "DynamicListTest. First element of source and destination arrays must be equal");
            Assert.AreEqual(array[1], dest[1], "DynamicListTest. First element of Source and destination arrays must be equal");

            Assert.AreEqual(array.IndexOf("one"), 0, "DynamicListTest. Index of 'one' element must be 0");
            Assert.AreEqual(array.IndexOf("three"), -1, "DynamicListTest. Index of 'three' element must be -1");

            array.Insert(0, "zero");
            Assert.AreEqual(array[0], "zero", "DynamicListTest. First element must be equal 'zero'");

            array.Remove("one");
            Assert.AreEqual(array[1], "two", "DynamicListTest. Second element must be equal 'two'");

            array.RemoveAt(0);
            Assert.AreEqual(array.Count, 1, "DynamicListTest. Items count must be equal 1");
            Assert.AreEqual(array[0], "two", "DynamicListTest. First element must be equal 'two'");

            array.Clear();
            Assert.AreEqual(array.Count, 0, "DynamicListTest. Items count must be equal 0");
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            IntSortTest((list) => { return SortedAlhorithms.BubbleSort<int>(list); });
        }

        [TestMethod]
        public void BubbleLikeSortTest()
        {
            IntSortTest((list) => { return SortedAlhorithms.BubbleLikeSort<int>(list); });
        }

        [TestMethod]
        public void QuickSortTest()
        {
            IntSortTest((list) => { return SortedAlhorithms.QuickSort<int>(list); });
        }

        void IntSortTest(Func<IList<int>, IList<int>> sortFunc)
        {
            var input = new List<int> { 3, 5, 2, 5, 7, 0 };
            var etalon = new List<int> { 0, 2, 3, 5, 5, 7 };
            var result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 1");

            input = new List<int> { 9, 9, 2, 0, 0, 5 };
            etalon = new List<int> { 0, 0, 2, 5, 9, 9 };
            result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 2");

            input = new List<int> { 3, 2, 1 };
            etalon = new List<int> { 1, 2, 3 };
            result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 3");

            input = new List<int> { 1, 2, 3 };
            etalon = new List<int> { 1, 2, 3 };
            result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 4");

            input = new List<int> { 1, 1, 0 };
            etalon = new List<int> { 0, 1, 1 };
            result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 5");

            input = new List<int> { 1, 0, 1 };
            etalon = new List<int> { 0, 1, 1 };
            result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 6");

            input = new List<int> { 0, 1, 2, 0, 0 };
            etalon = new List<int> { 0, 0, 0, 1, 2 };
            result = sortFunc(input);
            Assert.IsTrue(result.SequenceEqual(etalon), "Uncorrect result 7");
        }
    }
}
