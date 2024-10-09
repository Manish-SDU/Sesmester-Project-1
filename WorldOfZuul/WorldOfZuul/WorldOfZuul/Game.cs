using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;
using Eras;

namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            Room? outside = new("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Room? theatre = new("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Room? pub = new("Pub", "You've entered the campus pub. It's a cozy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Room? lab = new("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Room? office = new("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");

            outside.SetExits(null, theatre, lab, pub); // North, East, South, West
            theatre.SetExit("west", outside);
            pub.SetExit("east", outside);
            lab.SetExits(outside, office, null, null);
            office.SetExit("west", lab);

            currentRoom = outside;
        }

        public void Play()
        {
            Parser parser = new();
            var newMap = new Map();  // Making an instance of the map is necessary
             // WHEN SWITCHING ROOMS PLEASE DEFINE IT AS HERE!

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                //Console.WriteLine(currentRoom?.ShortDescription);
               // Console.Write("> ");

               newMap.CurrentRoomName = "Era1";
               Era1.PlayEra1();

                string? input = Console.ReadLine();


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    Console.WriteLine("I don't know that command.");
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom?.LongDescription);
                        break;

                    case "back":
                        if (previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentRoom = previousRoom;
                        break;

                    /*case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break; */


                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "map":
                        // string CurrentRoom = RoomNow;
                        // string CurrentRoomName= "Era1";
                        Map.DisplayMap(newMap.CurrentRoomName);
                        break;

                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Darwin's quest!");
        }

        private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }

        private static void PrintWelcome()
        {
            Console.Clear();

            string[] lines = {
                "+====+",
                "|(::)|",
                "| )( |",
                "|(  )|",
                "+====+",
                "In the shadow of a dying Earth, where rivers run dry and the sky chokes with ash, humanity stands at the brink of extinction."
            };
            Map.CenterText(lines);

            // Wait for user input
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey(); // Wait for a key press
            Console.Clear();

            lines = new string[] {
                "+====+",
                "|(..)|",
                "| )( |",
                "|(..)|",
                "+====+",
                "A secret, ancient technology, lost to time, is unearthed — a gateway to the past."
            };
            Map.CenterText(lines);

            // Wait for user input
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey(); // Wait for a key press
            Console.Clear();

            lines = new string[] {
                "+====+",
                "|(  )|",
                "| )( |",
                "|(::)|",
                "+====+",
                "Only by traveling through the forgotten eras of human history can you rewrite the mistakes that brought the world to its knees, and restore balance before it’s too late."
            };
            Map.CenterText(lines);

            // Wait for user input
            /* 
               Manish: Ask the user if they want to use the "s" option for Tablet display - Like a Surface Pro (My Computer)
               This logic is primarily for my own use so I can view the game on my computer.
               If I remove this logic, all the ASCII art becomes misaligned and disoriented on my computer. 
            */

            Console.WriteLine("\n\n\n\n");

            // Set color for the prompt message
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Message to display
            string message = "Press 's' for small devices like tablets (e.g., Microsoft Surface) or any other key for larger devices like laptops:";

            // Get the console width and calculate the starting position for centering
            int consoleWidth = Console.WindowWidth;
            int messageLength = message.Length;
            int spaces = (consoleWidth - messageLength) / 2;

            // Print spaces to center the message
            Console.WriteLine(new string(' ', spaces) + message);

            Console.ResetColor(); // Reset color to default

            // Capture user input without displaying it
            char userInput = Console.ReadKey(true).KeyChar;
            Console.WriteLine(); // Move to the next line for better formatting
            Console.Clear(); // Clear the console

            // ASCII art lines with dollar signs
            lines = new string[]
            {
                @"           ::                                                                                                                             ::            ",
                @"           ::                                                                                                                             ::**@@@@@     ",
                @"           ::                                                                                                                             ::*@@@@@@@    ",
                @"           ::                                                                                                                             ::*@@@@@@@    ",
                @"    *@@@@@@::                                                                                                                             ::@@@@@@      ",
                @"   *@@@@@@@:: $$$$$$$\                                    $$\         $$\                $$$$$$\                                  $$\     ::@@@@@       ",
                @"   @@@@ **@:: $$  __$$\                                   \__|        $  |              $$  __$$\                                 $$ |    ::@@@@@@*     ",
                @"   *@@  *@@:: $$ |  $$ | $$$$$$\   $$$$$$\  $$\  $$\  $$\ $$\ $$$$$$$\\_/$$$$$$$\       $$ /  $$ |$$\   $$\  $$$$$$\   $$$$$$$\ $$$$$$\   ::@@@**@@@@   ",
                @"       *@@@:: $$ |  $$ | \____$$\ $$  __$$\ $$ | $$ | $$ |$$ |$$  __$$\ $$  _____|      $$ |  $$ |$$ |  $$ |$$  __$$\ $$  _____|\_$$  _|  ::@@   *@@@@@ ",
                @"**     @@@@:: $$ |  $$ | $$$$$$$ |$$ |  \__|$$ | $$ | $$ |$$ |$$ |  $$ |\$$$$$$\        $$ |  $$ |$$ |  $$ |$$$$$$$$ |\$$$$$$\    $$ |    ::@       *** ",
                @"@@@ *@@@@@@:: $$ |  $$ |$$  __$$ |$$ |      $$ | $$ | $$ |$$ |$$ |  $$ | \____$$\       $$ $$\$$ |$$ |  $$ |$$   ____| \____$$\   $$ |$$\ ::@**         ",
                @"*@@@@@@@ @@:: $$$$$$$  |\$$$$$$$ |$$ |      \$$$$$\$$$$  |$$ |$$ |  $$ |$$$$$$$  |      \$$$$$$ / \$$$$$$  |\$$$$$$$\ $$$$$$$  |  \$$$$  |::@@@@*       ",
                @" *@@@@@  *@:: \_______/  \_______|\__|       \_____\____/ \__|\__|  \__|\_______/        \___$$$\  \______/  \_______|\_______/    \____/ ::@@@*        ",
                @"  **@@     ::                                                                                \___|                                        ::@*          ",
                @"           ::                                                                                                                             :@*           ",
                @"           ::                                                                                                                             ::*           ",
                @"                                                                                                                                                        ",
                @"                                                                                                                                                        ",                                                                                
            };

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

            PrintHelp();
        }

        private static void PrintHelp()
        {   

        string[] lines = {
                "This will be a quick intro to the commands a player must use",
                "",
                "Press any key to continue!"
        };
            Map.CenterText(lines);
            Console.ReadLine();
            Console.Clear();
            
            // Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            // Console.WriteLine("Type 'look' for more details.");
            // Console.WriteLine("Type 'back' to go to the previous room.");
            // Console.WriteLine("Type 'help' to print this message again.");
            // Console.WriteLine("Type 'quit' to exit the game."); 
        }
    }
}