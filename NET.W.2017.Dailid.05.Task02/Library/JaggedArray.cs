using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Implementation without interfaces usage
    /// </summary>
    public static class JaggedArray
    {
        /// <summary>
        /// This method sorts jagged array by increasing of the matrix row sum, using bubble sort
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted jagged array</returns>
        public static void BubbleSortBySumIncrease(int[][] array)
        {
            Verify(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (CountTheSumOfArray(array[i]) > CountTheSumOfArray(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);                     
                    }
                }
            }
        }

        /// <summary>
        /// This method sorts jagged array by decreasing of the matrix row sum, using bubble sort
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted jagged array</returns>
        public static void BubbleSortBySumDecrease(int[][] array)
        {
            Verify(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (CountTheSumOfArray(array[i]) < CountTheSumOfArray(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// This method sorts jagged array by increasing of the matrix row max elements, using bubble sort
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted jagged array</returns>
        public static void BubbleSortByMaxElementIncrease(int[][] array)
        {
            Verify(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (FindMaxElement(array[j]) < FindMaxElement(array[i]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// This method sorts jagged array by decreasing of the matrix row max elements, using bubble sort
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted jagged array</returns>
        public static void BubbleSortByMaxElementDecrease(int[][] array)
        {
            Verify(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (FindMaxElement(array[j]) > FindMaxElement(array[i]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// This method sorts jagged array by increasing of the matrix row min elements, using bubble sort
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted jagged array</returns>
        public static void BubbleSortByMinElementIncrease(int[][] array)
        {
            Verify(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (FindMinElement(array[j]) > FindMinElement(array[i]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// This method sorts jagged array by decreasing of the matrix row min elements, using bubble sort
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted jagged array</returns>
        public static void BubbleSortByMinElementDecrease(int[][] array)
        {
            Verify(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (FindMinElement(array[j]) < FindMinElement(array[i]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        #region Private

        private static void Verify(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException("Parameter cannot be null");
        }

        private static void Swap(ref int[] i, ref int[] j)
        {
            var temp = i;
            i = j;
            j = temp;
        }

        private static int CountTheSumOfArray(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                checked
                {
                    sum += array[i];
                }
            }

            return sum;
        }

        private static int FindMaxElement(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            return max;
        }

        private static int FindMinElement(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }

            return min;
        }

        #endregion
    }
}
