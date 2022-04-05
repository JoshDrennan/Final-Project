namespace lib;
public class Player : IPlayer
{
    public int Score { get; set; }
    public string Name { get; }
    public Throws PreviousThrow { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, int score) : this(name)
    {
        Score = score;
    }

    public Player(string name, int score, Throws previousThrow) : this(name, score)
    {
        PreviousThrow = previousThrow;
    }

    public override string ToString()
    {
        return Name;
    }
}
