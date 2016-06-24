using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glab.Base.Collection
{
    public class Dequeue<T>
    {
        public Dequeue()
        {
            _size = 0;
            _length = 0;
            _head = 0;
            _tail = -1;
            _array = new T[0];
        }

        public void EnqueueFirst(T value)
        {
            if (_length == _array.Length)
                ExtendedArraySize();

            if (_head == 0)
            {
                _head = _size - 1;
                _array[_head] = value;
            }
            else
                _array[--_head] = value;
        }

        private void ExtendedArraySize()
        {
            
        }

        public void EnqueueLast(T value)
        {
            if (_length == _array.Length)
                ExtendedArraySize();

            if (_taill == 0)
            {
                _head = _size - 1;
                _array[_head] = value;
            }
            else
                _array[--_head] = value;
        }

        #region private

        int _size;
        int _head;
        int _tail;
        int _length;

        T[] _array;

        #endregion

    }
}
