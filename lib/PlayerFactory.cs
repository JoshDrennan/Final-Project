namespace lib;

public class PlayerFactory : IPlayerFactory
{
    public IPlayer Create()
    {
        Console.WriteLine("Enter the player's name.");
        string name = Console.ReadLine();
        Player player = new Player(name, 0);
        return player;
    }
}