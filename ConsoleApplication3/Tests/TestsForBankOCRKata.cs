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
        [Test]
        public void TestingGetSingleCharacters()
        {
            var bankocr = new BankOCR();
            var textFile = bankocr.ParseFile("firstOCRFile.txt");
            var expected = "     |  |   ";
            var actual = bankocr.GetSingleIntCharacter(0, textFile);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetSingleCharacter()
        {
            var bankocr = new BankOCR();
            var dictionary = new DictionaryOfCharacters();
            var textFile = bankocr.ParseFile("firstOCRFile.txt");
            var substringCharacter = bankocr.GetSingleIntCharacter(0, textFile);
            dictionary.defineDictionary(dictionary.textFileCharacters); 
            var expected = dictionary.textFileCharacters[1]; 
            Assert.AreEqual(expected, substringCharacter); 
        }

        [Test]
        public void TestConverter()
        {
            var bankocr = new BankOCR();
            var dictionary = new DictionaryOfCharacters();
            var textFile = bankocr.ParseFile("firstOCRFile.txt");
            var substringCharacter = bankocr.GetSingleIntCharacter(0, textFile);
            var convertFirstCharacter = bankocr.ConvertOneCharacter(textFile);
            dictionary.defineDictionary(dictionary.textFileCharacters);
            var expected = dictionary.textFileCharacters[1];
            Assert.AreEqual(expected, substringCharacter);
        }
    }
}
