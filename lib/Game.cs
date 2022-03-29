namespace lib;

public class Game
{
    public int Length { get; }

    public List<IPlayer> PlayersList { get; set; }

    public Game(int length, Player player)
    {
        PlayersList = new List<IPlayer>();
        Length = length;
        PlayersList.Add(player);
    }
    public List<IPlayer> GetList()
    {

        return PlayersList;

    }
}
