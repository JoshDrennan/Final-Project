using System.Collections;

namespace lib;
public class Player : IPlayer
{
    string name;


    public Player(string Name)
    {
        this.name = Name;
    }

    public string Name
    {
        get
        {
            return name;
        }
    }
    public int score = 0;
    public int Score
    {
        get => score;
    }

}