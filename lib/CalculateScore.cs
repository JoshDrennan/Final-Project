namespace lib;

public class CalculateScore
{
    public CalculateScore(int roll1, int roll2)
    {
        if(roll1 < 10 && roll1 + roll2 < 10)
        {
            //score = score + roll1 + roll2;
        }

        if(roll1 == 10)
        {
            //Strike(roll1, roll2);
        }

        if(roll1 + roll2 == 10)
        {
            //Spare(roll1, roll2);
        }
    }
}