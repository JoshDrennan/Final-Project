namespace lib;

public delegate int MyDelegate(int x, int y);
public delegate TypesOfThrows MyDelegate2(int x, int y);
public delegate int MyDelegate3(int w, int x, TypesOfThrows y, TypesOfThrows z);
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
        MyDelegate2 Del2 = new MyDelegate2(Program.SetPreviousThrow);
        MyDelegate3 Del3 = new MyDelegate3(Program.CalculatePreviousStrikeOrSpare);
        for (int i = 0; i <= rounds.frames.Length; i++)
        {
            Console.WriteLine($"it is round {round}");
            foreach (var p in PlayersList)
            {
                while (loop == true)
                {
                    Console.WriteLine($"{p} it is your turn");
                    Console.WriteLine();
                    Console.WriteLine("What is the score of your first roll");
                    roll1 = Convert.ToInt32(Console.ReadLine());
                    if (roll1 == 10)
                    {
                        roll2 = 0;
                    }
                    else
                    {
                        Console.WriteLine("What is the score of your second roll");
                        roll2 = Convert.ToInt32(Console.ReadLine());
                    }

                    if (roll1 <= 10 && roll1 >= 0 && roll2 <= 10 && roll2 >= 0)
                    {
                        p.Score = p.Score + Del1(roll1, roll2) + Del3(roll1, roll2, p.PreviousRoundResult, p.TwoRoundsAgoResult);
                        p.TwoRoundsAgoResult = p.PreviousRoundResult;
                        p.PreviousRoundResult = Del2(roll1, roll2);
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Your Inputs were invalid try again");
                    }
                    Console.WriteLine($"your current score is {p.Score}");
                }

                loop = true;
            }
            round++;
        }
    }

    private static int CalculatePreviousStrikeOrSpare(int roll1, int roll2, TypesOfThrows previousRoundResult, TypesOfThrows twoRoundsAgoResult)
    {
        int StrikeSpareAddedRollScores = 0;
        if(previousRoundResult == TypesOfThrows.Strike)
        {
            StrikeSpareAddedRollScores = StrikeSpareAddedRollScores + roll1 + roll2;
        }

        if (previousRoundResult == TypesOfThrows.Spare)
        {
            StrikeSpareAddedRollScores = StrikeSpareAddedRollScores + roll1;
        }
        if (previousRoundResult == TypesOfThrows.Strike && twoRoundsAgoResult == TypesOfThrows.Strike)
        {
            StrikeSpareAddedRollScores = StrikeSpareAddedRollScores + roll1;
        }

        return StrikeSpareAddedRollScores;
    }

    public static TypesOfThrows SetPreviousThrow(int roll1, int roll2)
    {

        if (roll1 < 10 && roll1 + roll2 < 10)
        {
            return TypesOfThrows.Regular;
        }

        else if (roll1 == 10)
        {
            return TypesOfThrows.Strike;
        }

        else if (roll1 + roll2 == 10)
        {
            return TypesOfThrows.Spare;
        }
        else
        {
            Console.WriteLine("This was an invalid throw");
            return TypesOfThrows.InvalidThow;
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
