using System;
using System.Collections.Generic;
using System.Linq;

// Interface for taggable functionality
public interface ITaggable
{
    List<string> Tags { get; }
    void AddTag(string tag);
    void RemoveTag(string tag);
}

// Base Task class implementing ITaggable
public class Task : ITaggable
{
    private int _id;
    private string _title;
    private string _description;
    private bool _isCompleted;
    private List<string> _tags = new List<string>();
    private static int _nextId = 1;

    public int Id { get { return _id; } }

    public string Title
    {
        get { return _title; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }
            _title = value;
        }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public bool IsCompleted
    {
        get { return _isCompleted; }
        private set { _isCompleted = value; }
    }

    public List<string> Tags { get { return new List<string>(_tags); } }

    public Task(string title, string description)
    {
        _id = _nextId++;
        Title = title;
        Description = description;
        IsCompleted = false;
    }

    public void MarkComplete()
    {
        IsCompleted = true;
        Console.WriteLine($"Task '{Title}' marked as complete.");
    }

    public void MarkIncomplete()
    {
        IsCompleted = false;
        Console.WriteLine($"Task '{Title}' marked as pending.");
    }

    public void AddTag(string tag)
    {
        if (string.IsNullOrEmpty(tag) || _tags.Contains(tag))
        {
            Console.WriteLine($"Invalid or duplicate tag: '{tag}'");
            return;
        }
        _tags.Add(tag);
        Console.WriteLine($"Tag '{tag}' added to task '{Title}'.");
    }

    public void RemoveTag(string tag)
    {
        if (_tags.Remove(tag))
        {
            Console.WriteLine($"Tag '{tag}' removed.");
        }
        else
        {
            Console.WriteLine($"Tag '{tag}' not found.");
        }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Pending")}");
        if (_tags.Count > 0)
        {
            Console.WriteLine($"Tags: {string.Join(", ", _tags)}");
        }
    }
}

// PriorityTask class inheriting from Task
public class PriorityTask : Task
{
    private int _priority;

    public int Priority
    {
        get { return _priority; }
        set
        {
            if (value < 1 || value > 5)
            {
                Console.WriteLine("Priority must be between 1 and 5.");
                return;
            }
            _priority = value;
        }
    }

    public PriorityTask(string title, string description, int priority)
        : base(title, description)
    {
        Priority = priority;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Priority: {Priority}");
    }
}

// DeadlineTask class inheriting from Task
public class DeadlineTask : Task
{
    public DateTime DueDate { get; set; }

    public DeadlineTask(string title, string description, DateTime dueDate)
        : base(title, description)
    {
        DueDate = dueDate;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Due Date: {DueDate.ToShortDateString()}");
    }
}

// Delegate for task comparison
public delegate int TaskComparisonDelegate(Task t1, Task t2);

// TaskManager class to manage all tasks
public class TaskManager
{
    private List<Task> _tasks = new List<Task>();

