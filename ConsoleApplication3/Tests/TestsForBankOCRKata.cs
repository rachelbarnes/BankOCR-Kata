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
        public void CanParseAllCharactersAtOnce()
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();

            var bankocr = new BankOCR();
            bankocr.ReadFile();
            bankocr.AssignCharactersToIndex();
            var result = bankocr.ParseAllCharacters();
            Assert.AreEqual(123456789, result);
        }

        [Test]
        public void CanParseAllCharacters()
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();

            var bankocr = new BankOCR();
            bankocr.ReadFile();
            bankocr.AssignCharactersToIndex();
            int number0 = bankocr.ParseCharacter(bankocr.zerothCharacter);
            int number1 = bankocr.ParseCharacter(bankocr.firstCharacter);
            int number2 = bankocr.ParseCharacter(bankocr.secondCharacter);
            int number3 = bankocr.ParseCharacter(bankocr.thirdCharacter);
            int number4 = bankocr.ParseCharacter(bankocr.fourthCharacter);
            int number5 = bankocr.ParseCharacter(bankocr.fifthCharacter);
            int number6 = bankocr.ParseCharacter(bankocr.sixthCharacter);
            int number7 = bankocr.ParseCharacter(bankocr.seventhCharacter);
            int number8 = bankocr.ParseCharacter(bankocr.eigthCharacter);

            Assert.AreEqual(1, number0);
            Assert.AreEqual(1, number1);
            Assert.AreEqual(1, number2);
            Assert.AreEqual(1, number3);
            Assert.AreEqual(1, number4);
            Assert.AreEqual(1, number5);
            Assert.AreEqual(1, number6);
            Assert.AreEqual(1, number7);
            Assert.AreEqual(1, number8);
        }

        [Test]
        public void NumbersValuesStringsValues()
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();
            var bankOCR = new BankOCR();
            List<string> numberValues = bankOCR.numbersValues;
            bankOCR.ReadFile();
            bankOCR.AssignCharactersToIndex(); 
            bankOCR.ParseCharacter(numberValues); 
            bankOCR.ParseAllCharacters();
            List<int> numbersValuesInt = bankOCR.numberValuesInt; 



            Assert.AreEqual(123, numbersValuesInt);
        }



        [Test]
        public void CanParseOneCharacter()
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();

            var bankocr = new BankOCR();
            bankocr.ReadFile();
            bankocr.AssignCharactersToIndex();
            int number = bankocr.ParseCharacter(bankocr.zerothCharacter);

            Assert.AreEqual(1, number);
        }

        [Test]
        public void TestingZerothCharacter()
        {
            var bankOCR = new BankOCR();
            var drawnNumberCharacters = new DrawnNumberCharacters();
            bankOCR.ReadFile();
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
        public void TestingTheSetCharacters()
        {
            var bankOCR = new BankOCR();
            var drawnNumberCharacters = new DrawnNumberCharacters();
            bankOCR.ReadFile();
            bankOCR.AssignCharactersToIndex();


            Assert.AreEqual(drawnNumberCharacters.Numbers[1], bankOCR.zerothCharacter);
        }

        [Test]
        public void TestingComparingListSize()
        {
            var comparer = new Comparer();
            var ListA = comparer.ListA;
            var ListB = comparer.ListB;
            var ListACount = ListA.Count();
            var ListBCount = ListB.Count();
            comparer.ComparingListSize(ListA, ListB);

            Assert.AreEqual(ListACount, ListBCount);
        }

        [Test]
        public void TestingComparingListValues()
        {
            var comparer = new Comparer();
            var ListA = comparer.ListA;
            var ListB = comparer.ListB;
            comparer.ComparingListValues(ListA, ListB);

            Assert.AreEqual(ListA, ListB);
        }

        [Test]
        public void TestingFirstCharacterWithDictionaryValue()
        {
            var bankocr = new BankOCR();
            var drawnNumberCharacters = new DrawnNumberCharacters();
            bankocr.ReadFile();
            bankocr.AssignCharactersToIndex();

            Assert.AreEqual(drawnNumberCharacters.Numbers[1], bankocr.secondCharacter);
        }

        [Test]
        public void TestingFirstOCRFileFirstLine()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile();
            List<string> textStrings = bankOCR.TextLines;
            string actualString =
              "                           ";
            Assert.AreEqual(textStrings[0], actualString);
        }

        [Test]
        public void TestingFirstOCRFileSecondLine()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile();
            List<string> textStrings = bankOCR.TextLines;
            string actualString =
              "  |  |  |  |  |  |  |  |  |";
            Assert.AreEqual(textStrings[2], actualString);
        }

        [Test]
        public void TestingFirstOCRFinalListTest()
        {
            var bankOCR = new BankOCR();
            bankOCR.ReadFile();
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
            bankOCR.ReadFile();
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
