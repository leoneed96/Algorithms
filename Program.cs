using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static Executor executor;
        static DataProvider provider;
        static Program()
        {
            executor = new Executor();
            provider = new DataProvider();
        }
        static void Main(string[] args)
        {
            Execute(new ISortAlgorithm[] { new BubbleSort(), new InsertionSort() }, provider);
        }

        static void Execute(IEnumerable<ISortAlgorithm> algorithms, DataProvider provider)
        {
            var data = provider.Provide(100).ToArray();
            foreach (var item in algorithms)
            {
                executor.Execute(item, data);
            }
            var key = Console.ReadKey();
            if (key.Key != ConsoleKey.Escape)
                Execute(algorithms, provider);
        }
    }
}
