using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSort : BaseSortAlgorithm, ISortAlgorithm
    {
        public override string Title => "Merge sort";

        public override int[] Sort(int[] data)
        {
            var start = DateTime.Now;
            DivideAndMerge(data);
            TimeSpan = DateTime.Now - start;
            CheckSorted(data);
            return data;
        }

        void DivideAndMerge(int[] data)
        {
            if (data.Length <= 1)
                return;
            var leftSize = data.Length / 2;
            var rightSize = data.Length - leftSize;

            var leftArr = new int[leftSize];
            var rightArr = new int[rightSize];
            Array.Copy(data, leftArr, leftSize);
            Array.Copy(data, leftSize, rightArr, 0, rightSize);
            // будем делить, пока не получим массивы из одного элемента
            DivideAndMerge(leftArr);
            DivideAndMerge(rightArr);
            Merge(data, leftArr, rightArr);
            
        }

        void Merge(int[] source, int[] left, int[] right)
        {
            var itemsToMergeLength = left.Length + right.Length;
            int mainIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;
            while (mainIdx < itemsToMergeLength)
            {
                // рассовали весь левый массив - берем из правого
                if (leftIdx >= left.Length)
                    source[mainIdx] = right[rightIdx++];
                else if (rightIdx >= right.Length)
                    source[mainIdx] = left[leftIdx++];
                // если в обоих массивах есть элемент - берем меньший
                else
                    source[mainIdx] = left[leftIdx] < right[rightIdx] ? left[leftIdx++] : right[rightIdx++];
                mainIdx++;
            }
        }
    }
}
