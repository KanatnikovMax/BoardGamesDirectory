using BoardGamesDirectory.Api.Controllers.BoardGames.Entities;
using FluentValidation;

namespace BoardGamesDirectory.Api.Validator.BoardGames;

public class CreateBoardGameRequestValidator : AbstractValidator<CreateBoardGameRequest>
{
    public CreateBoardGameRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must be less than 50 characters");
        
        RuleFor(x => x.Genre)
            .NotEmpty()
            .WithMessage("Genre is required")
            .MaximumLength(50)
            .WithMessage("Genre must be less than 50 characters")
            .Matches(@"^[\sa-zA-Zа-яА-ЯёЁ-]+$")
            .WithMessage("Genre is invalid");

        RuleFor(x => x.Publisher)
            .NotEmpty()
            .WithMessage("Publisher is required")
            .MaximumLength(50)
            .WithMessage("Publisher must be less than 50 characters")
            .Matches(@"^[\sa-zA-Zа-яА-ЯёЁ-]+$")
            .WithMessage("Publisher is invalid");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
        
        RuleFor(x => x.MinAge)
            .ExclusiveBetween(0, 18)
            .WithMessage("Age must be between 0 and 18");
        
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}