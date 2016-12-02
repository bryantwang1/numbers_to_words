using System.Collections.Generic;
using System.Linq;
using System;

namespace NumbersToWords.Objects
{
    public class NumberConverter
    {
        private long _number;
        private string _result;
        private long _countdown;
        private Dictionary<long, string> _numberWords = new Dictionary<long, string> ()
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

        public NumberConverter(long input)
        {
            _number = input;
            _result = "";
            // safeguard against stack overflow
            _countdown = input.ToString().Length;
        }

        public string Convert()
        {
            List<long> digits = new List<long> {};
            int size = _number.ToString().Length;
            string[] digitStrings = _number.ToString().ToCharArray().Select( n => n.ToString()).ToArray();
            for (int idx = 0; idx < size; idx++)
            {
                digits.Add(Int64.Parse(digitStrings[idx]));
            }

            int skipAmount = 0;
            string word = "";
            int numberOfZero = digits.Count-1;

            if(digits[0] != 0)
            {
                if(numberOfZero % 3 == 0)
                {
                    skipAmount++;
                    word = _numberWords[digits[0]];
                }
                else
                {
                    // This should find hundreds and tens
                    if(numberOfZero % 3 <= 2)
                    {
                        if(numberOfZero % 3 == 2)
                        {
                            skipAmount++;
                            word = _numberWords[digits[0]] + " hundred";
                        }
                        // This should find tens
                        else if(numberOfZero % 3 == 1)
                        {
                            int twoDigitKey = int.Parse(digits[0].ToString() + digits[1].ToString());
                            // This if should handle 1-20 or the other round tens (i.e. 30, 40)
                            if(_numberWords.ContainsKey(twoDigitKey))
                            {
                                skipAmount += 2;
                                word = _numberWords[twoDigitKey];
                                numberOfZero--;
                            }
                            else
                            {
                                skipAmount++;
                                int tensKey = int.Parse(digits[0].ToString() + "0");
                                word = _numberWords[tensKey];
                            }
                        }
                    }
                }

            }
            else // if the digit is 0
            {
                skipAmount = 1;
                word = "";
            }
            if(numberOfZero == 12)
            {
                word += " trillion";
            }
            else if(numberOfZero == 9)
            {
                word += " billion";
            }
            else if(numberOfZero == 6)
            {
                word += " million";
            }
            else if(numberOfZero == 3)
            {
                word += " thousand";
            }

            if (_result == "" || word == "")
            {
                _result += word;
            }
            else
            {
                _result += " " + word;
            }

            // ADJUST HOW MANY NUMBERS ARE REMOVED BASED ON WHAT HAS BEEN PASSED
            string stringForNumber = "";
            for (int idx = skipAmount; idx < digits.Count; idx++)
            {
                stringForNumber += digits[idx].ToString();
            }

            if(stringForNumber != "" && _countdown > 1)
            {
                _number = Int64.Parse(stringForNumber);
                _countdown--;
                Convert();
            }
            Console.WriteLine("result: " + _result);
            return _result;
        }
    }
}
