using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.SortingImplementation;

namespace Library.Tests
{
    [TestClass]
    public class JaggedArrayTests
    {

        [TestMethod]
        public void BubbleSortBySumIncrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[4][];
            jArray[0] = new int[3] { 1, 3, 5 };
            jArray[1] = new int[2] { 2, 4 };
            jArray[2] = new int[4] { 2, 4, 6, 8 };
            jArray[3] = null;

            int[][] arrangeArray = new int[4][];
            arrangeArray[0] = null;
            arrangeArray[1] = new int[2] { 2, 4 };
            arrangeArray[2] = new int[3] { 1, 3, 5 };
            arrangeArray[3] = new int[4] { 2, 4, 6, 8 };


            #endregion

            SortJaggedArray.Sort(jArray, new CompareBySumIncrease());

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
            CollectionAssert.AreEqual(arrangeArray[3], jArray[3]);

        }

        [TestMethod]
        public void BubbleSortBySumDecrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[4][];
            jArray[0] = new int[3] { 1, 3, 5 };
            jArray[1] = new int[2] { 2, 4 };
            jArray[2] = new int[4] { 2, 4, 6, 8 };
            jArray[3] = null;

            int[][] arrangeArray = new int[4][];
            arrangeArray[0] = new int[4] { 2, 4, 6, 8 };
            arrangeArray[1] = new int[3] { 1, 3, 5 };
            arrangeArray[2] = new int[2] { 2, 4 };
            jArray[3] = null;

            #endregion

         //   SortJaggedArray.Sort(jArray, new CompareBySumDecrease());
            SortJaggedArray.SortUsingDelegate(jArray, new CompareBySumDecrease().Compare);

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
            CollectionAssert.AreEqual(arrangeArray[3], jArray[3]);
        }

        [TestMethod]
        public void BubbleSortByMaxElementIncrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[3][];
            jArray[0] = new int[3] { 1, 2, 5 };
            jArray[1] = new int[2] { 2, 1 };
            jArray[2] = new int[4] { 2, 4, -10, 8 };

            int[][] arrangeArray = new int[3][];
            arrangeArray[0] = new int[2] { 2, 1 };
            arrangeArray[1] = new int[3] { 1, 2, 5 };
            arrangeArray[2] = new int[4] { 2, 4, -10, 8 };

            #endregion

            SortJaggedArray.Sort(jArray, new CompareByMaxElementIncrease());

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
        }

        [TestMethod]
        public void BubbleSortByMaxElementDecrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[3][];
            jArray[0] = new int[3] { 1, 2, 5 };
            jArray[1] = new int[2] { 2, 1 };
            jArray[2] = new int[4] { 2, 4, -10, 8 };

            int[][] arrangeArray = new int[3][];
            arrangeArray[0] = new int[4] { 2, 4, -10, 8 };
            arrangeArray[1] = new int[3] { 1, 2, 5 };
            arrangeArray[2] = new int[2] { 2, 1 };

            #endregion

            SortJaggedArray.Sort(jArray, new CompareByMaxElementDecrease());

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
        }

        [TestMethod]
        public void BubbleSortByMinElementIncrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[3][];
            jArray[0] = new int[4] { 2, 4, -10, 8 };
            jArray[1] = new int[2] { -2, 1 };
            jArray[2] = new int[3] { 1, 2, 5 };

            int[][] arrangeArray = new int[3][];
            arrangeArray[0] = new int[4] { 2, 4, -10, 8 };
            arrangeArray[1] = new int[2] { -2, 1 };
            arrangeArray[2] = new int[3] { 1, 2, 5 };

            #endregion

            SortJaggedArray.Sort(jArray, new CompareByMinElementIncrease());

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
        }

        [TestMethod]
        public void BubbleSortByMinElementDecrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[3][];
            jArray[0] = new int[3] { 1, 2, 5 };
            jArray[1] = new int[4] { 2, 4, -10, 8 };
            jArray[2] = new int[2] { -2, 1 };

            int[][] arrangeArray = new int[3][];
            arrangeArray[0] = new int[3] { 1, 2, 5 };
            arrangeArray[1] = new int[2] { -2, 1 };
            arrangeArray[2] = new int[4] { 2, 4, -10, 8 };


            #endregion
            
            SortJaggedArray.Sort(jArray, new CompareByMinElementDecrease());

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortByMinElementDecrease_NullArray_Exception()
        {
            int[][] jArray = null;
            JaggedArray.BubbleSortByMinElementDecrease(jArray);
        }
    }
}
