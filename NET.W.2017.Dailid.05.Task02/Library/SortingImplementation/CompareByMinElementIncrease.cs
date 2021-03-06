﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.SortingImplementation
{
    public class CompareByMinElementIncrease : IComparer<int[]>
    {
        /// <summary>
        /// This method Compare two array by min element increasing 
        /// </summary>
        /// <param name="x">first array</param>
        /// <param name="y">second array</param>
        /// <returns>1: x bigger then y
        /// 0: x equals y
        /// -1: x less then y
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            int result = -1;

            if (x == null && y != null)
                return -1;
            if (y == null && x != null)
                return 1;

            if (x.Min() > y.Min())
                result = 1;
            if (x.Min() < y.Min())
                result = -1;
            if (x.Min() == y.Min())
                result = 0;

            return result;

        }
    }
}
