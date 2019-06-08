using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Models;

namespace Terminal.Data.Repository
{
  public class RepositoryCorrentista : EFRepository<Correntista, int>, IRepositoryCorrentista
  {
    public RepositoryCorrentista(TerminalContext context)
            : base(context)
    {

    }
  }
}
