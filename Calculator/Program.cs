using System;
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
                Console.WriteLine("Enter 2 numbers to add together, seperated by a comma");
                userInput = Console.ReadLine();

                // Return answer to the user
                Console.WriteLine($"The sum of your two numbers is {AddNumbers(userInput)}");

                //Ask user if they continue
                Console.WriteLine("Press Y To enter new numbers");
                if (Console.ReadLine().ToLower() != "y") keepGoing = false;

            }
        }

        public static int AddNumbers(string userInput)
        {
            int sum = 0;
            int count = userInput.Count(x => x == ',');

            if (userInput.Length != 0)
            {
                //Return an argument exception when more than one comma is entered
                if (count > 1)
                {
                    Console.WriteLine("The string contains more than one comma. Unable to perform operation");
                    throw new ArgumentException("User entered more than one comma");
                }
                //Split the string at the comma
                string[] numStrings = userInput.Split(',');
                foreach (string argument in numStrings)
                {
                    int num = 0;

                    //Check that value is a number
                    var success = int.TryParse(argument, out num);

                    //If value is a number, add it to the sum
                    if (success)
                    {
                        sum += num;
                    }
                }
            }
            return sum;
        }
    }
}
