namespace lib;


public class Frames
{
    public int TotalScore = 0;
    public int[] frames = new int[7];

    void FillArray()
    {
        for(int i = 0; i <= 10; i++)
        {
            frames[i] = 0;
        }
    }

}