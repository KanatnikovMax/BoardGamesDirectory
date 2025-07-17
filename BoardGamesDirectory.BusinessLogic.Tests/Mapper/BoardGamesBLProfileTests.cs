using AutoMapper;
using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;
using BoardGamesDirectory.BusinessLogic.Mapper;
using BoardGamesDirectory.DataAccess.Entities;

namespace BoardGamesDirectory.BusinessLogic.Tests.Mapper
{
    [TestFixture]
    public class BoardGamesBLProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoardGamesBLProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Test]
        public void CreateMap_BoardGameToBoardGameModel_ShouldHaveValidConfig()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void CreateMap_BoardGameToBoardGameModel_ShouldMapCorrectly()
        {
            var boardGame = new BoardGame
            {
                Name = "Test Game",
                Genre = "Strategy",
                Price = 100,
                MinAge = 10,
                Publisher = "Test Publisher",
                Description = "Test Description"
            };

            var model = _mapper.Map<BoardGameModel>(boardGame);

            Assert.AreEqual(boardGame.Name, model.Name);
            Assert.AreEqual(boardGame.Genre, model.Genre);
            Assert.AreEqual(boardGame.Price, model.Price);
            Assert.AreEqual(boardGame.MinAge, model.MinAge);
            Assert.AreEqual(boardGame.Publisher, model.Publisher);
            Assert.AreEqual(boardGame.Description, model.Description);
        }

        [Test]
        public void CreateMap_CreateBoardGameModelToBoardGame_ShouldHaveValidConfig()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void CreateMap_CreateBoardGameModelToBoardGame_ShouldMapCorrectly()
        {
            var createModel = new CreateBoardGameModel
            {
                Name = "Test Game",
                Genre = "Strategy",
                Price = 100,
                MinAge = 10,
                Publisher = "Test Publisher",
                Description = "Test Description"
            };

            var boardGame = _mapper.Map<BoardGame>(createModel);

            Assert.AreEqual(createModel.Name, boardGame.Name);
            Assert.AreEqual(createModel.Genre, boardGame.Genre);
            Assert.AreEqual(createModel.Price, boardGame.Price);
            Assert.AreEqual(createModel.MinAge, boardGame.MinAge);
            Assert.AreEqual(createModel.Publisher, boardGame.Publisher);
            Assert.AreEqual(createModel.Description, boardGame.Description);
        }

        [Test]
        public void CreateMap_UpdateBoardGameModelToBoardGame_ShouldHaveValidConfig()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void CreateMap_UpdateBoardGameModelToBoardGame_ShouldMapCorrectly()
        {
            var updateModel = new UpdateBoardGameModel
            {
                Price = 200,
                Description = "Updated Description"
            };

            var boardGame = new BoardGame
            {
                Name = "Original Name",
                Genre = "Original Genre",
                Price = 100,
                MinAge = 10,
                Publisher = "Original Publisher",
                Description = "Original Description"
            };

            _mapper.Map(updateModel, boardGame);

            Assert.AreEqual(updateModel.Price, boardGame.Price);
            Assert.AreEqual(updateModel.Description, boardGame.Description);
            Assert.AreEqual("Original Name", boardGame.Name);
            Assert.AreEqual("Original Genre", boardGame.Genre);
            Assert.AreEqual(10, boardGame.MinAge);
            Assert.AreEqual("Original Publisher", boardGame.Publisher);
        }
    }
}
