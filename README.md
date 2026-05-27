# KeyArrowMenu

A lightweight, reusable arrow-key menu for C# console applications.  
Drop in one file. No dependencies.

---

## Usage

```csharp
new ConsoleMenu
{
    Title = "My Program"
}
.Add("Option 1", () => Console.WriteLine("Hello!"))
.Add("Option 2", MyMethod)
.AddExit("Exit")
.Show();
```

## Controls

| Key       | Action          |
|-----------|-----------------|
| ↑ / ↓    | Navigate        |
| Enter     | Select          |
| ESC       | Close           |

## Configuration

```csharp
new ConsoleMenu
{
    Title               = "My Program",
    HighlightBackground = ConsoleColor.DarkBlue,
    HighlightForeground = ConsoleColor.White,
    AutoReturn          = true   // skip "press any key" after action
}
```

## Setup

Copy `ConsoleMenu.cs` into your project — done.
