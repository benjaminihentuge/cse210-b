using System;
using System.Collections.Generic;
using System.IO;

public class EternalQuest
{
    private List<Goal> goals;
    private int totalPoints;
    private int level;
    private int pointsForNextLevel;

    public EternalQuest()
    {
        goals = new List<Goal>();
        totalPoints = 0;
        level = 1;
        pointsForNextLevel = 1000;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                totalPoints += goal.Points;
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
                {
                    totalPoints += checklistGoal.GetBonusPoints();
                }

                if (totalPoints >= pointsForNextLevel)
                {
                    level++;
                    pointsForNextLevel += 1000;
                    Console.WriteLine($"Congratulations! You leveled up to level {level}.");
                }
                return;
            }
        }
        Console.WriteLine($"Goal '{goalName}' not found.");
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.GetProgress()} {goal.Name}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Points: {totalPoints}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.SaveString());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        goals.Clear();
        totalPoints = 0;

        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    goals.Add(new SimpleGoal(data[0], int.Parse(data[1])) { IsCompleted = bool.Parse(data[2]) });
                    break;
                case "EternalGoal":
                    goals.Add(new EternalGoal(data[0], int.Parse(data[1])) { TimesCompleted = int.Parse(data[2]) });
                    break;
                case "ChecklistGoal":
                    goals.Add(new ChecklistGoal(data[0], int.Parse(data[1]), int.Parse(data[3]), int.Parse(data[4])) { CurrentCount = int.Parse(data[2]) });
                    break;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EternalQuest eq = new EternalQuest();

        eq.AddGoal(new SimpleGoal("Run a marathon", 1000));
        eq.AddGoal(new EternalGoal("Read scriptures", 100));
        eq.AddGoal(new ChecklistGoal("Attend temple", 50, 10, 500));

        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Record Event");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Show Score");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();
                    eq.RecordEvent(goalName);
                    break;
                case "2":
                    eq.ShowGoals();
                    break;
                case "3":
                    eq.ShowScore();
                    break;
                case "4":
                    eq.SaveGoals("goals.txt");
                    break;
                case "5":
                    eq.LoadGoals("goals.txt");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
