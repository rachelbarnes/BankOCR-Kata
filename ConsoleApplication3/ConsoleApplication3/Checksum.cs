using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class CheckSum
    {
        //BankOCR Bank;
        //public CheckSum CheckAccountNumbersForValidity(BankOCR BankAccountNumbers)
        //{
        //    var textToBeConverted = Bank.
        //    this.Bank.GetAccountNumber(textToBeConverted);
        //    this.Bank = BankAccountNumbers;

        //}
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

        public bool CheckForValidCheckSum(int accountNumber)
        {
            var Checksum = ChecksumAllDigits(accountNumber) % 11;
            if (Checksum == 0)
            { return true; }
            else return false;
        }


        public int FindInverse(int x)
        {
            return Math.Abs(x - 9);
        }

        ////Class Variables
        //   public BankOCR HSBC;


        //   //Constructor
        //   public IllegibleCharacter(BankOCR bankOCRInstance)
        //   {
        //       HSBC = bankOCRInstance;
        //   }


        //Class Methods
        public string CheckValidAccountNumber(string accountNumber)
        {
            var bankOCR = new BankOCR();
            var validAccountNumber = (CheckForValidCheckSum(int.Parse(accountNumber)));
            var improperlyScannedNumber = accountNumber;
            var invalidAccountNumberResponse = accountNumber + " ERR";
            var improperlyScannedNumberRepsonse = accountNumber + " ILL";


            if (validAccountNumber == true)
            { return accountNumber; }
            if (validAccountNumber == false)
            {
                if (improperlyScannedNumber.Contains("?"))
                { return improperlyScannedNumberRepsonse; }
            }

            return invalidAccountNumberResponse;
            //i realized that this really only works for when one of the account numbers has the value of a ?, 
            //which means this is not versitile. 

            //if file is correct, print the file
            //if file is not a valid number according to the checksum, print the number and 
            //print ERR next to the number
            //if the number is illegible, print the number and replace illegible numbers with ?s
            //and print ILL next to the number
        }
    }
}



