using System.Collections;

namespace lib;
public partial class Player : IPlayer
{
    public Player(string name)
    {
        
    }

    public string Name => Name;

    public int score = 0;
    public int Score 
    { 
        get => score; 
    }
}