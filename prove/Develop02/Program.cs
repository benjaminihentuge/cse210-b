using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        UserInterface userInterface = new UserInterface();
        JournalWriter journalWriter = new JournalWriter();

        while (true)
        {
            userInterface.DisplayMenu();

            int choice = userInterface.GetUserChoice();

            switch (choice)
            {
                case 1:
                string prompt = userInterface.GetUserPrompt();
                Console.WriteLine($"Prompt: {prompt}"); 
                string response = userInterface.GetUserResponse();
                string date = DateTime.Now.ToString();
                JournalEntry entry = new JournalEntry(prompt, response, date);
                journal.AddEntry(entry);
                break;

                case 2:
                    userInterface.DisplayJournal(journal);
                    break;
                case 3:
                string loadFilename = userInterface.GetLoadFilename();
                journal.LoadFromFile(loadFilename);
                break;
                case 4:
               
                string saveFilename = userInterface.GetSaveFilename();
                journal.SaveToFile(saveFilename);
                break;
                case 5: 
                    userInterface.Quit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
