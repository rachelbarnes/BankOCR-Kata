using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            var bankocr = new BankOCR();
            var displayFile = bankocr.ParseFile("firstOCRFile.txt");
            var displaySingleCharacter = bankocr.GetSingleIntCharacter(0, displayFile);
            Console.WriteLine(displayFile);
            Console.WriteLine(displaySingleCharacter);
            Console.ReadLine();
        }
    }
    public class BankOCR
    {
        public List<string> ParseFile(string textFileName)
        {
            List<string> textFile = new List<string>();
            var file = "firstOCRFile.txt";
            string[] readFile = System.IO.File.ReadAllLines(file);
            foreach (string line in readFile)
            {
                textFile.Add(line);
            }
            return textFile;
        }

        public string GetSingleIntCharacter(int index, List<string> textLines)
        {
            string substringLine;
            string singleDrawnCharacter = "";
            foreach (string line in textLines)
            {
                substringLine = line.Substring((index * 3), 3);
                singleDrawnCharacter += substringLine;
            }
            return singleDrawnCharacter;
        }

        public int ConvertCharactersToIntegers(List<string> textToBeConverted)
        {
            var dictionary = new DictionaryOfCharacters();
            int lengthOfLine = textToBeConverted[1].Count() / 3;
            string retrieveDictionaryValue = "";
            for (int characterIndex = 0; characterIndex < lengthOfLine; characterIndex++)
            {
                string drawnCharacterString = GetSingleIntCharacter(characterIndex, textToBeConverted); 
                retrieveDictionaryValue += dictionary.textFileCharacters[drawnCharacterString].ToString();
            }
            return int.Parse(retrieveDictionaryValue);
        }
    }
}

