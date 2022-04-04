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