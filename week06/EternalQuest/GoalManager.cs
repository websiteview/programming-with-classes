using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create New Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Quit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    CreateGoal();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please select again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player's Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }
        Console.WriteLine("Goal Names:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }
        Console.WriteLine("Goal Details:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target number to complete: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points upon completion: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                return;
        }
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("Select a goal to record an event for:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("Enter goal number: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= _goals.Count)
        {
            Goal goal = _goals[choice - 1];
            int earnedPoints = goal.RecordEvent();
            _score += earnedPoints;
            Console.WriteLine($"Event recorded. Points earned: {earnedPoints}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string scoreLine = reader.ReadLine();
                _score = int.Parse(scoreLine);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Goal goal = ParseGoalFromString(line);
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private Goal ParseGoalFromString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 0)
            return null;

        string type = parts[0];

        try
        {
            switch (type)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(parts[4]);
                    SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    var isCompleteField = typeof(SimpleGoal).GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (isCompleteField != null)
                    {
                        isCompleteField.SetValue(simpleGoal, isComplete);
                    }
                    return simpleGoal;

                case "EternalGoal":
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));

                case "ChecklistGoal":
                    ChecklistGoal checklistGoal = new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[5]),
                        int.Parse(parts[4])
                    );
                    var amountCompletedField = typeof(ChecklistGoal).GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (amountCompletedField != null)
                    {
                        amountCompletedField.SetValue(checklistGoal, int.Parse(parts[6]));
                    }
                    return checklistGoal;

                default:
                    return null;
            }
        }
        catch
        {
            return null;
        }
    }
}
