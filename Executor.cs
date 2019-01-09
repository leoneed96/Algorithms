using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Executor
    {
        public void Execute(ISortAlgorithm algorithm, IEnumerable<int> data)
        {
            Console.WriteLine($"*** Algorithm:{algorithm.Title} ***");
            Console.WriteLine("Unsorted:");
            foreach (var item in data)
            {
                Console.Write(item + ", ");
            }
            var sorted = algorithm.Sort(data);
            Console.WriteLine();
            Console.WriteLine("Sorted:");
            foreach (var item in sorted)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"Iterations: {algorithm.Iterations}");
            Console.WriteLine();
        }
    }
}
