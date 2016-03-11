﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    public class Runner
    {
        //have a seperate class to hold the main to let the project start and finish apart from the logic of the other classes
        public static void Main(string[] args)
        {
            var bankOCR = new BankOCR();
            var drawnNumberCharacters = new DrawnNumberCharacters();
            //var comparer = new Comparer();
            var TextLines = bankOCR.TextLines;
            //bankOCR.ReadFile();

            //      var GettingIntsFromTextLines = comparer.ComparingLists(bankOCR.GetNthCharacter(), drawnNumberCharacters.Numbers);
            //     Console.Write(GettingIntsFromTextLines); 
            Console.ReadLine();
        }
    }

    public class BankOCR
    {
        public string test = "123456789";
        public string firstRow, secondRow, thirdRow, fourthRow;
        public int key;
        //public List<int> numberValuesInt;
        public List<string> numbersValues;
        public int[] keyArray;

        public object ParseAllCharacters() //max's method
        {
            List<string>[] Character = new List<string>[] { zerothCharacter, firstCharacter, secondCharacter, thirdCharacter, fourthCharacter, fifthCharacter, sixthCharacter, seventhCharacter, eigthCharacter };
            return Character.Select(ParseCharacter).Select((v, idx) => ((int)Math.Pow(10, 8 - idx)) * v).Aggregate((acc, elm) => acc + elm);
        }
        public object ParseAllCharacters_2()
        {
            //string.Join(", ", new [] {1,2,3,4,5,6}) // "1, 2, 3, 4, 5, 6"
            //string.Join(" ", new [] {1,2,3,4,5,6}) // "1 2 3 4 5 6"
            //"1 2 3 4 5".Split(' ').Select(stringnumber => Int32.Parse(stringnumber)); // [1,2,3,4,5]
            var drawnNumbersCharacter = new DrawnNumberCharacters();
            int number0 = ParseCharacter(zerothCharacter);
            int number1 = ParseCharacter(firstCharacter);
            int number2 = ParseCharacter(secondCharacter);
            int number3 = ParseCharacter(thirdCharacter);
            int number4 = ParseCharacter(fourthCharacter);
            int number5 = ParseCharacter(fifthCharacter);
            int number6 = ParseCharacter(sixthCharacter);
            int number7 = ParseCharacter(seventhCharacter);
            int number8 = ParseCharacter(eigthCharacter);
            int[] numberN = new int[] { number0, number1, number2, number3, number4, number5, number6, number7, number8 };
            List<string>[] Character = new List<string>[] { zerothCharacter, firstCharacter, secondCharacter, thirdCharacter, fourthCharacter, fifthCharacter, sixthCharacter, seventhCharacter, eigthCharacter };
            string aggregatedNumber = "";
            //foreach (List<string> character in Character)
            //{
            //    ParseCharacter(character);
            foreach (int number in numberN)
            {
                aggregatedNumber += number.ToString();
            }
            //}

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

        public int lengthOfSubstring = 3;
        public List<string> TextLines = new List<string>();
        public List<string> zerothCharacter, firstCharacter, secondCharacter, thirdCharacter, fourthCharacter, fifthCharacter, sixthCharacter, seventhCharacter, eigthCharacter;


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
            //for (MatrixedDigitIndex = 0; MatrixedDigitIndex < 10; MatrixedDigitIndex++) { 
            string firstRow = TextLines[0].Substring(Index * 3, lengthOfSubstring);
            string secondRow = TextLines[1].Substring(Index * 3, lengthOfSubstring);
            string thirdRow = TextLines[2].Substring(Index * 3, lengthOfSubstring);
            string fourthRow = TextLines[3].Substring(Index * 3, lengthOfSubstring);

            MatrixedDigit.Add(firstRow);
            MatrixedDigit.Add(secondRow);
            MatrixedDigit.Add(thirdRow);
            MatrixedDigit.Add(fourthRow);
            //}
            return MatrixedDigit;
        }



        public void AssignCharactersToIndex()
        {
            zerothCharacter = GetNthCharacter(0);
            firstCharacter = GetNthCharacter(1);
            secondCharacter = GetNthCharacter(2);
            thirdCharacter = GetNthCharacter(3);
            fourthCharacter = GetNthCharacter(4);
            fifthCharacter = GetNthCharacter(5);
            sixthCharacter = GetNthCharacter(6);
            seventhCharacter = GetNthCharacter(7);
            eigthCharacter = GetNthCharacter(8);
        }



    }
}