using AutoMapper;
using BoardGamesDirectory.BusinessLogic.Mapper;

namespace BoardGamesDirectory.BusinessLogic.Tests.Mapper;

public static class MapperHelper
{
    public static IMapper Mapper { get; }
    
    static MapperHelper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<BoardGamesBLProfile>();
        });

        Mapper = config.CreateMapper();
    }
}