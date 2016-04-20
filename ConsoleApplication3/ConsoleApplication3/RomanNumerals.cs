using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class RomanNumerals
    {
        public int ParseRomanNumeralString(string number)
        {
            var totalSum = 0;
            //var aggregate = 0;
            var dictionary = new DictionaryRomanNumerals();
            for (int position = 0; position < number.Length; position++)
            {
                var currentNumber = number[position];
                if (position == number.Length - 1)
                {
                    totalSum += dictionary.RomanNumerals[currentNumber];
                }
                else {
                    var nextNumber = number[position + 1];
                    if (dictionary.RomanNumerals[nextNumber] > dictionary.RomanNumerals[currentNumber])
                    {
                        totalSum -= dictionary.RomanNumerals[currentNumber];
                    }
                    else {
                        totalSum += dictionary.RomanNumerals[currentNumber];
                    }
                }
            }
            return totalSum;
        }

        public string aggregate(int subtractedNumber)
        {
            var concat = "";
            concat += ParseArabicNumber(subtractedNumber);
            return concat;
        }
        public string ParseArabicNumber(int number)
        {
            //in for loops, need to initialize and set the variable to something so it can be called and accessed after being manipulated in the loop. 
            //var newNumber = 0; 
            var dictionary = new DictionaryRomanNumerals();
            if (number.ToString().Contains("4") || number.ToString().Contains("9"))
            {
                var firstLetter = dictionary.ArabicNumbers[/*key less than number*/];   //the romannumeral less than number; use parseromannumeralstring(number) to see which roman numeral is less than number
                var secondLetter = dictionary.ArabicNumbers[/* key greater than number*/]; //these both should return characters
                var concatLetters = firstLetter + secondLetter;
                return concatLetters;  //will give me a two characters, which will be a string. 
            }
            if (number >= 1000)
            {
                var newNumber = number - 1000;
                return "M" + aggregate(newNumber);
            }
            if (number >= 500)
            {
                var newNumber = number - 500;
                return "D" + aggregate(newNumber);
            }
            if (number >= 100)
            {
                var newNumber = number - 100;
                return "C" + aggregate(newNumber);
            }
            if (number >= 50)
            {
                var newNumber = number - 50;
                return "L" + aggregate(newNumber);
            }
         
            if (number >= 10)
            {
                var newNumber = number - 10;
                return "X" + aggregate(newNumber);
            }
            if (number >= 5)
            {
                var newNumber = number - 5;
                return "V" + aggregate(newNumber);
            }
            if (number >= 1)
            {
                var newNumber = number - 1;
                return "I" + aggregate(newNumber);
            }
            else
            {
                return "";
            }
        }
    }
}
