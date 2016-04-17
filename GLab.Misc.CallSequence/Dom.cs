using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.CallSequence
{
    internal class Dom : DomBase
    {
        internal Dom()
        {
            Console.WriteLine("Dom cons.");
            VirtFunc();
        }

        static Dom()
        {
            Console.WriteLine("Dom static cons.");
        }

        StrObj _prop2 = new StrObj("Dom");

        protected override void VirtFunc()
        {
            Console.WriteLine("Dom VirtFunc.");
        }
    }
}
