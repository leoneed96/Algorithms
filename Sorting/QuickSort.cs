using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class QuickSort : BaseSortAlgorithm, ISortAlgorithm
    {
        private Random _rnd;
        public QuickSort()
        {
            _rnd = new Random();
        }
        public override string Title => "Quick sort";

        public override int[] Sort(int[] data)
        {
            _quickSort(data, 0, data.Length - 1);
            CheckSorted(data);
            return data;
        }

        private void _quickSort(int[] data, int left, int right)
        {
            if (left > right)
                return;
            var pivotIdx = _rnd.Next(left, right);
            // переместим значение по опорному индексу в конец
            _swap(data, pivotIdx, right);
            for (int i = left; i < right; i++)
            {
                // TODO: запоминать индекс. и в следующем вызове не должно участвовать стоящее на месте значение после текущего вызова

                if (data[i] > data[right])
                    _swap(data, i, right);
            }
            _quickSort(data, 0, pivotIdx - 1);
            _quickSort(data, pivotIdx, data.Length -1);

        }

        private void _swap(int[] data, int from, int to)
        {
            var tmp = data[from];
            data[from] = data[to];
            data[to] = tmp;
        }

        //private int _move(int[] data, int left, int right, int pivot)
        //{
        //    var pivotVal = data[pivot];
        //}
    }
}
