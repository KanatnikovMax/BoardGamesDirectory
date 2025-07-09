using AutoMapper;
using BoardGamesDirectory.Api.Controllers.BoardGames.Entities;
using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

namespace BoardGamesDirectory.Api.Mapper;

public class BoardGamesServiceProfile : Profile
{
    public BoardGamesServiceProfile()
    {
        CreateMap<CreateBoardGameRequest, CreateBoardGameModel>();
        CreateMap<BoardGameFilter, BoardGameModelFilter>();
        CreateMap<UpdateBoardGameRequest, UpdateBoardGameModel>();
    }
}