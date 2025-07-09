using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

namespace BoardGamesDirectory.BusinessLogic.BoardGames.Managers;

public interface IBoardGamesManager
{
    Task<BoardGameModel> CreateBoardGameAsync(CreateBoardGameModel model);
    Task DeleteBoardGameAsync(int id);
    Task<BoardGameModel> UpdateBoardGameAsync(UpdateBoardGameModel model, int id);
}