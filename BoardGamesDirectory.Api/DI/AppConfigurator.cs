using BoardGamesDirectory.Api.IoC;
using BoardGamesDirectory.Api.Settings;

namespace BoardGamesDirectory.Api.DI;

public class AppConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, BoardGamesShopSettings settings)
    {
        DbContextConfigurator.ConfigureService(builder.Services, settings);
        SerilogConfigurator.ConfigureService(builder);
        SwaggerConfigurator.ConfigureServices(builder.Services);
        MapperConfigurator.ConfigureServices(builder.Services);
        ServicesConfigurator.ConfigureServices(builder.Services, settings);

        builder.Services.AddControllers();
    }

    public static void ConfigureApplication(WebApplication app, BoardGamesShopSettings settings)
    {
        SerilogConfigurator.ConfigureApplication(app);
        SwaggerConfigurator.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);
        app.MapControllers();
    }
}