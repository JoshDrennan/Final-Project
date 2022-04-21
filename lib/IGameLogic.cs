namespace lib;

public interface IGameLogic
{
    public int CalculateScore(int roll1, int roll2);
    public int CalculatePreviousStrikeOrSpare(int roll1, int roll2, TypesOfThrows previousRoundResult, TypesOfThrows twoRoundsAgoResult);
    public TypesOfThrows SetPreviousThrow(int roll1, int roll2);
    public void SavePlayers(List<IPlayer> PlayersList);
    public void LoadAccounts(List<IPlayer> PlayersList);
}
