namespace lib;

public class Game
{
    int length = 0;
    public int Length
    {
        get
        {
            return length;
        }
    }

    List<IPlayer> Players { get; set; }
    public Game(int Length)
    {
        Players = new List<IPlayer>();
        this.length = Length;
    }

    public async void Add(string v)
    {
        try
        {
            Player player = new Player($"{v}");
            for(int i = 0; i <= Players.Capacity; i++)
            {
                Players[i] = player;
                length++;
            }
        }
        catch
        {
            throw new NotImplementedException();
        }

    }
}
