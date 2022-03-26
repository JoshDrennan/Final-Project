namespace lib;

public class Program
{ 
    public static void Main()
    {
        List<IPlayer> GamePlayers = new List<IPlayer>();
        Console.WriteLine("Welcome to the bowling game scorekeeper.");
        Console.WriteLine("Please enter names of players");
        AddPlayers();
        
    }

    static void AddPlayers()
    {
        while(true)
        {
            Console.WriteLine("Press A to add players or press D to move on");
            string userInput = Console.ReadLine();
            if(userInput == "A")
            {
                Console.WriteLine("Type in your name");
                string playerName = Console.ReadLine();
                Player player = new Player($"{playerName}");
            }
            else if(userInput == "D")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input try again.");
            }
        }
    }
}
