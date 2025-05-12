---
title: "🤖 Classes and Objects - Part 3"
date: 2025-05-10 09:34:10 +1000
tags: [C#, Programming, OOP, Classes, Objects, Static, Properties, this, Advanced]
categories: [C# Fundamentals]
comments: true
---

Building on our understanding of classes, objects, encapsulation, constructors, and properties, this lesson explores further refinements and features related to class design in C#. These concepts help write more concise, efficient, and powerful object-oriented code.

We will cover:
*   **`static` Members:** Fields and methods belonging to the class itself, not individual objects.
*   **The `this` Keyword:** Referencing the current object instance.
*   **Auto-Implemented Properties:** A shorthand syntax for simple properties.
*   **Expression-Bodied Members:** Concise syntax for simple methods and properties.
*   **Object Initializers:** An alternative syntax for setting properties during object creation.

**(Prerequisites: Ensure you understand the concepts from the previous "Classes and Objects" posts.)**

## Lesson: Refining Class Design

### `static` Members: Shared by All Objects

So far, the fields and methods we've defined (like `_name` or `Deposit()`) belong to *individual objects*. Each `Player` object has its own `_name`, and calling `Deposit()` on one `BankAccount` object affects only that object's balance.

Sometimes, however, you need data or functionality related to the *class itself*, rather than any specific instance. For this, we use the `static` keyword.

*   **`static` Fields:** A single copy of the field exists, shared across *all* objects of the class (and accessible even if no objects exist). Useful for constants shared by all instances or for keeping track of class-level information (like how many objects have been created).
*   **`static` Methods:** Methods called directly on the *class*, not on an object instance. They cannot directly access instance fields or methods (like `_name` or `Deposit()`) because they don't operate on a specific object. They often work with static fields or operate solely on their input parameters. `Console.WriteLine()` and `Math.Max()` are examples of static methods.

```csharp
public class Circle
{
    // Instance field (each circle has its own radius)
    private double _radius;

    // Static field (shared constant for all circles)
    public const double Pi = 3.14159; // Constants are implicitly static

    // Static field (shared counter for all circles)
    private static int _numberOfCirclesCreated = 0;

    // Constructor (instance method)
    public Circle(double radius)
    {
        _radius = radius;
        _numberOfCirclesCreated++; // Increment the static counter
    }

    // Instance method (operates on a specific circle's radius)
    public double CalculateArea()
    {
        return Pi * _radius * _radius; // Can access static Pi and instance _radius
    }

    // Static method (belongs to the Circle class, not an instance)
    public static int GetNumberOfCirclesCreated()
    {
        // Cannot access _radius here because it belongs to an instance
        // Console.WriteLine(_radius); // Error!
        return _numberOfCirclesCreated; // Can access static field
    }
}

// --- Usage ---
Console.WriteLine($"Value of Pi: {Circle.Pi}"); // Access static constant via class name

Circle c1 = new Circle(5.0);
Circle c2 = new Circle(10.0);

Console.WriteLine($"Area of c1: {c1.CalculateArea()}"); // Call instance method on object

// Access static method via class name
Console.WriteLine($"Number of circles created: {Circle.GetNumberOfCirclesCreated()}"); // Output: 2
```

`static` is useful for utility methods, constants, factory methods, or managing class-level state.

### The `this` Keyword: Referring to the Current Instance

Inside an instance method or constructor, you sometimes need to refer explicitly to the *current object* the method is being called on. The `this` keyword provides this reference.

Common uses:

1.  **Disambiguation:** When a parameter name is the same as a field name.
2.  **Passing the Current Object:** Passing the current object as an argument to another method.
3.  **Constructor Chaining:** Calling one constructor from another within the same class.

```csharp
public class Rectangle
{
    private double _width;
    private double _height;

    // Constructor using 'this' for disambiguation
    public Rectangle(double width, double height)
    {
        this._width = width;   // 'this._width' is the field, 'width' is the parameter
        this._height = height; // 'this._height' is the field, 'height' is the parameter
    }

    // Constructor chaining: Call the first constructor with default values
    public Rectangle() : this(1.0, 1.0) // Calls Rectangle(1.0, 1.0)
    {
        Console.WriteLine("Default rectangle created.");
    }

    public double CalculateArea()
    {
        return _width * _height;
    }

    // Example of passing 'this'
    public void PrintDetails(Printer printer)
    {
        printer.Print(this); // Pass the current Rectangle object to the Printer
    }
}

// Dummy Printer class for example
public class Printer
{
    public void Print(Rectangle rect) { /* ... print rect details ... */ }
}
```

While not always strictly necessary (the compiler often infers it), `this` can improve clarity, especially when dealing with naming conflicts or constructor chaining.

### Auto-Implemented Properties: Less Boilerplate

Often, a property simply gets and sets a private backing field without any extra logic. C# provides a shorthand syntax called **auto-implemented properties** for this common case.

```csharp
public class Product
{
    // Auto-Implemented Property for Name
    // Compiler automatically creates a hidden private backing field.
    public string Name { get; set; }

    // Auto-Implemented Property for Price (with private set)
    public decimal Price { get; private set; }

    // Constructor to set initial values
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price; // Can use the private set from within the class
    }

    // You can still add methods
    public void ApplyDiscount(decimal percentage)
    {
        if (percentage > 0 && percentage < 1)
        {
            Price *= (1 - percentage); // Modify using the private set
        }
    }
}

// --- Usage ---
Product laptop = new Product("Laptop", 1200.00m);
Console.WriteLine($"Product: {laptop.Name}, Price: {laptop.Price:C}");

laptop.Name = "Gaming Laptop"; // Use the public set
// laptop.Price = 1100.00m; // Error! Price has a private set.
laptop.ApplyDiscount(0.10m); // Price is changed internally
Console.WriteLine($"Updated Price: {laptop.Price:C}");
```

Use auto-properties when you don't need custom logic in the `get` or `set` accessors. You can always expand them later if needed.

### Expression-Bodied Members: Concise Syntax

For methods, constructors, or property accessors that consist of only a *single* expression or statement, C# offers a more concise syntax using `=>`.

```csharp
public class Point
{
    public double X { get; }
    public double Y { get; }

    // Constructor using expression body
    public Point(double x, double y) => (X, Y) = (x, y);

    // Read-only property using expression body
    public double DistanceFromOrigin => Math.Sqrt(X * X + Y * Y);

    // Method using expression body
    public void Translate(double dx, double dy) => (X, Y) = (X + dx, Y + dy); // Note: This won't compile as X,Y are readonly. Example syntax only.

    // Method returning a value using expression body
    public override string ToString() => $"({X}, {Y})";
}
```

This syntax can make simple members much shorter and sometimes easier to read.

### Object Initializers: Setting Properties on Creation

Besides using constructors, you can also set the values of *accessible* properties immediately after creating an object using **object initializer** syntax.

```csharp
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}

// --- Usage ---

// Using default constructor and object initializer
Customer customer1 = new Customer
{
    CustomerId = 1,
    Name = "Bob",
    City = "New York" // Properties must be settable (have a public set)
};

Console.WriteLine($"Customer: {customer1.Name} from {customer1.City}");
```

This syntax is convenient when you have multiple properties to set and don't have (or don't want to use) a constructor that takes all those values.

## Tutorial: Static Utility Class - `Calculator`

Let's create a simple utility class with only `static` methods.

**Objective:** Create a `Calculator` class with static methods for basic arithmetic operations.

**Prerequisites:** A C# console project.

**Step 1: Define the `Calculator` Class**

Create `Calculator.cs`. Since this class will only contain static methods and doesn't need to be instantiated, we can also mark the class itself as `static`.

```csharp
// Calculator.cs
using System;

public static class Calculator // Static class
{
    // Static method for Addition
    public static double Add(double a, double b)
    {
        return a + b;
    }

    // Static method for Subtraction
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Static method for Multiplication (using expression body)
    public static double Multiply(double a, double b) => a * b;

    // Static method for Division (with check for zero)
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            return double.NaN; // Not a Number indicates failure
        }
        return a / b;
    }
}
```
*Explanation: A `static` class cannot be instantiated (`new Calculator()` is illegal) and can only contain `static` members. We define static methods for the operations.*

**Step 2: Use the `Calculator` Class in `Program.cs`**

Call the static methods directly using the class name.

```csharp
// Program.cs
using System;

public class Program
{
    public static void Main(string[] args)
    {
        double num1 = 10.5;
        double num2 = 2.5;

        // Call static methods using the class name
        double sum = Calculator.Add(num1, num2);
        double difference = Calculator.Subtract(num1, num2);
        double product = Calculator.Multiply(num1, num2);
        double quotient = Calculator.Divide(num1, num2);
        double invalidQuotient = Calculator.Divide(num1, 0);

        Console.WriteLine($"{num1} + {num2} = {sum}");
        Console.WriteLine($"{num1} - {num2} = {difference}");
        Console.WriteLine($"{num1} * {num2} = {product}");
        Console.WriteLine($"{num1} / {num2} = {quotient}");
        Console.WriteLine($"{num1} / 0 = {invalidQuotient}"); // Will show NaN after error message
    }
}
```

**Step 3: Build and Run**

Save both files, build, and run. Observe how the static methods are called directly on the `Calculator` class.

## Exercise: Configurable `Logger` Class

Let's create a `Logger` class that uses static members for configuration and instance members for logging messages, incorporating auto-properties and the `this` keyword.

**Project Goal:** Create a `Logger` class where you can set a static logging level, and instances of the logger prepend a specific prefix to messages.

**Requirements:**

1.  Create a new console project.
2.  Define a `Logger` class (`Logger.cs`).
3.  Add a **`static` property** `LogLevel` of type `int` (e.g., 0=Debug, 1=Info, 2=Warning, 3=Error). Use an auto-property with a public `get` and a public `set`. Initialize it to 1 (Info) by default.
4.  Add a **private instance field** `_prefix` of type `string`.
5.  Add a **public constructor** that takes a `string prefix` parameter. Use the `this` keyword to assign the parameter to the `_prefix` field.
6.  Add a **public instance method** `Log(string message, int messageLevel)`.
    *   This method should only print the message if `messageLevel` is greater than or equal to the **static** `LogLevel`.
    *   If it prints, the output should be formatted as: `[PREFIX]: [Message]` (e.g., `[WebApp]: User logged in`).
7.  In `Program.cs`:
    *   Create two different `Logger` instances with different prefixes (e.g., `new Logger("[WebApp]")`, `new Logger("[Database]")`).
    *   Log messages using different levels with both loggers.
    *   Change the static `Logger.LogLevel` and log messages again to see the filtering effect.

**Hints:**

*   Static auto-property: `public static int LogLevel { get; set; } = 1;`
*   Accessing static property inside instance method: `if (messageLevel >= Logger.LogLevel)`
*   Constructor: `public Logger(string prefix) { this._prefix = prefix; }`

**Steps:**

1.  Implement the `Logger` class.
2.  Implement the test code in `Program.cs`.
3.  Save, build, and run.
4.  Verify that messages are filtered based on the static `LogLevel` and that each logger uses its correct prefix.

## Conclusion

This lesson introduced powerful C# features for class design: `static` members for class-level data and behavior, the `this` keyword for instance referencing and constructor chaining, auto-implemented properties and expression-bodied members for concise syntax, and object initializers for flexible object creation. Using these tools effectively allows you to write cleaner, more maintainable, and more expressive object-oriented code.
