using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class InsertionSort : ISortAlgorithm
    {
        public string Title => "Insertion";

        public int Iterations { get; set; }

        public IEnumerable<int> Sort(IEnumerable<int> data)
        {
            Iterations = 0;
            var arr = data.ToArray();
            var ret = new int[arr.Length];
            ret[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                var insertingValue = arr[i];
                // если больше последнего, вставляем в конец
                if (insertingValue > ret[i - 1])
                    ret[i] = insertingValue;
                // найти куда вставить
                else
                {
                    var idxToInsert = -1;
                    if (ret[0] >= insertingValue)
                        idxToInsert = 0;
                    for (int j = 0; j < i; j++)
                    {
                        Iterations++;
                        if (ret[j] <= insertingValue && ret[j + 1] >= insertingValue)
                        {
                            idxToInsert = j + 1;
                            break;
                        }
                    }
                    if (idxToInsert == -1)
                        throw new Exception();
                    // сдвинуть всё вправо на 1 за местом вставки
                    for (int k = i; k > idxToInsert; k--)
                    {
                        Iterations++;
                        ret[k] = ret[k-1];
                    }
                    ret[idxToInsert] = insertingValue;
                }
                Iterations++;
            }
            return ret;
        }

    }
}
