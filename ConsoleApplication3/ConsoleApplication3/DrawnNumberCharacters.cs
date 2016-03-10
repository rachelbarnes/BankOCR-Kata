using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3 {

  //i think i will have to create lists to subsitute the dictionary - I can't seem to call a dictionary key
  //or at least im having a hard time doing so
  public class DrawnNumberCharacters {
    // public void AddingToTheDictionary() {
    public Dictionary<int, List<string>> Numbers = new Dictionary<int, List<string>>() {
      { 0, new List<string>() { " _ ", "| |", "|_|", "   " } },
      { 1, new List<string>() { "   ", "  |", "  |", "   " } },
      { 2, new List<string>() { " _ ", " _|", "|_ ", "   " } },
      { 3, new List<string>() { " _ ", " _|", " _|", "   " } },
      { 4, new List<string>() { "   ", "|_|", "  |", "   " } },
      { 5, new List<string>() { " _ ", "|_ ", " _|", "   " } },
      { 6, new List<string>() { " _ ", "|_ ", "|_|", "   " } },
      { 7, new List<string>() { " _ ", "  |", "  |", "   " } },
      { 8, new List<string>() { " _ ", "|_|", "|_|", "   " } },
      { 9, new List<string>() { " _ ", "|_|", " _|", "   " } },
    };

    public List<string> one = new List<string>() {
        "   ",
        "  |",
        "  |",
        "   "
      };

    public List<string> two = new List<string> {
        " _ ",
        " _|",
        "|_ ",
        "   "
      };

    public List<string> three = new List<string> {
        " _ ",
        " _|",
        " _|",
        "   "
      };

    public List<string> four = new List<string> {
        "   ",
        "|_|",
        "  |",
        "   "
      };

    public List<string> five = new List<string> {
        " _ ",
        "|_ ",
        " _|",
        "   "
      };

    public List<string> six = new List<string> {
        " _ ",
        "|_ ",
        "|_|",
        "   "
      };

    public List<string> seven = new List<string> {
       " _ ",
       "  |",
       "  |",
       "   "
      };

    public List<string> eight = new List<string> {
       " _ ",
       "|_|",
       "|_|",
       "   "
      };

    public List<string> nine = new List<string> {
        " _ ",
        "|_|",
        " _|",
        "   "
      };

    public List<string> zero = new List<string> {
        " _ ",
        "| |",
        "|_|",
        "   "
      };
  
  }
}