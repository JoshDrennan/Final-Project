namespace lib;

public enum TypesOfThrows
{
    Regular,
    Gutterball,
    Strike,
    Spare,
    InvalidThow
}
public abstract class Throws
{
    public abstract TypesOfThrows TypeOfThrow {get;}
}

public class Gutterball : Throws
{
    public override TypesOfThrows TypeOfThrow => TypesOfThrows.Gutterball;
}

public class Strike : Throws
{
    public override TypesOfThrows TypeOfThrow => TypesOfThrows.Strike;
}

public class Regular : Throws
{
    public override TypesOfThrows TypeOfThrow => TypesOfThrows.Regular;
}

public class Spare : Throws
{
    public override TypesOfThrows TypeOfThrow => TypesOfThrows.Spare;
}

public class InvalidThow : Throws
{
    public override TypesOfThrows TypeOfThrow => TypesOfThrows.InvalidThow;
}

