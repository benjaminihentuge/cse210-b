using System;
using System.Collections.Generic;
using System.IO;

// Base class
public abstract class Goal
{
    public string ShortName { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    public Goal(string name, string description, int points)
    {
        ShortName = name;
        Description = description;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsGoalComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}

// SimpleGoal class
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public bool IsComplete
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsGoalComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"[Simple] {ShortName}: {Description} - {Points} Points - Complete: {IsGoalComplete()}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
    }
}

// EternalGoal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        
    }

    public override bool IsGoalComplete()
    {
        return false;7
    }

    public override string GetDetailsString()
    {
        return $"[Eternal] {ShortName}: {Description} - {Points} Points";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName},{Description},{Points}";
    }
}

// ChecklistGoal class
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public int AmountCompleted
    {
        get { return _amountCompleted; }
        set { _amountCompleted = value; }
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsGoalComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[Checklist] {ShortName}: {Description} - {Points} Points - Completed: {_amountCompleted}/{_target} - Bonus: {_bonus} Points";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName},{Description},{Points},{_amountCompleted},{_target},{_bonus}";
    }

    public int GetBonusPoints()
    {
        return _bonus;
    }
}