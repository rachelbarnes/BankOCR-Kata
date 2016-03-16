using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class DictionaryOfCharacters
    {
        public Dictionary<int, string> textFileCharacters = new Dictionary<int, string>();
        public Dictionary<int, string> defineDictionary(Dictionary<int, string> textFileCharacters)
        {
            textFileCharacters.Add(1, "     |  |   ");
            textFileCharacters.Add(2, " _  _||_    ");
            textFileCharacters.Add(3, " _  _| _|   ");
            textFileCharacters.Add(4, "   |_|  |   ");
            textFileCharacters.Add(5, " _ |_  _|   ");
            textFileCharacters.Add(6, " _ |_ |_|   ");
            textFileCharacters.Add(7, " _   |  |   ");
            textFileCharacters.Add(8, " _ |_||_|   ");
            textFileCharacters.Add(9, " _ |_|  |   ");
            textFileCharacters.Add(0, " _ | ||_|   ");

            return textFileCharacters;
        }
    }
}
