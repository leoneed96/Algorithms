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
        public Task Execute(ISortAlgorithm algorithm, int[] data)
        {
            var forTask = new int[data.Length];
            Array.Copy(data, forTask, data.Length);

            return new Task(() =>
           {
               var sorted = algorithm.Sort(forTask);
               Console.WriteLine($"*** Algorithm:{algorithm.Title} completed in {algorithm.TimeSpan.TotalMilliseconds} ms ***");
           });
            
        }
    }
}
