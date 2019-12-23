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
                Console.WriteLine("Enter a list of numbers to add together. Seperate each number with a comma");
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

            if (userInput.Length != 0)
            {
                //Split the string at the commas
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
