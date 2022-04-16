namespace lib;

public interface IPlayer
{
    public string Name { get; }

    public int Score { get; set; }

    public TypesOfThrows PreviousRoundResult { get; set; }
    public TypesOfThrows TwoRoundsAgoResult { get; set; }
}
