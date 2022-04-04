namespace lib;

public class Program
{
    public static void Main()
    {
        List<IPlayer> PlayersList = new List<IPlayer>();
        Console.WriteLine("Welcome to the bowling game scorekeeper.");
        AddPlayers(PlayersList);
        GameLoop(PlayersList);
    }

    private static void GameLoop(List<IPlayer> PlayersList)
    {
        Frames rounds = new Frames();
        int round = 1;
        int roll1;
        int roll2;
        for (int i = 0; i <= rounds.frames.Length; i++)
        {
            foreach (var p in PlayersList)
            {
                Console.WriteLine($"it is round {round}");
                Console.WriteLine();
                Console.WriteLine("What is the score of your first roll");
                roll1 = Convert.ToInt32(Console.ReadLine());
                roll2 = Convert.ToInt32(Console.ReadLine());
                p.Score = CalculateScore(roll1, roll2);
            }

            round++;
        }
    }

    public void CalculateScore(int roll1, int roll2)
    {
        if (roll1 < 10 && roll1 + roll2 < 10)
        {
            //score = score + roll1 + roll2;
        }

        if (roll1 == 10)
        {
            //Strike(roll1, roll2);
        }

        if (roll1 + roll2 == 10)
        {
            //Spare(roll1, roll2);
        }
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
