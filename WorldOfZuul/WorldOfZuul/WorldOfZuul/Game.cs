using System.Security.Cryptography;
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

              string[] lines = {
            "+====+",
            "|(::)|",
            "| )( |",
            "|(  )|",
            "+====+",
            "In the shadow of a dying Earth, where rivers run dry and the sky chokes with ash, humanity stands at the brink of extinction. "
            };
              Map.CenterText(lines);
              Thread.Sleep(5000);
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
              Thread.Sleep(5000);
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
              Thread.Sleep(5000);
              Console.Clear();

              lines = new string[] {
            @"________                       .__     /\                                      __",
            @"\______ \ _____ _________  _  _|__| ___)/  ______   ________ __  ____   ______/  |_ ",
            @" |    |  \\__  \\_  __ \ \/ \/ /  |/    \ /  ___/  / ____/  |  \/ __ \ /  ___|   __\",
            @" |    `   \/ __ \|  | \/\     /|  |   |  \\___ \  < <_|  |  |  |  ___/ \___ \ |  |  ",
            @"/_______  (____  /__|    \/\_/ |__|___|  /____  >  \__   |____/ \___  >____  >|__|  ",
            @"        \/     \/                      \/     \/      |__|          \/     \/       "
            };
                
             Map.CenterText(lines);
        

           // PrintHelp();q


            
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You are lost. You are alone. You wander");
            Console.WriteLine("around the university.");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}
