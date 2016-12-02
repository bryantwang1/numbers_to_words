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
            List<int> digits = new List<int> {};
            int size = _number.ToString().Length;
            string[] digitStrings = _number.ToString().ToCharArray().Select( n => n.ToString()).ToArray();
            for (int idx = 0; idx < size; idx++)
            {
                digits.Add(int.Parse(digitStrings[idx]));
            }

            string result = "";

            for (int idx = 0; idx < digits.Count; idx++)
            {
                bool noSpace = false;
                string word = "";
                if (digits.Count <= 2)
                {
                    if (digits.Count == 1)
                    {
                        word = _numberWords[digits[idx]];
                    }
                    else
                    {
                        int combinedIndex = int.Parse(digits[0].ToString() + digits[1].ToString());
                        word = _numberWords[combinedIndex];
                        idx++;
                    }
                }
                else
                {
                    noSpace = true;
                    if (digits[idx] > 0)
                    {
                        noSpace = false;
                        int numberOfZero = digits.Count - 1;
                        word = _numberWords[digits[idx]];
                        if (numberOfZero == 2)
                        {
                            word += " hundred";
                        }
                        else if (numberOfZero == 3)
                        {
                            word += " thousand";
                        }
                    }
                    digits.RemoveAt(idx);
                    idx--;
                }

                if (noSpace || result == "")
                {
                    result += word;
                }
                else
                {
                    result += " " + word;
                }
            }
            return result;
        }
    }
}
