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
        //public List<string> TextLines = new List<string>();
        //public List<List<string>> Characters = new List<List<string>>(); 

        //public object ParseAllCharacters_2() //max's method
        //{
        //    List<string>[] Character = new List<string>[] { zerothCharacter, firstCharacter, secondCharacter, thirdCharacter, fourthCharacter, fifthCharacter, sixthCharacter, seventhCharacter, eigthCharacter };
        //    return Character.Select(ParseCharacter).Select((v, idx) => ((int)Math.Pow(10, 8 - idx)) * v).Aggregate((acc, elm) => acc + elm);
        //}

        public List<string> ReadFile(string fileName)
        { //this is an impure method... it has to get a file from a specific location, allowing room for error outside of problems with the syntax, etc. 
            List<string> fileContents = new List<string>();
            string line;
            var file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                fileContents.Add(line);
            }
            return fileContents;
        }

        public List<List<string>> AssignCharactersToIndex(List<string> lines)
        { //this is a pure function... it only relies on itself and doesn't reach out to a file location, etc. It only relies on the logic within the (). 
          //the parameter lines is defined in the test... it is not hardcoded and it is not related to the lines in GetNthCharacter(index, lines). These are methods that 
          //will get defined when we do our tests; they're "on reserve for use"
            List<List<string>> Characters = new List<List<string>>();
            int i = 0;
            for (i = 0; i < 9; i++)
            {
                Characters.Add(GetNthCharacter(i, lines));
            }
            return Characters;
        }

        public List<string> GetNthCharacter(int Index, List<string> TextLines)
        { //empty shell functionality on this method allows the TextLines to be defined elsewhere when the parameter is assigned, such as the tests. 
            List<string> MatrixedDigit = new List<string>(); 
            int lengthOfSubstring = 3;
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

        public int ParseAllCharacters(List<List<string>> Characters)
        {//this () takes in ParseCharacter as part of its functionality; 
            var bankOCR = new BankOCR();
            string aggregatedNumber = "";
            foreach (List<string> character in Characters)
            {
                aggregatedNumber += ParseCharacter(character).ToString();
            }
            return int.Parse(aggregatedNumber);
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
    }
}

//talking with Steve on 3.14.16: the ()s are empty shells that return values based on the parameters given to it. To have an add(), you need to have 2 parameters to add, which 
//    can change, which is why you put the placeholding parameters. So, the example method is below: 

    //public int add(int a, int b)
    //{
    //    a = 1;
    //    b = 2;
    //    addition = a + b; 
    //    return addition;
    //}

//    with this set up, the values of a and b are not assigned until they're set in the (). This allows movability, changability and allows it impact other functions and be used in 
//    other functions based on indirect reliability when "addition" is called in another function. This is a stand alone method that takes parameters that you assign in the method - 
//    they're an empty shell. They are not hardcoded... and if they are, then you will have problems with flexibility and complexity. 
