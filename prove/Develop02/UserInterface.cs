public class UserInterface
{
    private List<string>  prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void DisplayMenu()
    {
        Console.WriteLine("Welcome to the journal program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1 Write");
        Console.WriteLine("2 Display");
        Console.WriteLine("3 Load");
        Console.WriteLine("4 Save");
        Console.WriteLine("5 Quit");
    }

    public int GetUserChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("What would you like to do? ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice >= 1 && choice <= 5)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public string GetUserPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public string GetUserResponse()
    {
        Console.Write("Enter a response: ");
        return Console.ReadLine();
    }

    public string GetLoadFilename()
    {
        Console.Write("Enter the filename to load: ");
        return Console.ReadLine();
    }

    public string GetSaveFilename()
    {
        Console.Write("Enter the filename to save: ");
        return Console.ReadLine();
    }

    public void DisplayJournal(Journal journal)
    {
        journal.DisplayEntries();
    }

    public void Quit()
    {
        Environment.Exit(0);
    }
}
