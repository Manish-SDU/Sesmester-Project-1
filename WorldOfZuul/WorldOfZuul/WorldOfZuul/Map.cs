namespace MapAndCenter {

    public class Map{

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
        // get the width of the console window
        int consoleWidth = Console.WindowWidth;

        // loop through each line and center it
        foreach (string line in lines)
        {
            // calculate the spaces needed to center the text
            int padding = (consoleWidth - line.Length) / 2;

            // if padding is less than 0, it means the text is wider than the console, so set padding to 0
            if (padding < 0) padding = 0;

            // print the line with the padding applied
            Console.WriteLine(new string(' ', padding) + line);
        }
    }

    public static void DisplayMap(string CurrentRoomName)
    {
        string[] drawMap ={" "}; 
       
        switch(CurrentRoomName)
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
"  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
" You are in ERA 1."
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
"  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
" You are in ERA 2 - main room."
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
"  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
" You are in ERA 2 - save the bees."
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
"  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
" You are in ERA 2 - save the coral reefs."
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
"  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
" You are in ERA 3 - SDU."
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
"  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
" You are in ERA 3 - outside SDU."
            };
                Map.CenterText(drawMap);
                break;


        }



    }
}
}