public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
       
        if (!filename.ToLower().EndsWith(".csv"))
        {
            filename += ".csv";
        }

        try
        {
            
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
                }
            }

            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving journal to {filename}: {e.Message}");
        }
    }



    public void LoadFromFile(string filename)
    {
       
        entries.Clear();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];
                        JournalEntry entry = new JournalEntry(prompt, response, date);
                        entries.Add(entry);
                    }
                }
            }

            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error loading journal from {filename}: {e.Message}");
        }
    }

    public int GetEntryCount()
    {
        return entries.Count;
    }
}
