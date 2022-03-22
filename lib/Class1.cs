namespace lib;
public interface IPerson
{
    public string Name{get;}
    public int Score{get; set;}
}
public class Person : IPerson
{
    public Person(string name)
    {
        Person player = new Person(name);
    }
    public string Name => Name;

    public int Score 
    { 
        get => Score; 
        set
        {
            Score = value;
        }
    }
}