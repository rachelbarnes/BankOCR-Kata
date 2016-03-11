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
            Console.ReadLine();
        }
    }
    public class BankOCR
    {
        public string firstRow, secondRow, thirdRow, fourthRow;
        public int lengthOfSubstring = 3;
        public List<string> TextLines = new List<string>();
        public List<List<string>> Characters = new List<List<string>>(); 

        //public object ParseAllCharacters_2() //max's method
        //{
        //    List<string>[] Character = new List<string>[] { zerothCharacter, firstCharacter, secondCharacter, thirdCharacter, fourthCharacter, fifthCharacter, sixthCharacter, seventhCharacter, eigthCharacter };
        //    return Character.Select(ParseCharacter).Select((v, idx) => ((int)Math.Pow(10, 8 - idx)) * v).Aggregate((acc, elm) => acc + elm);
        //}

        public object ParseAllCharacters()
        {
            string aggregatedNumber = "";
            foreach (List<string> character in Characters)
            {
                aggregatedNumber += ParseCharacter(character).ToString();  
            
            } 
            return Int64.Parse(aggregatedNumber);
        }
        public int ParseCharacter(List<string> character)
        {
            var drawnNumberCharacters = new DrawnNumberCharacters();
            for (int key = 0; key < 10; key++)
            {
                if (character.SequenceEqual(drawnNumberCharacters.Numbers[key]))
                {
                    return key;
                }
            }
            return -1;
        }

        public List<string> ReadFile(string fileName)
        {
            string line;
            var file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                TextLines.Add(line);
            }
            return TextLines;
        }

        public List<string> GetNthCharacter(int Index)
        {
            List<string> MatrixedDigit = new List<string>();
            string firstRow = TextLines[0].Substring(Index * 3, lengthOfSubstring);
            string secondRow = TextLines[1].Substring(Index * 3, lengthOfSubstring);
            string thirdRow = TextLines[2].Substring(Index * 3, lengthOfSubstring);
            string fourthRow = TextLines[3].Substring(Index * 3, lengthOfSubstring);

            MatrixedDigit.Add(firstRow);
            MatrixedDigit.Add(secondRow);
            MatrixedDigit.Add(thirdRow);
            MatrixedDigit.Add(fourthRow);
            return MatrixedDigit;
        }

        public void AssignCharactersToIndex()
        {
            for (int i = 0; i < 9; i++)
            {
                Characters.Add(GetNthCharacter(i)); 
            }
        }



    }
}