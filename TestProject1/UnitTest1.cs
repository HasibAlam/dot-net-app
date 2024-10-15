using Xunit;
using System;

public class LotteryTests
{
    [Fact]
    public void Test_Lottery_WinningNumber()
    {
        // Arrange
        int userGuess = 5;
        int winningNumber = 5;

        // Act
        bool isWinner = userGuess == winningNumber;

        // Assert
        Assert.True(isWinner, "User should win with the correct guess.");
    }

    [Fact]
    public void Test_Lottery_LosingNumber()
    {
        // Arrange
        int userGuess = 3;
        int winningNumber = 7;

        // Act
        bool isWinner = userGuess == winningNumber;

        // Assert
        Assert.False(isWinner, "User should lose with the incorrect guess.");
    }
}
