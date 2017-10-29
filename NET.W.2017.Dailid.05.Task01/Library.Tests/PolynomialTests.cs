using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class PolynomialTests
    {

        //Methods implemented for polynomials with equal degree only

        [DataRow(new double[] { 6.4, 3.3, 0 }, new double[] { 1, 1.1}, new double[] {6.4, 2.3, -1.1 })]
        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { 2, 0, 4, 9, -4})]
        [DataRow(new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -12, 3, 28, 14, -15})]
        [DataRow(new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { 1, 12, -3, -28, -14, 15 })]
        [DataTestMethod]
        public void Subtract_TwoPolynomials_ResultPolynomial(double[] first, double[] second, double[] result)
        {        
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            Polynomial resultPol = Polynomial.Subtract(firstPol, secondPol);

            CollectionAssert.AreEqual( result, resultPol.Coefficients, "Wrong result of subtract operation!");
        }

        [DataRow(new double[] { 6.4, 3.3, 0 }, new double[] { 1, 1.1 }, new double[] { 6.4, 4.3, 1.1 })]
        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { 10, 6, 8, -9, 8 })]
        [DataRow(new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -4, 9, 32, -4, -3})]
        [DataRow(new double[] { 4, 3, 2, -9, 6 }, new double[] { -1, -8, 6, 30, 5, -9 }, new double[] { -1, -4, 9, 32, -4, -3 })]
        [DataTestMethod]
        public void Add_TwoPolynomials_ResultPolynomial(double[] first, double[] second, double[] result)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            Polynomial resultPol = Polynomial.Add(firstPol, secondPol);

            CollectionAssert.AreEqual(result, resultPol.Coefficients, "Wrong result of add operation!");
        }

        [DataRow(new double[] { 6.4, 3.3, 0 }, new double[] { 1, 1.1 }, new double[] { 6.4, 10.34, 3.63, 0})]
        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 4, 3, 2, -9, 6 }, new double[] { 24, 30, 45, -30, 29, -30, 40, -18, 12})]
        [DataRow(new double[] { -6, 0, -2}, new double[] { -9, 6 }, new double[] { 54, -36, 18, -12})]
        [DataTestMethod]
        public void Multiply_TwoPolynomials_ResultPolynomial(double[] first, double[] second, double[] result)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            Polynomial resultPol = Polynomial.Multiply(firstPol, secondPol);

            CollectionAssert.AreEqual(result, resultPol.Coefficients, "Wrong result of maltyply operation!");
        }

        [DataRow(new double[] { 6, 3, 6, 0, 2 }, new double[] { 6, 3, 6, 0, 2 }, true)]
        [DataRow(new double[] { -6, 0, -2 }, new double[] { -9, 6 }, false)]
        [DataRow(new double[] { 0}, new double[] { -9}, true)]
        [DataTestMethod]
        public void Equals_TwoPolynomials_AreEquals(double[] first, double[] second, bool expectedResult)
        {
            Polynomial firstPol = new Polynomial(first);
            Polynomial secondPol = new Polynomial(second);
            var actualResult = firstPol.Equals(secondPol);

            Assert.AreEqual(expectedResult, actualResult, "Wrong result of Equals method!");
        }
    }
}
