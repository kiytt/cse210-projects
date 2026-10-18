using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        List<string> msg = ["Super secure, completely safe ", "We don't need encryption where we're going!\n\n", "Honestly, you don't even need to include a ", "Password must contain:\nAt least 8 characters\nThree capital letters\nOne special character\nYour father's maiden name\nThe capital of a country whose name is the same length as the number of the month you were born\nTwo lower case letters\nA number\nThe reason for the matter-antimatter asymmetry in the Universe\n\n"];
        
        // "login" //////////////////////////////////////////////////////////////////////////////////
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine();
        Console.Write($"{msg[rand.Next(0,msg.Count)]}Password: ");
        string password = Console.ReadLine();
        UserManager userman = new UserManager(name, password);

        // load upon login //////////////////////////////////////////////////////////////////////////////////
        List<string> rawLines = FileParser.ReadLines(userman.GetGoalPath());
        List<Goal> goals = new List<Goal>();

        foreach (string line in rawLines)
        {
            string[] parts = line.Split('|');
            if (parts[0] == "SimpleGoal") goals.Add(new SimpleGoal(parts));
            else if (parts[0] == "EternalGoal") goals.Add(new EternalGoal(parts));
            else if (parts[0] == "ChecklistGoal") goals.Add(new ChecklistGoal(parts));
        }

        // main menu //////////////////////////////////////////////////////////////////////////////////
        Menu mainMenu = new Menu();
        Console.WriteLine();
        mainMenu.AddOption("1. \u001b[4mC\u001b[24mreate new goal", new string[] {"create new goal", "n", "1", "new", "create", "c"});
        mainMenu.AddOption("2. \u001b[4mL\u001b[24mist goals", new string[] {"list goals", "2", "l", "list"});
        mainMenu.AddOption("3. \u001b[4mV\u001b[24miew points", new string[] {"view points", "3", "p", "points", "v", "view"});
        mainMenu.AddOption("4. \x1b[31m\u001b[4mQ\u001b[24muit\x1b[0m", new string[] {"quit", "q", "4"});

        string choice = "";

            while (choice != "quit")
            {
                Console.Clear();
                choice = mainMenu.GetChoice();

                if (choice == "create new goal") //////////////////////////////////////////////////////////////////////////////////
                {
                    Console.WriteLine("Create New Goal\nSelect goal type:\n");
                    Menu goalMenu = new Menu();
                    goalMenu.AddOption("1. \u001b[4mS\u001b[24mimple", new string[] {"simple", "s", "1"});
                    goalMenu.AddOption("2. \u001b[4mE\u001b[24mternal", new string[] {"eternal", "e", "2"});
                    goalMenu.AddOption("3. \u001b[4mC\u001b[24mhecklist", new string[] {"checklist", "c", "3"});
                    goalMenu.AddOption("4. \u001b[4mB\u001b[24mack", new string[] {"back", "b", "4"});

                    string goalChoice = "";

                    while (goalChoice != "back")
                    {
                        goalChoice = goalMenu.GetChoice();
                        if (goalChoice == "simple") //////////////////////////////////////////////////////////////////////////////////
                        {
                            Console.Clear();
                            Console.WriteLine("Simple goal:");
                            Thread.Sleep(500);

                            Console.Write("Name: ");
                            string goalName = Console.ReadLine();
                            Console.Write("Description: ");
                            string desc = Console.ReadLine();
                            Console.Write("Points: ");
                            int points = int.Parse(Console.ReadLine());

                            SimpleGoal newGoal = new SimpleGoal(goalName, desc, points);
                            goals.Add(newGoal);

                            List<string> lines = new List<string>(); // saving as you go
                            foreach (var g in goals)
                            {
                                lines.Add(g.ToFileString());
                            }
                            
                            FileParser.WriteLines(userman.GetGoalPath(), lines);
                            Console.Clear();
                        }
                        else if (goalChoice == "eternal") //////////////////////////////////////////////////////////////////////////////////
                        {
                            Console.Clear();
                            Console.WriteLine("Eternal goal:");
                            Thread.Sleep(500);

                            Console.Write("Name: ");
                            string goalName = Console.ReadLine();
                            Console.Write("Description: ");
                            string desc = Console.ReadLine();
                            Console.Write("Points: ");
                            int points = int.Parse(Console.ReadLine());

                            EternalGoal newGoal = new EternalGoal(goalName, desc, points);
                            goals.Add(newGoal);

                            List<string> lines = new List<string>(); // saving as you go
                            foreach (var g in goals)
                            {
                                lines.Add(g.ToFileString());
                            }
                            
                            FileParser.WriteLines(userman.GetGoalPath(), lines);
                            Console.Clear();
                        }
                        else if (goalChoice == "checklist") //////////////////////////////////////////////////////////////////////////////////
                        {
                            Console.Clear();
                            Console.WriteLine("Checklist goal:");
                            Thread.Sleep(500);

                            Console.Write("Name: ");
                            string goalName = Console.ReadLine();
                            Console.Write("Description: ");
                            string desc = Console.ReadLine();
                            Console.Write("Points: ");
                            int points = int.Parse(Console.ReadLine());
                            Console.Write("Times to complete: ");
                            int maxTimes = int.Parse(Console.ReadLine());
                            Console.Write("Bonus: ");
                            int bonus = int.Parse(Console.ReadLine());

                            ChecklistGoal newGoal = new ChecklistGoal(goalName, desc, points, maxTimes, bonus);
                            goals.Add(newGoal);

                            List<string> lines = new List<string>(); // saving as you go
                            foreach (var g in goals)
                            {
                                lines.Add(g.ToFileString());
                            }
                            
                            FileParser.WriteLines(userman.GetGoalPath(), lines);
                            Console.Clear();
                        }
                    }
                }
                else if (choice == "list goals") 
                {
                    while (true)
                    {
                        Console.Clear();
                        List<string> goalsList = new List<string>();
                        foreach (var goal in goals) 
                        {
                            goalsList.Add(goal.GetDisplayString());
                        }

                        int index = FileParser.GetPagedIndex(goalsList, "Select number for options:");

                        if (index == -1) break;

                        Goal selectedGoal = goals[index];

                        Menu listMenu = new Menu();
                        listMenu.AddOption("1. \u001b[4mR\u001b[24mecord progress", new string[] {"record progress", "r", "1", "record"});
                        listMenu.AddOption("2. \u001b[4mD\u001b[24melete goal", new string[] {"delete goal", "d", "2", "delete"});
                        listMenu.AddOption("3. \u001b[4mB\u001b[24mack", new string[] {"back", "b", "3"});
                    
                        string listChoice = listMenu.GetChoice();

                        if (listChoice == "record progress")
                        {
                            int earnedPoints = selectedGoal.RecordEvent(); 
                            Progress progress = new Progress(userman.GetProgressPath());
                            progress.AddPoints(earnedPoints);
                            Console.WriteLine($"You earned {earnedPoints} points!");

                            List<string> goalLines = new List<string>();
                            foreach (var goal in goals) goalLines.Add(goal.ToFileString());
                            
                            FileParser.WriteLines(userman.GetGoalPath(), goalLines);
                            FileParser.WriteLines(userman.GetProgressPath(), new List<string>(progress.GetProgress()));
                            Console.ReadLine();
                        }
                        else if (listChoice == "delete goal")
                        {
                            goals.RemoveAt(index); 

                            List<string> lines = new List<string>();
                            foreach (var goal in goals) lines.Add(goal.ToFileString());
                            
                            FileParser.WriteLines(userman.GetGoalPath(), lines);
                        }

                    }
                }
                else if (choice == "view points") //////////////////////////////////////////////////////////////////////////////////
                {
                    Console.Clear();
                    Console.WriteLine("Points:");
                    Thread.Sleep(500);

                    Progress progress = new Progress(userman.GetProgressPath());
                    progress.ViewProgress();


                }
            }
    }
}