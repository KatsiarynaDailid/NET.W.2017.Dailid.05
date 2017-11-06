using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [DataRow(new double[] { 6.4, 3.3, 0.000000001, 0.0000000022, 0 }, new double[] { 1, 1.1, 0, 0, 0.0000000005 }, new double[] { 5.4, 2.2 })]
        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { 2, 0, 4, 9, -4 })]
        [DataRow(new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -12, 3, 28, 14, -15 })]
        [DataRow(new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { 1, 12, -3, -28, -14, 15 })]
        [DataTestMethod]
        public void Subtract_TwoPolynomials_ResultPolynomial(double[] first, double[] second, double[] result)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            Polynomial expectedPol = new Polynomial(result);
            Polynomial actualPol = Polynomial.Subtract(firstPol, secondPol);

            Assert.IsTrue(expectedPol.Equals(actualPol), "Wrong result of subtract operation!");
        }

        [DataRow(new double[] { 6.4, 3.3, 0.000000001, 0.0000000022, 0 }, new double[] { 1, 1.1, 0, 0, 0.0000000005 }, new double[] { 7.4, 4.4 })]
        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { 10, 6, 8, -9, 8 })]
        [DataRow(new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -4, 9, 32, -4, -3 })]
        [DataRow(new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { -1, -4, 9, 32, -4, -3 })]
        [DataTestMethod]
        public void Add_TwoPolynomials_ResultPolynomial(double[] first, double[] second, double[] result)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            Polynomial expectedPol = new Polynomial(result);
            Polynomial actualPol = Polynomial.Add(firstPol, secondPol);

            Assert.IsTrue(expectedPol.Equals(actualPol), "Wrong result of Add operation!");

        }

        [DataRow(new double[] { 6.4, 3.3, 0 }, new double[] { 1, 1.1 }, new double[] { 6.4, 10.34, 3.63 })]
        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { 24, 30, 45, -30, 29, -30, 40, -18, 12 })]
        [DataRow(new double[] { -6, 0, -2 }, new double[] { -9, 6 }, new double[] { 54, -36, 18, -12 })]
        [DataTestMethod]
        public void Multiply_TwoPolynomials_ResultPolynomial(double[] first, double[] second, double[] result)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            Polynomial expectedPol = new Polynomial(result);
            Polynomial actualPol = Polynomial.Multiply(firstPol, secondPol);

            Assert.IsTrue(expectedPol.Equals(actualPol), "Wrong result of Multiply operation!");
        }

        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 6, 3, 6, 0, 2 }, true)]
        [DataRow(new double[] { -6, 0, -2 }, new double[] { -9, 6 }, false)]
        [DataRow(new double[] { -9}, new double[] {-9}, true)]
        [DataTestMethod] 
        public void Equals_TwoPolynomials_AreEquals(double[] first, double[] second, bool result)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);

            Assert.AreEqual(result, firstPol.Equals(secondPol), "Wrong result of Equals operation!");
        }
    }
}
