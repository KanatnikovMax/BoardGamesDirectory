namespace BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

public class BoardGameModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Price { get; set; }
    public int MinAge { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
}