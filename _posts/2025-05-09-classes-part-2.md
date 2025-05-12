---
title: "🤖 Classes and Objects - Part 2"
date: 2025-05-09 08:42:48 +1000
tags: [C#, Programming, Basics, OOP, Classes, Objects, Constructors, Properties, Encapsulation, Intermediate]
categories: [C# Fundamentals]
comments: true
---

In the previous lesson on Classes and Objects, we learned how to define a class (a blueprint) with public fields and methods, and how to create objects (instances) from that class. However, directly exposing fields as `public` isn't always the best practice.

This lesson builds upon that foundation, introducing:
*   **Access Modifiers (`private`):** Controlling visibility of class members.
*   **Encapsulation:** The principle of bundling data and methods, and hiding internal details.
*   **Constructors:** Special methods for initializing objects when they are created.
*   **Properties:** Controlled access points to an object's data (using `get` and `set`).

**(Prerequisite: Ensure you understand the concepts from the "Classes and Objects" post.)**

## Lesson: Better Blueprints - Encapsulation and Control

### Why Not Just Use Public Fields?

In the previous example, we made fields like `Name` and `Breed` in the `Dog` class `public`. This works, but it has drawbacks:

1.  **No Validation:** Anyone using the `Dog` object can set the fields to *any* value, even invalid ones (e.g., setting `age` to -50).
2.  **Lack of Control:** If we later decide to change *how* the data is stored internally (e.g., combine first and last names into one field), any code directly accessing the old public fields will break.
3.  **Breaks Encapsulation:** The internal state of the object is wide open, making the code harder to maintain and reason about.

Object-Oriented Programming promotes **Encapsulation**, which means bundling an object's data (state) and the methods that operate on that data (behavior) together, while hiding the internal implementation details from the outside world.

### Access Modifiers: `public` vs. `private`

To control visibility, C# uses **access modifiers**:

*   `public`: The member (field, method, property, class) can be accessed from *anywhere*.
*   `private`: The member can *only* be accessed from *within the same class*. This is the default if you don't specify an access modifier for a member inside a class.

Good practice often involves making fields `private` to protect the object's internal state.

```csharp
public class Player
{
    // Fields are now private
    private string _name;
    private int _health;
    private int _score;

    // How do we access _name, _health, _score from outside now?
}
```

**Naming Convention:** It's common to prefix private fields with an underscore (`_`) followed by camelCase (e.g., `_name`, `_health`).

### Constructors: Initializing Objects Properly

When we create an object using `new ClassName()`, a special method called a **constructor** is automatically called. Its job is to initialize the object's state.

*   A constructor has the **same name** as the class.
*   It has **no return type** (not even `void`).
*   It can take parameters, just like regular methods.

If you don't define any constructor, C# provides a default, parameterless one that does nothing. But we can define our own to ensure objects are created with valid initial data.

```csharp
public class Player
{
    private string _name;
    private int _health;
    private int _score;

    // Constructor
    public Player(string initialName, int initialHealth)
    {
        _name = initialName; // Use parameter to set private field
        _health = initialHealth; // Use parameter to set private field
        _score = 0; // Initialize score to 0 by default
        Console.WriteLine($"Player {_name} created with {_health} health.");
    }

    // Other methods...
}
```

Now, when you create a `Player` object, you *must* provide the required arguments:

```csharp
// Player player1 = new Player(); // Error! No matching constructor without parameters.

Player player1 = new Player("Alice", 100); // Calls the constructor
Player player2 = new Player("Bob", 80);
```

Constructors ensure that objects start in a valid state.

### Properties: The Gatekeepers of Data

Since our fields are `private`, how do we allow controlled access? We use **Properties**. Properties look like fields when you use them (e.g., `player1.Name`), but they are actually special methods called **accessors** (`get` and `set`) hidden behind the scenes.

*   The `get` accessor runs when you read the property's value. It should return the value of the underlying private field.
*   The `set` accessor runs when you assign a value to the property. It receives the assigned value in a special implicit parameter called `value`. Here, you can add validation logic before updating the private field.

Properties use **PascalCase** naming convention.

```csharp
public class Player
{
    private string _name;
    private int _health;
    private int _score;

    // Constructor
    public Player(string initialName, int initialHealth)
    {
        // Use properties inside constructor for validation (if needed)
        Name = initialName; // Calls the 'set' accessor of Name property
        _health = (initialHealth > 0) ? initialHealth : 100; // Basic validation for health
        _score = 0;
        Console.WriteLine($"Player {Name} created with {_health} health.");
    }

    // Property for Name (Read and Write)
    public string Name
    {
        get
        {
            return _name; // Returns the value of the private field
        }
        set
        {
            // 'value' holds the incoming value (e.g., "Alice")
            if (!string.IsNullOrEmpty(value)) // Basic validation: name cannot be empty
            {
                _name = value; // Update the private field
            }
            else
            {
                Console.WriteLine("Player name cannot be empty.");
            }
        }
    }

    // Property for Health (Read-only from outside)
    public int Health
    {
        get { return _health; }
        // No 'set' accessor means health cannot be directly changed from outside
        // It can only be changed by methods within the class (like TakeDamage)
    }

    // Property for Score (Read-only from outside)
    public int Score
    {
        get { return _score; }
        private set { _score = value; } // 'private set' allows setting only from within the class
    }

    // Example of trying to use private set from outside (will cause error)
    // Player tempPlayer = new Player("Test", 50);
    // tempPlayer.Score = 10; // Error! The property 'Player.Score' cannot be used in this context because the set accessor is inaccessible

    // Methods to modify state internally
    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            _health -= amount;
            if (_health < 0) _health = 0;
            Console.WriteLine($"{Name} took {amount} damage! Health: {_health}");
        }
    }

    public void AddScore(int points)
    {
        if (points > 0)
        {
            Score += points; // Use the 'private set' accessor of the Score property
            Console.WriteLine($"{Name} scored {points} points! Score: {Score}");
        }
    }
}
```

Now, you interact with the properties:

```csharp
Player player1 = new Player("Alice", 100);

Console.WriteLine("Initial Name: " + player1.Name); // Uses 'get' accessor

player1.Name = "Alicia"; // Uses 'set' accessor
Console.WriteLine("New Name: " + player1.Name);

// player1.Health = 150; // Error! Health property has no public 'set' accessor.
player1.TakeDamage(20); // Health is modified internally by the method
Console.WriteLine("Current Health: " + player1.Health); // Uses 'get' accessor

player1.AddScore(50); // Uses the AddScore method, which uses the private 'set' of Score
Console.WriteLine("Current Score: " + player1.Score);
```

Properties are the standard way in C# to expose object data in a controlled and flexible manner, supporting the principle of encapsulation.

## Tutorial: Building a Better `BankAccount`

Let's revisit the `BankAccount` example from the previous tutorial and improve it using `private` fields, a constructor, and properties.

**Objective:** Refactor the `BankAccount` class to use encapsulation principles.

**Prerequisites:** A C# console project. You can modify the `BankApp` project or create a new one.

**Step 1: Refactor `BankAccount.cs` - Fields and Constructor**

Modify `BankAccount.cs`. Make the fields `private` and ensure the constructor initializes them.

```csharp
// BankAccount.cs
using System;

public class BankAccount
{
    // Private fields
    private string _accountNumber;
    private decimal _balance;

    // Constructor
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        _accountNumber = accountNumber; // Assume account number is valid for now

        // Validate initial balance
        if (initialBalance >= 0)
        {
            _balance = initialBalance;
        }
        else
        {
            _balance = 0; // Default to 0 if initial balance is negative
            Console.WriteLine("Initial balance cannot be negative. Setting to 0.");
        }
        Console.WriteLine($"Account {_accountNumber} created with balance: {_balance:C}");
    }

    // Properties and Methods will go here...
}
```

**Step 2: Add Properties**

Add public properties for `AccountNumber` (read-only) and `Balance` (read-only).

```csharp
// BankAccount.cs
public class BankAccount
{
    // ... Fields and Constructor ...

    // Property for AccountNumber (Read-only)
    public string AccountNumber
    {
        get { return _accountNumber; }
    }

    // Property for Balance (Read-only)
    public decimal Balance
    {
        get { return _balance; }
        // No 'set' accessor - balance changes only via Deposit/Withdraw methods
    }

    // Methods will go here...
}
```

**Step 3: Update Methods**

The `Deposit` and `Withdraw` methods already work with the private `_balance` field, so they don't need significant changes, but ensure they use `_balance`.

```csharp
// BankAccount.cs
public class BankAccount
{
    // ... Fields, Constructor, Properties ...

    // Method to deposit funds
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount; // Modify private field
            Console.WriteLine($"Deposited {amount:C}. New balance: {_balance:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    // Method to withdraw funds
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return false;
        }

        if (amount > _balance) // Check against private field
        {
            Console.WriteLine("Insufficient funds.");
            return false;
        }

        _balance -= amount; // Modify private field
        Console.WriteLine($"Withdrew {amount:C}. New balance: {_balance:C}");
        return true;
    }
}
```

**Step 4: Test in `Program.cs`**

The code in `Program.cs` to *use* the `BankAccount` class remains largely the same, as it was already interacting via the constructor, methods, and (now) properties.

```csharp
// Program.cs (Should still work as before)
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Simple Bank!");

        BankAccount myAccount = new BankAccount("ACC12345", 100.00m);
        BankAccount invalidAccount = new BankAccount("ACC67890", -50.00m); // Test negative initial balance

        Console.WriteLine($"Account Holder: {myAccount.AccountNumber}"); // Uses property
        Console.WriteLine($"Initial Balance: {myAccount.Balance:C}"); // Uses property

        Console.WriteLine($"\n--- Transactions for {myAccount.AccountNumber} ---");
        myAccount.Deposit(50.50m);
        myAccount.Withdraw(30.00m);
        myAccount.Withdraw(200.00m);
        myAccount.Deposit(-10.00m);

        Console.WriteLine("\n--- Final Status ---");
        Console.WriteLine($"Final Balance for {myAccount.AccountNumber}: {myAccount.Balance:C}");
        Console.WriteLine($"Final Balance for {invalidAccount.AccountNumber}: {invalidAccount.Balance:C}");
    }
}
```

**Step 5: Build and Run**

Save both files, build (`dotnet build`), and run (`dotnet run`). Verify the output, including the handling of the negative initial balance.

**Expected Output:**

```
Welcome to Simple Bank!
Account ACC12345 created with balance: $100.00
Initial balance cannot be negative. Setting to 0.
Account ACC67890 created with balance: $0.00
Account Holder: ACC12345
Initial Balance: $100.00

--- Transactions for ACC12345 ---
Deposited $50.50. New balance: $150.50
Withdrew $30.00. New balance: $120.50
Insufficient funds.
Deposit amount must be positive.

--- Final Status ---
Final Balance for ACC12345: $120.50
Final Balance for ACC67890: $0.00
```

This tutorial demonstrated how to refactor a class to use `private` fields, a constructor for initialization, and `public` properties for controlled access, adhering to the principle of encapsulation.

## Exercise: Refactor the `Product` Class

Let's apply these concepts to the `Product` class from the previous exercises.

**Project Goal:** Refactor the `Product` class to use private fields, a constructor, and public properties with appropriate access control.

**Requirements:**

1.  Start with the `Product` class and `Program.cs` from the previous exercises.
2.  Modify the `Product` class:
    *   Change all fields (`_productId`, `_name`, `_price`, `_quantityInStock`) to be `private` (use the `_` prefix convention).
    *   Ensure the constructor correctly initializes these private fields.
    *   Replace the public fields with **public properties** (`ProductId`, `Name`, `Price`, `QuantityInStock`).
    *   `ProductId` and `Name` should be read-only after creation (only `get` accessor).
    *   `Price` should be read/write, but the `set` accessor should prevent setting a negative price (if negative, maybe default to 0 or keep the old price and print a warning).
    *   `QuantityInStock` should be read-only from outside, but you should add a public method `UpdateStock(int change)` that modifies the private `_quantityInStock` field (allow positive or negative changes, but perhaps prevent stock going below zero).
3.  Modify the `DisplayProductDetails()` method to use the properties (e.g., `Console.WriteLine("Name: " + Name);`).
4.  Modify `Program.cs`:
    *   Ensure it uses the constructor to create `Product` objects.
    *   Ensure it uses properties (e.g., `product1.Price`) instead of fields to access data.
    *   Try setting an invalid price (e.g., `product1.Price = -10;`) and see if your validation works.
    *   Call the new `UpdateStock()` method.
    *   Call `DisplayProductDetails()` to see the final state.

**Hints:**

*   Property with validation in `set`: `public decimal Price { get { return _price; } set { if (value >= 0) _price = value; else Console.WriteLine("Price cannot be negative."); } }`
*   Method to update stock: `public void UpdateStock(int change) { /* add logic here */ }`

**Steps:**

1.  Refactor `Product.cs` with private fields, constructor, properties (with validation), and the `UpdateStock` method.
2.  Update `Program.cs` to use the constructor and properties/methods.
3.  Save, build, and run.
4.  Test creating products, setting an invalid price, updating stock, and displaying details.

## Conclusion

This lesson significantly improved our class design by introducing encapsulation using `private` fields and `public` properties. We learned how constructors ensure proper object initialization and how properties (`get`/`set` accessors) provide controlled access to an object's state, allowing for validation and flexibility. These techniques are crucial for building robust, maintainable object-oriented applications in C#.
