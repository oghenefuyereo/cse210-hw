using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🎓 Welcome to the Grade Evaluator 3000! 🚀");
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();

        if (int.TryParse(answer, out int percent))
        {
            string letter = "";

            if (percent >= 90)
            {
                letter = "A";
            }
            else if (percent >= 80)
            {
                letter = "B";
            }
            else if (percent >= 70)
            {
                letter = "C";
            }
            else if (percent >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"📚 Your grade is: {letter} 🌟");

            if (percent >= 70)
            {
                Console.WriteLine("🎉 Congratulations! You passed with flying colors! 🌈");
            }
            else
            {
                Console.WriteLine("😢 Oops! Better luck next time! 🍀");
            }
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid percentage.");
        }
    }
}
