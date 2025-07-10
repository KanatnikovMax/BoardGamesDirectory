/*
 * CRUD-приложение для каталога настольных игр.
 * Предоставляет простейшие возможности для просмотра и редактирования списка настольных игр.
 * Для хранения данных использована СУБД PostgreSQL.
 */


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