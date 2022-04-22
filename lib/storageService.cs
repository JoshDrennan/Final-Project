namespace lib;

public class storageService : IStorageService
{
    public void SavePlayers(List<IPlayer> PlayersList)
    {
        using (var writer = new StreamWriter("SavedPlayers.txt"))
        {
            foreach(var p in PlayersList)
            {
                writer.WriteLine(p.Name);
            }
            writer.Close();
        }
    }

    public List<IPlayer> LoadPlayers()
    {
        List<IPlayer> PlayersList = new List<IPlayer>();
        string[] SavedNames;
        if (File.Exists("SavedPlayers.txt"))
        {
            SavedNames = System.IO.File.ReadAllLines("SavedPlayers.txt");
            foreach (var line in SavedNames)
            {
                Player player = new Player(line);
                PlayersList.Add(player);
            }
        }
        return PlayersList;
    }
}
