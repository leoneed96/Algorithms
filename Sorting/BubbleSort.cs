using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BubbleSort : ISortAlgorithm
    {
        public string Title => "Bubble sort";

        public int Iterations { get; set; } = 0;

        public IEnumerable<int> Sort(IEnumerable<int> data)
        {
            Iterations = 0;
            var arr = data.ToArray();
            bool isSorted = true;
            do
            {
                isSorted = true;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        var next = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = next;
                        isSorted = false;
                    }
                    arr[i + 1] = arr[i + 1] > arr[i] ? arr[i + 1] : arr[i];
                    Iterations++;
                }
            }
            while (isSorted == false);
            return arr;
        }
    }
}
