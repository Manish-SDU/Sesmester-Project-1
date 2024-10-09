using System;

namespace MapAndCenter
{
    public class ScreenCentering
    {
        public static void DisplayCenteredMessage(string message)
        {
            // Get the console width and calculate the starting position for centering
            int consoleWidth = Console.WindowWidth;
            int messageLength = message.Length;
            int spaces = (consoleWidth - messageLength) / 2;

            // Print spaces to center the message
            Console.WriteLine(new string(' ', spaces) + message);
        }

        public static void DisplayCenteredAscii(string[] lines, char userInput)
        {
            // Color and centering of the characters
            foreach (var line in lines)
            {
                // Calculate the padding for centering
                int totalWidth = Console.WindowWidth;
                int lineLength = line.Length;
                int spacesToPad = Math.Max((totalWidth - lineLength) / 2, 0);
                
                // Print leading spaces for centering
                Console.Write(new string(' ', spacesToPad));
                
                // Print the line with colored characters
                foreach (char i in line)
                {
                    switch (i)
                    {
                        case '$':
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.Write(i); 
                            break;
                        case '@':
                            Console.ForegroundColor = ConsoleColor.Gray; 
                            Console.Write(i); 
                            break;
                        case ':':
                            Console.ForegroundColor = ConsoleColor.Yellow; 
                            Console.Write(i); 
                            break;
                        case '*':
                            Console.ForegroundColor = ConsoleColor.DarkGray; 
                            Console.Write(i); 
                            break;
                        default:
                            Console.ResetColor(); 
                            Console.Write(i); 
                            break;
                    }
                }
                
                // Reset color for the next line
                Console.ResetColor();
                
                // Move to the next line after printing the current line or use "\r" based on user input
                if (userInput == 's' || userInput == 'S') // Check if user pressed 's' or 'S' for Tablet display
                {
                    Console.Write("\r"); // Overwrite the current line
                }
                else
                {
                    Console.WriteLine(); // Move to the next line
                }
            }
        }
    }
}