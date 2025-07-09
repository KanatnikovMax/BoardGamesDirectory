using System.Linq.Expressions;
using BoardGamesDirectory.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesDirectory.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<BoardGamesDirectoryDbContext> _contextFactory;

    public Repository(IDbContextFactory<BoardGamesDirectoryDbContext> contextFactory) =>
        _contextFactory = contextFactory;

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var dbContext = await _contextFactory.CreateDbContextAsync();
        return dbContext.Set<T>().AsNoTracking()
            .ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        using var dbContext = await _contextFactory.CreateDbContextAsync();
        return dbContext.Set<T>().AsNoTracking()
            .Where(predicate)
            .ToList();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        using var dbContext = await _contextFactory.CreateDbContextAsync();
        return await dbContext.Set<T>().AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        using var dbContext = await _contextFactory.CreateDbContextAsync();
        return await dbContext.Set<T>().AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExternalId == id);
    }

    public async Task<T> SaveAsync(T entity)
    {
        using var dbContext = await _contextFactory.CreateDbContextAsync();
        if (await dbContext.Set<T>().AsNoTracking().AnyAsync(x => x.Id == entity.Id))
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        else
        {
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = entity.CreationTime;
            var result = await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }

    public async Task DeleteAsync(T entity)
    {
        using var dbContext = await _contextFactory.CreateDbContextAsync();
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}