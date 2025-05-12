---
title: "🤖 Classes and Objects - Part 1"
date: 2025-05-08 07:42:13 +1000
tags: [C#, Programming, Basics, OOP, Classes, Objects, Beginner]
categories: [C# Fundamentals]
comments: true
---

Welcome back! So far, we've learned how to store simple pieces of data like numbers and text using variables. But what if we want to represent more complex things, like a player in a game, a bank account, or even a simple pet? This is where **Classes** and **Objects** come in – they are fundamental ideas in C# and Object-Oriented Programming (OOP).

This lesson introduces:
*   What classes and objects are (think blueprints and the things made from them).
*   How to define a simple class.
*   How to create objects from a class.
*   How objects can store data (using fields) and perform actions (using methods).

**(Prerequisite: Ensure you understand the concepts from the "Variables and Data Types".)**

## Lesson: Blueprints and Real Things

### A New Way to Organize: Objects

Imagine you want to represent a dog in your program. A dog isn't just one piece of data; it has several characteristics (like its name, breed, age) and it can do things (like bark, wag its tail, eat).

Object-Oriented Programming (OOP) helps us model real-world things like this. We think of our program as being made up of interacting **objects**. Each object represents something specific and has:

1.  **State:** What the object *knows* about itself (e.g., the dog's name is "Buddy", its breed is "Golden Retriever").
2.  **Behavior:** What the object can *do* (e.g., the dog can `Bark()`).

### Classes: The Blueprint for Objects

How do we tell the computer what a "dog" is? We define a **class**. A class is like a blueprint or a template. It describes *what kind* of information a dog object will store and *what actions* a dog object can perform.

Here’s how you define a simple `Dog` class in C#:

```csharp
// Define the blueprint for a Dog
public class Dog
{
    // What a Dog knows (State) - called Fields
    public string Name;
    public string Breed;

    // What a Dog can do (Behavior) - called Methods
    public void Bark()
    {
        Console.WriteLine(Name + " says Woof! Woof!");
    }
}
```

Let's break this down:
*   `public class Dog`: This declares a new blueprint named `Dog`. The `public` keyword means we can use this blueprint from other parts of our code.
*   `public string Name;` and `public string Breed;`: These are **fields**. They are variables declared inside the class. They define the *state* – every `Dog` object we create will have its own `Name` and `Breed`.
*   `public void Bark() { ... }`: This is a **method**. It defines a *behavior* – something a `Dog` object can do. The code inside the curly braces `{}` is executed when we tell a `Dog` object to `Bark()`. `void` means this method doesn't send back any information when it's done.

**Naming Convention:** Class names usually start with an uppercase letter (**PascalCase**), like `Dog`, `Player`, `BankAccount`.

### Objects: Creating Actual Dogs from the Blueprint

The `Dog` class is just the blueprint. To have an actual dog in our program, we need to create an **object** (also called an **instance**) from the class. We use the `new` keyword for this:

```csharp
// Create an actual Dog object from the Dog blueprint
Dog myDog = new Dog();

// Create another, separate Dog object
Dog neighborsDog = new Dog();
```

*   `Dog myDog`: Declares a variable named `myDog` that can hold a reference to a `Dog` object.
*   `= new Dog();`: This is the important part! `new Dog()` actually creates a new `Dog` object in the computer's memory based on the `Dog` class blueprint, and the `=` assigns a reference to this new object to the `myDog` variable.

Now, `myDog` and `neighborsDog` refer to two completely separate `Dog` objects. Each one has its *own* `Name` and `Breed` fields.

### Using Objects: Accessing Fields and Calling Methods

Once you have an object, you can interact with it using the **dot operator (`.`)**.

**1. Accessing Fields (State):** You can get or set the values of the object's public fields.

```csharp
Dog myDog = new Dog();

// Set the values for myDog's fields
myDog.Name = "Buddy";
myDog.Breed = "Golden Retriever";

// Get the value from myDog's field and print it
Console.WriteLine("My dog's name is: " + myDog.Name);

Dog neighborsDog = new Dog();
neighborsDog.Name = "Lucy";
neighborsDog.Breed = "Poodle";

Console.WriteLine("Neighbor's dog is a " + neighborsDog.Breed);

// Let's prove they are separate!
Console.WriteLine("My dog is still named: " + myDog.Name); // Still Buddy!
```
*Notice how `myDog.Name` ("Buddy") is different from `neighborsDog.Name` ("Lucy"). Each object has its own data.*

**2. Calling Methods (Behavior):** You can tell the object to perform an action defined in its class.

```csharp
Dog myDog = new Dog();
myDog.Name = "Buddy";

// Tell myDog to perform the Bark action
myDog.Bark(); // Output: Buddy says Woof! Woof!

Dog neighborsDog = new Dog();
neighborsDog.Name = "Lucy";

neighborsDog.Bark(); // Output: Lucy says Woof! Woof!
```
*When you call `myDog.Bark()`, the code inside the `Bark` method runs using `myDog`'s `Name`. When you call `neighborsDog.Bark()`, it uses `neighborsDog`'s `Name`.*

Classes and objects are powerful because they let us group related data and behavior together, making our code more organized and easier to understand, especially as programs get bigger.

## Tutorial: Creating and Using a Simple `Car` Class

Let's practice by creating a simple `Car` class.

**Objective:** Define a `Car` class, create `Car` objects, set their data, and call their methods.

**Prerequisites:** A C# console project set up.

**Step 1: Define the `Car` Class**

Create a new file named `Car.cs` in your project and add the following code:

```csharp
// Car.cs
using System;

public class Car
{
    // Fields (State)
    public string Color;
    public string Make;
    public int Year;

    // Method (Behavior)
    public void StartEngine()
    {
        Console.WriteLine("The " + Color + " " + Make + " starts. Vroom!");
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Car Details: Year=" + Year + ", Make=" + Make + ", Color=" + Color);
    }
}
```
*Explanation: We've defined a `Car` blueprint with fields for `Color`, `Make`, and `Year`, and methods `StartEngine()` and `DisplayDetails()`.*

**Step 2: Use the `Car` Class in `Program.cs`**

Now, go to your main `Program.cs` file. Inside the `Main` method, let's create and use some `Car` objects.

```csharp
// Program.cs
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Creating some cars...");

        // Create the first Car object
        Car myCar = new Car();
        // Set its field values
        myCar.Color = "Red";
        myCar.Make = "Toyota";
        myCar.Year = 2020;

        // Create a second Car object
        Car friendsCar = new Car();
        friendsCar.Color = "Blue";
        friendsCar.Make = "Honda";
        friendsCar.Year = 2019;

        Console.WriteLine("\n--- Car Actions ---");

        // Call methods on the objects
        myCar.DisplayDetails();
        myCar.StartEngine();

        Console.WriteLine(); // Add a blank line

        friendsCar.DisplayDetails();
        friendsCar.StartEngine();
    }
}
```
*Explanation: We create two separate `Car` objects (`myCar`, `friendsCar`). We set the `Color`, `Make`, and `Year` for each one individually using the dot (`.`) operator. Then, we call the `DisplayDetails()` and `StartEngine()` methods on each object.*

**Step 3: Build and Run**

1.  Save both `Car.cs` and `Program.cs`.
2.  In your terminal (in the project folder), run `dotnet build`.
3.  Then run `dotnet run`.

**Expected Output:**

```
Creating some cars...

--- Car Actions ---
Car Details: Year=2020, Make=Toyota, Color=Red
The Red Toyota starts. Vroom!

Car Details: Year=2019, Make=Honda, Color=Blue
The Blue Honda starts. Vroom!
```

This shows how we defined a blueprint (`Car` class) and then created and interacted with individual instances (`myCar`, `friendsCar`) based on that blueprint.

## Exercise: Create a `Book` Class

Now it's your turn to create a class from scratch!

**Project Goal:** Define a simple `Book` class and use it to create book objects.

**Requirements:**

1.  Create a new C# console project (e.g., `BookCatalog`).
2.  Define a new class named `Book` in its own file (`Book.cs`).
3.  Inside the `Book` class, add **public fields** for:
    *   `Title` (string)
    *   `Author` (string)
    *   `NumberOfPages` (int)
4.  Add a **public method** named `DisplayBookInfo()` that prints the book's title, author, and number of pages to the console (e.g., "Title: [Title], Author: [Author], Pages: [NumberOfPages]").
5.  In `Program.cs`, inside the `Main` method:
    *   Create at least two different `Book` objects using `new Book()`.
    *   Set the `Title`, `Author`, and `NumberOfPages` for each book object.
    *   Call the `DisplayBookInfo()` method on each book object.

**Hints:**

*   Remember the `public class Book { ... }` structure.
*   Declare fields like `public string Title;`.
*   Define the method like `public void DisplayBookInfo() { ... }`.
*   Use `Console.WriteLine()` inside the method to print the details.
*   Create objects like `Book book1 = new Book();`.
*   Set fields like `book1.Title = "Some Book";`.
*   Call methods like `book1.DisplayBookInfo();`.

**Steps:**

1.  Set up the project.
2.  Write the `Book.cs` file.
3.  Write the `Program.cs` file to use the `Book` class.
4.  Save, build (`dotnet build`), and run (`dotnet run`).
5.  Check if the output correctly displays the details for both books.

## Conclusion

This lesson introduced the fundamental concepts of Object-Oriented Programming in C#: **classes** as blueprints and **objects** as the actual instances created from those blueprints. We learned how to define simple classes with **fields** (to store data) and **methods** (to define actions), and how to create and interact with objects using the `new` keyword and the dot (`.`) operator. This way of organizing code helps us model complex things and build more structured programs.
