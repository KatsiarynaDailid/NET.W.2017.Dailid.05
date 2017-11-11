using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class SortJaggedArray
    {
        /// <summary>
        /// Sort Jagged Array using IComparer
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <param name="comparer">Interface reference</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            Verify(array, comparer);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        public static void SortUsingDelegate(int[][] array, Comparison<int[]> comparer)
        {
            Adapter adapter = new Adapter(comparer);
            Sort(array, adapter);
        }

            #region Private

            private static void Verify(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null || comparer == null)
                throw new ArgumentNullException("Parameter cannot be null");
        }

        private static void Swap(ref int[] i, ref int[] j)
        {
            var temp = i;
            i = j;
            j = temp;
        }

        #endregion
    }
}
