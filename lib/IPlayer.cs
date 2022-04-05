namespace lib;

public interface IPlayer
{
    public string Name { get; }

    public int Score { get; set; }

    public Throws PreviousThrow { get; set; }
}
