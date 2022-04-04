namespace lib;
public class Player : IPlayer
{
    public int Score { get; set; }
    public string Name { get; }
    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, int score) : this(name)
    {
        Score = score;
    }

    public override string ToString()
    {
        return Name;
    }
}
