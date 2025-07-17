

using System.Linq.Expressions;
using BoardGamesDirectory.BusinessLogic.BoardGames.Providers;
using BoardGamesDirectory.BusinessLogic.Tests.Mapper;
using BoardGamesDirectory.DataAccess.Entities;
using BoardGamesDirectory.DataAccess.Repository;
using Moq;

namespace BoardGamesDirectory.BusinessLogic.Tests.BoardGames.Providers;

[TestFixture]
public class BoardGamesProviderTests
{
    [Test]
    public void TestGetAllBoardGames()
    {
        Expression expression = null;
        var repositoryMock = new Mock<IRepository<BoardGame>>();
        repositoryMock.Setup(repository => repository.GetAllAsync(It.IsAny<Expression<Func<BoardGame, bool>>>()).Result)
            .Callback((Expression<Func<BoardGame, bool>> x) => expression = x);
        var boardGamesProvider = new BoardGamesProvider(repositoryMock.Object, MapperHelper.Mapper);
        var result = boardGamesProvider.GetAllBoardGamesAsync().Result;
        
        repositoryMock.Verify(repository => repository
            .GetAllAsync(It.IsAny<Expression<Func<BoardGame, bool>>>()).Result, Times.Once);
    }
}