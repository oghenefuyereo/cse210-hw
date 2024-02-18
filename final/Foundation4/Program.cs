using System;

// Base class: Activity
class Activity
{
    public virtual string Type { get; set; }
    public int Duration { get; set; }

    public Activity(int duration)
    {
        Duration = duration;
    }

    public virtual void DisplaySummary()
    {
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Duration: {Duration} minutes");
    }
}

// Derived class: Running
class Running : Activity
{
    public double Distance { get; set; }
    public double Pace { get; set; }

    public Running(int duration, double distance) : base(duration)
    {
        Type = "Running";
        Distance = distance;
        Pace = distance / duration * 60; // Pace in minutes per mile
    }

    public override void DisplaySummary()
    {
        base.DisplaySummary();
        Console.WriteLine($"Distance: {Distance} miles");
        Console.WriteLine($"Pace: {Pace} minutes/mile");
    }
}

// Derived class: Cycling
class Cycling : Activity
{
    public double Distance { get; set; }
    public double Speed { get; set; }

    public Cycling(int duration, double distance) : base(duration)
    {
        Type = "Cycling";
        Distance = distance;
        Speed = distance / (duration / 60); // Speed in miles per hour
    }

    public override void DisplaySummary()
    {
        base.DisplaySummary();
        Console.WriteLine($"Distance: {Distance} miles");
        Console.WriteLine($"Speed: {Speed} mph");
    }
}

// Derived class: Swimming
class Swimming : Activity
{
    public double Distance { get; set; }

    public Swimming(int duration, double distance) : base(duration)
    {
        Type = "Swimming";
        Distance = distance;
    }

    public override void DisplaySummary()
    {
        base.DisplaySummary();
        Console.WriteLine($"Distance: {Distance} meters");
    }
}

class Program4
{
    static void Main(string[] args)
    {
        // Test polymorphism with different types of activities
        Activity running = new Running(30, 3.5);
        Activity cycling = new Cycling(45, 10.0);
        Activity swimming = new Swimming(60, 1500);

        Console.WriteLine("Activity Summary:");
        Console.WriteLine("---------------");
        Console.WriteLine("\nRunning Summary:");
        running.DisplaySummary();

        Console.WriteLine("\nCycling Summary:");
        cycling.DisplaySummary();

        Console.WriteLine("\nSwimming Summary:");
        swimming.DisplaySummary();
    }
}
