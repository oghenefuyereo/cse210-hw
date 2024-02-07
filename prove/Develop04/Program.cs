using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
class Activity
{
    protected int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    // Common starting message for all activities
    public virtual void Start()
    {
        Console.WriteLine("Starting activity...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    // Common ending message for all activities
    public virtual void End()
    {
        Console.WriteLine("Great job! You have completed the activity.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}

// Breathing Activity class inheriting from Activity
class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity:");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        base.Start();
    }

    public override void End()
    {
        base.End();
    }

    // Additional animation for breathing activity
    public void PerformBreathing()
    {
        Console.WriteLine("Starting breathing exercise...");
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}

// Reflection Activity class inheriting from Activity
class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        // Additional reflection prompts
        "Think of a time when you overcame a fear.",
        "Think of a time when you learned a valuable lesson."
    };

    private List<string> questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity:");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        base.Start();
    }

    public override void End()
    {
        base.End();
    }

    // Additional animation for reflection activity
    public void Reflect()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.WriteLine($"Prompt: {prompt}");
        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000); // Pause for 3 seconds
        }
    }
}

// Listing Activity class inheriting from Activity
class ListingActivity : Activity
{
    private List<string> prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Listing Activity:");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        base.Start();
    }

    public override void End()
    {
        base.End();
    }

    // Additional animation for listing activity
    public void ListItems()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"You have {duration} seconds to list items (Press Enter after each item):");

        List<string> items = new List<string>();
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter)
            {
                items.Add(key.KeyChar.ToString());
            }
        } while (key.Key != ConsoleKey.Enter && items.Count < duration);

        Console.WriteLine();
        Console.WriteLine($"Number of items listed: {items.Count}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Main menu
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        // Get user choice
        int choice;
        do
        {
            Console.Write("Enter your choice (1-3): ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3);

        int duration;
        do
        {
            Console.Write("Enter duration of activity in seconds: ");
        } while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0);

        // Execute selected activity
        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity(duration);
                breathingActivity.Start();
                breathingActivity.PerformBreathing();
                breathingActivity.End();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.Start();
                reflectionActivity.Reflect();
                reflectionActivity.End();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity(duration);
                listingActivity.Start();
                listingActivity.ListItems();
                listingActivity.End();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}
