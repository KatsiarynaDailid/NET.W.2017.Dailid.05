using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Adapter : IComparer<int[]>
    {
        private Comparison<int[]> comparer;

        public Adapter(Comparison<int[]> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(int[] x, int[] y)
        {
            return comparer(x, y);
        }
    }
}
