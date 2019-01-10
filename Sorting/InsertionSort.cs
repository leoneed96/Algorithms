using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class InsertionSort : BaseSortAlgorithm, ISortAlgorithm
    {
        public override string Title => "Insertion";

        //public int[] Sort(int[] data)
        //{
        //    Iterations = 0;
        //    var ret = new int[data.Length];
        //    ret[0] = data[0];
        //    for (int i = 1; i < data.Length; i++)
        //    {
        //        var insertingValue = data[i];
        //        // если больше последнего, вставляем в конец
        //        if (insertingValue > ret[i - 1])
        //            ret[i] = insertingValue;
        //        // найти куда вставить
        //        else
        //        {
        //            var idxToInsert = -1;
        //            if (ret[0] >= insertingValue)
        //                idxToInsert = 0;
        //            for (int j = 0; j < i; j++)
        //            {
        //                Iterations++;
        //                if (ret[j] <= insertingValue && ret[j + 1] >= insertingValue)
        //                {
        //                    idxToInsert = j + 1;
        //                    break;
        //                }
        //            }
        //            if (idxToInsert == -1)
        //                throw new Exception();
        //            // сдвинуть всё вправо на 1 за местом вставки
        //            for (int k = i; k > idxToInsert; k--)
        //            {
        //                Iterations++;
        //                ret[k] = ret[k-1];
        //            }
        //            ret[idxToInsert] = insertingValue;
        //        }
        //        Iterations++;
        //    }
        //    return ret;
        //}

        // без создания вспомогательного массива
        public override int[] Sort(int[] data)
        {
            var start = DateTime.Now;
            for (int i = 1; i < data.Length; i++)
            {
                var insertingValue = data[i];
                // если больше предудущего, оставляем как есть
                if (insertingValue > data[i - 1])
                    continue;
                // найти куда вставить
                else
                {
                    var idxToInsert = -1;
                    if (data[0] >= insertingValue)
                        idxToInsert = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (data[j] <= insertingValue && data[j + 1] >= insertingValue)
                        {
                            idxToInsert = j + 1;
                            break;
                        }
                    }
                    if (idxToInsert == -1)
                        throw new Exception("can't find correct insertion index");
                    // сдвинуть всё вправо на 1 за местом вставки
                    for (int k = i; k > idxToInsert; k--)
                    {
                        data[k] = data[k - 1];
                    }
                    data[idxToInsert] = insertingValue;
                }
            }
            TimeSpan = DateTime.Now - start;
            CheckSorted(data);
            return data;
        }

    }
}
