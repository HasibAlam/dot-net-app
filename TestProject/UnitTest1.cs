using Xunit;

public class LotteryGameTests
{
    [Fact]
    public void GuessMatchesWinningNumber_ReturnsWin()
    {
        // Arrange
        int userGuess = 5;
        int winningNumber = 5;

        // Act
        bool result = userGuess == winningNumber;

        // Assert
        Assert.True(result);  // This should be true if the guess matches the winning number
    }

    [Fact]
    public void GuessDoesNotMatchWinningNumber_ReturnsLose()
    {
        // Arrange
        int userGuess = 4;
        int winningNumber = 7;

        // Act
        bool result = userGuess == winningNumber;

        // Assert
        Assert.False(result);  // This should be false if the guess does not match the winning number
    }
}
