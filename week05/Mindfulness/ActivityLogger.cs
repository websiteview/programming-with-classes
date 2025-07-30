using System;
using System.Collections.Generic;

public class ActivityLogger
{
    private Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public void LogActivity(string activityName)
    {
        if (_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName]++;
        }
        else
        {
            _activityCounts[activityName] = 1;
        }
    }

    public void DisplaySummary()
    {
        Console.WriteLine("\nSession Activity Summary:");
        foreach (var entry in _activityCounts)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine();
    }
}
