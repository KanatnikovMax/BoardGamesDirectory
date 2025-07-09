using AutoMapper;
using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;
using BoardGamesDirectory.DataAccess.Entities;

namespace BoardGamesDirectory.BusinessLogic.Mapper;

public class BoardGamesBLProfile : Profile
{
    public BoardGamesBLProfile()
    {
        CreateMap<BoardGame, BoardGameModel>();
        
        CreateMap<CreateBoardGameModel, BoardGame>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore());

        CreateMap<UpdateBoardGameModel, BoardGame>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.Ignore())
            .ForMember(dest => dest.Genre, opt => opt.Ignore())
            .ForMember(dest => dest.MinAge, opt => opt.Ignore())
            .ForMember(dest => dest.Publisher, opt => opt.Ignore());
    }
}