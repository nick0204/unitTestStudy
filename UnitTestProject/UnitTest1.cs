using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test.Model;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 
            Assert.AreEqual(29, new Person().ConvertToAge(new DateTime(1993, 1, 10), new DateTime(2022, 1, 12))); // Pass
            Assert.AreEqual(28, new Person().ConvertToAge(new DateTime(1993, 8, 10), new DateTime(2022, 1, 12))); // Pass

            // Birthday => 29 Feb  (Birth, Current)
            Assert.AreEqual(29, new Person().ConvertToAge(new DateTime(1992, 2, 29), new DateTime(2022, 1, 12))); // Pass
            Assert.AreEqual(29, new Person().ConvertToAge(new DateTime(1992, 2, 29), new DateTime(2022, 2, 28))); // Pass
            Assert.AreEqual(30, new Person().ConvertToAge(new DateTime(1992, 2, 29), new DateTime(2022, 3, 1))); // Pass
            Assert.AreEqual(30, new Person().ConvertToAge(new DateTime(1992, 3, 1), new DateTime(2022, 3, 1))); //  <--------  Year leak day(29 Feb)

            // Current day => 29 Feb
            Assert.AreEqual(31, new Person().ConvertToAge(new DateTime(1993, 2, 28), new DateTime(2024, 2, 29))); // Pass
            Assert.AreEqual(30, new Person().ConvertToAge(new DateTime(1993, 3, 1), new DateTime(2024, 2, 29))); // <--------  Year leak day(29 Feb)
            Assert.AreEqual(31, new Person().ConvertToAge(new DateTime(1993, 3, 1), new DateTime(2024, 3, 1))); // <--------  Year leak day(29 Feb)

            // Birthday && Current has leak day (all ok)
            Assert.AreEqual(31, new Person().ConvertToAge(new DateTime(1992, 2, 29), new DateTime(2024, 1, 12))); // Pass
            Assert.AreEqual(31, new Person().ConvertToAge(new DateTime(1992, 2, 29), new DateTime(2024, 2, 28))); // Pass
            Assert.AreEqual(32, new Person().ConvertToAge(new DateTime(1992, 2, 29), new DateTime(2024, 3, 1))); // Pass
            Assert.AreEqual(32, new Person().ConvertToAge(new DateTime(1992, 3, 1), new DateTime(2024, 3, 1))); //  Pass

            // new year 
            Assert.AreEqual(32, new Person().ConvertToAge(new DateTime(1992, 12, 31), new DateTime(2024, 12, 31))); // Pass
            Assert.AreEqual(32, new Person().ConvertToAge(new DateTime(1992, 12, 31), new DateTime(2025, 1, 1))); // Pass
            Assert.AreEqual(32, new Person().ConvertToAge(new DateTime(1993, 1, 1), new DateTime(2025, 1, 1))); // Pass


        }
    }
}
