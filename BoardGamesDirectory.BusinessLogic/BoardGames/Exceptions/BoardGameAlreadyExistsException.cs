namespace BoardGamesDirectory.BusinessLogic.BoardGames.Exceptions;

public class BoardGameAlreadyExistsException : Exception
{
    public BoardGameAlreadyExistsException()
    {
    }

    public BoardGameAlreadyExistsException(string? message) : base(message)
    {
    }
}