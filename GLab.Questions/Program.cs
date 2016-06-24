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
            //UseMutableStruct();
            //UseTestStruct();
            UseObjWithInterface();

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
            //if (t1 == t2) return;
            if (null == null) ;
            if (t1.Equals(t2)) return;
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
