namespace BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

public class CreateBoardGameModel
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Price { get; set; }
    public int? MinAge { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
}