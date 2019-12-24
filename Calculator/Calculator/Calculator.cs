using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calculator
    {
        static int _sum;
        static string[] _numStrings;
        static List<int> _negativeNumbers;

        public static int Calculate(string userInput)
        {

            _sum = 0;
            _numStrings = Array.Empty<string>();
            _negativeNumbers = new List<int>();

            if (userInput.Length != 0)
            {
                FormatNumbers(userInput);

            }
            if (_negativeNumbers.Any())
            {
                throw new ArgumentException($"Cannot enter negative numbers. Invalid values: {string.Join(",", _negativeNumbers.ToArray())}");
            }
            return _sum;
        }

        private static void FormatNumbers(string userInput)
        {
            List<string> delimiters = new List<string> { ",", "\\n" };

            if (userInput.StartsWith("//", StringComparison.Ordinal))
            {
                ManageCustomDelimiter(userInput, delimiters);
            }

            //Split the string at the commas and new line characters
            _numStrings = userInput.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string argument in _numStrings)
            {
                //Check that value is a number
                var success = int.TryParse(argument, out int num);

                //If value is a number, add it to the sum
                if (success)
                {
                    if (num < 0)
                    {
                        _negativeNumbers.Add(num);
                    }
                    else if (num > 1000)
                    {
                        num = 0;
                    }
                    else
                    {
                        _sum += num;
                    }
                }
            }
        }

        private static void ManageCustomDelimiter(string userInput, List<string> delimiters)
        {
            Console.WriteLine(userInput[2]);
            string customDelimiter = "";

            //User is entering a custom delimiter of more than one character
            if (userInput[2].ToString().Equals("["))
            {
                customDelimiter = userInput.Split('[', ']')[1];
                //Remove section of string where user sets delimiter
                userInput = userInput.Substring(userInput.IndexOf("]", StringComparison.Ordinal) + 3);
            }
            //User is entering a one character custom delimiter
            else
            {
                customDelimiter = userInput[2].ToString();
                //Remove section of string where user sets delimiter
                userInput = userInput.Substring(5);
            }

            //Add custom delimiter to existing list
            delimiters.Add(customDelimiter);

            
            

            //Remove characters in cases where user selects a number as a custom delimiter
            var numDelimiter = int.TryParse(customDelimiter, out _);
            if (numDelimiter)
            {
                foreach (string d in delimiters)
                {
                    userInput.Replace(d, "");
                }
            }
        }
    }
}
