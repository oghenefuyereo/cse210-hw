using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scripture object
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

            // Display the complete scripture
            Console.WriteLine(scripture.Display());

            // Keep prompting the user until all words are hidden
            while (!scripture.AllWordsHidden())
            {
                Console.WriteLine("Press enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                // Clear the console
                Console.Clear();

                // Prompt the user for the number of words to hide
                Console.WriteLine("Enter the number of words to hide (or type 'all' to hide all remaining words):");
                string userInput = Console.ReadLine();
                int wordsToHide;
                if (userInput.ToLower() == "all")
                    wordsToHide = scripture.GetRemainingWordsCount();
                else
                    wordsToHide = int.Parse(userInput);

                // Hide the specified number of words
                scripture.HideRandomWords(wordsToHide);

                // Display the updated scripture
                Console.WriteLine(scripture.Display());
            }

            Console.WriteLine("You've hidden all the words! Congratulations!");
        }
    }

    // Class to represent a scripture
    class Scripture
    {
        private string reference;
        private List<ScriptureWord> words;

        // Constructor
        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
        }

        // Method to display the scripture
        public string Display()
        {
            return $"{reference}: {string.Join(" ", words.Select(word => word.IsHidden ? "_" : word.Text))}";
        }

        // Method to check if all words are hidden
        public bool AllWordsHidden()
        {
            return words.All(word => word.IsHidden);
        }

        // Method to hide a specified number of random words
        public void HideRandomWords(int count)
        {
            Random random = new Random();
            int wordsToHide = Math.Min(count, GetRemainingWordsCount());
            List<int> indices = Enumerable.Range(0, words.Count).Where(i => !words[i].IsHidden).ToList();
            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(indices.Count);
                words[indices[index]].Hide();
                indices.RemoveAt(index);
            }
        }

        // Method to get the count of remaining words to hide
        public int GetRemainingWordsCount()
        {
            return words.Count(word => !word.IsHidden);
        }
    }

    // Class to represent a word in the scripture
    class ScriptureWord
    {
        public string Text { get; }
        public bool IsHidden { get; private set; }

        // Constructor
        public ScriptureWord(string text)
        {
            Text = text;
            IsHidden = false;
        }

        // Method to hide the word
        public void Hide()
        {
            IsHidden = true;
        }
    }
}
