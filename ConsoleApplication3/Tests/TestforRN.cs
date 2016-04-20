using ConsoleApplication3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tests
{
    [TestFixture]
    class TestforRN 
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(15, "XV")]
        [TestCase(6, "VI")]
        [TestCase(16, "XVI")]
        [TestCase(4, "IV")]
        [TestCase(90, "XC")]
        [TestCase(9, "IX")]
        [TestCase(24, "XXIV")]
        [TestCase(83, "LXXXIII")]
        [TestCase(109, "CIX")]
        public void RomanToArabicTest(int expectedOutput, string input)
        {
            var converter = new RomanNumerals();
            Assert.AreEqual(expectedOutput, converter.ParseRomanNumeralString(input));
        }


        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(15, "XV")]
        [TestCase(6, "VI")]
        [TestCase(16, "XVI")]
        [TestCase(4, "IV")]
        [TestCase(90, "XC")]
        [TestCase(9, "IX")]
        [TestCase(24, "XXIV")]
        [TestCase(83, "LXXXIII")]
        [TestCase(109, "CIX")]
        public void ArabicToRomanTest(int input, string expectedOutput)
        {
            var converter = new RomanNumerals();
            Assert.AreEqual(expectedOutput, converter.ParseArabicNumber(input));
        }
    }
}
