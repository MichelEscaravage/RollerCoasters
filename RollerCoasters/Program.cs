using System;
using System.Collections.Generic;

public class Program
{
    static List<Rollercoaster> rollercoasters = new List<Rollercoaster>();

    static bool run = true;
    public static void Main()
    {
        FillRollerCoasterList();

        while (run)
        {
            Console.Clear();

            Console.WriteLine("Welkom bij de achtbanenlijst!\n" +
            "Maak een keuze om door te gaan!\n" +
            "1. Achtbanenlijst bekijken\n" +
            "2. Achtbanen toevoegen\n" +
            "3. Achtbanen tonen tussen bepaalde jaren\n");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    ShowRollerCoasters();
                    ContinueOrClose();

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Vul de naam, het park en het bouwjaar in van de achtbaan\n");

                    Console.Write("Naam: ");
                    string name = Console.ReadLine();
                    Console.Clear();

                    Console.Write("Bouwjaar: ");
                    string buildYear = Console.ReadLine();
                    Console.Clear();

                    Console.Write("Park: ");
                    string Park = Console.ReadLine();
                    Console.Clear();

                    int buildYearNum;

                    if (int.TryParse(buildYear, out buildYearNum))
                    {
                        AddRollerCoaster(name, buildYearNum, Park);

                        string LoadingSave = ".....!";
                        foreach (char character in LoadingSave)
                        {
                            Console.Write(character);
                            Thread.Sleep(300);
                        }
                        Console.WriteLine("\n\nAttractie opgeslagen!");
                        Thread.Sleep(1000);
                        ContinueOrClose();
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige invoer, probeer opnieuw!");
                        ContinueOrClose();
                    }

                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Vul de 2 jaargetallen in om de achtbanen te tonen binnen die jaren\n");

                    Console.Write("Jaargetal 1: ");
                    string inputYear = Console.ReadLine();
                    Console.Clear();

                    Console.Write("Jaargetal 2: ");
                    string inputYear2 = Console.ReadLine();
                    Console.Clear();

                    if (inputYear != inputYear2)
                    {
                        ShowRollerCoastersBetweenYears(inputYear, inputYear2);
                        ContinueOrClose();
                    }

                    break;

                default:

                    break;
            }
        }
    }

    public static void FillRollerCoasterList()
    {
        rollercoasters.Add(new Rollercoaster("Python", "Efteling", 1981));
        rollercoasters.Add(new Rollercoaster("Fenix", "Toverland", 2018));
        rollercoasters.Add(new Rollercoaster("Troy", "Toverland", 2007));
        rollercoasters.Add(new Rollercoaster("Baron 1898", "Efteling", 2015));
        rollercoasters.Add(new Rollercoaster("Condor", "Walibi", 1994));
        rollercoasters.Add(new Rollercoaster("Xpress", "Walibi", 2000));
    }

    public static void ShowRollerCoasters()
    {
        foreach (Rollercoaster coaster in rollercoasters)
        {
            Console.WriteLine($"In {coaster.BuildYear} werd de {coaster.Name} geopend in {coaster.Park}");
        }
    }

    public static void ShowRollerCoastersBetweenYears(string inputYear, string inputYear2)
    {
        if (!int.TryParse(inputYear, out int yearStart) || !int.TryParse(inputYear2, out int yearEnd))
        {
            Console.WriteLine("Ongeldige invoer! Probeer opnieuw ");

            return;
        }

        foreach (Rollercoaster coaster in rollercoasters)
        {
            if (coaster.BuildYear >= yearStart && coaster.BuildYear <= yearEnd)
            {
                Console.WriteLine($"In {coaster.BuildYear} werd de {coaster.Name} geopend in {coaster.Park}");
            }
        }
        ContinueOrClose();
    }

    public static void AddRollerCoaster(string name, int buildYearNum, string park)
    {
        rollercoasters.Add(new Rollercoaster(name, park, buildYearNum));
    }


    public static void ContinueOrClose()
    {
        Console.WriteLine($"\n\n");
        Console.WriteLine($"Druk op X om af te sluiten of een andere toets om door te gaan\n");

        string input = Console.ReadLine();

        if (input?.ToLower() == "x")
        {
            Console.Clear();
            run = false;
        }
    }
}

public class Rollercoaster
{
    public string Name { get; set; }
    public string Park { get; set; }
    public int BuildYear { get; set; }

    public Rollercoaster(string name, string park, int buildYear)
    {
        Name = name;
        BuildYear = buildYear;
        Park = park;
    }
}