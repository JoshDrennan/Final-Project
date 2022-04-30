namespace lib;

public class Program
{
    public static void Main()
    {
        bool loop = true;
        while (loop = true)
        {
            GameLogic gameLogic = new GameLogic();
            storageService storageService = new storageService();
            List<IPlayer> PlayersList = new List<IPlayer>();
            Console.WriteLine();
            Console.WriteLine("Welcome to the bowling game scorekeeper.");
            Console.WriteLine();
            PlayersList = AddPlayers(PlayersList, storageService);
            GameLoop(PlayersList, gameLogic);
            EndOfgame(PlayersList, storageService);
            PlayAgain(loop);
        }
    }

    public static bool PlayAgain(bool loop)
    {
        while (true)
        {
            Console.WriteLine("Would You like to play again?");
            Console.WriteLine("Enter Y to play agian or N to end");
            string PlayAgainInput = Console.ReadLine();
            if (PlayAgainInput == "N")
            {
                Console.WriteLine("Thank you for playing!");
                return loop = false;
            }
            if (PlayAgainInput == "Y")
            {
                Console.WriteLine("You have chose to play again enjoy!");
                Console.WriteLine();
                return loop = true;
            }
            if (PlayAgainInput != "N" || PlayAgainInput != "Y")
            {
                Console.WriteLine("Invalid input press Enter to try agian");
                PlayAgainInput = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
    private static void GameLoop(List<IPlayer> PlayersList, GameLogic gameLogic)
    {
        bool loop = true;
        Frames rounds = new Frames();
        int round = 1;
        int roll1;
        int roll2;
        MyDelegate Del1 = new MyDelegate(gameLogic.CalculateScore);
        MyDelegate2 Del2 = new MyDelegate2(gameLogic.SetPreviousThrow);
        MyDelegate3 Del3 = new MyDelegate3(gameLogic.CalculatePreviousStrikeOrSpare);
        for (int i = 0; i < rounds.frames.Length; i++)
        {
            Console.WriteLine($"it is round {round}");
            Console.WriteLine();
            foreach (var p in PlayersList)
            {
                while (loop == true)
                {
                    Console.WriteLine($"{p.Name} it is your turn");
                    Console.WriteLine("What is the score of your first roll");
                    Console.WriteLine();
                    roll1 = GetRollScore();
                    Console.WriteLine(roll1);
                    if (roll1 == 10)
                    {
                        roll2 = 0;
                    }
                    else
                    {
                        Console.WriteLine("What is the score of your second roll");
                        Console.WriteLine();
                        roll2 = GetRollScore();
                        while (roll1 + roll2 > 10)
                        {
                            Console.WriteLine("Your second roll input was invalid try again. enter the score of your second roll");
                            roll2 = GetRollScore();
                        }
                    }
                    if (round == 10)
                    {
                        if (roll1 == 10 || roll1 + roll2 == 10)
                        {
                            p.Score = p.Score + FinalRound(roll1, roll2);
                        }
                    }
                    p.Score = p.Score + Del1(roll1, roll2) + Del3(roll1, roll2, p.PreviousRoundResult, p.TwoRoundsAgoResult);
                    p.TwoRoundsAgoResult = p.PreviousRoundResult;
                    p.PreviousRoundResult = Del2(roll1, roll2);
                    loop = false;
                    Console.Clear();
                    Console.WriteLine($"{p.Name}'s current score is {p.Score}");
                    Console.WriteLine();
                }

                loop = true;
            }
            round++;
        }

    }

    public static int GetRollScore()
    {
        string UserInput;
        int rollScore;
        bool success;
        while (true)
        {
            UserInput = Console.ReadLine();
            success = int.TryParse(UserInput, out rollScore);
            if (success)
            {
                if (rollScore <= 10 && rollScore >= 0)
                {
                    return rollScore;
                }
                else
                {
                    Console.WriteLine("Invalid Input roll score must be a number between 0 and 10 try again");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid Input roll score must be a number between 0 and 10 try again");
                Console.WriteLine();
            }
        }
    }
    public static List<IPlayer> AddPlayers(List<IPlayer> PlayersList, storageService storageService)
    {
        bool Loop = true;
        while (Loop == true)
        {
            Console.WriteLine("Press A to add players");
            Console.WriteLine("Press D to move on");
            Console.WriteLine("Press P to print the list of players");
            Console.WriteLine("Press L to load names from last rounds");

            Console.WriteLine();
            string userInput = Console.ReadLine();
            if (userInput == "A")
            {
                PlayerFactory player = new PlayerFactory();
                PlayersList.Add(player.Create());
                Console.WriteLine();
            }
            else if (userInput == "D")
            {
                if (PlayersList.Count >= 1)
                {
                    Loop = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Add players to begin the game");
                    Console.WriteLine();
                }
            }
            else if (userInput == "P")
            {
                for (int i = 0; i < PlayersList.Count; i++)
                {
                    Console.WriteLine(PlayersList[i].Name);
                }
            }
            else if (userInput == "L")
            {
                PlayerFactory player = new PlayerFactory();
                PlayersList = storageService.LoadPlayers();
            }
            else
            {
                Console.WriteLine("Invalid input try again.");
                Console.WriteLine();
            }
        }
        return PlayersList;
    }

    public static int FinalRound(int roll1, int roll2)
    {
        int FinalRoundStrikeOrSpareAddedRollsScore = 0;
        int addedRoll1;
        int addedRoll2;
        if (roll1 == 10)
        {
            Console.WriteLine("You rolled a strike on the final round.");
            Console.WriteLine("You get two more rolls");
            Console.WriteLine("What is the score of your first added roll");
            Console.WriteLine();
            addedRoll1 = GetRollScore();
            Console.WriteLine("What is the score of your second added roll");
            Console.WriteLine();
            addedRoll2 = GetRollScore();
            if (addedRoll1 == 10)
            {
                FinalRoundStrikeOrSpareAddedRollsScore = addedRoll1 + addedRoll2 + addedRoll2;
            }
            else
            {
                FinalRoundStrikeOrSpareAddedRollsScore = addedRoll1 + addedRoll2;
            }
        }
        else if (roll1 + roll2 == 10)
        {
            Console.WriteLine("You rolled a spare on the final round.");
            Console.WriteLine("You get one more roll");
            Console.WriteLine("What is the score of your roll");
            Console.WriteLine();
            addedRoll1 = GetRollScore();
        }
        return FinalRoundStrikeOrSpareAddedRollsScore;
    }

    private static void EndOfgame(List<IPlayer> PlayersList, storageService storageService)
    {
        Console.WriteLine("You finished the game!");
        Console.WriteLine("The final scores are:");
        Console.WriteLine();
        foreach (var p in PlayersList)
        {
            Console.WriteLine($"{p.Name}: {p.Score}");
        }

        Console.WriteLine("would you like to save your names for next time you play? if so enter Y if not enter anything else");
        Console.WriteLine();
        string UserInput = Console.ReadLine();
        if (UserInput == "Y")
        {
            storageService.SavePlayers(PlayersList);
            PlayersList.Clear();
            Console.WriteLine("Thank you for playing. Your names have been saved. Load them next time you play");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Your names won't be saved. Thanks for playing");
            Console.WriteLine();

        }
    }
}
