using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Misc.Castle
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMixinImple();
        }

        private static void TestMixinImple()
        {
            ProxyGenerator proxy = new ProxyGenerator();
            //GeneratorContext context = new GeneratorContext();

            //proxy.CreateClassProxy(typeof(MainEntity), new Type[] { typeof(MixinEntity) }, null);
        }
    }
}
