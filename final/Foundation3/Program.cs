using System;

// Base class: Event
class Event
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public Event(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Event: {Name}");
        Console.WriteLine($"Date: {Date}");
    }
}

// Derived class: Lecture
class Lecture : Event
{
    public string Speaker { get; set; }

    public Lecture(string name, DateTime date, string speaker) : base(name, date)
    {
        Speaker = speaker;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Speaker: {Speaker}");
    }
}

// Derived class: Reception
class Reception : Event
{
    public int Guests { get; set; }

    public Reception(string name, DateTime date, int guests) : base(name, date)
    {
        Guests = guests;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Number of Guests: {Guests}");
    }
}

// Derived class: OutdoorGathering
class OutdoorGathering : Event
{
    public string Location { get; set; }

    public OutdoorGathering(string name, DateTime date, string location) : base(name, date)
    {
        Location = location;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Location: {Location}");
    }
}

class Program3
{
    static void Main(string[] args)
    {
        // Test inheritance with different types of events
        Event event1 = new Lecture("Introduction to Programming", new DateTime(2024, 2, 20), "Dr. Smith");
        Event event2 = new Reception("Company Anniversary", new DateTime(2024, 3, 15), 100);
        Event event3 = new OutdoorGathering("Summer Picnic", new DateTime(2024, 7, 10), "City Park");

        Console.WriteLine("Event Details:");
        Console.WriteLine("--------------");
        event1.DisplayDetails();
        Console.WriteLine();

        event2.DisplayDetails();
        Console.WriteLine();

        event3.DisplayDetails();
    }
}
