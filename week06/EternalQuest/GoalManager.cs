using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void RecordGoal(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[index].RecordEvent();

        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    public int GetScore()
    {
        return _score;
    }

    // Creativity Feature
    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter output = new StreamWriter(fileName))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(
                        new SimpleGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3])));
                    break;

                case "EternalGoal":
                    _goals.Add(
                        new EternalGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    _goals.Add(
                        new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[6]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded.");
    }
}