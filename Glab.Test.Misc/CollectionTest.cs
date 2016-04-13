using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Glab.Base.Collection;
using System.Collections.Generic;

namespace Glab.Test.Misc
{
    [TestClass]
    public class CollectionTest
    {
        [TestMethod]
        public void DynamicArrayTest()
        {
            IEnumerable<Tuple<object>> array = new DynamicArray<Tuple<object>>();
            foreach (var item in array)
                Assert.Fail("Empty array can not be iterrate");

            List<Tuple<object>> source = new List<Tuple<object>> { new Tuple<object>("str1"), new Tuple<object>("str2") };
            array = new DynamicArray<Tuple<object>>(source);

            var count = 0;
            foreach (var item in array)
                Assert.AreSame(item, source[++count], "The input source and result array' element are different");

            Assert.AreEqual<int>(source.Count, count, "Size of input source and result array is different");
        }
    }
}
