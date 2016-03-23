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
            var Checksum = ChecksumAllDigits(accountNumber) % 11;
            if (Checksum == 0)
            { return true; }
            else return false; 
        }

        public int ChecksumAllDigits(int number)
        {
            string accountNumberString = number.ToString();
            var sumOfPositionValueAndIncrement = 0;
            int increment = 1; 
            for (var position = 8; position >= 0; position--, increment++)
            {
                sumOfPositionValueAndIncrement += (int.Parse(accountNumberString[position].ToString()) * FindInverse(position));
            }

            return sumOfPositionValueAndIncrement;
        }
        public int FindInverse(int x)
        {
            return Math.Abs(x - 9);
        }

          //if (checkSum == 0)
          //  { return true; }
          //  else return false;
    }
}

//the position names are the positions of the account number; the account number will
//be added with a particular interger based on its location and then the sum of these numbers will be multiplied
//the 9th position will be added with 2, the 8th position with 3, etc. 

            //IEnumerable<int> IndexOfNumberInAccountNumber = Enumerable.Range(characterPosition, 9); //starting at, how many ints are in the range
            //foreach (char number in IndexOfNumberInAccountNumber)
            //{
            //    characterPosition++;
            //    numberCharacter = accountNumberString.ToCharArray()[characterPosition];
            //}



//                multOfPositionValuesandIncrements *= sumOfPositionValueAndIncrement;

 //               int numberPostionInAccount = position;
         //   }
            //int checkSum = multOfPositionValuesandIncrements % 11;

