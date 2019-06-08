using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Models;

namespace Terminal.Data.Repository
{
  public class RepositoryConta : EFRepository<Conta, Guid>, IRepositoryConta
  {
    public RepositoryConta(TerminalContext context)
            : base(context)
    {

    }
  }
}
