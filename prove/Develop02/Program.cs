using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear();

        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split(',');
                    if (parts.Length == 3)
                    {
                        JournalEntry entry = new JournalEntry
                        {
                            Date = parts[0],
                            Prompt = parts[1],
                            Response = parts[2]
                        };
                        entries.Add(entry);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(@"
   ______ _           _   _             
   |  ____(_)         | | (_)            
   | |__   _ _ __ ___ | |_ _  __ _ ___  
   |  __| | | '_ ` _ \| __| |/ _` / __| 
   | |    | | | | | | | |_| | (_| \__ \ 
   |_|    |_|_| |_| |_|\__|_|\__,_|___/
   ");

        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();

        while (true)
        {
            Console.WriteLine("1. 📝 Write a new entry");
            Console.WriteLine("2. 📖 Display the journal");
            Console.WriteLine("3. 💾 Save the journal to a file");
            Console.WriteLine("4. 📂 Load the journal from a file");
            Console.WriteLine("5. 🚪 Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    JournalEntry newEntry = new JournalEntry
                    {
                        Prompt = GenerateRandomPrompt(),
                        Date = GetCurrentDate(),
                    };

                    Console.WriteLine($"🌟 Prompt: {newEntry.Prompt}");
                    Console.Write("💬 Response: ");
                    newEntry.Response = Console.ReadLine();

                    journal.AddEntry(newEntry);
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    journal.DisplayEntries();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 3:
                    Console.Write("💾 Enter filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    Console.WriteLine("✨ Journal saved successfully.");
                    break;

                case 4:
                    Console.Write("📂 Enter filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    Console.WriteLine("🔍 Journal loaded successfully.");
                    break;

                case 5:
                    Console.WriteLine("👋 Exiting the journal application. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static string GenerateRandomPrompt()
    {
        // Implement your creative prompt generation logic here
        // For example, you can create a list of creative prompts and randomly select one
        List<string> creativePrompts = new List<string>
        {
            "If you could time-travel to any historical event, which one would it be?",
            "Describe your day using only emojis.",
            "Write a letter to your future self.",
            "If you were a superhero, what would be your superpower and costume?",
            "What fictional world would you like to live in for a day?"
        };

        return creativePrompts[new Random().Next(creativePrompts.Count)];
    }

    private static string GetCurrentDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }
}
