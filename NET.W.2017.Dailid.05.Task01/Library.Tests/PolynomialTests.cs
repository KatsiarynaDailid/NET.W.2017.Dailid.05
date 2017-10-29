using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class PolynomialTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            var array = new double[] { 6, 3, 6, 0, 2};
            var array1 = new double[] { -1, -8, 6, 30, 5, -9};
            Polynomial poly = new Polynomial(array);
            Polynomial poly1 = new Polynomial(array1);

            var pol = Polynomial.Multiply(poly, poly1);
        }

    }
}
