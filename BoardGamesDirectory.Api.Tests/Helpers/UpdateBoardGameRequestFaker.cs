using AutoBogus;
using BoardGamesDirectory.Api.Controllers.BoardGames.Entities;

namespace BoardGamesDirectory.Api.Tests.Helpers;

internal static class UpdateBoardGameRequestFaker
{
    public static UpdateBoardGameRequest GenerateValid()
    {
        return new AutoFaker<UpdateBoardGameRequest>()
            .RuleFor(x => x.Price, f => f.Random.Int(1, 10000))
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .Generate();
    }
}