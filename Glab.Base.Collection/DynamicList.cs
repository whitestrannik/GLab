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
            throw new NotImplementedException();
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

        private T[] CreateNewArray(Array source, int capasity)
        {            
            T[] newArray = new T[capasity];
            Array.Copy(source, newArray, source.Length);
            return newArray;
        }

        public void Clear()
        {
            _capasity = CalcCapasity(5);
            _array = CreateNewArray(new T[0], _capasity);
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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

        #endregion
    }
}
