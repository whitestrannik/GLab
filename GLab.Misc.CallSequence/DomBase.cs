using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.CallSequence
{
    internal class DomBase
    {
        internal DomBase()
        {
            Console.WriteLine("DomBase cons.");
            VirtFunc();
        }

        static DomBase()
        {
            Console.WriteLine("DomBase static cons.");            
        }

        StrObj _prop1 = new StrObj("DomBase");
        //internal string Prop1
        //{
        //    get { return _prop1; }
        //    set
        //    {
        //        _prop1 = value;
        //        Console.WriteLine("DomBase Prop1 property set.");
        //    }
        //} 

        protected class StrObj
        {
            internal StrObj(string val)
            {
                Console.WriteLine($"{val}.StrObj cons.");
            }

            string PropStr { get; set; }
        }

        protected virtual void VirtFunc()
        {
            Console.WriteLine("DomBase VirtFunc.");
        }
    }
}
