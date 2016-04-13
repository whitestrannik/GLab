using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glab.Base.Collection
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable
    {
        public DynamicArray()
        {
            _elementCount = 0;
            _length = 7;
            _array = new T[_length];
        }

        public DynamicArray(IEnumerable<T> array)
        {
            _length = GetEnumerableLength(array);
            _elementCount = _length;            
            _array = new T[_length];

            int index = 0;
            foreach (var item in array)
                _array[++index] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        #region private

        T[] _array;
        int _elementCount;
        int _length;

        private int GetEnumerableLength(IEnumerable array)
        {
            if (array == null) return 0;

            int count = 0;
            foreach (var item in array)
                count++;

            return count;
        }

        #endregion
    }
}
