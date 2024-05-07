using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Logic.Database;
using Logic.Database.Models;

namespace Logic.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBase
{
    public PgDbContext Context { get; }
    public DbSet<TEntity> DbSet { get; }

    public Repository(PgDbContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }

    public void Save()
    {
        Context.SaveChanges();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        return (await DbSet.AddAsync(entity)).Entity;
    }

    public TEntity Add(TEntity entity)
    {
        return DbSet.Add(entity).Entity;
    }

    public async Task<TEntity> AddSaveAsync(TEntity entity)
    {
        entity = await AddAsync(entity);
        await SaveAsync();
        return entity;
    }

    public TEntity AddSave(TEntity entity)
    {
        entity = Add(entity);
        Save();
        return entity;
    }

    public async Task UpdateSaveAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.Now;
        Update(entity);
        await SaveAsync();
    }
    
    public void UpdateRange(List<TEntity> entities)
    {
        var updateRange = entities.ToList();
        var currentTime = DateTime.Now;
        foreach (var entity in entities)
        {
            entity.UpdatedAt = currentTime;
        }

        DbSet.UpdateRange(updateRange);
    }

    public async Task UpdateRangeSaveAsync(List<TEntity> entities)
    {
        var updateRangeSaveAsync = entities.ToList();
        var currentTime = DateTime.Now;
        foreach (var entity in entities)
        {
            entity.UpdatedAt = currentTime;
        }

        DbSet.UpdateRange(updateRangeSaveAsync);
        await SaveAsync();
    }

    public void UpdateSave(TEntity entity)
    {
        Update(entity);
        Save();
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.Now;
        DbSet.Update(entity);
    }

    public List<TEntity> List()
    {
        return DbSet.ToList();
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return DbSet.Where(expression);
    }

    public async Task<int> RowsCountAsync()
    {
        return await DbSet.CountAsync();
    }

    public int RowsCount()
    {
        return DbSet.Count();
    }

    public async Task<IEnumerable<TEntity>> AddRangeSaveAsync(IEnumerable<TEntity> entities)
    {
        var addRangeSaveAsync = entities.ToList();

        await AddRangeAsync(addRangeSaveAsync);
        await SaveAsync();
        return addRangeSaveAsync;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        var addRangeAsync = entities.ToList();

        await DbSet.AddRangeAsync(addRangeAsync);
        return addRangeAsync;
    }

    public IEnumerable<TEntity> AddRangeSave(IEnumerable<TEntity> entities)
    {
        var addRangeSaveAsync = entities.ToList();

        AddRange(addRangeSaveAsync);
        Save();
        return addRangeSaveAsync;
    }

    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
    {
        var addRangeAsync = entities.ToList();

        DbSet.AddRangeAsync(addRangeAsync);
        return addRangeAsync;
    }

    public void DeleteSave(TEntity entity)
    {
        Delete(entity);
        Save();
    }

    public async Task DeleteSaveAsync(TEntity entity)
    {
        Delete(entity);
        await SaveAsync();
    }

    public void DeleteRange(List<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public async Task DeleteRangeSaveAsync(List<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
        await SaveAsync();
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

}