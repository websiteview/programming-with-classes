using System;
using System.Collections.Generic;

class Program
// EXTRA FEATURE:
// The journal can now be saved as a properly formatted CSV file for Excel.
// This exceeds the assignment requirements by providing a more useful export option.

{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string userChoice = "";
        while (userChoice != "6")
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Save as CSV file (Excel compatible)");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Random rand = new Random();
                string prompt = prompts[rand.Next(prompts.Count)];
                Console.WriteLine(prompt);
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                myJournal.AddEntry(prompt, response);
            }
            else if (userChoice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved.");
            }
            else if (userChoice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded.");
            }
            else if (userChoice == "5")
            {
                Console.Write("Enter filename to save as CSV (e.g. journal.csv): ");
                string filename = Console.ReadLine();
                myJournal.SaveToCsv(filename);
                Console.WriteLine("Journal saved as CSV.");
            }

            else if (userChoice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
