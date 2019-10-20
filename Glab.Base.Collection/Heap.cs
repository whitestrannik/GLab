using System;
using System.Collections.Generic;

namespace Glab.Base.Collection
{
    public class Heap<T>
    {
        private T[] _array;
        private int _count;
        private readonly IComparer<T> _comparer;

        public Heap(T[] input, int size, IComparer<T> comparer)
        {
            var arraySize = Math.Max(input == null? 0 : input.Length, size);

            _array = new T[arraySize];

            _comparer = comparer;

            foreach (var item in input)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            if (_count == _array.Length)
            {
                var newArray = new T[2 * _array.Length];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
            }

            AddInternal(value);
        }

        public bool IsEmpty => _count == 0;

        public T GetExtremum()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            return _array[0];
        }

        public T GetAndRemoveExtremum()
        {
            var extremum = GetExtremum();

            _array[0] = _array[_count - 1];
            _count--;

            var index = 0;
            while (true)
            {
                var nextElementIndex = GetMaxChildIndex(index);
                if (nextElementIndex == -1 || _comparer.Compare(_array[nextElementIndex], _array[index]) < 0)
                {
                    break;
                }
                else
                {
                    SwapValues(index, nextElementIndex);
                    index = nextElementIndex;
                }
            }

            return extremum;
        }

        private int GetMaxChildIndex(int index)
        {
            var leftIndex = GetLeftChildIndex(index);
            var rightIndex = GetRightChildIndex(index);
            if (leftIndex >= _count)
            {
                return -1;
            }
            else if (leftIndex < _count && rightIndex >= _count)
            {
                return leftIndex;
            }
            else
            {
                return _comparer.Compare(_array[leftIndex], _array[rightIndex]) > 0 ? leftIndex : rightIndex;
            }
        }


        private void AddInternal(T value)
        {
            var index = _count;
            _array[index] = value;
            _count++;

            var parentIndex = GetParentIndex(index);
            while (parentIndex >= 0 && _comparer.Compare(value, _array[parentIndex]) > 0)
            {
                SwapValues(parentIndex, index);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        private void SwapValues(int parentIndex, int index)
        {
            var temp = _array[parentIndex];
            _array[parentIndex] = _array[index];
            _array[index] = temp;
        }

        private int GetParentIndex(int childIndex)
        {
            if (childIndex == 0)
            {
                return -1;
            }

            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private T GetParentValue(int childIndex)
        {
            return _array[(childIndex - 1) / 2];
        }

        private T GetLeftChildValue(int parentIndex)
        {
            return _array[parentIndex * 2 + 1];
        }

        private T GetRightChildValue(int parentIndex)
        {
            return _array[parentIndex * 2 + 2];
        }
    }
}
