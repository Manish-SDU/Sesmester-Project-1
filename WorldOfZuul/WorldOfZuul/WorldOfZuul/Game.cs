using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;

namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;
        private Portal? portal;

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
            portal = new Portal();
            // WHEN SWITCHING ROOMS PLEASE DEFINE IT AS HERE!

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                // Show the current era instead of the default "Outside"
                Console.WriteLine($"Current Era: {portal.CurrentRoomName}");
                // Console.WriteLine(currentRoom?.ShortDescription);
                // Console.Write("> ");

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
                        break;*/

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "map":
                    // Display the map of the current era
                    Map.DisplayMap(portal.CurrentRoomName);
                    break;

                    case "teleport":
                    // Teleport and change the era
                    portal.Teleport();
                    break;

                    default:
                        Console.WriteLine("I don't know that command.");
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
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
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
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            // Title Display for Tablets or Small Computers
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string message = "Press 's' for small devices like tablets (e.g., Microsoft Surface) or any other key for larger devices like laptops:";

            // Use the new function to center the message
            Console.WriteLine();
            Console.WriteLine();
            ScreenCentering.DisplayCenteredMessage(message);
            Console.ResetColor();

            // Capture user input without displaying it
            char userInput = Console.ReadKey(true).KeyChar;
            Console.WriteLine();
            Console.Clear();

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

            // Use the new function to center ASCII art and handle device display
            ScreenCentering.DisplayCenteredAscii(lines, userInput);

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
            
            // Execute Darwin_Homeworld.cs - Luigi's file
            Darwin_Homeworld darwinHomeworld = new Darwin_Homeworld();
            darwinHomeworld.Enter();

            // Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            // Console.WriteLine("Type 'look' for more details.");
            // Console.WriteLine("Type 'back' to go to the previous room.");
            // Console.WriteLine("Type 'help' to print this message again.");
            // Console.WriteLine("Type 'quit' to exit the game."); 
        }
    }
}