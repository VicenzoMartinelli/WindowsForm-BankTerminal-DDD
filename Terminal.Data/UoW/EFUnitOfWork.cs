using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Interfaces;

namespace Terminal.Data.UoW
{
  public class EFUnitOfWork : IUnitOfWork
  {
    private TerminalContext _context;

    public EFUnitOfWork(TerminalContext context)
    {
      _context = context;
    }

    public bool Commit()
    {
      _context.SaveChanges();
      return true;
    }
    public Task<bool> CommitAsync()
    {
      return Task.FromResult(Commit());
    }

    public void Dispose()
    {
      _context.Dispose();
      GC.Collect();
    }

    public bool RollBack()
    {
      _context.Database.CurrentTransaction?.Rollback();
      return true;
    }
    public Task<bool> RollBackAsync()
    {
      return Task.FromResult(RollBack());
    }
  }
}
