namespace lib;
public class Player : IPlayer
{
    public int Score { get; set; }
    public string Name { get; }
    public TypesOfThrows PreviousRoundResult { get; set; }
    public TypesOfThrows TwoRoundsAgoResult { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, int score) : this(name)
    {
        Score = score;
    }

    public Player(string name, int score, TypesOfThrows previousThrow) : this(name, score)
    {
        PreviousRoundResult = previousThrow;
    }

    public Player(string name, int score, TypesOfThrows previousThrow, TypesOfThrows twoRoundsAgoResult) : this(name, score, previousThrow)
    {
        TwoRoundsAgoResult = twoRoundsAgoResult;
    }

}
