using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the Awesome Number Analyzer!");
        Console.ResetColor();

        List<int> numbers = new List<int>();

        Console.Write("Do you want to add some random numbers? (yes/no): ");
        string addRandom = Console.ReadLine().ToLower();

        if (addRandom == "yes")
        {
            Random random = new Random();
            int numberOfRandomNumbers = random.Next(1, 6);

            Console.WriteLine($"\nAdding {numberOfRandomNumbers} random numbers to the list:");

            for (int i = 0; i < numberOfRandomNumbers; i++)
            {
                int randomNum = random.Next(1, 101); // Generates random numbers between 1 and 100
                numbers.Add(randomNum);
                Console.WriteLine($"Generated: {randomNum}");
            }
        }

        Console.WriteLine("\nEnter your own numbers (enter 0 to finish):");

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");

            string userResponse = Console.ReadLine();

            try
            {
                userNumber = int.Parse(userResponse);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                continue; // Skip the rest of the loop and ask for input again
            }

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = numbers.Sum();
        Console.WriteLine($"\n*** Analysis Results ***");
        Console.WriteLine($"Sum:      {sum}");
        Console.WriteLine($"Average:  {(numbers.Count > 0 ? ((float)sum) / numbers.Count : 0):F2}");
        Console.WriteLine($"Max:      {(numbers.Count > 0 ? numbers.Max() : 0)}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThank you for using the Awesome Number Analyzer! Have a great day!");
        Console.ResetColor();
    }
}
