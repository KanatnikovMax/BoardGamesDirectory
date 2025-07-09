using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

namespace BoardGamesDirectory.Api.Controllers.BoardGames.Entities;

public class BoardGamesListResponse
{
    public List<BoardGameModel> BoardGames { get; set; }
}