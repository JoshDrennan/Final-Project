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
        bool loop = true;
        Frames rounds = new Frames();
        int round = 1;
        int roll1;
        int roll2;
        MyDelegate Del1 = new MyDelegate(GameLogic.CalculateScore);
        MyDelegate2 Del2 = new MyDelegate2(GameLogic.SetPreviousThrow);
        MyDelegate3 Del3 = new MyDelegate3(GameLogic.CalculatePreviousStrikeOrSpare);
        for (int i = 0; i < rounds.frames.Length; i++)
        {
            Console.WriteLine($"it is round {round}");
            foreach (var p in PlayersList)
            {
                while (loop == true)
                {
                    Console.WriteLine($"{p.Name} it is your turn");
                    Console.WriteLine();
                    Console.WriteLine("What is the score of your first roll");
                    roll1 = GetRollScore();
                    if (roll1 == 10)
                    {
                        roll2 = 0;
                    }
                    else
                    {
                        Console.WriteLine("What is the score of your second roll");
                        roll2 = GetRollScore();
                    }

                    p.Score = p.Score + Del1(roll1, roll2) + Del3(roll1, roll2, p.PreviousRoundResult, p.TwoRoundsAgoResult);
                    p.TwoRoundsAgoResult = p.PreviousRoundResult;
                    p.PreviousRoundResult = Del2(roll1, roll2);
                    loop = false;

                    Console.WriteLine($"your current score is {p.Score}");
                }

                loop = true;
            }
            round++;
        }
    }

    public static int GetRollScore()
    {
        int UserInput;
        while (true)
        {
            UserInput = Convert.ToInt32(Console.ReadLine());
            if (UserInput <= 10 && UserInput >= 1)
            {
                return UserInput;
            }
            else
            {
                Console.WriteLine("Invalid Input roll score must be between 1 and 10 try again");
            }
        }
    }
    public static void AddPlayers(List<IPlayer> PlayersList)
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
                    Console.WriteLine(PlayersList[i].Name);
                }
            }
            else
            {
                Console.WriteLine("Invalid input try again.");
            }
        }
    }
}
