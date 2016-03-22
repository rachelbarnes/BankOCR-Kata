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
        public long ParseFile(string textFileName)
        {
            List<string> textFile = new List<string>();
            var file = "fourthOCRFile.txt";
            string[] readFile = System.IO.File.ReadAllLines(file); 
            foreach (string line in readFile)
            {
                textFile.Add(line);
            }
            //return textFile;
            return GetAccountNumber(textFile);  
        }


        public string GetSingleIntCharacter(int index, List<string> textLines)
        {
            string substringLine;
            string singleDrawnCharacter = "";
            //index = 5; 
            foreach (string line in textLines)
            {
                substringLine = line.Substring((index * 3), 3);
                singleDrawnCharacter += substringLine;
            }
            return singleDrawnCharacter;
        }

        public long GetAccountNumber(List<string> textToBeConverted)
        {
            var dictionary = new DictionaryOfCharacters();
            int lengthOfLine = textToBeConverted[1].Count() / 3;
            string retrieveDictionaryValue = "";

            for (int characterIndex = 0; characterIndex < lengthOfLine; characterIndex++)
            {
                string drawnCharacterString = GetSingleIntCharacter(characterIndex, textToBeConverted); 
                retrieveDictionaryValue += dictionary.textFileCharacters[drawnCharacterString].ToString();
            }
            return Int64.Parse(retrieveDictionaryValue);
        }
    }
}

//next story: be able to import a file and not change the file name in the 
//file variable assignment in ParseFile(textfile). 
//having an empty path is not "legal"