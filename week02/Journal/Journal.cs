using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        Entry entry = new Entry
        {
            _date = DateTime.Now.ToString("yyyy-MM-dd"),
            _promptText = prompt,
            _entryText = response
        };
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };
                _entries.Add(entry);
            }
        }
    }

    // EXTRA FEATURE: Save journal in CSV format compatible with Excel
    public void SaveToCsv(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Header row
            outputFile.WriteLine("Date,Prompt,Entry");

            foreach (Entry entry in _entries)
            {
                // Escape any quotes
                string escapedPrompt = entry._promptText.Replace("\"", "\"\"");
                string escapedResponse = entry._entryText.Replace("\"", "\"\"");
                outputFile.WriteLine($"\"{entry._date}\",\"{escapedPrompt}\",\"{escapedResponse}\"");
            }
        }
    }
}
