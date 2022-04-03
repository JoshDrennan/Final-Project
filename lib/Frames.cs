namespace lib;


public class Frames
{
    public int TotalScore = 0;
    public int[] frames = new int[10];

    void FillArray()
    {
        for(int i = 0; i <= 10; i++)
        {
            frames[i] = 0;
        }
    }

    public int getTotalScore()
    {
        for (int j = 0; j <= 10; j++)
        {
            TotalScore += frames[j];
        }
        return TotalScore;
    }

    void appendFramesArray()
    {
        
    }
}