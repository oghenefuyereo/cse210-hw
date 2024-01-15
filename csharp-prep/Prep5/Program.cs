using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("~~~ Welcome to the Magical Number Square Program! ~~~");
        Console.ResetColor();
    }

    static string PromptUserName()
    {
        Console.Write("🌟 Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("🔮 Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✨ {name}, the magic square of your number is {square}! ✨");
        Console.ResetColor();
    }
}
