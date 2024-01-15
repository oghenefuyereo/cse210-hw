using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🌟 Welcome to the Grade Evaluator 5000! 🚀");
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();

        if (int.TryParse(answer, out int percent))
        {
            string letter = "";
            string sign = "";

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

            // Determine the sign
            int lastDigit = percent % 10;
            if (percent >= 60 && (lastDigit >= 7))
            {
                sign = "+";
            }
            else if (percent >= 60 && (lastDigit < 3))
            {
                sign = "-";
            }

            // Handle exceptional cases
            if (letter == "A" && lastDigit >= 7)
            {
                letter = "A-";
                sign = "";
            }
            else if (letter == "F" && (lastDigit >= 3 || lastDigit <= 0))
            {
                letter = "F";
                sign = "";
            }

            Console.WriteLine($"🎓 Your grade is: {letter}{sign} 🌈");

            if (percent >= 70)
            {
                Console.WriteLine("🎉 Congratulations! You've mastered the material! 🚀");
            }
            else
            {
                Console.WriteLine("😢 Oops! Don't worry, keep striving for success! 🌟");
            }
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid percentage.");
        }
    }
}
