public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void PerformActivity()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You have a few seconds to prepare...");
        ShowSpinner(5);
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }
        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}
