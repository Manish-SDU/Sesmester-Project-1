namespace MapAndCenter {

    class Map{

    public string CurrentRoom { get; set;} = "";
    /// <STRING VALUES FOR EACH OF THE ROOMS - please change the note here if you wish to make big changes>
    /// Player's current room value must change EVERY TIME PLAYER CHANGES ROOMS for the map to work
    /// 
    /// Era1
    /// Era2, Era2Bees, Era2Corals
    /// Era3SDU, Era3Cement
    /// 
    /// intro and outro play automatically at the beginning/end and thus are not marked on the map
    /// </summary>
    

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

    public void DisplayMap()
    {
    }
}
}