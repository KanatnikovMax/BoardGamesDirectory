using AutoBogus;
using BoardGamesDirectory.Api.Controllers.BoardGames.Entities;

namespace BoardGamesDirectory.Api.Tests.Helpers;

internal static class CreateBoardGameRequestFaker
{
    private static readonly string ValidName = "DnD";
    private static readonly string ValidGenre = "НРИ";
    private static readonly string ValidPublisher = "Hobby World";
    private static readonly string ValidDescription = "Самая популярная НРИ";
    private static readonly int ValidMinAge = 6;
    private static readonly int ValidPrice = 3999;

    public static CreateBoardGameRequest GenerateValid()
    {
        return new AutoFaker<CreateBoardGameRequest>()
            .RuleFor(x => x.Name, f => ValidName)
            .RuleFor(x => x.Genre, f => ValidGenre)
            .RuleFor(x => x.Publisher, f => ValidPublisher)
            .RuleFor(x => x.Description, f => ValidDescription)
            .RuleFor(x => x.MinAge, f => ValidMinAge)
            .RuleFor(x => x.Price, f => ValidPrice)
            .Generate();
    }
}