public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        currentCount = 0;
    }

    public override void RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            Console.WriteLine($"Goal '{Name}' progress recorded! You earned {Points} points.");

            if (currentCount == targetCount)
            {
                Console.WriteLine($"Congratulations! You completed the checklist goal '{Name}' and earned a bonus of {bonusPoints} points!");
            }
        }
    }

    public override string GetProgress()
    {
        return $"[{currentCount}/{targetCount}]";
    }

    public override bool IsCompleted()
    {
        return currentCount >= targetCount;
    }

    public override string SaveString()
    {
        return $"ChecklistGoal:{Name},{Points},{currentCount},{targetCount},{bonusPoints}";
    }

    public int GetBonusPoints()
    {
        return bonusPoints;
    }
}
