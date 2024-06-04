public class SimpleGoal : Goal
{
    private bool isCompleted;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        isCompleted = false;
    }

    public override void RecordEvent()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
    }

    public override string GetProgress()
    {
        return isCompleted ? "[X]" : "[ ]";
    }

    public override bool IsCompleted()
    {
        return isCompleted;
    }

    public override string SaveString()
    {
        return $"SimpleGoal:{Name},{Points},{isCompleted}";
    }
}
