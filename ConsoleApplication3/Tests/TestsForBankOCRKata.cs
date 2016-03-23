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
        public void testValidAccountNumber1()
        {
            var accountNumber = 123456789; // 45750800;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(true, Sum);
        }

        [Test]
        public void testValidAccountNumber3 ()
        {
            var accountNumber = 490067715;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(false, Sum);
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
        public void testIncorrectAccountNumber2()
        {
            var accountNumber = 554433995;
            var checksum = new CheckSum();
            var Sum = checksum.CheckForValidCheckSum(accountNumber);
            Assert.AreEqual(false, Sum);
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

        [Test]
        public void testSumAllDigits()
        {
            var accountNumber = 111111111;
            var checksum = new CheckSum();
            var Sum = checksum.ChecksumAllDigits(accountNumber);
            Assert.AreEqual(45, Sum);
        }

        [Test]
        public void test_Inverse()
        {
            var checksum = new CheckSum();
            Assert.AreEqual(1, checksum.FindInverse(8));
            Assert.AreEqual(2, checksum.FindInverse(7));
            Assert.AreEqual(3, checksum.FindInverse(6));
            Assert.AreEqual(4, checksum.FindInverse(5));
            Assert.AreEqual(5, checksum.FindInverse(4));
            Assert.AreEqual(6, checksum.FindInverse(3));
            Assert.AreEqual(7, checksum.FindInverse(2));
            Assert.AreEqual(8, checksum.FindInverse(1));
            Assert.AreEqual(9, checksum.FindInverse(0));
        }
    }
}
