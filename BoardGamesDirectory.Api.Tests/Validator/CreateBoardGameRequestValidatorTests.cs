using BoardGamesDirectory.Api.Controllers.BoardGames.Entities;
using BoardGamesDirectory.Api.Tests.Helpers;
using BoardGamesDirectory.Api.Validator.BoardGames;
using FluentValidation.TestHelper;

namespace BoardGamesDirectory.Api.Tests.Validator;

[TestFixture]
public class CreateBoardGameRequestValidatorTests
{
    private CreateBoardGameRequestValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateBoardGameRequestValidator();
    }

    [Test]
    public void Validate_WhenNameEmpty_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Name = string.Empty;

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name is required");
    }

    [Test]
    public void Validate_WhenNameTooLong_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Name = new string('a', 51);

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name must be less than 50 characters");
    }

    [Test]
    public void Validate_WhenGenreInvalidCharacters_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Genre = "Invalid@Genre#123";

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Genre)
            .WithErrorMessage("Genre is invalid");
    }

    [Test]
    public void Validate_WhenPublisherInvalidCharacters_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Publisher = "Publisher@123!";

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Publisher)
            .WithErrorMessage("Publisher is invalid");
    }

    [Test]
    public void Validate_WhenDescriptionEmpty_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Description = string.Empty;

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage("Description is required");
    }

    [Test]
    public void Validate_WhenMinAgeZero_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.MinAge = 0;

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.MinAge)
            .WithErrorMessage("Age must be between 0 and 18");
    }

    [Test]
    public void Validate_WhenMinAgeEighteen_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.MinAge = 18;

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.MinAge)
            .WithErrorMessage("Age must be between 0 and 18");
    }

    [Test]
    public void Validate_WhenPriceZero_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Price = 0;

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price must be greater than 0");
    }

    [Test]
    public void Validate_WhenPriceNegative_ShouldHaveError()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();
        request.Price = -10000;

        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price must be greater than 0");
    }

    [Test]
    public void Validate_WhenAllValid_ShouldNotHaveErrors()
    {
        var request = CreateBoardGameRequestFaker.GenerateValid();

        _validator.TestValidate(request)
            .ShouldNotHaveAnyValidationErrors();
    }
}