using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            // For Part 3, where we use a random number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int numberOfGuesses = 0;

            Console.WriteLine("🔮 Welcome to the Guess My Number Game! 🔮");
            Console.WriteLine("I've selected a magic number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"🎉 Congratulations! You guessed it in {numberOfGuesses} guesses!");
                }

                numberOfGuesses++;
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();

            if (playAgainInput != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing! Come back soon!");
            }
            else
            {
                Console.Clear(); // Clear the console for a fresh start
            }
        }
    }
}
