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
            var accountNumberString = number.ToString();
            var sumOfPositionValueAndIncrement = 0;
            var increment = 1;
            for (var position = 8; position >= 0; position--, increment++)
            {
                sumOfPositionValueAndIncrement += (int.Parse((accountNumberString[position].ToString())) * FindInverse(position));
            }//string allows us to choose positions in the string without creating a foreach loop
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
        public string CheckValidityAccountNumber(string accountNumber)
        {

            //int outResult;
            var improperlyScannedNumber = accountNumber;
            var invalidAccountNumberResponse = accountNumber + " ERR";
            var improperlyScannedNumberRepsonse = accountNumber + " ILL";
            if (accountNumber.Contains("?"))
            { return improperlyScannedNumberRepsonse; }

            var validAccountNumber = CheckForValidCheckSum(Convert.ToInt32(int.Parse(accountNumber))); //, out outResult)));
            if (validAccountNumber == true)
            { return accountNumber; }
            else return invalidAccountNumberResponse;
        }
    }
}

//i battled with the int.TryParse... and I lost. So i rearranged the order of operations to check if it's illegible before it can
//parse the string into an int, which was my problem as ? cannot be parsed into an int, so it broke the code. 
