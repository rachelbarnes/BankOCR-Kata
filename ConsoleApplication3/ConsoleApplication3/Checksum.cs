using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Checksum
    {

        public int ChecksumAllDigits(int number)
        {
            var digitSum = 0;
            for (var position = 8; position >= 0; position--)
            {
                var digit = int.Parse((number.ToString()[position].ToString()));
                digitSum += (digit * FindInverse(position));
            }//string allows us to choose positions in the string without creating a foreach loop
            return digitSum;
        }

        public bool CheckForValidCheckSum(int accountNumber)
        {
            var Checksum = ChecksumAllDigits(accountNumber) % 11;
            return Checksum == 0;
        }

        public int FindInverse(int x)
        {
            return Math.Abs(x - 9);
        }

        public string CheckValidityAccountNumber(string accountNumber)
        {
            if (accountNumber.Contains("?")) {
                return accountNumber + " ILL";
            }

            if (CheckForValidCheckSum(Convert.ToInt32(int.Parse(accountNumber)))) {
                return accountNumber;
            } else {
                return accountNumber + " ERR";
            }
        }
    }
}

//i battled with the int.TryParse... and I lost. So i rearranged the order of operations to check if it's illegible before it can
//parse the string into an int, which was my problem as ? cannot be parsed into an int, so it broke the code. 
