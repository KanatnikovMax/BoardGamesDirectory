using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

namespace BoardGamesDirectory.BusinessLogic.BoardGames.Providers;

public interface IBoardGamesProvider
{
    Task<IEnumerable<BoardGameModel>> GetAllBoardGamesAsync(BoardGameModelFilter filter = null);
    Task<BoardGameModel> GetBoardGameInfoAsync(int userId);
}