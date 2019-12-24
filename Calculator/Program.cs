using System;

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
                Console.WriteLine($"Welcome to the addition app! {Environment.NewLine}" +
                    $"----------------------------------------- {Environment.NewLine}" +
                    $"Enter a list of dilimiter of your choice followed by a list of numbers {Environment.NewLine}" +
                    $"Use the following format: //[delimiter1][delimiter2]\\n(numbers)// {Environment.NewLine}" +
                    $"----------------------------------------- {Environment.NewLine}" +
                    $"Numbers must be between 0 and 1000");

                //Read the user's input
                userInput = Console.ReadLine();

                // Return answer to the user
                Console.WriteLine($"The sum of your numbers is {Calculator.Calculate(userInput)}");

                //Ask user if they continue
                Console.WriteLine("Press Ctrl + C to Exit Program");
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Modifiers == ConsoleModifiers.Control && input.Key == ConsoleKey.C)
                {
                    keepGoing = false;
                }

            }
        }
    }
}
