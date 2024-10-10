using System;

namespace MapAndCenter
{
    public class Map
    {
        /// <STRING VALUES FOR EACH OF THE ROOMS - please change the note here if you wish to make name changes>
        /// Player's current room value must change EVERY TIME PLAYER CHANGES ROOMS for the map to work
        /// 
        /// Era1
        /// Era2, Era2Bees, Era2Corals
        /// Era3SDU, Era3Cement
        /// 
        /// intro and outro play automatically at the beginning/end and thus are not marked on the map
        /// </summary>
        
        public string CurrentRoomName = " ";

        public static void CenterText(string[] lines)
        {
            int consoleWidth = Console.WindowWidth;

            foreach (string line in lines)
            {
                int padding = (consoleWidth - line.Length) / 2;
                if (padding < 0) padding = 0;

                // If the line contains the '*' symbol, make it green
                int starIndex = line.IndexOf('*');
                if (starIndex != -1)
                {
                    string beforeStar = line.Substring(0, starIndex);
                    string afterStar = line.Substring(starIndex + 1);
                    Console.Write(new string(' ', padding) + beforeStar);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('*');
                    Console.ResetColor();
                    Console.WriteLine(afterStar);
                }
                else
                {
                    // Print the line normally if there's no '*'
                    Console.WriteLine(new string(' ', padding) + line);
                }
            }
        }

        public static void DisplayMap(string CurrentRoomName)
        {
            string[] drawMap = { " " };

            switch (CurrentRoomName)
            {
                case "Era1":
                    drawMap = new string[] {
                        " _________",
                        " |         |",
                        " |  ERA 1  |",
                        " |    *    |",
                        " |_________|",
                        " _________     ___|_|___     _________",
                        " |         |   |         |   |         |",
                        " |         |___|         |___|         |",
                        " |         |___|         |___|         |",
                        " |_________|   |_________|   |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " | |",
                        " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                        " You are in ERA 1"
                    };
                    Map.CenterText(drawMap);
                    break;

                case "Era2":
                    drawMap = new string[] {
                        " _________",
                        " |         |",
                        " |  ERA 1  |",
                        " |         |",
                        " |_________|",
                        " _________     ___|_|___     _________",
                        " |         |   |         |   |         |",
                        " |  BEES   |___|  ERA 2  |___| CORALS  |",
                        " |         |___|    *    |___|         |",
                        " |_________|   |_________|   |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " | |",
                        " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                        " You are in ERA 2 - Main Room"
                    };
                    Map.CenterText(drawMap);
                    break;

                case "Era2Bees":
                    drawMap = new string[] {
                        " _________",
                        " |         |",
                        " |  ERA 1  |",
                        " |         |",
                        " |_________|",
                        " _________     ___|_|___     _________",
                        " |         |   |         |   |         |",
                        " |  BEES   |___|  ERA 2  |___| CORALS  |",
                        " |   *     |___|         |___|         |",
                        " |_________|   |_________|   |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " | |",
                        " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                        " You are in ERA 2 - Save The Bees"
                    };
                    Map.CenterText(drawMap);
                    break;

                case "Era2Corals":
                    drawMap = new string[] {
                        " _________",
                        " |         |",
                        " |  ERA 1  |",
                        " |         |",
                        " |_________|",
                        " _________     ___|_|___     _________",
                        " |         |   |         |   |         |",
                        " |  BEES   |___|  ERA 2  |___| CORALS  |",
                        " |         |___|         |___|    *    |",
                        " |_________|   |_________|   |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " | |",
                        " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                        " You are in ERA 2 - Save The Coral Reefs"
                    };
                    Map.CenterText(drawMap);
                    break;

                case "Era3SDU":
                    drawMap = new string[] {
                        " _________",
                        " |         |",
                        " |  ERA 1  |",
                        " |         |",
                        " |_________|",
                        " _________     ___|_|___     _________",
                        " |         |   |         |   |         |",
                        " |  BEES   |___|  ERA 2  |___| CORALS  |",
                        " |         |___|         |___|         |",
                        " |_________|   |_________|   |_________|",
                        " ___|_|___",
                        " |         |",
                        " |  ERA 3  |",
                        " |   SDU   |",
                        " |____*____|",
                        " ___|_|___",
                        " |         |",
                        " |         |",
                        " |         |",
                        " |_________|",
                        " | |",
                        " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                        " You are in ERA 3 - SDU (Sønderborg)"
                    };
                    Map.CenterText(drawMap);
                    break;

                case "Era3Cement":
                    drawMap = new string[] {
                        " _________",
                        " |         |",
                        " |  ERA 1  |",
                        " |         |",
                        " |_________|",
                        " _________     ___|_|___     _________",
                        " |         |   |         |   |         |",
                        " |  BEES   |___|  ERA 2  |___| CORALS  |",
                        " |         |___|         |___|         |",
                        " |_________|   |_________|   |_________|",
                        " ___|_|___",
                        " |         |",
                        " |  ERA 3  |",
                        " |   SDU   |",
                        " |_________|",
                        " ___|_|___",
                        " |         |",
                        " |  ERA 3  |",
                        " | OUTSIDE |",
                        " |____*____|",
                        " | |",
                        " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
                        " You are in ERA 3 - Outside SDU (Sønderborg)"
                    };
                    Map.CenterText(drawMap);
                    break;
            }
        }
    }
}