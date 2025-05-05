---
title: "More on Control Flow in C#"
date: 2025-05-05 15:45:41 +1000
tags: [C#, Programming, Basics, Control Flow, If, Else, Switch, Loops, While, Do While, Intermediate]
categories: [C# Fundamentals]
comments: true
---

In the Beginner Control Flow lesson, we learned how to make simple decisions using `if` and `else`. Now, let's expand our toolkit for controlling the program's execution path.

This intermediate lesson covers:
*   Handling multiple choices efficiently using the `switch` statement.
*   Repeating blocks of code using `while` loops (condition checked first).
*   Repeating blocks of code using `do-while` loops (code runs at least once).

**(Prerequisites: Ensure you understand the concepts from "Control Flow - Beginner".)**

## Lecture Article: Multiple Choices and Repetition

### Handling Multiple Specific Cases: The `switch` Statement

Sometimes, you have a variable and want to perform different actions based on several specific, constant values it might hold. While you *could* use a long chain of `if-else if` statements, the `switch` statement often provides a cleaner and more readable alternative for this scenario.

```csharp
// Syntax:
// switch (variable_or_expression)
// {
//     case constant_value_1:
//         // Code to run if variable == constant_value_1
//         break; // Important: Exits the switch
//     case constant_value_2:
//         // Code to run if variable == constant_value_2
//         break;
//     // ... more cases ...
//     default:
//         // Optional: Code to run if none of the cases match
//         break;
// }

Console.Write("Enter a command (start, stop, pause): ");
string command = Console.ReadLine();

switch (command)
{
    case "start":
        Console.WriteLine("Starting process...");
        // Add code to start something
        break; // Exit the switch

    case "stop":
        Console.WriteLine("Stopping process...");
        // Add code to stop something
        break; // Exit the switch

    case "pause":
        Console.WriteLine("Pausing process...");
        // Add code to pause something
        break; // Exit the switch

    default: // If command is not "start", "stop", or "pause"
        Console.WriteLine("Unknown command.");
        break;
}
```

**Key points about `switch`:**

*   It compares the value in the parentheses (e.g., `command`) against the value after each `case` label.
*   The values in `case` labels must be constants (like `"start"`, `1`, `true`, etc.), not variables.
*   The `break` statement is crucial. It tells the program to exit the `switch` block once a matching `case` is found and executed. Without `break`, the code would continue executing into the *next* case (this is called "fall-through" and is usually undesirable in C# unless done intentionally with specific syntax).
*   The `default` case is optional and acts like a final `else`, catching any values that don't match any specific `case`.
*   You can have multiple `case` labels point to the same block of code if they should perform the same action.
    ```csharp
    switch (dayNumber)
    {
        case 6: // Saturday
        case 7: // Sunday
            Console.WriteLine("It's the weekend!");
            break;
        default:
            Console.WriteLine("It's a weekday.");
            break;
    }
    ```

### Repeating Actions: The `while` Loop

What if you need to perform an action multiple times? For example, counting down from 10 or processing items until none are left. Loops are used for repetition.

The `while` loop repeats a block of code *as long as* a specified Boolean condition remains `true`. The condition is checked *before* each potential execution of the loop body.

```csharp
// Syntax:
// while (condition)
// {
//     Code to repeat as long as condition is true
// }

int counter = 0;

Console.WriteLine("Counting up to 3:");
while (counter < 3) // Check condition BEFORE entering/repeating
{
    counter = counter + 1; // Increment the counter
    Console.WriteLine("Counter is now: " + counter);
}

Console.WriteLine("Loop finished.");

// Output:
// Counting up to 3:
// Counter is now: 1
// Counter is now: 2
// Counter is now: 3
// Loop finished.
```

**Important:** Inside the `while` loop, you usually need to do something that will eventually make the condition `false`. In the example above, `counter = counter + 1;` ensures that `counter` eventually reaches 3, making `counter < 3` false and stopping the loop. If the condition *never* becomes false, you create an **infinite loop**, and your program will get stuck!

If the condition is `false` the very first time it's checked, the code inside the `while` loop will never run.

### Repeating Actions (Guaranteed Once): The `do-while` Loop

The `do-while` loop is similar to `while`, but with one key difference: the condition is checked *after* the loop body runs.

This means the code inside a `do-while` loop is **guaranteed to execute at least once**, even if the condition is initially false.

```csharp
// Syntax:
// do
// {
//     Code to repeat
// } while (condition); // Check condition AFTER running the code

string passwordAttempt;

do
{
    Console.Write("Enter the password: ");
    passwordAttempt = Console.ReadLine();

    if (passwordAttempt != "secret123")
    {
        Console.WriteLine("Incorrect password. Try again.");
    }

} while (passwordAttempt != "secret123"); // Keep looping until correct password entered

Console.WriteLine("Password accepted!");
```

In this example, the user is always prompted to enter the password at least once. The loop continues *while* the entered password is *not* equal to "secret123".

## Tutorial: Simple Menu with `switch` and `do-while`

Let's create a simple text menu that keeps showing options until the user chooses to quit. This combines the `do-while` loop (to ensure the menu shows at least once) and the `switch` statement (to handle the user's choice).

**Objective:** Practice using `do-while` for repeated actions and `switch` for handling multiple choices.

**Prerequisites:** A C# console project.

**Step 1: Set up `Program.cs`**

```csharp
using System;

public class Program
{
    public static void Main(string[] args)
    {
        string userChoice;

        do // Start a do-while loop
        {
            // Display Menu Inside the loop
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Say Hello");
            Console.WriteLine("2. Tell a Joke");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            userChoice = Console.ReadLine();

            // Switch statement to handle the choice goes here...

        } while (userChoice != "0"); // Continue while choice is NOT "0"

        Console.WriteLine("Goodbye!"); // This runs after the loop finishes
    }
}
```
*Explanation: The `do-while` loop ensures the menu is displayed and input is read at least once. The loop continues as long as `userChoice` is not "0".*

**Step 2: Add the `switch` Statement**

Inside the `do-while` loop, after reading `userChoice`, add a `switch` statement to handle the different options.

```csharp
            userChoice = Console.ReadLine();

            // Handle the choice
            switch (userChoice)
            {
                case "1": // If user entered "1"
                    Console.WriteLine("\nHello there! Nice to meet you.");
                    break; // Exit the switch

                case "2": // If user entered "2"
                    Console.WriteLine("\nWhy don't scientists trust atoms? Because they make up everything!");
                    break; // Exit the switch

                case "0": // If user entered "0"
                    Console.WriteLine("\nExiting menu...");
                    // No action needed here, the loop condition will handle exit
                    break; // Exit the switch

                default: // If user entered anything else
                    Console.WriteLine("\nInvalid choice, please try again.");
                    break; // Exit the switch
            }

        } while (userChoice != "0"); // Loop condition
```
*Explanation: The `switch` checks the value of `userChoice`. Each `case` handles a specific input ("1", "2", "0"). The `default` case catches any other input. `break` is used after each case.*

**Step 3: Build and Run**

1.  Save `Program.cs`.
2.  Build (`dotnet build`) and run (`dotnet run`).
3.  Try selecting options 1, 2, an invalid option (like 5), and finally 0 to exit.

**Example Interaction:**

```
--- MENU ---
1. Say Hello
2. Tell a Joke
0. Exit
Enter your choice: 1

Hello there! Nice to meet you.

--- MENU ---
1. Say Hello
2. Tell a Joke
0. Exit
Enter your choice: 2

Why don't scientists trust atoms? Because they make up everything!

--- MENU ---
1. Say Hello
2. Tell a Joke
0. Exit
Enter your choice: 9

Invalid choice, please try again.

--- MENU ---
1. Say Hello
2. Tell a Joke
0. Exit
Enter your choice: 0

Exiting menu...
Goodbye!
```

## Exercise: Countdown Timer

Create a program that counts down from a number specified by the user.

**Project Goal:** Practice using the `while` loop and basic arithmetic within a loop.

**Requirements:**

1.  Create a new console project (e.g., `Countdown`).
2.  Prompt the user to enter a positive starting number for the countdown.
3.  Use `int.TryParse` to safely get the starting number.
4.  If the input is invalid or not positive, print an error message and exit.
5.  If the input is valid and positive, use a `while` loop:
    *   The loop should continue as long as the number is greater than 0.
    *   Inside the loop, print the current value of the number.
    *   **Crucially**, decrease the number by 1 in each iteration (e.g., `number = number - 1;` or `number--;`).
6.  After the loop finishes, print "Blast off!".

**Hints:**

*   Check `success && startNumber > 0` after `TryParse`.
*   The `while` condition will be `while (currentNumber > 0)`.
*   Don't forget to decrease the number inside the loop to avoid an infinite loop!

**Steps:**

1.  Write the code in `Program.cs`.
2.  Save, build, and run.
3.  Test with a starting number like 5, 1, and also with 0 or invalid input.

## Conclusion

This intermediate lesson introduced powerful tools for controlling program flow beyond simple `if-else`. The `switch` statement provides a clean way to handle multiple specific choices, while `while` and `do-while` loops allow us to repeat blocks of code based on conditions. Mastering loops and selection statements is essential for creating dynamic and interactive applications.
