namespace BoardGamesDirectory.Api.Controllers.BoardGames.Entities;

public class UpdateBoardGameRequest
{
    public int? Price { get; set; }
    public string? Description { get; set; }
}