using BoardGamesDirectory.Api.Settings;
using BoardGamesDirectory.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesDirectory.Api.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, BoardGamesShopSettings settings)
    {
        services.AddDbContextFactory<BoardGamesDirectoryDbContext>(options =>
        {
            options.UseNpgsql(settings.BoardGamesShopDbConnectionString);
        }, ServiceLifetime.Scoped);

    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BoardGamesDirectoryDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}