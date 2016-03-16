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
    public class TestsForBankOCRKata
    {

        [Test]
        public void CanParseAllCharactersAtOnceJustOnes()
        {
            var bankocr = new BankOCR();
            var result = bankocr.ParseFile("firstOCRFile.txt");
            Assert.AreEqual(111111111, result);
        }
    }
}
