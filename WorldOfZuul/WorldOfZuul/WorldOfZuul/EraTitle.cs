using System;

public class EraTitle
{
    // Method that prints the welcome message in a styled box
    public void Print(string message)
    {
        Console.Clear();

        // Box width includes padding around the text
        int boxWidth = message.Length + 12;
        int consoleWidth = Console.WindowWidth;
        int padding = (consoleWidth - boxWidth) / 2;

        // Borders
        string topBorder = $"╔{new string('═', boxWidth)}╗";
        string bottomBorder = $"╚{new string('═', boxWidth)}╝";
        
        // Borders styles
        Console.WriteLine(new string('\n', 1));
        Console.ForegroundColor = ConsoleColor.DarkYellow; // Color for Box
        Console.WriteLine(topBorder.PadLeft(padding + topBorder.Length)); // Centered
        Console.ForegroundColor = ConsoleColor.DarkCyan; // Color for title

        // Print the message inside the box
        Console.WriteLine($"║    {message}    ║".PadLeft(padding + boxWidth));

        // Print the bottom border of the box
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(bottomBorder.PadLeft(padding + bottomBorder.Length));
        Console.ResetColor();
        Console.WriteLine();
    }
}