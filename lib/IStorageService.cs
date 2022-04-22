namespace lib;

public interface IStorageService
{
    public void SavePlayers(List<IPlayer> PlayersList);
    public List<IPlayer> LoadPlayers();
}

