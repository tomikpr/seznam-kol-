using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> tasks = new List<string>();
    const string fileName = "tasks.txt";

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.WriteLine("1. Přidání úkolu");
            Console.WriteLine("2. Mazání úkolu");
            Console.WriteLine("3. Zobrazení seznamu úkolů");
            Console.WriteLine("4. Uložení a ukončení");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DeleteTask();
                    break;
                case "3":
                    ShowTasks();
                    break;
                case "4":
                    SaveAndExit();
                    break;
                default:
                    Console.WriteLine("Neplatná volba. Zadejte prosím číslo od 1 do 4.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Název úkolu: ");
        string title = Console.ReadLine();

        Console.Write("Popis úkolu: ");
        string description = Console.ReadLine();

        tasks.Add($"{title} - {description} (nedokončeno)");
    }

    static void DeleteTask()
    {
        ShowTasks();

        if (tasks.Count == 0)
        {
            Console.WriteLine("Seznam úkolů je prázdný.");
            return;
        }

        Console.Write("Zadejte číslo úkolu k smazání: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Úkol byl smazán.");
        }
        else
        {
            Console.WriteLine("Neplatná volba. Zadejte prosím platné číslo úkolu.");
        }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Seznam úkolů je prázdný.");
        }
        else
        {
            Console.WriteLine("Seznam úkolů:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void SaveAndExit()
    {
        File.WriteAllLines(fileName, tasks);
        Console.WriteLine("Seznam úkolů byl uložen. Aplikace se ukončuje.");
        Environment.Exit(0);
    }

    static void LoadTasks()
    {
        if (File.Exists(fileName))
        {
            tasks = new List<string>(File.ReadAllLines(fileName));
        }
    }
}