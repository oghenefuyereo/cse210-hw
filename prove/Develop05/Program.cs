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
        int totalScore = 0;
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
                    outputFile.WriteLine($"{goal.Name},{goal.IsCompleted},1,{((SimpleGoal)goal).Points}");
                }
                else if (goal is EternalGoal)
                {
                    outputFile.WriteLine($"{goal.Name},{goal.IsCompleted},2");
                }
                else if (goal is ChecklistGoal)
                {
                    outputFile.WriteLine($"{goal.Name},{goal.IsCompleted},3,{((ChecklistGoal)goal).TotalTimes},{((ChecklistGoal)goal).CompletedTimes}");
                }
            }
        }
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
                string name = parts[0];
                bool isCompleted = bool.Parse(parts[1]);
                int type = int.Parse(parts[2]);

                Goal goal;
                switch (type)
                {
                    case 1:
                        int points = int.Parse(parts[3]);
                        goal = new SimpleGoal { Name = name, IsCompleted = isCompleted, Points = points };
                        break;
                    case 2:
                        goal = new EternalGoal { Name = name, IsCompleted = isCompleted };
                        break;
                    case 3:
                        int totalTimes = int.Parse(parts[3]);
                        int completedTimes = int.Parse(parts[4]);
                        goal = new ChecklistGoal { Name = name, IsCompleted = isCompleted, TotalTimes = totalTimes, CompletedTimes = completedTimes };
                        break;
                    default:
                        Console.WriteLine("Invalid goal type in file!");
                        continue;
                }

                goals.Add(goal);
            }
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
    }

    static void MarkGoalComplete(GoalManager goalManager)
    {
        Console.Write("Enter the name of the goal to mark as complete: ");
        string name = Console.ReadLine();
        goalManager.MarkGoalComplete(name);
    }
}
