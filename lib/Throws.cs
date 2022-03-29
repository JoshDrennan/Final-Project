namespace lib;

public abstract class Throws
{
    public abstract int score();
}

class Gutterball : Throws
{
    public override int score()
    {
        return 0;
    }
}

class Strike : Throws
{
    public override int score()
    {
        throw new NotImplementedException();
    }
}

class regular : Throws
{
    public override int score()
    {
        throw new NotImplementedException();
    }
}

/*
    public void CalculateScore(int roll1, int roll2)
    {
        if(roll1 < 10 && roll1 + roll2 < 10)
        {
            score = score + roll1 + roll2;
        }

        if(roll1 == 10)
        {
            Strike(roll1, roll2);
        }

        if(roll1 + roll2 == 10)
        {
            Spare(roll1, roll2);
        }
    }
    */

