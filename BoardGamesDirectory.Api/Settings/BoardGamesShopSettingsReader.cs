namespace BoardGamesDirectory.Api.Settings;

public class BoardGamesShopSettingsReader
{
    public static BoardGamesShopSettings Read(IConfiguration configuration)
    {
        return new BoardGamesShopSettings
        {
            BoardGamesShopDbConnectionString = configuration.GetValue<string>("BoardGamesDirectoryDbContext")
        };
    }
}