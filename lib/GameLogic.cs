namespace lib;


public delegate int MyDelegate(int x, int y);
public delegate TypesOfThrows MyDelegate2(int x, int y);
public delegate int MyDelegate3(int w, int x, TypesOfThrows y, TypesOfThrows z);
public class GameLogic : IGameLogic
{
    public GameLogic()
    {

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

    public int CalculatePreviousStrikeOrSpare(int roll1, int roll2, TypesOfThrows previousRoundResult, TypesOfThrows twoRoundsAgoResult)
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

    public TypesOfThrows SetPreviousThrow(int roll1, int roll2)
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

    public void SavePlayers(List<IPlayer> PlayersList)
    {
        using (var writer = new StreamWriter("SavedPlayers.txt"))
        {
            foreach(var p in PlayersList)
            {
                writer.WriteLine(p.Name);
            }
            writer.Close();
        }
    }

    public void LoadAccounts(List<IPlayer> PlayersList)
    {
        string[] SavedNames;
        if (File.Exists("SavedPlayers.txt"))
        {
            SavedNames = System.IO.File.ReadAllLines("SavedPlayers.txt");
            foreach (var line in SavedNames)
            {
                Player player = new Player(line);
                PlayersList.Add(player);
            }
        }
    }
}
