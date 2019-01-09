using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class DataProvider
    {
        Random random;
        public DataProvider()
        {
            random = new Random();
        }
        public IEnumerable<int> Provide(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return random.Next(0, count);
            }
        }
    }
}
