using AutoMapper;
using BoardGamesDirectory.Api.Settings;
using BoardGamesDirectory.BusinessLogic.BoardGames.Managers;
using BoardGamesDirectory.BusinessLogic.BoardGames.Providers;
using BoardGamesDirectory.DataAccess;
using BoardGamesDirectory.DataAccess.Entities;
using BoardGamesDirectory.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesDirectory.Api.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, BoardGamesShopSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        // board games
        services.AddScoped<IRepository<BoardGame>>(x =>
            new Repository<BoardGame>(x.GetRequiredService<IDbContextFactory<BoardGamesDirectoryDbContext>>()));
        services.AddScoped<IBoardGamesProvider>(x =>
            new BoardGamesProvider(x.GetRequiredService<IRepository<BoardGame>>(),
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IBoardGamesManager>(x =>
            new BoardGamesManager(x.GetRequiredService<IRepository<BoardGame>>(),
                x.GetRequiredService<IMapper>()));
    }
}