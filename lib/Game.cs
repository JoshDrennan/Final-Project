namespace lib;

public class Game
{
    List<IPlayer> Players {get; set;}
    public Game()
    {
        Players = new List<IPlayer>();
    }
}
