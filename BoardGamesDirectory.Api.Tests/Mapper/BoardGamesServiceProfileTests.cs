using AutoMapper;
using BoardGamesDirectory.Api.Controllers.BoardGames.Entities;
using BoardGamesDirectory.Api.Mapper;
using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;

namespace BoardGamesDirectory.Api.Tests.Mapper
{
    [TestFixture]
    public class BoardGamesServiceProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoardGamesServiceProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Test]
        public void CreateMap_CreateBoardGameRequestToCreateBoardGameModel_ShouldHaveValidConfig()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void CreateMap_CreateBoardGameRequestToCreateBoardGameModel_ShouldMapCorrectly()
        {
            var request = new CreateBoardGameRequest
            {
                Name = "Test Game",
                Genre = "Strategy",
                Price = 100,
                MinAge = 10,
                Publisher = "Test Publisher",
                Description = "Test Description"
            };

            var model = _mapper.Map<CreateBoardGameModel>(request);

            Assert.AreEqual(request.Name, model.Name);
            Assert.AreEqual(request.Genre, model.Genre);
            Assert.AreEqual(request.Price, model.Price);
            Assert.AreEqual(request.MinAge, model.MinAge);
            Assert.AreEqual(request.Publisher, model.Publisher);
            Assert.AreEqual(request.Description, model.Description);
        }

        [Test]
        public void CreateMap_BoardGameFilterToBoardGameModelFilter_ShouldHaveValidConfig()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void CreateMap_BoardGameFilterToBoardGameModelFilter_ShouldMapCorrectly()
        {
            var filter = new BoardGameFilter
            {
                NamePart = "Test",
                GenrePart = "Strategy",
                MinPrice = 50,
                MaxPrice = 150,
                MinAge = 8,
                PublisherPart = "Publisher"
            };

            var modelFilter = _mapper.Map<BoardGameModelFilter>(filter);

            Assert.AreEqual(filter.NamePart, modelFilter.NamePart);
            Assert.AreEqual(filter.GenrePart, modelFilter.GenrePart);
            Assert.AreEqual(filter.MinPrice, modelFilter.MinPrice);
            Assert.AreEqual(filter.MaxPrice, modelFilter.MaxPrice);
            Assert.AreEqual(filter.MinAge, modelFilter.MinAge);
            Assert.AreEqual(filter.PublisherPart, modelFilter.PublisherPart);
        }

        [Test]
        public void CreateMap_UpdateBoardGameRequestToUpdateBoardGameModel_ShouldHaveValidConfig()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void CreateMap_UpdateBoardGameRequestToUpdateBoardGameModel_ShouldMapCorrectly()
        {
            var request = new UpdateBoardGameRequest
            {
                Price = 200,
                Description = "Updated Description"
            };

            var model = _mapper.Map<UpdateBoardGameModel>(request);

            Assert.AreEqual(request.Price, model.Price);
            Assert.AreEqual(request.Description, model.Description);
        }
    }
}