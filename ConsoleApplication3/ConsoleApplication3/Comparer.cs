using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Comparer
    {
        BankOCR bankOCR = new BankOCR();
        DrawnNumberCharacters drawnNumberCharacters;
        public List<string> ListA = new List<string>();
        public List<string> ListB = new List<string>();
        public int comparerDigitIndex;
        public Comparer()
        {
            comparerDigitIndex = 0;
            drawnNumberCharacters = new DrawnNumberCharacters();
        }

        public bool ComparingListSize(List<string> ListA, List<string> ListB)
        {
            //bankOCR.ReadFile();
            bankOCR.AssignCharactersToIndex();
            ListA = bankOCR.zerothCharacter;
            ListB = drawnNumberCharacters.Numbers[1];
            int ListACount = ListA.Count();
            int ListBCount = ListB.Count();


            if (ListACount != ListBCount)
                return false;
            else return true;
            //i printed out the else here because vs was compaining that not all paths returned a code
        }
        public bool ComparingListValues(List<string> ListA, List<string> ListB)
        {
            //bankOCR.ReadFile();
            bankOCR.AssignCharactersToIndex();
            //bankOCR.GetNthCharacter(MatricedDigitIndex); 
            ListA = bankOCR.zerothCharacter;
            ListB = drawnNumberCharacters.Numbers[1];

            if (ListA != ListB)
                return false;
            else return true;
        }
        public int ComparingLists(List<string> IndexedList, Dictionary<int, List<string>> DictionaryB)
        {
            //bankOCR.ReadFile();
            bankOCR.AssignCharactersToIndex();
            bankOCR.GetNthCharacter(comparerDigitIndex);
            for (comparerDigitIndex = 0; comparerDigitIndex < 9; comparerDigitIndex++)
            {
                for (int key = 0; key <10; key++)
                {
                    if (DictionaryB[0] == IndexedList)
                        return key;
                }
            }
            return -1;
        }
    }
}

