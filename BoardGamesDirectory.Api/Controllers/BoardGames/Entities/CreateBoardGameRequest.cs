namespace BoardGamesDirectory.Api.Controllers.BoardGames.Entities;

public class CreateBoardGameRequest
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Price { get; set; }
    public int? MinAge { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
}