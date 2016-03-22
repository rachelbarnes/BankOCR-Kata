using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class CheckSum
    {
        //public enum CharacterPosition(){
        public bool CheckForValidCheckSum(int accountNumber)
        {
            //this needs to be cleaned up - this is not very readable
            BankOCR bankocr = new BankOCR();
            string file = "thirdOCRFile.txt";
            long fullAccountNumber = bankocr.GetAccountNumber(bankocr.ParseFile(file));
            string accountNumberString = (bankocr.GetAccountNumber(bankocr.ParseFile(file))).ToString();
            int incrementStartingPoint = 1;
            int increment = incrementStartingPoint++;
            int sumOfPositionValueAndIncrement = 0;
            int multOfPositionValuesandIncrements = 0;

            int position;
            //Dictionary<int, char> AccountNumberDictionary = new Dictionary<int, char>();
            int characterPosition = 1;
            char numberCharacter = ' ';
            IEnumerable<int> IndexOfNumberInAccountNumber = Enumerable.Range(characterPosition, 9); //starting at, how many ints are in the range
            foreach (char number in IndexOfNumberInAccountNumber)
            {
                characterPosition++;
                numberCharacter = accountNumberString.ToCharArray()[characterPosition];
            }
            //this foreach is taking the characters in the account number and putting them in an array; then i have the characterPosition increasing for each number
            //for each character; the numberCharacter variable is equaled to a particular point in the array of the account number. 
            //this passes until I tell the characterposition to break if the characterposition is greater than 8
            //because I havent created any class objects or class variables, I can't test this foreach method individually, although the error says the index
            //is outside of the range of my array, which I would say it's safe to assume I'm having a problem with my array
            //characterPosition 9 produces a 53 '5' for my character string, which is unexpected, esp for a char

            for (position = 9, characterPosition = 1; position > 0; position--, characterPosition++)
            {
                ++increment;
                if (increment < 10)
                { increment++; }
                if (increment > 9)
                { increment = 0; }

                sumOfPositionValueAndIncrement = numberCharacter + increment;
                //having the characterPosition should give numberCharacter the different values it's supposed to have
                //but i still have the same problem, that the index was outside the bounds of the array
                multOfPositionValuesandIncrements *= sumOfPositionValueAndIncrement;

                int numberPostionInAccount = position;
            }
            int checkSum = multOfPositionValuesandIncrements % 11;

            if (checkSum == 0)
            { return true; }
            else return false;
        }

    }
}

//the position names are the positions of the account number; the account number will
//be added with a particular interger based on its location and then the sum of these numbers will be multiplied
//the 9th position will be added with 2, the 8th position with 3, etc. 