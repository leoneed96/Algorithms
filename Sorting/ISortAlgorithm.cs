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
        int Iterations { get; set; }
        IEnumerable<int> Sort(IEnumerable<int> data);
    }
}
