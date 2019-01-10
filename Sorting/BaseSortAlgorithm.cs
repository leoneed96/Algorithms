using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public abstract class BaseSortAlgorithm : ISortAlgorithm
    {
        public abstract string Title { get; }
        public TimeSpan TimeSpan { get; set; }
        public abstract int[] Sort(int[] data);
        public void CheckSorted(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] > data[i + 1])
                    throw new Exception("invalid sort order");
            }
        }
    }
}