    public void AddTaskFromUserInput()
    {
        Console.WriteLine("\n--- Add New Task ---");
        Console.WriteLine("Select task type:");
        Console.WriteLine("1. Basic Task");
        Console.WriteLine("2. Priority Task");
        Console.WriteLine("3. Deadline Task");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter Task Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Task Description: ");
        string description = Console.ReadLine();

        Task newTask = null;
        switch (typeChoice)
        {
            case "1":
                newTask = new Task(title, description);
                break;
            case "2":
                Console.Write("Enter Priority (1-5): ");
                if (int.TryParse(Console.ReadLine(), out int priority))
                {
                    newTask = new PriorityTask(title, description, priority);
                }
                else
                {
                    Console.WriteLine("Invalid priority. Task not created.");
                    return;
                }
                break;
            case "3":
                Console.Write("Enter Due Date (MM/dd/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    newTask = new DeadlineTask(title, description, dueDate);
                }
                else
                {
                    Console.WriteLine("Invalid date format. Task not created.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Invalid task type. Task not created.");
                return;
        }

        _tasks.Add(newTask);
        Console.WriteLine("Task added successfully!");
    }

    public void ViewAllTasks()
    {
        Console.WriteLine("\n--- All Tasks ---");
        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        foreach (Task task in _tasks)
        {
            task.DisplayDetails();
            Console.WriteLine("-----");
        }
    }

    public void ToggleTaskCompletionStatusById()
    {
        Console.Write("\nEnter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        Task task = FindTaskById(id);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            return;
        }

        if (task.IsCompleted)
        {
            task.MarkIncomplete();
        }
        else
        {
            task.MarkComplete();
        }
    }

    public void AddTagToTaskFromUserInput()
    {
        Console.Write("\nEnter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        Task task = FindTaskById(id);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            return;
        }

        Console.Write("Enter Tag: ");
        string tag = Console.ReadLine();
        task.AddTag(tag);
    }

    public void RemoveTagFromTaskUserInput()
    {
        Console.Write("\nEnter Task ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        Task task = FindTaskById(id);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            return;
        }

        Console.Write("Enter Tag to Remove: ");
        string tag = Console.ReadLine();
        task.RemoveTag(tag);
    }

    public void SortTasks(TaskComparisonDelegate comparisonLogic)
    {
        if (_tasks == null || _tasks.Count == 0)
        {
            Console.WriteLine("No tasks to sort.");
            return;
        }

        _tasks.Sort(new Comparison<Task>(comparisonLogic));
        Console.WriteLine("Tasks sorted.");
        ViewAllTasks();
    }

    public void ViewFilteredTasks(Func<Task, bool> filterPredicate, string filterDescription)
    {
        Console.WriteLine($"\n--- Filtered Tasks: {filterDescription} ---");
        if (_tasks == null || _tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to filter.");
            return;
        }

        var filteredTasks = _tasks.Where(filterPredicate).ToList();
        if (filteredTasks.Count == 0)
        {
            Console.WriteLine($"No tasks match the filter: {filterDescription}");
            return;
        }

        foreach (Task task in filteredTasks)
        {
            task.DisplayDetails();
            Console.WriteLine("-----");
        }
    }

    private Task FindTaskById(int id)
    {
        return _tasks.FirstOrDefault(task => task.Id == id);
    }
}

// Main program
public class Program
{
    public static void Main()
    {
        TaskManager taskManager = new TaskManager();
        bool keepRunning = true;

        Console.WriteLine("Welcome to the Miniature Task Tracker!");

        while (keepRunning)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Toggle Task Completion");
            Console.WriteLine("4. Add Tag to Task");
            Console.WriteLine("5. Remove Tag from Task");
            Console.WriteLine("6. Sort Tasks by Title");
            Console.WriteLine("7. Sort Tasks by ID");
            Console.WriteLine("8. View Completed Tasks");
            Console.WriteLine("9. View Pending Tasks");
            Console.WriteLine("10. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    taskManager.AddTaskFromUserInput();
                    break;
                case "2":
                    taskManager.ViewAllTasks();
                    break;
                case "3":
                    taskManager.ToggleTaskCompletionStatusById();
                    break;
                case "4":
                    taskManager.AddTagToTaskFromUserInput();
                    break;
                case "5":
                    taskManager.RemoveTagFromTaskUserInput();
                    break;
                case "6":
                    taskManager.SortTasks((t1, t2) => string.Compare(t1.Title, t2.Title, StringComparison.OrdinalIgnoreCase));
                    break;
                case "7":
                    taskManager.SortTasks((t1, t2) => t1.Id.CompareTo(t2.Id));
                    break;
                case "8":
                    taskManager.ViewFilteredTasks(task => task.IsCompleted, "Completed Tasks");
                    break;
                case "9":
                    taskManager.ViewFilteredTasks(task => !task.IsCompleted, "Pending Tasks");
                    break;
                case "10":
                    keepRunning = false;
                    Console.WriteLine("Thank you for using the Task Tracker. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
