using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Core;

namespace Terminal.Domain.Interfaces
{
  public interface IRepository<TEntity, TID> : IDisposable where TEntity : AbstractEntity<TID>
  {
    void Add(TEntity obj);
    TEntity GetById(TID id);
    IQueryable<TEntity> GetAll();
    void Update(TEntity obj);
    void Remove(TID id);
    Task AddAsync(TEntity obj);
    Task<TEntity> GetByIdAsync(TID id);
    Task RemoveAsync(TID id);
    Task UpdateAsync(TEntity obj);
  }
}
