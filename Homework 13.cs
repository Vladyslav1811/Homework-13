class Program
{
    static void Main()
    {
        List<string> tasks = new List<string>(); 
        List<bool> isCompleted = new List<bool>();
        List<bool> isFullyCompleted = new List<bool>();

        while (true)
        {
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Show tasks");
            Console.WriteLine("3. Mark task as completed");
            Console.WriteLine("4. Mark task as fully completed");
            Console.WriteLine("5. Delete task");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            if (choice == "1") 
                AddTask(tasks, isCompleted, isFullyCompleted);
            else if (choice == "2") 
                ShowTasks(tasks, isCompleted, isFullyCompleted);
            else if (choice == "3") 
                MarkTaskAsCompleted(tasks, isCompleted);
            else if (choice == "4") 
                MarkTaskAsFullyCompleted(tasks, isCompleted, isFullyCompleted);
            else if (choice == "5") 
                DeleteTask(tasks, isCompleted, isFullyCompleted);
            else if (choice == "6") 
                break;
            else 
                Console.WriteLine("Invalid input. Please enter a valid option (1-6).");
        }
    }

    static void AddTask(List<string> tasks, List<bool> isCompleted, List<bool> isFullyCompleted) 
    {
        Console.Write("Enter task name: ");
        string taskName = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(taskName))
        {
            Console.WriteLine("Task name cannot be empty.");
            return;
        }

        tasks.Add(taskName);
        isCompleted.Add(false); 
        isFullyCompleted.Add(false); 
        Console.WriteLine("Task added.");
    }

    static void ShowTasks(List<string> tasks, List<bool> isCompleted, List<bool> isFullyCompleted) 
    {
        bool hasIncompleteTasks = false;
        bool hasCompletedTasks = false;
        bool hasFullyCompletedTasks = false;
        bool hasPartiallyCompletedTasks = false;

        Console.WriteLine("\nIncomplete tasks:");
        for (int i = 0; i < tasks.Count; i++) 
        {
            if (!isCompleted[i])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i + 1}. {tasks[i]}");
                hasIncompleteTasks = true;
            }
        }

        if (!hasIncompleteTasks)
        {
            Console.WriteLine("No incomplete tasks.");
        }

        Console.ForegroundColor = ConsoleColor.Gray; 

        Console.WriteLine("\nPartially completed tasks (marked as completed but not fully completed):");
        for (int i = 0; i < tasks.Count; i++) 
        {
            if (isCompleted[i] && !isFullyCompleted[i])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{i + 1}. {tasks[i]}");
                hasPartiallyCompletedTasks = true;
            }
        }

        if (!hasPartiallyCompletedTasks)
        {
            Console.WriteLine("No partially completed tasks.");
        }

        Console.ForegroundColor = ConsoleColor.Gray; 

        Console.WriteLine("\nFully completed tasks:");
        for (int i = 0; i < tasks.Count; i++) 
        {
            if (isCompleted[i] && isFullyCompleted[i])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{i + 1}. {tasks[i]}");
                hasFullyCompletedTasks = true;
            }
        }

        if (!hasFullyCompletedTasks)
        {
            Console.WriteLine("No fully completed tasks.");
        }

        Console.ForegroundColor = ConsoleColor.Gray; 
    }

    static void MarkTaskAsCompleted(List<string> tasks, List<bool> isCompleted) 
    {
        Console.Write("Enter task number to mark as completed: ");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int taskNumber) || taskNumber <= 0 || taskNumber > tasks.Count)
        {
            Console.WriteLine("Invalid task number.");
            return;
        }

        isCompleted[taskNumber - 1] = true;
        Console.WriteLine("Task marked as completed.");
    }

    static void MarkTaskAsFullyCompleted(List<string> tasks, List<bool> isCompleted, List<bool> isFullyCompleted)
    {
        Console.Write("Enter task number to mark as fully completed: ");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int taskNumber) || taskNumber <= 0 || taskNumber > tasks.Count)
        {
            Console.WriteLine("Invalid task number.");
            return;
        }

        if (!isCompleted[taskNumber - 1])
        {
            Console.WriteLine("Task must be marked as completed before it can be fully completed.");
            return;
        }

        isFullyCompleted[taskNumber - 1] = true;
        Console.WriteLine("Task marked as fully completed.");
    }

    static void DeleteTask(List<string> tasks, List<bool> isCompleted, List<bool> isFullyCompleted) 
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to delete.");
            return;
        }

        Console.WriteLine("Available tasks to delete:");
        for (int i = 0; i < tasks.Count; i++) 
            Console.WriteLine($"{i + 1}. {tasks[i]} {(isCompleted[i] ? (isFullyCompleted[i] ? "[Fully Completed]" : "[Partially Completed]") : "[Not Completed]")}");

        Console.Write("Enter task number to delete: ");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int taskNumber) || taskNumber <= 0 || taskNumber > tasks.Count)
        {
            Console.WriteLine("Invalid task number.");
            return;
        }

        tasks.RemoveAt(taskNumber - 1);
        isCompleted.RemoveAt(taskNumber - 1);
        isFullyCompleted.RemoveAt(taskNumber - 1);
        Console.WriteLine("Task deleted.");
    }
}
