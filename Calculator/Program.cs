using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class CalculatorApp
    {
        static int _sum;
        static string[] _numStrings;
        static List<int> _negativeNumbers;

        public static void Main()
        {
            // Declare and initial list of numbers 
            string userInput = "";
            bool keepGoing = true;

            while (keepGoing)
            {
                // Ask the user to enter numbers
                Console.WriteLine("Enter a list of numbers to add together.");
                Console.WriteLine("Seperate each number with a comma or new line characters");
                Console.WriteLine("Numbers must be between 0 and 1000");
                userInput = Console.ReadLine();

                // Return answer to the user
                Console.WriteLine($"The sum of your numbers is {Calculate(userInput)}");

                //Ask user if they continue
                Console.WriteLine("Press Y To enter new numbers");
                if (Console.ReadLine().ToLower() != "y") keepGoing = false;

            }
        }

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
            //Split the string at the commas and new line characters
            _numStrings = userInput.Split(new string[] { ",", "\\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string argument in _numStrings)
            {
                int num = 0;

                //Check that value is a number
                var success = int.TryParse(argument, out num);

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
    }
}
