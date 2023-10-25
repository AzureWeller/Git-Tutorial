using Git_Tutorial.Models;
using System.ComponentModel.Design;

List<GitEntry> gitCommands = new List<GitEntry>
{
    new GitEntry
    {
        Title = "Initialization",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git init", Description = "Initialize a new Git repository." },
            new GitCommand { Command = "git clone <repository-url>", Description = "Clone an existing repository." }
        },
        Description = "This category includes commands related to initializing a new Git repository or cloning an existing one. These commands are essential when you start a new project or want to collaborate with an existing codebase."
    },
    new GitEntry
    {
        Title = "Basic Commands",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git add <file>", Description = "Stage changes for commit." },
            new GitCommand { Command = "git commit -m \"<message>\"", Description = "Commit staged changes with a message." },
            new GitCommand { Command = "git status", Description = "Show the status of changes as untracked, modified, or staged." },
            new GitCommand { Command = "git diff", Description = "Show changes between working directory, staging area, and the last commit." },
            new GitCommand { Command = "git log", Description = "Show commit history." },
            new GitCommand { Command = "git pull", Description = "Fetch changes from a remote repository and merge them into the current branch." },
            new GitCommand { Command = "git push", Description = "Push changes to a remote repository." }
        },
        Description = "Basic Git commands that are fundamental for version control. These commands help you stage changes, commit them, check the status of your repository, view differences between versions, track commit history, and synchronize changes with remote repositories."
    },
    new GitEntry
    {
        Title = "Branching and Merging",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git branch", Description = "List all branches in the repository." },
            new GitCommand { Command = "git branch <branch-name>", Description = "Create a new branch." },
            new GitCommand { Command = "git checkout <branch-name>", Description = "Switch to a different branch." },
            new GitCommand { Command = "git merge <branch-name>", Description = "Merge changes from a specified branch into the current branch." },
            new GitCommand { Command = "git branch -d <branch-name>", Description = "Delete a branch." }
        },
        Description = "Commands related to branching and merging in Git. Branches allow you to work on different features or bug fixes independently. Merging combines changes from different branches, allowing you to integrate new code into the main branch."
    },
    new GitEntry
    {
        Title = "Remote Repositories",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git remote", Description = "List remote repositories." },
            new GitCommand { Command = "git remote add <name> <url>", Description = "Add a remote repository." },
            new GitCommand { Command = "git remote remove <name>", Description = "Remove a remote repository." },
            new GitCommand { Command = "git fetch <remote>", Description = "Fetch changes from a remote repository." },
            new GitCommand { Command = "git pull <remote> <branch>", Description = "Pull changes from a remote repository." },
            new GitCommand { Command = "git push <remote> <branch>", Description = "Push changes to a remote repository." }
        },
        Description = "Commands for working with remote repositories. Remote repositories are copies of your project hosted on the Internet or network. These commands help you manage connections to remote repositories, fetch changes from them, and push your changes to them."
    },
    new GitEntry
    {
        Title = "Undoing Changes",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git reset <file>", Description = "Unstage changes in a file." },
            new GitCommand { Command = "git reset --hard HEAD", Description = "Discard all changes in the working directory and staging area." },
            new GitCommand { Command = "git revert <commit>", Description = "Create a new commit that undoes changes made in a specific commit." }
        },
        Description = "Commands for undoing changes in Git. These commands help you revert changes you've made, either in the staging area or committed, back to a previous state. This allows you to fix mistakes or remove unwanted changes."
    },
    new GitEntry
    {
        Title = "Git Configuration",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git config --global user.name \"<name>\"", Description = "Set your name for commits." },
            new GitCommand { Command = "git config --global user.email \"<email>\"", Description = "Set your email for commits." }
        },
        Description = "Commands for configuring Git settings. These commands allow you to set your identity for Git commits. Configuring your name and email is essential to associate your commits with your identity in the version history."
    },
    new GitEntry
    {
        Title = "Git Help",
        Commands = new List<GitCommand>
        {
            new GitCommand { Command = "git --help", Description = "Show help for Git commands." },
            new GitCommand { Command = "git help <command>", Description = "Show help for a specific Git command." }
        },
        Description = "Commands for accessing Git help. Git provides comprehensive documentation and help for its commands. These commands allow you to access general help for Git and detailed help for specific commands, providing guidance on their usage and options."
    }
};

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
    Console.Write("\nEnter the number of the category to see related Git commands: ");
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
            Thread.Sleep(2000);
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
