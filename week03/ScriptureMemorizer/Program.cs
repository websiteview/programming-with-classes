using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Enhancement: Randomly select from a list of scriptures to make each session unique.
        List<(Reference, string)> scriptures = new List<(Reference, string)>
        {
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            (new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."),
            (new Reference("Mosiah", 2, 17), "When ye are in the service of your fellow beings ye are only in the service of your God."),
            (new Reference("Alma", 37, 6), "By small and simple things are great things brought to pass.")
        };

        Random rand = new Random();
        int randomIndex = rand.Next(scriptures.Count);
        var selected = scriptures[randomIndex];

        Scripture scripture = new Scripture(selected.Item1, selected.Item2);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program has ended.");
    }
}
