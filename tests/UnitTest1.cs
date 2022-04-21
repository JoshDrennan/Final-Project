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

    [Test]
    public void Test2()
    {
        Player TestPlayer1 = new Player("Brad");
        TestPlayer.Add(TestPlayer1);
        Assert.AreEqual(1, TestPlayer.Count);
    }

    [Test]
    public void TestPlayerCountInList()
    {
        Player TestPlayer2 = new Player("Josh");
        TestPlayer.Add(TestPlayer2);
        Assert.AreEqual(2, TestPlayer.Count);
    }

    [Test]
    public void TestFramesArrayLength()
    {
        Frames testFrames = new Frames();
        Assert.AreEqual(10, testFrames.frames.Length);
    }

    [Test]
    public void TestCalculateScore()
    {
        GameLogic gameLogic = new GameLogic();
        Assert.AreEqual(6, gameLogic.CalculateScore(3, 3));
    }

    [Test]
    public void TestCalculatePreviousStrikesOrSpares()
    {
        GameLogic gameLogic = new GameLogic();
        Assert.AreEqual(11, gameLogic.CalculatePreviousStrikeOrSpare(3, 5, TypesOfThrows.Strike, TypesOfThrows.Strike));
    }

    // [Test]
    // public void TestSavePlayers()
    // {
    //     Player TestPlayer3 = new Player("josh");
    //     Player TestPlayer4 = new Player("Brad");
    //     GameLogic gameLogic = new GameLogic();
    //     TestPlayer.Clear();
    //     TestPlayer.Add(TestPlayer3);
    //     TestPlayer.Add(TestPlayer4);
    // }
}