using BoardGamesDirectory.Api.DI;
using BoardGamesDirectory.Api.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = BoardGamesShopSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

AppConfigurator.ConfigureServices(builder, settings);

var app = builder.Build();

AppConfigurator.ConfigureApplication(app, settings);

app.Run();

public partial class Program;