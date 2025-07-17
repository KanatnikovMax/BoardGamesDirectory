using System.Linq.Expressions;
using AutoMapper;
using BoardGamesDirectory.BusinessLogic.BoardGames.Entities;
using BoardGamesDirectory.BusinessLogic.BoardGames.Exceptions;
using BoardGamesDirectory.BusinessLogic.BoardGames.Managers;
using BoardGamesDirectory.BusinessLogic.Tests.Mapper;
using BoardGamesDirectory.DataAccess.Entities;
using BoardGamesDirectory.DataAccess.Repository;
using Moq;
using FluentAssertions;

namespace BoardGamesDirectory.BusinessLogic.Tests.BoardGames.Managers;

[TestFixture]
public class BoardGamesManagerTests
{
    private Mock<IRepository<BoardGame>> _repositoryMock;
    private IMapper _mapper;
    private BoardGamesManager _boardGamesManager;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<BoardGame>>();
        _mapper = MapperHelper.Mapper;
        _boardGamesManager = new BoardGamesManager(_repositoryMock.Object, _mapper);
    }
    [Test]
    public void BoardGamesManager_CreateBoardGame_Success()
    {
        _repositoryMock.Setup(repository => repository.GetAllAsync(It.IsAny<Expression<Func<BoardGame, bool>>>()))
            .ReturnsAsync(new List<BoardGame>().AsQueryable());
        var externalId = Guid.NewGuid();
        _repositoryMock.Setup(repository => repository.SaveAsync(It.IsAny<BoardGame>()))
            .ReturnsAsync((BoardGame x) =>
            {
                x.Id = 1;
                x.CreationTime = DateTime.Now;
                x.ModificationTime = DateTime.Now;
                x.ExternalId = externalId;
                return x;
            });
        
        var mapper = MapperHelper.Mapper;
        
        var boardGamesManager = new BoardGamesManager(_repositoryMock.Object, mapper);

        var createBoardGameModel = new CreateBoardGameModel
        {
            Name = "DnD",
            Description = "Самая популярная НРИ",
            Genre = "НРИ",
            Publisher = "Hobby World",
            Price = 3999,
            MinAge = 6
        };
        
        var boardGameModel = boardGamesManager.CreateBoardGameAsync(createBoardGameModel).Result;
        
        boardGameModel.Should().NotBeNull();
        boardGameModel.Id.Should().Be(1);
        boardGameModel.ExternalId.Should().Be(externalId);
        boardGameModel.Name.Should().Be(createBoardGameModel.Name);
        boardGameModel.Description.Should().Be(createBoardGameModel.Description);
        boardGameModel.Genre.Should().Be(createBoardGameModel.Genre);
        boardGameModel.Publisher.Should().Be(createBoardGameModel.Publisher);
        boardGameModel.Price.Should().Be(createBoardGameModel.Price);
        boardGameModel.MinAge.Should().Be(createBoardGameModel.MinAge);
        
        _repositoryMock.Verify(repository => repository.SaveAsync(It.IsAny<BoardGame>()), Times.Once);
    }
    
    [Test]
    public async Task BoardGamesManager_DeleteBoardGame_Success()
    {
        var boardGame = new BoardGame
        {
            Id = 1,
            Name = "Test Game"
        };

        _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(boardGame);
        _repositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<BoardGame>())).Returns(Task.CompletedTask);

        await _boardGamesManager.DeleteBoardGameAsync(1);

        _repositoryMock.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<BoardGame>()), Times.Once);
    }

    [Test]
    public void BoardGamesManager_DeleteBoardGame_NotFound()
    {
        _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((BoardGame)null);

        Func<Task> act = async () => await _boardGamesManager.DeleteBoardGameAsync(1);

        act.Should().ThrowAsync<BoardGameNotFoundException>().WithMessage("Board game not found");

        _repositoryMock.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<BoardGame>()), Times.Never);
    }
    
    [Test]
    public async Task BoardGamesManager_UpdateBoardGame_Success()
    {
        var boardGame = new BoardGame
        {
            Id = 1,
            Name = "Name",
            Genre = "Genre",
            Price = 100,
            MinAge = 10,
            Publisher = "Publisher",
            Description = "Description",
            ExternalId = Guid.NewGuid(),
            CreationTime = DateTime.Now,
            ModificationTime = DateTime.Now
        };

        _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(boardGame);
        _repositoryMock.Setup(repo => repo.SaveAsync(It.IsAny<BoardGame>())).ReturnsAsync((BoardGame x) => x);

        var updateBoardGameModel = new UpdateBoardGameModel
        {
            Price = 200,
            Description = "Updated Description"
        };

        var updatedBoardGameModel = await _boardGamesManager.UpdateBoardGameAsync(updateBoardGameModel, 1);

        updatedBoardGameModel.Should().NotBeNull();
        updatedBoardGameModel.Price.Should().Be(updateBoardGameModel.Price);
        updatedBoardGameModel.Description.Should().Be(updateBoardGameModel.Description);
        updatedBoardGameModel.Name.Should().Be(boardGame.Name);
        updatedBoardGameModel.Genre.Should().Be(boardGame.Genre);
        updatedBoardGameModel.MinAge.Should().Be(boardGame.MinAge);
        updatedBoardGameModel.Publisher.Should().Be(boardGame.Publisher);

        _repositoryMock.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        _repositoryMock.Verify(repo => repo.SaveAsync(It.IsAny<BoardGame>()), Times.Once);
    }
}

