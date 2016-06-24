using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLab.Questions
{
    public struct StructWithInterface : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
