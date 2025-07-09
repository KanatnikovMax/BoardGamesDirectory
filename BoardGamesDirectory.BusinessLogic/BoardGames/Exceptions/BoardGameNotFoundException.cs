namespace BoardGamesDirectory.BusinessLogic.BoardGames.Exceptions;

public class BoardGameNotFoundException : Exception
{
    public BoardGameNotFoundException()
    {
    }

    public BoardGameNotFoundException(string? message) : base(message)
    {
    }
}