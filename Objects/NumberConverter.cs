using System.Collections.Generic;
using System.Linq;
using System;

namespace NumbersToWords.Objects
{
    public class NumberConverter
    {
        private int _number;
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
        }

        public string Convert()
        {
            string numberString = _number.ToString();
            string[] digitStrings = numberString.ToCharArray().Select( n => n.ToString()).ToArray();
            Array.Reverse(digitStrings);
            string zeroString = "";
            for (var idx = 0; idx < digitStrings.Length; idx++)
            {
                digitStrings[idx] += zeroString;
                Console.WriteLine("digit: " + digitStrings[idx] + ", zeroString: " + zeroString);
                zeroString += "0";
            }

            Array.Reverse(digitStrings);

            string result = "";
            for (var idx = 0; idx < digitStrings.Length; idx++)
            {
                string digit = digitStrings[idx];
                string word = "";
                if(digit[0] == '0')
                {

                }
                else
                {
                    if(digit == "10")
                    {
                        word = _numberWords[int.Parse(digit) + int.Parse(digitStrings[idx+1])];
                        idx++;
                    }
                    else
                    {
                        word = _numberWords[int.Parse(digit)];
                    }

                    if (result != "")
                    {
                        result += " " +  word;
                    }
                    else
                    {
                        result += word;
                    }
                }
            }
            return result;
        }
    }
}
