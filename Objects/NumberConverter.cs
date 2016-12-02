using System.Collections.Generic;
using System.Linq;
using System;

namespace NumbersToWords.Objects
{
    public class NumberConverter
    {
        private int _number;
        private string _result;
        private Dictionary<int, string> _numberWords = new Dictionary<int, string> ()
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
        };

        public NumberConverter(int input)
        {
            _number = input;
            _result = "";
        }

        public string Convert()
        {
            List<int> digits = new List<int> {};
            int size = _number.ToString().Length;
            string[] digitStrings = _number.ToString().ToCharArray().Select( n => n.ToString()).ToArray();
            for (int idx = 0; idx < size; idx++)
            {
                digits.Add(int.Parse(digitStrings[idx]));
            }

            string word = "";
            int numberOfZero = digits.Count-1;

            if(digits[0] != 0)
            {
                if(numberOfZero % 3 == 0)
                {
                    word = _numberWords[digits[0]];
                }
                else
                {
                    // This should find tens above 1000
                    if(numberOfZero % 3 == 1)
                    {
                        int key = int.Parse(digits[0].ToString() + digits[1].ToString());
                        // This if should handle 1-20 or the other round tens (i.e. 30, 40)
                        if(_numberWords.ContainsKey(key))
                        {
                            word = _numberWords[digits[key]];
                        }
                        else
                        {
                            int key2 = int.Parse(digits[0].ToString() + "0");
                            int key3 = digits[1];
                            word = _numberWords[key2] + " " + _numberWords[key3];
                        }
                    }
                    // This should find hundreds above 1000
                    else if(numberOfZero % 3 == 2)
                    {
                        int key = int.Parse(digits[0].ToString() + digits[1].ToString() + digits[2].ToString());
                        word = _numberWords[digits[key]];
                        // THIS NEEDS FLESHING OUT
                    }

                    if(numberOfZero >= 12)
                    {
                        word += " trillion";
                    }
                    else if(numberOfZero >= 9)
                    {
                        word += " billion";
                    }
                    else if(numberOfZero >= 6)
                    {
                        word += " million";
                    }
                    else if(numberOfZero >= 3)
                    {
                        word += " thousand";
                    }
                }
            }

            if (_result == "")
            {
                _result += word;
            }
            else
            {
                _result += " " + word;
            }

            // ADJUST HOW MANY NUMBERS ARE REMOVED BASED ON WHAT HAS BEEN PASSED
            string stringForNumber = "";
            for (int idx = 1; idx < digits.Count; idx++)
            {
                stringForNumber += digits[idx].ToString();
            }

            if(stringForNumber != "")
            {
                _number = int.Parse(stringForNumber);
                Convert();
            }

            return _result;
        }
    }
}
