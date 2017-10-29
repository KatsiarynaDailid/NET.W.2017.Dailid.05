using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class JaggedArrayTests
    {

        [TestMethod]
        public void BubbleSortBySumIncrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[3][];
            jArray[0] = new int[3] { 1, 3, 5 };
            jArray[1] = new int[2] { 2, 4 };
            jArray[2] = new int[4] { 2, 4, 6, 8 };

            int[][] arrangeArray = new int[3][];
            arrangeArray[0] = new int[4] { 2, 4, 6, 8 };
            arrangeArray[1] = new int[3] { 1, 3, 5 };
            arrangeArray[2] = new int[2] { 2, 4 };

            #endregion

            JaggedArray.BubbleSortBySumIncrease(jArray);

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);

        }

        [TestMethod]
        public void BubbleSortBySumDecrease_JArray_SortedJArray()
        {
            #region Arrange

            int[][] jArray = new int[3][];
            jArray[0] = new int[3] { 1, 3, 5 };
            jArray[1] = new int[2] { 2, 4 };
            jArray[2] = new int[4] { 2, 4, 6, 8 };

            int[][] arrangeArray = new int[3][];
            arrangeArray[0] = new int[2] { 2, 4 };
            arrangeArray[1] = new int[3] { 1, 3, 5 };
            arrangeArray[2] = new int[4] { 2, 4, 6, 8 };

            #endregion

            JaggedArray.BubbleSortBySumDecrease(jArray);

            CollectionAssert.AreEqual(arrangeArray[0], jArray[0]);
            CollectionAssert.AreEqual(arrangeArray[1], jArray[1]);
            CollectionAssert.AreEqual(arrangeArray[2], jArray[2]);
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

            JaggedArray.BubbleSortByMaxElementIncrease(jArray);

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

            JaggedArray.BubbleSortByMaxElementDecrease(jArray);

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
            arrangeArray[0] = new int[3] { 1, 2, 5 };
            arrangeArray[1] = new int[2] { -2, 1 };
            arrangeArray[2] = new int[4] { 2, 4, -10, 8 };

            #endregion

            JaggedArray.BubbleSortByMinElementIncrease(jArray);

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
            arrangeArray[0] = new int[4] { 2, 4, -10, 8 };
            arrangeArray[1] = new int[2] { -2, 1 };
            arrangeArray[2] = new int[3] { 1, 2, 5 };

            #endregion

            JaggedArray.BubbleSortByMinElementDecrease(jArray);

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
