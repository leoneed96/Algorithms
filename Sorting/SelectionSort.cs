using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class SelectionSort : BaseSortAlgorithm, ISortAlgorithm
    {
        public override string Title => "Selection sort";

        public override int[] Sort(int[] data)
        {
            var start = DateTime.Now;
            // найти локальный минимум
            var min = new Extremum(0, data[0]);
            var currentPosition = 0;
            do
            {
                // минимальный элемент - на текущей позиции
                min.value = data[currentPosition];
                min.index = currentPosition;
                // ищем минимальный
                for (int i = currentPosition; i < data.Length; i++)
                {
                    if (data[i] < min.value)
                    {
                        min.value = data[i];
                        min.index = i;
                    }
                }
                // минимальный ставим на текущую позицию, а элемент с текущей позиции в индекс минимального
                var tmp = data[currentPosition];
                data[currentPosition] = min.value;
                data[min.index] = tmp;
                currentPosition++;
            }
            while (currentPosition < data.Length);
            TimeSpan = DateTime.Now - start;
            CheckSorted(data);
            return data;
        }

        struct Extremum
        {
            public Extremum(int idx, int val)
            {
                value = val;
                index = idx;
            }
            public int value;
            public int index;
        }
    }
}
