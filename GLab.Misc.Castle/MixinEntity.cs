using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Castle
{
    public class MixinEntity : IMixinEntity
    {
        public void Do()
        {
            Console.WriteLine("MixinEntity");
        }
    }
}
