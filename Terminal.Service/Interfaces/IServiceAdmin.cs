using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Models;

namespace Terminal.Service.Interfaces
{
  public interface IServiceAdmin
  {
    Task<bool> CriarConta(Conta model);
    Task<bool> CriarCorrentista(Correntista model);
    IEnumerable<Correntista> GetCorrentistas();
  }
}
