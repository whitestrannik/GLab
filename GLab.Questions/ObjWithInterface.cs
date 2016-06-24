using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Questions
{
    public class ObjWithInterface : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Base Dispose impl");
        }

        void IDisposable.Dispose()
        {
            Console.WriteLine("Base explicit Dispose impl");
        }
    }

    public class DerivedObjWithInterface : ObjWithInterface, IDisposable
    {
        //void IDisposable.Dispose()
        //{
        //    Console.WriteLine("Derived explicit Dispose impl");
        //}
    }
}
