namespace lib;

public class Program
{
    public static void Main()
    {
        List<IPlayer> PlayersList = new List<IPlayer>();
        Console.WriteLine("Welcome to the bowling game scorekeeper.");
        AddPlayers(PlayersList);
        GameLoop();
    }

    private static void GameLoop()
    {

    }

    static void AddPlayers(List<IPlayer> PlayersList)
    {
        bool Loop = true;
        while (Loop == true)
        {
            Console.WriteLine("Press A to add players, press D to move on, or press P to print the list of players");
            string userInput = Console.ReadLine();
            if (userInput == "A")
            {
                PlayerFactory player = new PlayerFactory();
                PlayersList.Add(player.Create());
            }
            else if (userInput == "D")
            {
                Loop = false;
            }
            else if (userInput == "P")
            {
                for (int i = 0; i < PlayersList.Count; i++)
                {
                    Console.WriteLine(PlayersList[i]);
                }
            }
            else
            {
                Console.WriteLine("Invalid input try again.");
            }
        }
    }
}
