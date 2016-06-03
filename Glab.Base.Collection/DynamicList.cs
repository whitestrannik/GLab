using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glab.Base.Collection
{
    public class DynamicList<T> : IList<T>, IList
    {
        public DynamicList()
        {
            _capasity = CalcCapasity(0);
            _count = 0;
            _array = new T[_capasity];
        }

        #region IList impl

        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        object IList.this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = (T)value; }
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public int Add(object value)
        {
            Add((T)value);
            return _count - 1;
        }

        public void Add(T item)
        {
            if (_count < _capasity)
                _array[_count++] = item;
            else
            {
                _capasity = CalcCapasity(_capasity);
                _array = CreateNewArray(_array, _capasity);
                _array[_count++] = item;
            }
        }       

        public void Clear()
        {
            _capasity = CalcCapasity(5);
            _array = CreateNewArray(new T[0], _capasity);
        }

        public bool Contains(object value)
        {
            return _array.Where((item) => { return Equals(value); }).Count() != 0;
        }

        public bool Contains(T item)
        {
            return _array.Where((i) => { return Equals(item); }).Count() != 0;
        }

        public void CopyTo(Array array, int index)
        {
            _array.CopyTo(array, index);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _array.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < _count; i++)
                yield return _array[i];
        }

        public int IndexOf(object value)
        {
            return IndexOf((T)value);           
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
                if (Equals(item))
                    return i;

            return -1;
        }

        public void Insert(int index, object value)
        {
            Insert(index, (T)value);
        }

        private void MoveElements(T[] array, int fromIndex, int toIndex, int length)
        {
            if (length>0)
                for (int i = 0; i < toIndex - fromIndex + 1; i++)
                    array[toIndex + length - i] = array[toIndex - i];
            else
                for (int i = 0; i < toIndex - fromIndex + 1; i++)
                    array[fromIndex - i] = array[fromIndex];
        }

        public void Insert(int index, T item)
        {
            if (_count + 1 > _capasity)
            {
                _capasity = CalcCapasity(_capasity);
                _array = CreateNewArray(_array, _capasity);
            }

            MoveElements(_array, index, _count - 1, 1);
            _array[index] = item;
            _count++;
        }

        public void Remove(object value)
        {
            Remove((T)value);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;

            RemoveAt(index);
            return true;           
        }

        public void RemoveAt(int index)
        {
            MoveElements(_array, index+1, _count - 1, -1);            
            _count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in _array)
                yield return item;
        }

        #endregion



        #region private

        T[] _array;
        int _count;
        int _capasity;

        int CalcCapasity(int capasity)
        {
            return capasity + capasity / 2 + 1;
        }

        private T[] CreateNewArray(Array source, int capasity)
        {
            T[] newArray = new T[capasity];
            Array.Copy(source, newArray, source.Length);
            return newArray;
        }

        #endregion
    }
}
