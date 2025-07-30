using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    private string _activityName;
    private string _description;
    private int _duration; // in seconds

    public MindfulnessActivity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void SetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }
    }

    public virtual void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_activityName}...");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDuration();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public virtual void End()
    {
        Console.WriteLine();
        Console.WriteLine($"Well done! You have completed the {_activityName} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();

    public int Duration => _duration;
}
