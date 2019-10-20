using System;
using System.Collections;
using System.Collections.Generic;
using Glab.Base.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Glab.Test.Base
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void HeapMinTest_AddAndGetExtremum()
        {
            var input = new int[] { 8, 5, 3, 3, 7, 11, 6, 0};
            Heap<int> heap = new Heap<int>(input, 5, new HeapMinComparator());
            Assert.AreEqual(0, heap.GetExtremum());

            heap.Add(0);
            Assert.AreEqual(0, heap.GetExtremum());

            heap.Add(2);
            Assert.AreEqual(0, heap.GetExtremum());

            heap.Add(-2);
            Assert.AreEqual(-2, heap.GetExtremum());

            heap.Add(-1);
            Assert.AreEqual(-2, heap.GetExtremum());

            heap.Add(-2);
            Assert.AreEqual(-2, heap.GetExtremum());

            heap.Add(1000);
            Assert.AreEqual(-2, heap.GetExtremum());

            heap.Add(-5);
            Assert.AreEqual(-5, heap.GetExtremum());
        }

        [TestMethod]
        public void HeapMinTest_GetAndRemoveExtremum()
        {
            var input = new int[] { 8, 5, 3, 3, 7, 2, 11, 6, 0, 1, 7 };
            Heap<int> heap = new Heap<int>(input, 5, new HeapMinComparator());
            Assert.AreEqual(0, heap.GetAndRemoveExtremum());
            Assert.AreEqual(1, heap.GetAndRemoveExtremum());
            Assert.AreEqual(2, heap.GetAndRemoveExtremum());
            Assert.AreEqual(3, heap.GetAndRemoveExtremum());
            Assert.AreEqual(3, heap.GetAndRemoveExtremum());
            Assert.AreEqual(5, heap.GetAndRemoveExtremum());
            Assert.AreEqual(6, heap.GetAndRemoveExtremum());
            Assert.AreEqual(7, heap.GetAndRemoveExtremum());
            Assert.AreEqual(7, heap.GetAndRemoveExtremum());
            Assert.AreEqual(8, heap.GetAndRemoveExtremum());
            Assert.AreEqual(11, heap.GetAndRemoveExtremum());
            Assert.IsTrue(heap.IsEmpty);
        }

        public class HeapMinComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == y)
                {
                    return 0;
                }
                else if (x > y)
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}
