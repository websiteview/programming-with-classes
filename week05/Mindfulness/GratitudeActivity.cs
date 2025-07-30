using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : MindfulnessActivity
{
    public GratitudeActivity() : base("Gratitude Activity",
        "This activity will help you focus on gratitude by listing things you are thankful for.")
    { }

    public override void Run()
    {
        Start();

        Console.WriteLine("List as many things as you are grateful for:");
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> gratitudeItems = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
                gratitudeItems.Add(response);
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {gratitudeItems.Count} things you're grateful for.");
        End();
    }
}
