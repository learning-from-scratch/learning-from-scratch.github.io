---
title: "🗃️ Variables and Data Types - Part 1"
date: 2025-05-03 11:32:00 +1000
tags: [C#, Programming, Basics, Variables, Data Types, Expressions, Beginner]
categories: [C# Fundamentals]
comments: true
---

Welcome back! In the first lesson, we learned how to create and run a basic C# program. Now, let's explore how programs remember and work with information. We'll learn about **variables** (like labeled boxes for storing data), **data types** (what kind of data goes in the box), and simple **expressions** (doing calculations).


<figure style="text-align: center;">
  <img src="/assets/img/2025-05-03.webp" alt="Boxes of variables" style="height: 300px">
</figure>

## Lesson: Storing Your First Pieces of Data

### What are Variables?

Imagine you're writing a program and need to keep track of a player's score or someone's name. You need a place to store this information while the program is running. That's what **variables** are for! A variable is simply a named spot in the computer's memory where you can store a piece of data.

To use a variable in C#, you first have to **declare** it. This tells the computer two things:

1.  **Data Type:** What *kind* of data will this variable hold? (e.g., a whole number, a number with decimals, some text).
2.  **Name (Identifier):** What name will you use to refer to this variable later?

Here's how you declare variables for common types:

```csharp
int score;       // Declares a variable named 'score' to hold whole numbers (integers).
string playerName; // Declares a variable named 'playerName' to hold text (strings).
double price;     // Declares a variable named 'price' to hold numbers with decimals.
bool isActive;    // Declares a variable named 'isActive' to hold true/false values.
```

*   `int`: Short for integer, used for whole numbers like `-5`, `0`, `100`.
*   `string`: Used for sequences of text characters, like `"Hello"` or `"Alice"`.
*   `double`: Used for numbers that might have a decimal point, like `19.99` or `-3.5`.
*   `bool`: Short for Boolean, used for values that are either `true` or `false`.

**Naming Your Variables:** It's a common practice in C# to name variables using **camelCase**. This means the first word starts with a lowercase letter, and any following words start with an uppercase letter (e.g., `playerScore`, `userName`, `itemPrice`). Choose names that clearly describe what the variable holds!

### Giving Variables a Value (Assignment)

Declaring a variable just creates the named box. To put something inside it, you use the **assignment operator**, which is the equals sign (`=`):

```csharp
int score;
score = 100; // Assigns the value 100 to the 'score' variable.

string playerName = "Bob"; // You can declare and assign in one step!

double price = 9.95;

isActive = true;

// You can change the value later!
score = 150; // Now the 'score' variable holds 150
playerName = "Alice"; // Now 'playerName' holds "Alice"

Console.WriteLine("The current score is: " + score); // Prints 150
```

The assignment works from right to left: the value on the right side of the `=` is put into the variable on the left side. If the variable already had a value, the old value is replaced.

**Important:** You usually need to assign a value to a variable before you can use it in calculations or print it.

### Simple Calculations: Expressions and Operators

Variables aren't very useful if you can't do things with them! We use **expressions** to perform calculations. An expression combines values (like `100`), variables (like `score`), and **operators** (like `+` or `-`) to produce a new value.

Here are the basic **arithmetic operators**:

*   `+` (Addition)
*   `-` (Subtraction)
*   `*` (Multiplication)
*   `/` (Division)

Let's see them in action:

```csharp
int score = 100;
int bonus = 25;
int totalScore = score + bonus; // totalScore will become 125

int apples = 10;
int eaten = 3;
int applesLeft = apples - eaten; // applesLeft will become 7

int pricePerItem = 5;
int quantity = 4;
int totalCost = pricePerItem * quantity; // totalCost will become 20

double totalDistance = 100.0;
double timeTaken = 2.5;
double averageSpeed = totalDistance / timeTaken; // averageSpeed will become 40.0
```

### Getting Input and Showing Output

Programs often need to interact with the user. We can display messages using `Console.WriteLine()` and read text input using `Console.ReadLine()`.

```csharp
Console.WriteLine("What is your name?"); // Ask the user a question
string userName = Console.ReadLine(); // Read the text the user types

Console.WriteLine("Hello, " + userName + "!"); // Greet the user
```

Notice how we used `+` to combine the text `"Hello, "` with the value stored in the `userName` variable and the text `"!"` before printing.

### Changing Types (Type Conversion)

Sometimes you get input as text (a `string`), but you need it as a number (`int` or `double`) to do calculations. You need to **convert** the type.

```csharp
Console.Write("Enter your age: ");
string ageString = Console.ReadLine(); // Reads age as text

int age = Convert.ToInt32(ageString); // Converts the text to a whole number

int ageNextYear = age + 1;
Console.WriteLine("Next year you will be " + ageNextYear);
```

*   `Convert.ToInt32()` tries to change a string into an `int`.
*   `Convert.ToDouble()` tries to change a string into a `double`.

**Caution:** If the user types something that isn't a valid number (like "abc"), these `Convert` methods will cause an error! We'll learn how to handle errors later.

## Tutorial: Simple Age Calculator

Let's build a small program that asks for your name and birth year, then calculates your approximate age.

**Objective:** Create a program that uses variables, input, output, type conversion, and a simple calculation.

**Prerequisites:** A C# console project set up (like `HelloWorld` from the previous lesson, or create a new one: `dotnet new console -o AgeCalculator`, then `cd AgeCalculator`).

**Step 1: Set up `Program.cs`**

Open `Program.cs` in VS Code.

```csharp
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // We'll add our code here
    }
}
```

**Step 2: Declare Variables**

We need variables for the name, birth year (as text and number), current year, and age.

```csharp
    // Inside Main...
    string name;              // For user's name
    string yearOfBirthString; // For birth year input (text)
    int yearOfBirth;          // For birth year (number)
    int currentYear;          // For the current year
    int age;                  // For the calculated age
```

**Step 3: Get the User's Name**

Ask for the name and read it.

```csharp
    // ... after variable declarations
    Console.Write("Please enter your name: "); // Ask without starting a new line
    name = Console.ReadLine(); // Read the typed name
```

**Step 4: Get the User's Birth Year**

Ask for the birth year and read it as text.

```csharp
    // ... after getting name
    Console.Write("Please enter your year of birth: ");
    yearOfBirthString = Console.ReadLine(); // Read the year as text
```

**Step 5: Convert Birth Year to a Number**

Change the text input into an integer.

```csharp
    // ... after getting birth year string
    yearOfBirth = Convert.ToInt32(yearOfBirthString); // Convert text to number
```

**Step 6: Get the Current Year**

C# can tell us the current year.

```csharp
    // ... after converting birth year
    currentYear = DateTime.Now.Year; // Gets the current year (e.g., 2025)
```

**Step 7: Calculate the Age**

Subtract the birth year from the current year.

```csharp
    // ... after getting current year
    age = currentYear - yearOfBirth; // Simple subtraction
```

**Step 8: Display the Result**

Show a message to the user.

```csharp
    // ... after calculating age
    Console.WriteLine("Hey " + name + ", you are approximately " + age + " years old this year.");
}
```

**Step 9: Build and Run**

1.  Save `Program.cs`.
2.  In your terminal (in the project folder), run `dotnet build`.
3.  Then run `dotnet run`.
4.  Try entering your name and birth year!

**Example Interaction:**

```
Please enter your name: Charlie
Please enter your year of birth: 2005
Hey Charlie, you are approximately 20 years old this year.
```
*(The age will depend on the current year when you run it.)*

## Exercise: Rectangle Area Calculator

Let's practice! Create a program that calculates the area of a rectangle.

**Project Goal:** Ask the user for the width and height of a rectangle and display its area.

**Requirements:**

1.  Create a new console project (e.g., `RectangleArea`).
2.  Ask the user to enter the width.
3.  Read the width as text (`string`).
4.  Convert the width text to a number (`double` is good here to allow decimals).
5.  Ask the user to enter the height.
6.  Read the height as text (`string`).
7.  Convert the height text to a number (`double`).
8.  Calculate the area: `area = width * height`.
9.  Display the width, height, and calculated area.

**Hints:**

*   Use `Console.Write()` for prompts.
*   Use `Console.ReadLine()`  convert text to a decimal number.
*   Use `Console.WriteLine()` to show the results (e.g., `Console.WriteLine("Area: " + area);`).

**Steps:**

1.  Set up the project.
2.  Write the code in `Program.cs`.
3.  Save, build (`dotnet build`), and run (`dotnet run`).
4.  Test with different numbers.

## Conclusion

In this lesson, we learned how to use variables (`int`, `string`, `double`, `bool`) to store different kinds of data. We saw how to assign values using `=`, perform simple calculations with `+`, `-`, `*`, `/`, get input from the user with `Console.ReadLine()`, display output with `Console.WriteLine()`, and convert between text and numbers using `Convert`. These are essential building blocks for almost any program!
