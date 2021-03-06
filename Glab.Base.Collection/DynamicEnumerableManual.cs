﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glab.Base.Collection
{
    public class DynamicEnumerableManual<T> : IEnumerable<T>, IEnumerable
    {
        public DynamicEnumerableManual()
        {
            _elementCount = 0;
            _length = 7;
            _array = new T[_length];
        }

        public DynamicEnumerableManual(IEnumerable<T> array)
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
            return new DynamicEnumerableEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicEnumerableEnumerator<T>(this);
        }

        #region IEnumerator

        class DynamicEnumerableEnumerator<T> : IEnumerator<T>
        {           
            internal DynamicEnumerableEnumerator(DynamicEnumerableManual<T> source)
            {
                __index = 0;
                __source = source;
            }

            public T Current
            {
                get
                {
                    int i = __index++;
                    return __source._array[i];
                }
            }

            object IEnumerator.Current
            {
                get
                {                    
                    return Current;
                }
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return __index < __source._elementCount;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            DynamicEnumerableManual<T> __source;
            int __index;
        }

        #endregion


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
