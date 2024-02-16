using System;
using System.Collections.Generic;
using System.IO;

// Base class for goals
class Goal
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public virtual void MarkComplete()
    {
        IsCompleted = true;
    }

    public virtual int CalculatePoints()
    {
        return IsCompleted ? 100 : 0;
    }

    public virtual string GetStatus()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

// Derived class for simple goals
class SimpleGoal : Goal
{
    public int Points { get; set; }

    public override int CalculatePoints()
    {
        return Points;
    }
}

// Derived class for eternal goals
class EternalGoal : Goal
{
    public override void MarkComplete()
    {
        throw new InvalidOperationException("Eternal goals cannot be marked as completed.");
    }

    public override int CalculatePoints()
    {
        return IsCompleted ? 100 : 0;
    }
}

// Derived class for checklist goals
class ChecklistGoal : Goal
{
    public int TotalTimes { get; set; }
    public int CompletedTimes { get; set; }

    public override void MarkComplete()
    {
        CompletedTimes++;
        IsCompleted = CompletedTimes >= TotalTimes;
    }

    public override int CalculatePoints()
    {
        int basePoints = CompletedTimes * 50;
        int bonusPoints = IsCompleted ? 500 : 0;
        return basePoints + bonusPoints;
    }

    public override string GetStatus()
    {
        return IsCompleted ? $"Completed {CompletedTimes}/{TotalTimes} times [X]" : $"Completed {CompletedTimes}/{TotalTimes} times [ ]";
    }
}

// Class for managing goals and providing additional functionalities
class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    // Method to add a new goal
    public void AddGoal(Goal newGoal)
    {
        goals.Add(newGoal);
        Console.WriteLine("Goal added successfully!");
    }

    // Method to mark a goal as complete by name
    public void MarkGoalComplete(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.MarkComplete();
            Console.WriteLine("Goal marked as complete!");
        }
        else
        {
            Console.WriteLine("Goal not found!");
        }
    }

    // Method to view all goals and their status
    public void ViewGoals()
    {
        Console.WriteLine("Current Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.GetStatus()} - {goal.Name}");
        }
        Console.WriteLine($"Total Score: {CalculateTotalScore()}");
    }

    // Method to calculate total score
    private int CalculateTotalScore()
    {
        totalScore = 0;
        foreach (var goal in goals)
        {
            totalScore += goal.CalculatePoints();
        }
        return totalScore;
    }

    // Method to save goals to a file
    public void SaveGoals(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var goal in goals)
            {
                if (goal is SimpleGoal)
                {
                    outputFile.WriteLine($"Simple,{goal.Name},{goal.IsCompleted},{((SimpleGoal)goal).Points}");
                }
                else if (goal is EternalGoal)
                {
                    outputFile.WriteLine($"Eternal,{goal.Name},{goal.IsCompleted}");
                }
                else if (goal is ChecklistGoal)
                {
                    outputFile.WriteLine($"Checklist,{goal.Name},{goal.IsCompleted},{((ChecklistGoal)goal).TotalTimes},{((ChecklistGoal)goal).CompletedTimes}");
                }
            }
            outputFile.WriteLine($"TotalScore,{totalScore}");
        }
        Console.WriteLine("Goals saved successfully!");
    }

    // Method to load goals from a file
    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == "Simple")
                {
                    int points = int.Parse(parts[3]);
                    var simpleGoal = new SimpleGoal { Name = parts[1], IsCompleted = bool.Parse(parts[2]), Points = points };
                    goals.Add(simpleGoal);
                }
                else if (parts[0] == "Eternal")
                {
                    var eternalGoal = new EternalGoal { Name = parts[1], IsCompleted = bool.Parse(parts[2]) };
                    goals.Add(eternalGoal);
                }
                else if (parts[0] == "Checklist")
                {
                    int totalTimes = int.Parse(parts[3]);
                    int completedTimes = int.Parse(parts[4]);
                    var checklistGoal = new ChecklistGoal { Name = parts[1], IsCompleted = bool.Parse(parts[2]), TotalTimes = totalTimes, CompletedTimes = completedTimes };
                    goals.Add(checklistGoal);
                }
                else if (parts[0] == "TotalScore")
                {
                    totalScore = int.Parse(parts[1]);
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.LoadGoals("goals.txt"); // Load saved goals

        bool running = true;
        while (running)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Mark Goal as Complete");
            Console.WriteLine("4. Save and Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    goalManager.ViewGoals();
                    break;
                case "2":
                    AddGoal(goalManager);
                    break;
                case "3":
                    MarkGoalComplete(goalManager);
                    break;
                case "4":
                    goalManager.SaveGoals("goals.txt");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }

    static void AddGoal(GoalManager goalManager)
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Select goal type (1. Simple, 2. Eternal, 3. Checklist): ");
        string typeInput = Console.ReadLine();
        int type = int.Parse(typeInput);

        Goal newGoal;
        switch (type)
        {
            case 1:
                Console.Write("Enter points: ");
                int points = int.Parse(Console.ReadLine());
                newGoal = new SimpleGoal { Name = name, Points = points };
                break;
            case 2:
                newGoal = new EternalGoal { Name = name };
                break;
            case 3:
                Console.Write("Enter total times: ");
                int totalTimes = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal { Name = name, TotalTimes = totalTimes };
                break;
            default:
                Console.WriteLine("Invalid goal type!");
                return;
        }

        goalManager.AddGoal(newGoal);
