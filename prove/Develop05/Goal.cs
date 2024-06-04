using System;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    protected Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetProgress();
    public abstract bool IsCompleted();
    public abstract string SaveString();
}
