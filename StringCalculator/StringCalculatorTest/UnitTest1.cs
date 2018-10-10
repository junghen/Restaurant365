using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTest
{
    [TestClass]
    public class UnitTestZeroToTwoNumbers
    {
        [TestMethod]
        public void TestEmptyString()
        {
            string numbers = "";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(0, sc.Add(numbers));
        }

        [TestMethod]
        public void TestZero()
        {
            string numbers = "0";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(0, sc.Add(numbers));
        }

        [TestMethod]
        public void TestOneNumber()
        {
            string numbers = "5";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(5, sc.Add(numbers));
        }
        [TestMethod]
        public void TestTwoNumbers()
        {
            string numbers = "1,5";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(6, sc.Add(numbers));
        }
        [TestMethod]
        public void TestThreeNumbers()
        {
            string numbers = "1,5,6";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            //Assert.AreEqual(-1, sc.Add(numbers));
            // JK 10/9 code exercise 2 - Added support for unknown amount of numbers 
            Assert.AreEqual(12, sc.Add(numbers));
        }
        [TestMethod]
        public void TestException()
        {
            string numbers = "1000000000,10000000000";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(-1, sc.Add(numbers));
        }
        [TestMethod]
        public void TestNewLineSeperator()
        {
            string numbers = "1\n2,3\n4";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(10, sc.Add(numbers));
        }
        [TestMethod]
        public void TestDifferentDelimiter()
        {
            string numbers = "//[;]\n1;2\n3\n4;5;6";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(21, sc.Add(numbers));
        }
        [TestMethod]
        public void TestNegativeNumberException()
        {
            string numbers = "1,-2,-3";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(-1, sc.Add(numbers));
        }
        [TestMethod]
        public void TestIgnoreNumberGreaterThan1000()
        {
            string numbers = "//[;]\n1;2\n3\n4;5;6;1001;1002";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(21, sc.Add(numbers));
        }
        [TestMethod]
        public void TestMultipleDelimitersWithLengthGreaterThanOne()
        {
            string numbers = "//[***][---][%@!]\n 1---2\n3\n4***5%@!6,1001\n1002";
            StringCalculator.StringCalculator sc = new StringCalculator.StringCalculator();
            Assert.AreEqual(21, sc.Add(numbers));
        }
    }
}
