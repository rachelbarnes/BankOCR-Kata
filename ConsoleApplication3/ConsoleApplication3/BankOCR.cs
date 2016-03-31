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
        }
    }
    public class BankOCR
    {
        
        public string ParseFile(string textFileName)
        {
            List<string> textFile = new List<string>();
            string[] readFile = System.IO.File.ReadAllLines(textFileName);
            foreach (string line in readFile)
            {
                textFile.Add(line);
            }
            return GetAccountNumber(textFile);
        }

        public string GetSingleIntCharacter(int index, List<string> textLines)
        {
            string singleDrawnCharacter = "";
            foreach (string line in textLines)
            {
                string substringLine = line.Substring((index * 3), 3);
                singleDrawnCharacter += substringLine;
            }
            return singleDrawnCharacter;
        }

        public string GetAccountNumber(List<string> textToBeConverted)
        {
            var dictionary = new DictionaryOfCharacters();
            int lengthOfLine = textToBeConverted[0].Count() / 3;
            string retrieveDictionaryValue = "";

            for (int characterIndex = 0; characterIndex < lengthOfLine; characterIndex++)
            {
                string drawnCharacterString = GetSingleIntCharacter(characterIndex, textToBeConverted);
                if (!dictionary.textFileCharacters.ContainsKey(drawnCharacterString))
                    retrieveDictionaryValue += '?';
                 else retrieveDictionaryValue += dictionary.textFileCharacters[drawnCharacterString].ToString();
            }
            return (retrieveDictionaryValue); 
        }
    }
}
