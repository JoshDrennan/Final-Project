namespace lib;

public class Program
{ 
    public static void Main()
    {
        Console.WriteLine("Welcome to the bowling game scorekeeper.");
        Console.WriteLine("Please enter names of players");
        AddPlayers();
        GameLoop();
        
    }

    private static void GameLoop()
    {
        //foreach(var i in )
    }

    static void AddPlayers()
    {
        int length = 0;
        bool Loop = true;
        while(Loop == true)
        {
            Console.WriteLine("Press A to add players or press D to move on");
            string userInput = Console.ReadLine();
            if(userInput == "A")
            {
                Console.WriteLine("Type in your name");
                string playerName = Console.ReadLine();
                Player player = new Player($"{playerName}");
                Game gamePlayers = new Game(length, player);
                length ++;
                
            }
            else if(userInput == "D")
            {
                Loop = false;
            }
            else
            {
                Console.WriteLine("Invalid input try again.");
            }
        }
    }
}
