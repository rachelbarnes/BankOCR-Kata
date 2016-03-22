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
        public void ParseAllCharacterFirstAccountNumber()
        {
            var bankocr = new BankOCR();
            var result = bankocr.ParseFile("firstOCRFile.txt");
            Assert.AreEqual(111111111, result);
        }

        [Test]
        public void ParseAllCharactersSecondAccountNumber()
        {
            var bankocr = new BankOCR();
            var result = bankocr.ParseFile("secondOCRFile.txt");
            Assert.AreEqual(123456789, result);
        }

        [Test]
        public void ParseAllCharactersThirdAccountNumber()
        {
            var bankocr = new BankOCR();
            var result = bankocr.ParseFile("thirdOCRFile.txt");
            Assert.AreEqual(490067715, result);
        }

        [Test]
        public void ParseAllCharactersFourthAccountNumber()
        {
            //testing a different length account number
            var bankocr = new BankOCR();
            var result = bankocr.ParseFile("fourthOCRFile.txt");
            Assert.AreEqual(245798001982, result);
        }

        //[Test]
        //public void TestingAllPartsOfClassBankOCR()
        //{
        //    var bank = new BankOCR();
        //    var dictionary = new DictionaryOfCharacters();
        //    var expected = 123456789;
        //    var textFile = bank.ParseFile("secondOCRFile.txt");
        //    var getdictionaryKey = bank.GetSingleIntCharacter(0, textFile);
        //    var actual = bank.GetAccountNumber(textFile); 
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void TestingGetSingleCharacters()
        //{
        //    var bankocr = new BankOCR();
        //    var textFile = bankocr.ParseFile("firstOCRFile.txt");
        //    var expected = "     |  |   ";
        //    var actual = bankocr.GetSingleIntCharacter(0, textFile);
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void TestGetSingleCharacter()
        //{
        //    var bankocr = new BankOCR();
        //    var dictionary = new DictionaryOfCharacters();
        //    var textFile = bankocr.ParseFile("firstOCRFile.txt");
        //    var substringCharacter = bankocr.GetSingleIntCharacter(0, textFile);
        //    var expected = dictionary.textFileCharacters[substringCharacter];
        //    Assert.AreEqual(expected, 1);
        //}

        //[Test]
        //[Ignore]
        //public void TestConverter()
        //{
        //    var bankocr = new BankOCR();
        //    var dictionary = new DictionaryOfCharacters();
        //    var textFile = bankocr.ParseFile("firstOCRFile.txt");
        //    var substringCharacter = bankocr.GetSingleIntCharacter(0, textFile);
        //    var convertFirstCharacter = bankocr.ConvertCharactersToIntegers(textFile);
        //    dictionary.defineDictionary(dictionary.textFileCharacters);
        //    var expected = dictionary.textFileCharacters[1];
        //    Assert.AreEqual(expected, substringCharacter);
        //}
        //[Test]
        //[Ignore]
        //public void TestConvertOneCharacterAtATime()
        //{
        //    var bankocr = new BankOCR();
        //    var dictionary = new DictionaryOfCharacters();
        //    var textFile = bankocr.ParseFile("firstOCRFile.txt");
        //    var substringCharacter = bankocr.GetSingleIntCharacter(0, textFile);
        //    var convertCharacters = bankocr.GetAccountNumber(textFile);
        //    var expected = 111111111;
        //    Assert.AreEqual(expected, convertCharacters);
        //}

        [Test]
        public void testValidAccountNumber123456789()
        {
            var accountNumber = 123456789; // 45750800;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }

        [Test]
        public void testValidAccountNumberThirdOCRFile ()
        {
            var accountNumber = 490067715;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }

        [Test]
        public void testValidAccountNumber2()
        {
            var accountNumber = 345882865;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }

        [Test]
        public void testValidAccountNumber3()
        {
            var accountNumber = 554433995;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }
        //these should not be passing; im just asking it to evaluate the
        //same set of positionValues in the for loop which is why everything
        //is passing. 



        [Test]
        public void testIncorrectAccountNumber()
        {

            var accountNumber = 664371495;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(false, Sum);
        }
//this is testing false - it is coming back as true in a failed test. 
    }
}
