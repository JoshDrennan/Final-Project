using System.Collections.Generic;
using NUnit.Framework;

namespace lib;

public class Tests
{
    public List<IPlayer> TestPlayer = new List<IPlayer>();
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Player TestPlayer1 = new Player("Brad");
        Assert.AreEqual("Brad", TestPlayer1.Name);
    }

    // [Test]
    // public void Test2()
    // {
    //     Player TestPlayer1 = new Player("Brad");
    //     TestPlayer.Add(TestPlayer1);
    //     Assert.AreEqual(1, TestPlayer.Count);
    // }

    // [Test]
    // public void TestPlayerCountInList()
    // {
    //     Player TestPlayer2 = new Player("Josh");
    //     TestPlayer.Add(TestPlayer2);
    //     Assert.AreEqual(2, TestPlayer.Count);
    // }

    // [Test]
    // public void TestFramesArrayLength()
    // {
    //     Frames testFrames = new Frames();
    //     Assert.AreEqual(10, testFrames.frames.Length);
    // }

    // [Test]
    // public void TestWhatIsInFramesArray()
    // {
    //     Frames testFrames2 = new Frames();
    //     Assert.AreEqual(0, testFrames2.frames[0]);
    // }

    // [Test]
    // public void TestCalculateScore()
    // {
    //     Assert.AreEqual(6, GameLogic.CalculateScore(3, 3));
    // }
}