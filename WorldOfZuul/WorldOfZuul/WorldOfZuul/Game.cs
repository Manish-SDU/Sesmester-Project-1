using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MapAndCenter;

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
            var newMap = new Map();  //making an instance of the map is neccecary
            newMap.CurrentRoomName = "Era2Corals";  //WHEN SWITCHING ROOMS PLEASE DEFINE IT AS HERE!

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                Console.WriteLine(currentRoom?.ShortDescription);
                Console.Write("> ");

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

                switch(command.Name)
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

                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "map":
                        //string CurrentRoom = RoomNow;
                         //string CurrentRoomName= "Era1";
                         Map.DisplayMap(newMap.CurrentRoomName);
                         break;

                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing World of Zuul!");
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
    
    // Set a fixed console window size (you may adjust as necessary)
    Console.SetWindowSize(100, 40); // Width, Height

    string[][] welcomeMessages = {
        new string[]
        {
            "+====+",
            "|(::)|",
            "| )( |",
            "|(  )|",
            "+====+",
            "In the shadow of a dying Earth, where rivers run dry and the sky chokes with ash, humanity stands at the brink of extinction."
        },
        new string[]
        {
            "+====+",
            "|(..)|",
            "| )( |",
            "|(..)|",
            "+====+",
            "A secret, ancient technology, lost to time, is unearthed — a gateway to the past."
        },
        new string[]
        {
            "+====+",
            "|(  )|",
            "| )( |",
            "|(::)|",
            "+====+",
            "Only by traveling through the forgotten eras of human history can you rewrite the mistakes that brought the world to its knees, and restore balance before it’s too late."
        }
    };

    // Loop through the welcome messages and print each one
    foreach (var lines in welcomeMessages)
    {
        Map.CenterText(lines);
        Console.WriteLine("\n\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    // ASCII art lines with dollar signs
    string[] asciiArtLines = new string[]
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

    // Center the ASCII art lines and print with green dollar signs
    foreach (var line in asciiArtLines)
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

        // Avoid adding an extra newline; use Write instead of WriteLine
        Console.Write("\r");
    }
    
    // Wait for user input before finishing
    Console.WriteLine("\n\nPress any key to exit...");
    Console.ReadKey();
}
        PrintHelp();
    }

        private static void PrintHelp()
        {   
            Console.WriteLine("Blah blah blah game text");
            Console.WriteLine("we'll add more text here as we go just testing the map");
            Console.WriteLine();
           // Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
           // Console.WriteLine("Type 'look' for more details.");
           // Console.WriteLine("Type 'back' to go to the previous room.");
           // Console.WriteLine("Type 'help' to print this message again.");
           // Console.WriteLine("Type 'quit' to exit the game."); 
            

        }
    }
}
