using System;

// Creative Additions:
// - GratitudeActivity: A new type of activity that prompts the user to list what they’re thankful for.
// - ActivityLogger: Tracks how many times each activity was run in a session and provides a summary.
// These features go beyond core requirements and demonstrate creativity.

class Program
{
    static void Main(string[] args)
    {
        ActivityLogger logger = new ActivityLogger();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity (New!)");
            Console.WriteLine("5. View Session Activity Summary");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option (1-6): ");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    logger.DisplaySummary();
                    Console.WriteLine("Press Enter to return to menu...");
                    Console.ReadLine();
                    continue;
                case "6":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid selection. Press Enter to try again...");
                    Console.ReadLine();
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
                logger.LogActivity(activity.GetType().Name);
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}
