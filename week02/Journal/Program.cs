using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\n=== Journal Menu ===");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Enter a number 1–5.");
                continue;
            }

            if (choice == 1)
            {
                string prompt = prompts.GetRandomPrompt();

                Console.WriteLine("\nPrompt:");
                Console.WriteLine(prompt);

                Console.WriteLine("\nWrite your entry (press ENTER on empty line to finish):");

                string response = "";
                string line;

                while (true)
                {
                    line = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        break;
                    }

                    response += line + "\n";
                }

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);

                Console.WriteLine("Entry saved!");
            }
            else if (choice == 2)
            {
                journal.Display();
            }
            else if (choice == 3)
            {
                Console.Write("Filename: ");
                string file = Console.ReadLine();

                journal.SaveToFile(file);
                Console.WriteLine("Saved.");
            }
            else if (choice == 4)
            {
                Console.Write("Filename: ");
                string file = Console.ReadLine();

                journal.LoadFromFile(file);
                Console.WriteLine("Loaded.");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}