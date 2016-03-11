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
            bankocr.ReadFile("firstOCRFile.txt");
            bankocr.AssignCharactersToIndex();
            var result = bankocr.ParseAllCharacters();
            Assert.AreEqual(111111111, result);
        }
        [Test]
        public void CanParseAllCharactersAtOnce()
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();

            var bankocr = new BankOCR();
            bankocr.ReadFile("secondOCRFile.txt");
            bankocr.AssignCharactersToIndex();
            var result = bankocr.ParseAllCharacters();
            Assert.AreEqual(123456789, result);
        }

        [Test]
        public void TestingZerothCharacter()
        {
            var bankOCR = new BankOCR();
            var drawnNumberCharacters = new DrawnNumberCharacters();
            bankOCR.ReadFile("firstOCRFile.txt");
            var TextLines = bankOCR.TextLines;
            var zerothCharacter = bankOCR.GetNthCharacter(0);
            List<string> expected = new List<string>
            {
                "   ",
                "  |",
                "  |",
                "   "
            };

            Assert.AreEqual(expected, zerothCharacter);
        }

        [Test]
        public void TestingFirstOCRFileFirstLine()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile("firstOCRFile.txt");
            List<string> textStrings = bankOCR.TextLines;
            string actualString =
              "                           ";
            Assert.AreEqual(textStrings[0], actualString);
        }

        [Test]
        public void TestingFirstOCRFileSecondLine()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile("firstOCRFile.txt");
            List<string> textStrings = bankOCR.TextLines;
            string actualString =
              "  |  |  |  |  |  |  |  |  |";
            Assert.AreEqual(textStrings[2], actualString);
        }

        [Test]
        public void TestingFirstOCRFinalListTest()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile("firstOCRFile.txt");
            List<string> textStrings = bankOCR.TextLines;
            List<string> actualList = new List<string> {
        "                           ",
        "  |  |  |  |  |  |  |  |  |",
        "  |  |  |  |  |  |  |  |  |",
        "                           "
      };
            Assert.AreEqual(actualList, textStrings);
        }

        [Test]
        public void GetNthCharacter_FirstCharacter()
        {
            var bankOCR = new BankOCR();
            var input = new List<string> {
              "111222333",
              "444555666",
              "777888999",
              "         "   };

            var expected = new List<string> {
              "111",
              "444",
              "777",
              "   "  };

            bankOCR.TextLines = input;
            Assert.AreEqual(expected, bankOCR.GetNthCharacter(0));
            //bankOCR.GetNthCharacter(0));
            //this test is not passing because the input is not returning anything in the ()
            //the error says the index is out of range, which is because it's failing to print
        }
        [Test]
        public void TestingConvertingOneLineAtATime()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile("firstOCRFile.txt");
            List<string> actualList = new List<string> {
                  "                           ",
                  "  |  |  |  |  |  |  |  |  |",
                  "  |  |  |  |  |  |  |  |  |",
                  "                           "
                        };
            Assert.AreEqual(actualList, bankOCR.TextLines);
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
            // bankOCR.TextLines = testForDrawnNumberOne; 
            Assert.AreEqual(testForDrawnNumberOne, drawnNumberCharacters.Numbers[1]);
        }


        [Test]
        public void TestingSubstrings()
        {
            string test = "123456789";

            Assert.AreEqual("123", test.Substring(0, 3));
        }

        [Test]
        public void GetNthCharacter_SecondCharacter()
        {
            var bankOCR = new BankOCR();
            var input = new List<String> {
                "111222333",
                "444555666",
                "777888999",
                "         "
                  };
            var expected = new List<String> {
                "222",
                "555",
                "888",
                "   "
                   };
            bankOCR.TextLines = input;
            Assert.AreEqual(expected, bankOCR.GetNthCharacter(1));
        }
    }
}
