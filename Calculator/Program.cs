using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class CalculatorApp
    {
        public static void Main()
        {
            // Declare and initial list of numbers 
            string userInput = "";
            bool keepGoing = true;

            while (keepGoing)
            {
                // Ask the user to enter numbers
                Console.WriteLine("Enter a list of numbers to add together. Seperate each number with a comma or new line characters");
                userInput = Console.ReadLine();

                // Return answer to the user
                Console.WriteLine($"The sum of your numbers is {AddNumbers(userInput)}");

                //Ask user if they continue
                Console.WriteLine("Press Y To enter new numbers");
                if (Console.ReadLine().ToLower() != "y") keepGoing = false;

            }
        }

        public static int AddNumbers(string userInput)
        {

            int sum = 0;
            string[] numStrings = Array.Empty<string>();
            List<int> negativeNumbers = new List<int>();

            if (userInput.Length != 0)
            {
                //Split the string at the commas and new line characters
                numStrings = userInput.Split(new string[] { ",", "\\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string argument in numStrings)
                {
                    int num = 0;

                    //Check that value is a number
                    var success = int.TryParse(argument, out num);

                    //If value is a number, add it to the sum
                    if (success)
                    {
                        if (num < 0)
                        {
                            negativeNumbers.Add(num);
                        }
                        else
                        {
                            sum += num;
                        }                        
                    }
                }
            }
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Cannot enter negative numbers. Invalid values: {string.Join(",", negativeNumbers.ToArray())}");
            }
            return sum;
        }
    }
}
