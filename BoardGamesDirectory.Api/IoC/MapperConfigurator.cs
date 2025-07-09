using BoardGamesDirectory.Api.Mapper;
using BoardGamesDirectory.BusinessLogic.Mapper;

namespace BoardGamesDirectory.Api.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<BoardGamesBLProfile>();
            config.AddProfile<BoardGamesServiceProfile>();
        });
    }
}