namespace lib;

public class GameLogic
{
    public static int CalculateScore(int roll1, int roll2)
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
}