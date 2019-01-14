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
            //Execute(new ISortAlgorithm[] 
            //{
            //    new BubbleSort(),
            //    new InsertionSort(),
            //    new SelectionSort(),
            //    new MergeSort(),
            //    new QuickSort()
            //}, 
            //provider);
        }

        static void Execute(IEnumerable<ISortAlgorithm> algorithms, DataProvider provider)
        {
            var data = provider.Provide(10).ToArray();
            Task[] tasks = new Task[algorithms.Count()];
            var idx = 0;
            foreach (var item in algorithms)
            {
                tasks[idx] = executor.Execute(item, data);
                tasks[idx].Start();
                idx++;
            }
            Task.WaitAll(tasks);
            Console.WriteLine("all completed");

            var str = Console.ReadLine();
            if (str != "exit")
            {
                Console.WriteLine("***************");
                Execute(algorithms, provider);
            }
            
        }
    }
}
