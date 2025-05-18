---
title: "🎮 Advanced Control Flow in C# - Part 3"
date: 2025-05-06 08:50:17 +1000
tags: [C#, Programming, Control Flow, Loops, Switch, Break, Continue, Return, Advanced]
categories: [C# Fundamentals]
comments: true
---

Having mastered basic decisions (`if-else`), multiple choices (`switch`), and fundamental loops (`while`, `do-while`) in the previous lessons, we now delve into more advanced techniques and considerations for controlling program execution flow in C#.

This lesson covers:
*   Fine-tuning loop behavior with `break` and `continue`.
*   Understanding the scope and impact of `return` within loops and methods.
*   Briefly introducing the `for` loop (a common loop structure not explicitly detailed in the source notes but essential for C#).
*   Nested control structures.
*   (Mention) Advanced `switch` features like pattern matching (though detailed implementation might be beyond initial notes).

**(Prerequisites: Ensure you understand the concepts from "Control Flow - Beginner" and "Intermediate".)**

## Lesson: Precise Control and Structure

### Mastering Loop Control: `break` and `continue`

While loops execute based on their condition, sometimes you need finer control *within* the loop's execution.

*   **`break`:** As seen in `switch` statements, `break` can also be used inside loops (`while`, `do-while`, `for`, `foreach`). When encountered, it **immediately terminates the innermost loop** it resides in. Execution continues with the first statement *after* the terminated loop.

    ```csharp
    // Example: Find the first multiple of 7
    int number = 1;
    while (true) // Potentially infinite loop!
    {
        if (number % 7 == 0)
        {
            Console.WriteLine($"Found first multiple of 7: {number}");
            break; // Exit the while loop
        }
        number++;
        if (number > 100) // Safety break to prevent actual infinite loop
        {
             Console.WriteLine("Reached limit without finding multiple.");
             break;
        }
    }
    // Execution continues here after break
    Console.WriteLine("Loop finished.");
    ```

*   **`continue`:** This statement doesn't exit the loop entirely. Instead, it **skips the rest of the current iteration** and jumps directly to the loop's condition check (for `while`, `do-while`) or the update step (for `for` loops) to start the next iteration.

    ```csharp
    // Example: Print only odd numbers up to 10
    int i = 0;
    while (i < 10)
    {
        i++;
        if (i % 2 == 0) // Is 'i' even?
        {
            continue; // Skip the Console.WriteLine for even numbers
        }
        // This line is skipped if 'continue' was executed
        Console.WriteLine($"Odd number: {i}");
    }
    ```

`break` and `continue` provide powerful ways to handle special cases or exit conditions within loops without complex nested `if` statements.

### The Scope of `return`

Remember that `return` exits the *entire method* it is in, not just a loop or `switch` statement. If a `return` statement is executed inside a loop, the loop terminates immediately, and control goes back to wherever the method was called from.

```csharp
public static bool FindValue(int[] data, int valueToFind)
{
    int index = 0;
    while (index < data.Length)
    {
        if (data[index] == valueToFind)
        {
            Console.WriteLine($"Value found at index {index}.");
            return true; // Exit the FindValue method immediately
        }
        index++;
    }
    // This part is only reached if the loop finishes without finding the value
    Console.WriteLine("Value not found.");
    return false; // Exit the FindValue method
}
```

### The `for` Loop: Structured Iteration

While the provided notes focus on `while` and `do-while`, another extremely common and often more structured loop in C# is the `for` loop. It's particularly useful when you know how many times you want to iterate or when you need an iterator variable that changes predictably.

```csharp
// Syntax:
// for (initializer; condition; iterator)
// {
//     Loop body
// }

// Example: Count from 0 to 4
Console.WriteLine("Using a for loop:");
for (int i = 0; i < 5; i++) // 1. Initialize i=0; 2. Check i<5; 4. Increment i++
{
    // 3. Execute loop body
    Console.WriteLine("i is now: " + i);
}
// Loop finishes when i < 5 becomes false

// Output:
// Using a for loop:
// i is now: 0
// i is now: 1
// i is now: 2
// i is now: 3
// i is now: 4
```

**How it works:**
1.  **Initializer (`int i = 0;`):** Runs *once* at the very beginning. Typically declares and initializes a loop counter.
2.  **Condition (`i < 5;`):** Checked *before* each iteration (like `while`). If true, the loop body runs. If false, the loop terminates.
3.  **Loop Body (`{...}`):** Executes if the condition is true.
4.  **Iterator (`i++`):** Runs *after* each execution of the loop body. Typically updates the loop counter.

The `for` loop neatly packages the initialization, condition check, and iteration update into one line, making it very clear for standard counting loops.

### Nested Control Structures

You can place loops inside other loops, `if` statements inside loops, loops inside `if` statements, etc. This is called **nesting**.

```csharp
// Example: Print a small multiplication table (nested for loops)
for (int row = 1; row <= 3; row++)
{
    Console.Write($"Row {row}: ");
    for (int col = 1; col <= 3; col++)
    {
        Console.Write($" {row * col} "); // Inner loop runs completely for each outer loop iteration
    }
    Console.WriteLine(); // Move to next line after inner loop finishes
}

// Output:
// Row 1:  1  2  3
// Row 2:  2  4  6
// Row 3:  3  6  9
```

When nesting, be mindful of how `break` and `continue` work – they only affect the *innermost* loop they are inside.

### Advanced `switch` (Pattern Matching - Mention)

Modern C# versions have significantly enhanced the `switch` statement (and introduced `switch` expressions) with **pattern matching**. This allows you to switch not just on constant values but also on types, property values, and other patterns. While a deep dive is beyond this scope, be aware that `switch` is more powerful than just comparing constants.

```csharp
// Conceptual Example (Syntax might vary slightly by C# version)
object shape = GetSomeShape();

switch (shape)
{
    case Circle c when c.Radius > 10:
        Console.WriteLine("Large circle");
        break;
    case Circle c:
        Console.WriteLine("Small circle");
        break;
    case Square s:
        Console.WriteLine("Square");
        break;
    case null:
        Console.WriteLine("Shape is null");
        break;
    default:
        Console.WriteLine("Unknown shape");
        break;
}
```

## Tutorial: Prime Number Checker

Let's write a program to check if a number is prime, using nested loops and `break`.

**Objective:** Practice using loops, `if` conditions, and the `break` statement for efficiency.

**Definition:** A prime number is a whole number greater than 1 that has only two divisors: 1 and itself. (e.g., 2, 3, 5, 7, 11...)

**Logic:** To check if a number `n` is prime, we can try dividing it by all numbers from 2 up to the square root of `n`. If we find *any* number that divides `n` evenly (remainder is 0), then `n` is not prime, and we can stop checking.

**Prerequisites:** A C# console project.

**Step 1: Get User Input**

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter a whole number greater than 1: ");
        string input = Console.ReadLine();
        int number;

        if (!int.TryParse(input, out number) || number <= 1)
        {
            Console.WriteLine("Invalid input. Please enter a whole number greater than 1.");
            return; // Exit the Main method
        }

        // Prime checking logic goes here
    }
}
```

**Step 2: Implement Prime Check Logic**

We'll assume the number is prime initially and use a loop to try and prove it's not.

```csharp
    // ... inside Main, after input validation ...
    bool isPrime = true; // Assume it's prime until proven otherwise

    // Loop from 2 up to the square root of the number
    // (Checking beyond the square root is redundant)
    for (int divisor = 2; divisor * divisor <= number; divisor++)
    {
        // Check if 'number' is perfectly divisible by 'divisor'
        if (number % divisor == 0)
        {
            isPrime = false; // Found a divisor, so it's not prime
            Console.WriteLine($"{number} is divisible by {divisor}.");
            break; // Exit the loop - no need to check further divisors
        }
    }

    // Step 3: Display the result (outside the loop)
    if (isPrime)
    {
        Console.WriteLine($"{number} is a prime number.");
    }
    else
    {
        Console.WriteLine($"{number} is not a prime number.");
    }
}
```
*Explanation: We initialize `isPrime` to `true`. The `for` loop iterates through potential divisors. `divisor * divisor <= number` is an efficient way to check up to the square root. If `number % divisor == 0` is true, we find a divisor, set `isPrime` to `false`, print why, and use `break` to exit the loop early because we already know the answer. If the loop finishes without finding any divisors (i.e., `break` was never hit), `isPrime` remains `true`.*

**Step 3: Build and Run**

1.  Save `Program.cs`.
2.  Build (`dotnet build`) and run (`dotnet run`).
3.  Test with prime numbers (e.g., 2, 3, 7, 11, 13, 101) and non-prime numbers (e.g., 4, 6, 9, 10, 100).

**Example Interaction (Prime):**

```
Enter a whole number greater than 1: 13
13 is a prime number.
```

**Example Interaction (Not Prime):**

```
Enter a whole number greater than 1: 12
12 is divisible by 2.
12 is not a prime number.
```

## Exercise: Text Analysis

Create a program that analyzes a piece of text entered by the user to count vowels, consonants, and digits.

**Project Goal:** Practice using loops (`for` or `while`), `if-else if-else` or `switch`, and `continue`.

**Requirements:**

1.  Create a new console project.
2.  Prompt the user to enter a line of text.
3.  Read the input string.
4.  Initialize counters for vowels, consonants, and digits to zero.
5.  Use a loop to iterate through each character in the input string.
6.  Inside the loop, for each character:
    *   Convert the character to lowercase for easier comparison (e.g., `char lowerChar = char.ToLower(currentChar);`).
    *   Use `if-else if-else` or a `switch` statement to check the character:
        *   If it's a vowel ('a', 'e', 'i', 'o', 'u'), increment the vowel counter.
        *   If it's a digit ('0' through '9'), increment the digit counter. (Hint: `char.IsDigit(currentChar)` is useful).
        *   If it's a letter but not a vowel, increment the consonant counter. (Hint: `char.IsLetter(currentChar)` is useful).
        *   If it's none of the above (e.g., punctuation, space), you can either ignore it or use `continue` to skip to the next character immediately.
7.  After the loop finishes, print the final counts for vowels, consonants, and digits.

**Hints:**

*   You can loop through a string using a `for` loop: `for (int i = 0; i < inputText.Length; i++) { char currentChar = inputText[i]; ... }`
*   Or using a `foreach` loop: `foreach (char currentChar in inputText) { ... }`
*   `char.ToLower(c)` converts a character `c` to lowercase.
*   `char.IsDigit(c)` returns `true` if `c` is '0'-'9'.
*   `char.IsLetter(c)` returns `true` if `c` is a letter.

**Steps:**

1.  Write the code in `Program.cs`.
2.  Save, build, and run.
3.  Test with various inputs containing letters, numbers, spaces, and punctuation (e.g., "Hello World 123!").

## Conclusion

This lesson covered techniques for more precise control within loops (`break`, `continue`), the scope of `return`, the common `for` loop structure, and the concept of nesting control structures. Understanding these allows you to write more efficient and targeted logic for handling complex conditions and repetitions. While modern C# offers even more advanced control flow features (like pattern matching), mastering these fundamentals provides a very strong foundation.
