---
title: "Introduction to Programming and C#"
date: 2025-05-02 10:52:38 +1000
tags: [C#, Programming, Beginner, Basics, .NET, Beginner]
categories: [C# Fundamentals, Introduction]
comments: true
---

Welcome to the very first step in our C# learning journey! If you've never programmed before, or if C# is your first programming language, you're in exactly the right place. This post covers the absolute basics: what programming means, how computers understand instructions, and how C# and its helper, the .NET platform, work together to bring your code to life. We'll finish by creating your very first program!

## Lesson: Understanding the Basics

### What is Programming?

<figure style="text-align: center;">
  <img src="/assets/img/2025-05-02.webp" alt="It's like writing recipes for the computer" style="height: 300px">
</figure>

Think of programming like writing a very detailed recipe for a computer. A computer program is just a list of instructions that tell the computer exactly what to do, step by step, to achieve a goal. The computer's main processor (the CPU) reads and follows these instructions one after another.


For instance, a simple program might have steps like:

1.  Show a small window on the screen.
2.  Put a button inside that window.
3.  Wait for someone to click the button.
4.  When clicked, show a message like "Hello!".

Every app you use, from your phone's calculator to complex games, is built from sequences of instructions like these.

### Machine Code: The Computer's Real Language

Computers don't understand English or C#. They speak a language called **machine code**, which is made up entirely of binary numbers (0s and 1s). Each pattern of 0s and 1s tells the CPU to do one tiny thing, like adding two numbers or storing a piece of information.

Writing programs directly in machine code is extremely difficult and slow for humans. Imagine trying to write a simple message using only 0s and 1s – it would take forever and be very easy to make mistakes!

### High-Level Languages: Making Programming Easier

This is why we use **high-level programming languages** like C#. They use words and symbols that are much closer to human language, making it easier for us to write, read, and fix code. C# uses keywords like `if`, `while`, `class`, and symbols like `+`, `-`, `{`, `}`.

But since the computer only understands machine code, we need a translator. That's where special tools called compilers and runtimes come in.

### The .NET Platform: C#'s Essential Toolkit

C# doesn't operate alone; it's part of a bigger system called the **.NET platform** (you might hear older terms like .NET Framework or newer ones like .NET Core or just .NET 6/7/8...). Think of .NET as a toolbox and workshop that provides everything needed to build, translate, and run C# programs.

.NET uses a two-step process to run your C# code:

1.  **The C# Compiler:** When you build your C# project (using a tool like Visual Studio Code or the command line), the compiler reads your C# code files (ending in `.cs`). It translates them into an intermediate language called **Common Intermediate Language (CIL)**. This CIL code is like a halfway point – it's not machine code yet, but it's closer to it than C# is. This CIL is stored in files like `.exe` (executable programs) or `.dll` (libraries of code).

2.  **The .NET Runtime (Common Language Runtime - CLR):** When you actually run your program, the .NET Runtime takes over. It contains another translator called the **Just-In-Time (JIT) compiler**. The JIT compiler reads the CIL code and, right at that moment ('just in time'), translates it into the specific machine code for the exact computer it's running on. The CLR then manages the execution of this machine code, taking care of things like managing memory and ensuring security.

This two-step process is clever because it means C# code compiled once can often run on different types of computers (Windows, Mac, Linux) as long as they have the correct .NET Runtime installed. The final translation to machine code happens right when it's needed.

### Summary of the Process

1.  **Write:** You write C# code in `.cs` files using a text editor.
2.  **Compile:** You use the C# compiler (e.g., via `dotnet build`) to translate `.cs` files into CIL (`.exe` or `.dll`).
3.  **Run:** You execute the program (e.g., via `dotnet run`). The .NET Runtime's JIT compiler translates CIL into machine code, which the CPU then executes.

Understanding these basic ideas – programming as instructions, machine code vs. high-level languages, and the role of the compiler and runtime – gives you a solid foundation for learning C#!

## Tutorial: Your First C# Program - "Hello World!"

Let's get our hands dirty and create the traditional first program: "Hello World!". This simple exercise confirms your tools are set up correctly and shows the basic steps of creating and running C# code.

**Objective:** Create a C# program that prints the message "Hello World!" to your computer's command line (terminal).

**Tools Needed:**

* A **Terminal** (like Command Prompt or PowerShell on Windows, or Terminal on macOS/Linux).

* The **.NET SDK** (Software Development Kit). Make sure it's installed!
  Open your terminal and type `dotnet --version`. If you see a version number, you're good to go.
  - [Linux](https://splashkit.io/installation/linux/)
  - [MacOS](https://splashkit.io/installation/macos/)
  - [Windows](https://splashkit.io/installation/windows-msys2/)

* A **Text Editor**. Visual Studio Code (VS Code) is a great free option.
  - [Download VS Code](https://code.visualstudio.com/Download)


**Step 1: Create a Project Folder**

Open your terminal. Navigate to a place where you like to keep your projects (like your Documents folder). Create a new folder for this project and go inside it.

```bash
# Example: Go to your Documents folder
cd Documents

# Create a folder named HelloWorld
mkdir HelloWorld

# Go inside the HelloWorld folder
cd HelloWorld
```
*Tip: It's often easier to use folder names without spaces when working with terminals.*

**Step 2: Create a New C# Console Project**

While inside the `HelloWorld` folder in your terminal, use this command:

```bash
dotnet new console
```
This command uses the .NET SDK to create the basic files for a simple command-line program:
*   `HelloWorld.csproj`: A project file with settings.
*   `Program.cs`: The C# code file. This is where we'll write our instructions.

**Step 3: Open the Project in VS Code**

Open VS Code. Go to `File > Open Folder...` and select the `HelloWorld` folder you just created.

*If VS Code suggests installing extensions for C#, it's a good idea to accept – they help with writing C# code.*

**Step 4: Look at `Program.cs`**

In VS Code's file explorer panel on the left, find and click on `Program.cs`. You'll see some starting code. Depending on your .NET version, it might look very simple:

```csharp
// Simpler template in newer .NET versions
Console.WriteLine("Hello, World!");
```

Or it might look slightly more structured (older versions):

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

Don't worry too much about the differences right now! The key instruction is:

`Console.WriteLine("Hello, World!");`

*   `Console`: Represents the terminal window.
*   `WriteLine`: A command (called a *method* - a reusable block of code) that tells the Console to print text.
*   `("Hello, World!")`: The text to be printed.
*   `;`: Marks the end of the instruction in C#.

You can add more instructions!

`Console.WriteLine("Programming is fun!");`

**Step 5: Save the File**

If you made any changes (or even if not, just to be sure), save the file (Ctrl+S on Windows/Linux, Cmd+S on macOS).

**Step 6: Build the Project**

Go back to your terminal (make sure you're still inside the `HelloWorld` folder). Type:

```bash
dotnet build
```
This tells the C# compiler to check your code for errors and translate it into the intermediate language (CIL).

**Step 7: Run the Program**

Now, run the program:

```bash
dotnet run
```

**Expected Output:**

You should see this printed in your terminal:

```
Hello World!
```

**Congratulations!** You've just created, built, and run your first C# program!

**Development Workflow Summary:**

1.  **Write/Edit Code:** Change `.cs` files in your editor.
2.  **Save:** Save your changes.
3.  **Build:** Run `dotnet build` in the terminal (compiles code).
4.  **Run:** Run `dotnet run` in the terminal (executes the program).

You'll repeat this Write-Save-Build-Run cycle often!

## Exercises: Your First Program Modification

Now that you can run "Hello World!", let's change it to print something different.

**Project Goal:** Modify the program to print a short, multi-line introduction about yourself or some simple text art (ASCII art).

**Requirements:**

1.  Use the `HelloWorld` project.
2.  Edit `Program.cs`.
3.  Use multiple `Console.WriteLine()` instructions.
4.  Print at least 3 lines of text.

**Example Ideas:**

*   Introduction:
    ```csharp
    Console.WriteLine("My name is [Your Name].");
    Console.WriteLine("I am learning C#!");
    Console.WriteLine("This is fun!");
    ```
*   Simple ASCII Art:
    ```csharp
    Console.WriteLine(" * ");
    Console.WriteLine("***");
    Console.WriteLine("*****");
    ```

**Steps:**

1.  Open `Program.cs` in VS Code.
2.  Replace or add `Console.WriteLine()` lines with your desired text.
3.  Save the file.
4.  In the terminal, run `dotnet build`.
5.  Then run `dotnet run`.T
6.  See your new output!

## Conclusion

In this first beginner post, we learned what programming is, how C# code gets turned into instructions a computer understands using the .NET platform, and how to create, build, and run a basic "Hello World!" program. You also practiced modifying the code to print your own message. Great start! In the next post, we'll learn how to store information in our programs using variables.
