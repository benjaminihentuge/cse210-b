
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        
        // Create a scripture object
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world...");

        // Display the complete scripture
        scripture.Display();

        // Main loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Exiting program. Goodbye!");
                return;
            }

            // Clear console screen
            Console.Clear();

            // Hide random words in the scripture
            scripture.HideRandomWord();

            // Display the updated scripture
            scripture.Display();
        }

        Console.WriteLine("Congratulations! You've hidden all the words. Program ending. Goodbye!");
    }
}