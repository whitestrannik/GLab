using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glab.Base.Collection;
using System.Collections.Generic;
using System.Collections;

namespace Glab.Test.Base
{
    [TestClass]
    public class CollectionTest
    {
        [TestMethod]
        public void DynamicArrayTest()
        {
            List<string> source = new List<string> { "One", "Two", "Three" };
            DynamicArray<string> array = new DynamicArray<string>(source);

            int counter = 0;
            var enumerator = array.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    Assert.AreEqual(enumerator.Current, source[counter++], $"DynamicArrayTest. Elements are not equal");
            }
            finally
            {
                enumerator.Dispose();
            }

            Assert.AreEqual<int>(source.Count, counter, "DynamicArrayTest. Size of input source and result array is different");
        }

        [TestMethod]
        public void DynamicArrayTest2()
        {
            IEnumerable<Tuple<object>> array = new DynamicArray<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicArrayTest2. Empty array can not be iterrate (IEnumerable<>)");

            IEnumerable array2 = new DynamicArray<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicArrayTest2. Empty array can not be iterrate (IEnumerable)");



            List<Tuple<object>> source = new List<Tuple<object>> { new Tuple<object>("str1"), new Tuple<object>("str2") };
            array = new DynamicArray<Tuple<object>>(source);
            array2 = new DynamicArray<Tuple<object>>(source);

            var counter = 0;
            foreach (var item in array)
                Assert.AreSame(item, source[counter++], "DynamicArrayTest. The input source and result array' element are different (IEnumerable<>)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicArrayTest. Size of input source and result array is different (IEnumerable<>)");

            counter = 0;
            foreach (var item in array2)
                Assert.AreSame(item, source[counter++], "DynamicArrayTest. The input source and result array' element are different (IEnumerable)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicArrayTest. Size of input source and result array is different (IEnumerable)");
        }



        [TestMethod]
        public void DynamicArrayManualTest()
        {
            List<string> source = new List<string> { "One", "Two", "Three" };
            DynamicArrayManual<string> array = new DynamicArrayManual<string>(source);

            int counter = 0;
            var enumerator = array.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    Assert.AreEqual(enumerator.Current, source[counter++], $"DynamicArrayManualTest. Elements are not equal");
            }
            finally
            {
                enumerator.Dispose();
            }
            Assert.AreEqual<int>(source.Count, counter, "DynamicArrayManualTest. Size of input source and result array is different");



            array = new DynamicArrayManual<string>();
            try
            {
                while (enumerator.MoveNext())
                    Assert.Fail("DynamicArrayManualTest. Empty array can not be iterrate (IEnumerable<>)");
            }
            finally
            {
                enumerator.Dispose();
            }
        }

        [TestMethod]
        public void DynamicArrayManualTest2()
        {
            IEnumerable<Tuple<object>> array = new DynamicArrayManual<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicArrayManualTest2. Empty array can not be iterrate (IEnumerable<>)");

            IEnumerable array2 = new DynamicArrayManual<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("DynamicArrayManualTest2. Empty array can not be iterrate (IEnumerable)");



            List<Tuple<object>> source = new List<Tuple<object>> { new Tuple<object>("str1"), new Tuple<object>("str2") };
            array = new DynamicArrayManual<Tuple<object>>(source);
            array2 = new DynamicArrayManual<Tuple<object>>(source);

            var counter = 0;
            foreach (var item in array)
                Assert.AreSame(item, source[counter++], "DynamicArrayManualTest2. The input source and result array' element are different (IEnumerable<>)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicArrayManualTest2. Size of input source and result array is different (IEnumerable<>)");

            counter = 0;
            foreach (var item in array2)
                Assert.AreSame(item, source[counter++], "DynamicArrayManualTest2. The input source and result array' element are different (IEnumerable)");

            Assert.AreEqual<int>(source.Count, counter, "DynamicArrayManualTest2. Size of input source and result array is different (IEnumerable)");
        }
    }
}
