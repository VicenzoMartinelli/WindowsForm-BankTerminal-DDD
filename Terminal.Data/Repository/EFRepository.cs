using System;
using System.Linq;
using Terminal.Domain.Interfaces;
using Terminal.Data;
using System.Data.Entity;
using Terminal.Domain.Core;
using System.Threading.Tasks;

namespace Terminal.Data.Repository
{
  public class EFRepository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : AbstractEntity<TID>
  {
    protected readonly TerminalContext _db;
    protected readonly DbSet<TEntity> _dbSet;

    public EFRepository(TerminalContext context)
    {
      _db = context;
      _dbSet = _db.Set<TEntity>();
    }

    public virtual void Add(TEntity obj)
    {
      _dbSet.Add(obj);
    }
    public async Task AddAsync(TEntity obj)
    {
      await Task.FromResult(_dbSet.Add(obj));
    }

    public virtual IQueryable<TEntity> GetAll()
    {
      return _dbSet;
    }

    public void Dispose()
    {
      _db.Dispose();
      GC.SuppressFinalize(this);
    }

    public TEntity GetById(TID id)
    {
      return _dbSet.Find(id);
    }
    public Task<TEntity> GetByIdAsync(TID id)
    {
      return _dbSet.FindAsync(id);
    }

    public void Remove(TID id)
    {
      _dbSet.Remove(_dbSet.Find(id));
    }
    public async Task RemoveAsync(TID id)
    {
      await Task.FromResult(_dbSet.Remove(_dbSet.Find(id)));
    }

    public void Update(TEntity obj)
    {
      var entity = _dbSet.Find(obj.Id);

      if (entity == null)
      {
        return;
      }

      _db.Entry(entity).CurrentValues.SetValues(obj);
    }

    public async Task UpdateAsync(TEntity obj)
    {
      var entity = await GetByIdAsync(obj.Id);

      if (entity == null)
      {
        return;
      }

      _db.Entry(entity).CurrentValues.SetValues(obj);
    }
  }
}
