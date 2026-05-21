using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        // ⭐ Multiple scriptures (creativity feature)
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only Son"
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding"
            )
        };

        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            // ⭐ progress display
            Console.WriteLine($"\nHidden: {scripture.GetHiddenCount()}/{scripture.GetTotalWords()} words");

            if (scripture.AllHidden())
            {
                Console.WriteLine("\nAll words are hidden!");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit':");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2);
        }
    }
}