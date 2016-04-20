using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glab.Base.Collection
{
    public class DynamicEnumerable<T> : IEnumerable<T>, IEnumerable
    {
        public DynamicEnumerable()
        {
            _elementCount = 0;
            _length = 7;
            _array = new T[_length];
        }

        public DynamicEnumerable(IEnumerable<T> array)
        {
            _length = GetEnumerableLength(array);
            _elementCount = _length;            
            _array = new T[_length];

            int index = 0;
            foreach (var item in array)
                _array[index++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var index = 0; index < _elementCount; index++)
                yield return _array[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var index = 0; index < _elementCount; index++)
                yield return _array[index];
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
