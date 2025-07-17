using BoardGamesDirectory.Api.Tests.Helpers;
using BoardGamesDirectory.Api.Validator.BoardGames;
using FluentValidation.TestHelper;

namespace BoardGamesDirectory.Api.Tests.Validator;

[TestFixture]
    public class UpdateBoardGameRequestValidatorTests
    {
        private UpdateBoardGameRequestValidator _validator;
        
        [SetUp]
        public void Setup()
        {
            _validator = new UpdateBoardGameRequestValidator();
        }

        [Test]
        public void Validate_WhenPriceIsNull_ShouldNotHaveError()
        {
            var request = UpdateBoardGameRequestFaker.GenerateValid();
            request.Price = null;

            _validator.TestValidate(request)
                .ShouldNotHaveValidationErrorFor(x => x.Price);
        }

        [Test]
        public void Validate_WhenPriceIsZero_ShouldHaveError()
        {
            var request = UpdateBoardGameRequestFaker.GenerateValid();
            request.Price = 0;

            _validator.TestValidate(request)
                .ShouldHaveValidationErrorFor(x => x.Price)
                .WithErrorMessage("Price must be greater than 0");
        }

        [Test]
        public void Validate_WhenPriceIsNegative_ShouldHaveError()
        {
            var request = UpdateBoardGameRequestFaker.GenerateValid();
            request.Price = -100;

            _validator.TestValidate(request)
                .ShouldHaveValidationErrorFor(x => x.Price)
                .WithErrorMessage("Price must be greater than 0");
        }

        [Test]
        public void Validate_WhenPriceIsPositive_ShouldNotHaveError()
        {
            var request = UpdateBoardGameRequestFaker.GenerateValid();
            request.Price = 1500;

            _validator.TestValidate(request)
                .ShouldNotHaveValidationErrorFor(x => x.Price);
        }
    }