using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            Reactive();

            //Test();
            //UseMutableStruct();
            //UseTestStruct();
            //UseObjWithInterface();
            //UseGenericTest();

            Console.ReadLine();
        }

        private static void Reactive()
        {
            var o = new Observerables();
            o.Do();
        }

        private static void Test()
        {
            uint i = 100, j = 100;
            ulong diff = 0;

            while (i > 0)
            {
                j = i - 1;
                while (j > 0)
                {
                    diff = diff + 2 * i * j;
                    j--;
                }
                i--;
            }
        }

        private static void UseGenericTest()
        {
            GenericObj<int> go = new GenericObj<int>();
            GenericObj<int> go2 = new GenericObj<int>();
            GenericObjDerived<float> god = new GenericObjDerived<float>();
        }

        private static void UseObjWithInterface()
        {
            using (DerivedObjWithInterface obj = new DerivedObjWithInterface())
            { }

            using (IDisposable obj = new DerivedObjWithInterface())
            { }

            DerivedObjWithInterface obj1 = new DerivedObjWithInterface();
            obj1.Dispose();
        }

        private static void UseTestStruct()
        {
            TestStruct t1 = new TestStruct(), t2 = new TestStruct();
            if (t1 == t2) return;

            object o = t1;

            
            if (o.Equals(t2)) ;

        }

        private static void UseMutableStruct()
        {
            ClassWithMutableStructure a = new ClassWithMutableStructure();
            a.ValueField.Change();
            Debug.Assert(a.ValueField.i == 1);

            var copyVal = a.ValueField;
            copyVal.Change();
            Debug.Assert(a.ValueField.i == 1);
            Debug.Assert(copyVal.i == 2);


            a = new ClassWithMutableStructure();
            a.ValueProperty.Change();
            Debug.Assert(a.ValueProperty.i == 1);
        }
    }


}
