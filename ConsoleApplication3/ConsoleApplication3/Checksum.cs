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
            }
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
