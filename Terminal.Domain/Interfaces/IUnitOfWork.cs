using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Domain.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    bool Commit();
    Task<bool> CommitAsync();
    bool RollBack();
    Task<bool> RollBackAsync();
  }
}
