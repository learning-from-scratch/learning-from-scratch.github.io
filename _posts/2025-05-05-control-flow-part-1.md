---
title: "🎮 Control Flow in C# - Part 1"
date: 2025-05-05 07:32:00 +1000
tags: [C#, Programming, Basics, Control Flow, If, Else, Boolean, Beginner]
categories: [C# Fundamentals]
comments: true
---
Imagine you're giving someone directions. You might say, "*If* the light is red, stop. *Otherwise*, go." Or, "*Keep* walking *until* you reach the park." Programs need to make similar decisions and repeat actions too!

This lesson introduces **Control Flow** – how we guide the order in which instructions run in our C# programs. We'll learn how to make simple decisions using `if` and `else` based on true/false conditions.

**(Prerequisites: Ensure you understand the concepts from "Variables and Data Types".)**

## Lesson: Making Simple Decisions

### True or False: Boolean Logic

At the heart of decision-making is the concept of **true** and **false**. In C#, we use the `bool` data type, which can hold only one of two values: `true` or `false`.

How do we get these `true` or `false` values? Often, we use **comparison operators** to compare other values:

*   `==` (Is Equal To?): Checks if two values are the same.
    *   `5 == 5` is `true`
    *   `5 == 6` is `false`
*   `!=` (Is Not Equal To?): Checks if two values are different.
    *   `5 != 6` is `true`
    *   `"hello" != "hello"` is `false`
*   `>` (Greater Than?): Checks if the left value is bigger than the right.
    *   `10 > 5` is `true`
*   `<` (Less Than?): Checks if the left value is smaller than the right.
    *   `3 < 8` is `true`
*   `>=` (Greater Than or Equal To?)
    *   `7 >= 7` is `true`
*   `<=` (Less Than or Equal To?)
    *   `4 <= 5` is `true`

```csharp
int myAge = 20;
bool canVote = myAge >= 18; // canVote becomes true

int score = 50;
bool isPerfectScore = score == 100; // isPerfectScore becomes false

Console.WriteLine("Can I vote? " + canVote); // Output: Can I vote? True
```

These `true`/`false` results are what we use to make decisions.

### The `if` Statement: Doing Something Conditionally

The simplest way to make a decision is with the `if` statement. It checks if a condition is `true`. If it is, the code block inside the curly braces `{}` runs. If the condition is `false`, the block is skipped.

```csharp
// Syntax:
// if (condition)
// {
//     Code to run if condition is true
// }

int temperature = 15;

if (temperature < 20)
{
    Console.WriteLine("It's a bit chilly, wear a jacket!"); // This line runs
}

Console.WriteLine("Weather advice complete."); // This line always runs afterwards
```

### The `if-else` Statement: Choosing Between Two Paths

What if you want to do one thing if the condition is true, and a *different* thing if it's false? Use `if-else`.

```csharp
// Syntax:
// if (condition)
// {
//     Code to run if condition is true
// }
// else
// {
//     Code to run if condition is false
// }

int userAge = 16;

if (userAge >= 18)
{
    Console.WriteLine("You are eligible to vote.");
}
else
{
    Console.WriteLine("Sorry, you are not yet eligible to vote."); // This line runs
}
```

The `else` block only runs when the `if` condition is `false`.

### Combining Conditions: `&&` (AND) and `||` (OR)

Sometimes you need to check multiple conditions at once.

*   `&&` (**AND**): Both sides must be `true` for the whole thing to be `true`.
    *   `age >= 18 && hasLicense == true` (Must be 18+ AND have a license)
*   `||` (**OR**): At least one side must be `true` for the whole thing to be `true`.
    *   `isWeekend == true || isHoliday == true` (It's okay if it's the weekend OR a holiday)

```csharp
bool hasTicket = true;
bool isMember = false;

// Example using AND (&&)
if (hasTicket && isMember)
{
    Console.WriteLine("Welcome, valued member with a ticket!");
}
else
{
    Console.WriteLine("Ticket and membership required for this area."); // This runs
}

// Example using OR (||)
if (hasTicket || isMember)
{
    Console.WriteLine("You can enter the main area."); // This runs
}
else
{
    Console.WriteLine("You need either a ticket or membership to enter.");
}
```

These logical operators let you build more complex decision-making rules.

## Tutorial: Simple Number Checker

Let's write a program that asks the user for a number and tells them if it's positive, negative, or zero using `if-else`.

**Objective:** Practice using comparison operators and `if-else if-else` statements.

**Prerequisites:** A C# console project.

**Step 1: Set up `Program.cs`**

```csharp
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a whole number: ");
        string input = Console.ReadLine();

        int number;
        bool success = int.TryParse(input, out number);

        if (success)
        {
            // Decision logic goes here
        }
        else
        {
            Console.WriteLine("That wasn't a valid whole number.");
        }
    }
}
```
*Explanation: We get input and use `int.TryParse` to safely convert it to a number. The `if(success)` block runs only if the conversion worked.*

**Step 2: Add `if-else if-else` Logic**

Inside the `if (success)` block, add the conditions to check the number.

```csharp
if (success)
{
   // Check if the number is greater than 0
   if (number > 0)
   {
         Console.WriteLine("The number is positive.");
   }
   // If not positive, check if it's less than 0
   else if (number < 0)
   {
         Console.WriteLine("The number is negative.");
   }
   // If it's not positive and not negative, it must be 0
   else
   {
         Console.WriteLine("The number is zero.");
   }
}
else
{
   Console.WriteLine("That wasn't a valid whole number.");
}
```
*Explanation: We first check `number > 0`. If that's false, we then check `number < 0`. If that's also false, the final `else` block runs, meaning the number must be 0.*

**Step 3: Build and Run**

1.  Save `Program.cs`.
2.  Build (`dotnet build`) and run (`dotnet run`).
3.  Test by entering a positive number (e.g., `10`), a negative number (e.g., `-5`), zero (`0`), and invalid text (e.g., `hello`).

**Example Interaction:**

```
Enter a whole number: -7
The number is negative.
```

```
Enter a whole number: 0
The number is zero.
```

## Exercise: Simple Access Check

Create a program that simulates a basic access check based on age.

**Project Goal:** Ask the user for their age and print a specific message based on whether they are under 13, between 13 and 17 (inclusive), or 18 or older.

**Requirements:**

1.  Create a new console project (e.g., `AgeCheck`).
2.  Prompt the user to enter their age.
3.  Use `int.TryParse` to safely get the age as an integer.
4.  If the input is invalid, print an error message.
5.  If the input is valid, use `if-else if-else` statements:
    *   If age is less than 13, print "Child access only."
    *   If age is greater than or equal to 13 AND less than 18, print "Teenager access granted."
    *   If age is greater than or equal to 18, print "Adult access granted."

**Hints:**

*   Remember `int.TryParse(input, out age)`.
*   For the teenager check, you'll need the `&&` (AND) operator: `age >= 13 && age < 18`.

**Steps:**

1.  Write the code in `Program.cs`.
2.  Save, build, and run.
3.  Test with ages like 10, 15, 25, and invalid input.

## Conclusion

In this lesson, we learned the basics of controlling program flow. We saw how Boolean logic (`true`/`false`) and comparison operators (`==`, `>`, `<` etc.) allow us to form conditions. We then used these conditions with `if` and `if-else` statements to make our programs execute different code paths based on whether those conditions are met. This ability to make decisions is a fundamental part of programming!
