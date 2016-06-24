using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Questions
{
    public struct MutableStruct
    {
        public int i;

        public void Change()
        {
            i = i + 1;
        }
    }

    public class ClassWithMutableStructure
    {
        public MutableStruct ValueField;

        public MutableStruct ValueProperty { get; set; }
    }
}
