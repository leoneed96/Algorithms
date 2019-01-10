using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BubbleSort : BaseSortAlgorithm, ISortAlgorithm
    {
        public override string Title => "Bubble sort";

        public override int[] Sort(int[] data)
        {
            var start = DateTime.Now;
            bool isSorted = true;
            do
            {
                isSorted = true;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        var next = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = next;
                        isSorted = false;
                    }
                    data[i + 1] = data[i + 1] > data[i] ? data[i + 1] : data[i];
                }
            }
            while (isSorted == false);
            TimeSpan = DateTime.Now - start;
            CheckSorted(data);
            return data;
        }
    }
}
