using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class DictionaryOfCharacters
    {
        public Dictionary<string, int> textFileCharacters = new Dictionary<string, int> { 
            {"     |  |   ",1},
            {" _  _||_    ",2},
            {" _  _| _|   ",3},
            {"   |_|  |   ",4},
            {" _ |_  _|   ",5},
            {" _ |_ |_|   ",6},
            {" _   |  |   ",7},
            {" _ |_||_|   ",8},
            {" _ |_|  |   ",9},
            {" _ | ||_|   ",0},
        };
    }
}
