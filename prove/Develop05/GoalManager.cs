
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    DisplayPlayerInfo();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    exit = true;
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Enter goal type (Simple, Eternal, Checklist):");
        string type = Console.ReadLine();
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter goal description:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter points:");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "Simple":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "Eternal":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "Checklist":
                Console.WriteLine("Enter target amount:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
    }

    private void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("Select a goal to record event: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].Points;
            if (_goals[index].IsGoalComplete() && _goals[index] is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.GetBonusPoints();
            }
            Console.WriteLine($"Points earned: {_score}");
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
        ListGoalDetails();
    }

    private void SaveGoals()
    {
        List<string> lines = new List<string> { _score.ToString() };
        foreach (var goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }
        File.WriteAllLines("goals.txt", lines);
    }

    private void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] data = parts[1].Split(",");
                switch (type)
                {
                    case "SimpleGoal":
                        var simpleGoal = new SimpleGoal(data[0], data[1], int.Parse(data[2]))
                        {
                            IsComplete = bool.Parse(data[3])
                        };
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[5]))
                        {
                            AmountCompleted = int.Parse(data[3])
                        };
                        _goals.Add(checklistGoal);
                        break;
                }
            }
        }
    }
}