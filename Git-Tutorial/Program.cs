using Git_Tutorial.Models;
using System.ComponentModel.Design;

List<GitEntry> gitCommands = GitEntry.GetDefaultEntries();

Console.WriteLine("Git Commands Notes");
Console.WriteLine("------------------");

Console.WriteLine("\nAvailable Categories:");

DisplayCategories(gitCommands);
GetAndDisplayCommands(gitCommands);

Console.ReadLine();

static void DisplayCategories(List<GitEntry> gitCategorys)
{
    int categoryNumber = 1;
    foreach (var category in gitCategorys)
    {
        Console.WriteLine($"{categoryNumber}. {category.Title}");
        categoryNumber++;
    }
}

static void GetAndDisplayCommands(List<GitEntry> gitCategorys)
{
    Console.Write("\nEnter the number of the category to see related Git commands: ehiofjhwedklfhnwekjfhnwjkefhnkjwe");
    if (int.TryParse(Console.ReadLine(), out int selectedCategoryNumber) && selectedCategoryNumber >= 1 && selectedCategoryNumber <= gitCategorys.Count)
    {
        var selectedCategory = gitCategorys[selectedCategoryNumber - 1];
        Console.WriteLine($"\n{selectedCategory.Title}:");
        foreach (var command in selectedCategory.Commands)
        {
            Console.WriteLine($"- {command.Command}: {command.Description}");
        }
        if (ExitProgram())
        {
            Console.WriteLine("Exiting the application...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        else
        {
            DisplayCategories(gitCategorys);
            GetAndDisplayCommands(gitCategorys);
        }
    }
    else
    {
        Console.WriteLine("Invalid category selection.");
        GetAndDisplayCommands(gitCategorys);
    }
}

static bool ExitProgram()
{
    while (true)
    {
        Console.WriteLine("\n[B] - Back || [E] - Exit");
        char userResponse = char.ToUpper(Console.ReadKey(intercept: true).KeyChar);
        Console.WriteLine();

        if (userResponse == 'E')
        {
            return true;
        }
        else if (userResponse == 'B')
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'B' or 'E'.");
            return ExitProgram();
        }
    }
}
