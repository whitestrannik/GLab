using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Questions
{
    public struct TestStruct
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(TestStruct obj)
        {
            return Id == obj.Id;
        }

        public static bool operator ==(TestStruct t1, TestStruct t2)
        {
            return t1.Id == t2.Id;
        }

        public static bool operator !=(TestStruct t1, TestStruct t2)
        {
            return !(t1 == t2);
        }
    }
}
