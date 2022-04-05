namespace lib;

public abstract class Throws
{
    public abstract int score();
}

public class Gutterball : Throws
{
    public override int score()
    {
        return 0;
    }
}

public class Strike : Throws
{
    public override int score()
    {
        throw new NotImplementedException();
    }

    public void CalculateStrike()
    {

    }
}

public class Regular : Throws
{
    public override int score()
    {
        throw new NotImplementedException();
    }
}

public class Spare : Throws
{
    public override int score()
    {
        throw new NotImplementedException();
    }
}

public class InvalidThow : Throws
{
    public override int score()
    {
        return 0;
    }
}