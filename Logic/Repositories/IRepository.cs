using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Logic.Database;
using Logic.Database.Models;

namespace Logic.Repositories;

public interface IRepository<TEntity> where TEntity : class, IBase
{
   public PgDbContext Context { get; }
    public DbSet<TEntity> DbSet { get; }

    public Task SaveAsync();


    public void Save();


    public Task<TEntity> AddAsync(TEntity entity);


    public TEntity Add(TEntity entity);


    public Task<TEntity> AddSaveAsync(TEntity entity);


    public TEntity AddSave(TEntity entity);
    public Task UpdateRangeSaveAsync(List<TEntity> entity);
    public void UpdateRange(List<TEntity> entity);


    public Task UpdateSaveAsync(TEntity entity);


    public void UpdateSave(TEntity entity);


    public void Update(TEntity entity);


    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

    public List<TEntity> List();


    public Task<int> RowsCountAsync();


    public int RowsCount();


    public Task<IEnumerable<TEntity>> AddRangeSaveAsync(IEnumerable<TEntity> entities);


    public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);


    public IEnumerable<TEntity> AddRangeSave(IEnumerable<TEntity> entities);


    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

    public void DeleteSave(TEntity entity);

    public Task DeleteSaveAsync(TEntity entity);

    public void DeleteRange(List<TEntity> entity);
    
    public Task DeleteRangeSaveAsync(List<TEntity> entity);

    public void Delete(TEntity entity);
}