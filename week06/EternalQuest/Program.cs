using System;

/*
CREATIVITY FEATURE

Added a Level System.

Users gain a level every 1000 points:
Level 1 = 0-999 points
Level 2 = 1000-1999 points
Level 3 = 2000-2999 points

This provides additional gamification and motivation.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Score: {manager.GetScore()}");
            Console.WriteLine($"Level: {manager.GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("\nChoice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.DisplayGoals();
                    Pause();
                    break;

                case "3":
                    manager.DisplayGoals();

                    Console.Write("Goal Number: ");
                    int goalNum = int.Parse(Console.ReadLine());

                    manager.RecordGoal(goalNum - 1);

                    Pause();
                    break;

                case "4":
                    Console.Write("Filename: ");
                    manager.SaveGoals(Console.ReadLine());
                    Pause();
                    break;

                case "5":
                    Console.Write("Filename: ");
                    manager.LoadGoals(Console.ReadLine());
                    Pause();
                    break;

                case "6":
                    return;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(
                    new SimpleGoal(name, description, points));
                break;

            case "2":
                manager.AddGoal(
                    new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("Target Count: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());

                manager.AddGoal(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus));
                break;
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}