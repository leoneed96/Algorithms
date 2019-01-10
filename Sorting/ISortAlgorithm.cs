using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public interface ISortAlgorithm
    {
        string Title { get; }
        TimeSpan TimeSpan { get; set; }
        int[] Sort(int[] data);
    }
}
