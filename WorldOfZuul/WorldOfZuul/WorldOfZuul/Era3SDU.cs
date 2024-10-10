public class Era3SDU
{
    // Method that prints the welcome message for Era 3 SDU
    public void Enter()
    {
        EraTitle eraTitle = new EraTitle();
        eraTitle.Print("Welcome to Era 3 SDU!");
        
        // Print the ASCII art for Era 3 SDU
        PrintEra3Art();
    }

    private void PrintEra3Art()
    {
        string[] artLines = {
            "                                                                     *@@@            ",
            "    #@@@@@@#     %@@@@@@@@%*        @@@*         @@@               @@@@@             ",
            "  #@@@@@@@@@@    %@@@%%%@@@@@@:     @@@*         @@@             *@@@@*              ",
            " #@@@            %@@=      -@@@#    @@@*         @@@            *@@#*                ",
            "  @@@@           %@@=        @@@*   @@@*         @@@                   @@@@@@@@*     ",
            "   #@@@@@#       %@@=        :@@@   @@@*         @@@        *#####     @@@@@@@@@@*   ",
            "      #@@@@@#    %@@=        :@@@   @@@*         @@@     #*       ##    *@@@@@@@@@*  ",
            "         #@@@#   %@@=        @@@#   @@@#         @@@           @@@@@@@*              ",
            "          #@@#   %@@=       @@@@    *@@@        @@@@          #@@@@@@@@              ",
            "  @@@@@@@@@@@#   @@@@@@@@@@@@@@*      *@@@@@@@@@@@#           *@@@@@@@@              ",
            "   #@@@@@@@#     %@@@@@@@@@#           *@@@@@@@@#              *@@@@@@*              ",
        };

        // Get the width of the console window
        int consoleWidth = Console.WindowWidth;

        foreach (var line in artLines)
        {
            // Calculate padding to center the line horizontally
            int padding = (consoleWidth - line.Length) / 2;

            // Ensure padding is non-negative
            padding = Math.Max(0, padding);

            // Print the padded line
            Console.WriteLine(new string(' ', padding) + line);
        }
    }
}
