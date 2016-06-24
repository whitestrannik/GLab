using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glab.Base.Collection
{
    public static class SortedAlhorithms
    {
        public static IList<T> BubbleSort<T>(IList<T> list) where T : IComparable<T>
        {
            if (list == null) return null;

            List<T> result = new List<T>(list);

            for (int i = 0; i < result.Count-1; i++)
                for (int j = 0; j < result.Count-1-i; j++)
                    if (result[j].CompareTo(result[j + 1]) > 0)
                        Swap<T>(result, j, j + 1);

            return result;
        }

        public static IList<T> BubbleLikeSort<T>(IList<T> list) where T : IComparable<T>
        {
            if (list == null) return null;

            List<T> result = new List<T>(list);

            for (int i = 1; i < result.Count; i++)
                for (int j = i; j > 0; j--)
                    if (result[j - 1].CompareTo(result[j]) > 0)
                        Swap<T>(result, j - 1, j);
                    else break;

            return result;
        }

        public static IList<T> InsertionSort<T>(IList<T> list) where T: IComparable<T>
        {
            List<T> result = new List<T>(list);

            for (int i = 1; i < result.Count; i++)
            {
                int j = i;
                // i - элемент, который нужно отсортировать. Все что слева - уже отсортировано
                //Перемещаем послдедовательно влево, покане найдем элемент, который меньше исходного
                while (j > 0 && result[j].CompareTo(result[j-1]) < 0)
                {
                    Swap<T>(result, j, j-1);
                    j--;
                }
            }

            return result;
        }

        public static IList<T> SelectionSort<T>(IList<T> list) where T: IComparable<T>
        {
            var result = new List<T>(list);

            for (int i = 0; i < result.Count; i++)
            {
                int minIndex = i;
                for (int j = i; j < result.Count; j++)
                {
                    if (result[j].CompareTo(result[minIndex]) < 0)
                        minIndex = j;
                }

                Swap<T>(result, i, minIndex);
            }

            return result;
        }


        public static IList<T> MergeSort<T>(IList<T> list) where T : IComparable<T>
        {
            if (list == null) return null;

            List<T> result = new List<T>(list);

            MergeSortInternal(result, 0, result.Count);
            

            return result;
        }

        private static void MergeSortInternal<T>(List<T> result, int from, int to) where T : IComparable<T>
        {
            int count = to - from;
            if (count == 1) return;

            MergeSortInternal(result, 0, count % 2 - 1);
            MergeSortInternal(result, count%2, count - 1);

            MergeSortMerge<T>(result, from, to);
        }

        private static void MergeSortMerge<T>(List<T> result, int from, int to) where T : IComparable<T>
        {
            int leftCount = (to - from) % 2;
            int rightCount = to - leftCount;
            int leftIndex = 0;
            int rightIndex = 0;
            int currentIndex = from;

            while (currentIndex <= to)
            {
                if (leftIndex == leftCount - 1)
                    Swap(result, from + currentIndex, rightIndex++);
                else if (rightIndex == rightCount - 1)
                    Swap(result, from + currentIndex, rightIndex++);
            }

        }


        public static IList<T> QuickSort<T>(IList<T> list) where T : IComparable<T>
        {
            if (list == null) return null;

            List<T> result = new List<T>(list);

            QuickSortInternal(result, 0, result.Count-1);

            return result;
        }

        private static void QuickSortInternal<T>(List<T> result, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex == endIndex) return;

            int pivotIndex = GetPivotIndex(result, startIndex, endIndex);
            int realPivotIndex = Partition(result, startIndex, endIndex, pivotIndex);

            QuickSortInternal(result, startIndex, realPivotIndex - 1);
            QuickSortInternal(result, pivotIndex+1, endIndex);
        }

        private static int Partition<T>(List<T> result, int startIndex, int endIndex, int pivotIndex) where T : IComparable<T>
        {            
            T pivot = result[pivotIndex];
            Swap(result, pivotIndex, endIndex);

            int currentIndex = startIndex;
            for (int i = startIndex; i < endIndex; i++)
                if (result[i].CompareTo(pivot) < 0)
                {
                    Swap<T>(result, i, currentIndex++);
                }                
                    
            Swap<T>(result, currentIndex, endIndex);
            return currentIndex;
        }

        private static int GetPivotIndex<T>(List<T> result, int startIndex, int endIndex) where T : IComparable<T>
        {
            return (startIndex + endIndex) / 2;
        }

        private static void Swap<T>(IList<T> list, int fromIndex, int toIndex) where T : IComparable<T>
        {
            T temp = list[toIndex];
            list[toIndex] = list[fromIndex];
            list[fromIndex] = temp;
        }
    }
}
