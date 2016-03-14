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
            var drawnNumberCharacters = new DrawnNumberCharacters();

            var bankocr = new BankOCR();
            var contents = bankocr.ReadFile("firstOCRFile.txt");
            var characters = bankocr.AssignCharactersToIndex(contents);
            var result = bankocr.ParseAllCharacters(characters);
            Assert.AreEqual(111111111, result);
        }

        [Test]
        public void CanParseAllCharactersAtOnce()
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();

            var bankocr = new BankOCR();
            var contents = bankocr.ReadFile("secondOCRFile.txt");
            var characters = bankocr.AssignCharactersToIndex(contents);
            var result = bankocr.ParseAllCharacters(characters);
            Assert.AreEqual(123456789, result);
        }

        [Test]
        public void TestingFirstOCRFileFirstLine()
        {
            var bankOCR = new BankOCR();
            var textStrings = bankOCR.ReadFile("firstOCRFile.txt");
            string actualString = "                           ";
            Assert.AreEqual(textStrings[0], actualString);
        }

         [Test]
        public void TestingConvertingOneLineAtATime()
        {
            var bankOCR = new BankOCR();
            var contents = bankOCR.ReadFile("firstOCRFile.txt");
            List<string> actualList = new List<string> {
                  "                           ",
                  "  |  |  |  |  |  |  |  |  |",
                  "  |  |  |  |  |  |  |  |  |",
                  "                           "
                        };
            Assert.AreEqual(actualList, contents);
        }

        [Test]
        public void TestingDictionaryMatrixCharacter()
        {
            var bankOCR = new BankOCR();
            var drawnNumberCharacters = new DrawnNumberCharacters();
            List<string> testForDrawnNumberOne = new List<string> {
        "   ",
        "  |",
        "  |",
        "   " };
            Assert.AreEqual(testForDrawnNumberOne, drawnNumberCharacters.Numbers[1]);
        }
    }
}
