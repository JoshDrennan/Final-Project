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
                while (true)
                {
                    Console.WriteLine($"it is round {round}");
                    Console.WriteLine();
                    Console.WriteLine("What is the score of your first roll");
                    roll1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("What is the score of your second roll");
                    roll2 = Convert.ToInt32(Console.ReadLine());
                    if (roll1 <= 10 && roll1 >= 0 && roll2 <= 10 && roll2 >= 0)
                    {
                        p.Score = CalculateScore(roll1, roll2);
                        p.PreviousThrow = SetPreviousThrow(roll1, roll2);
                    }
                    else
                    {
                        throw new InvalidThrowException();
                    }

                }
            }

            round++;
        }
    }

    public Throws SetPreviousThrow(int roll1, int roll2)
    {

        if (roll1 < 10 && roll1 + roll2 < 10)
        {
            Throws regularRound = new Regular();
            return regularRound;
        }

        else if (roll1 == 10)
        {
            Throws strike = new Strike();
            return strike;
        }

        else if (roll1 + roll2 == 10)
        {
            Throws spare = new Spare();
            return spare;
        }
        else
        {
            Console.WriteLine("This was an invalid throw");
            Throws invalidThow = new InvalidThow();
            return invalidThow;
        }

    }

    public int CalculateScore(int roll1, int roll2)
    {
        int calculatedScore;

        if (roll1 < 10 && roll1 + roll2 < 10)
        {
            calculatedScore = roll1 + roll2;
            return calculatedScore;
        }

        else if (roll1 == 10)
        {
            calculatedScore = 10;
            return calculatedScore;
        }

        else if (roll1 + roll2 == 10)
        {
            calculatedScore = 10;
            return calculatedScore;
        }
        else
        {
            return 0;
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
