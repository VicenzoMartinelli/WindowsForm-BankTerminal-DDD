using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Models;
using Terminal.Service.Exceptions;
using Terminal.Service.Interfaces;

namespace Terminal.Service.Services
{
  public class ServiceAdmin : IServiceAdmin
  {
    private readonly IRepositoryCorrentista _repositoryCorrentista;
    private readonly IRepositoryConta _repositoryConta;
    private readonly IUnitOfWork _uow;

    public ServiceAdmin(IRepositoryCorrentista repositoryCorrentista, IRepositoryConta repositoryConta, IUnitOfWork uow)
    {
      _repositoryCorrentista = repositoryCorrentista;
      _repositoryConta = repositoryConta;
      _uow = uow;
    }

    public async Task<bool> CriarCorrentista(Correntista model)
    {
      try
      {
        await _repositoryCorrentista.AddAsync(model);
        await _uow.CommitAsync();

        var ls = _repositoryCorrentista.GetAll().ToList();

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
    public async Task<bool> CriarConta(Conta model)
    {
      if (_repositoryConta.GetAll().Where(x => x.NumConta == model.NumConta).Count() > 0)
        throw new NumContaJaExistenteException(model.NumConta);

      try
      {
        await _repositoryConta.AddAsync(model);
        await _uow.CommitAsync();

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public IEnumerable<Correntista> GetCorrentistas()
    {
      return _repositoryCorrentista.GetAll();
    }
  }
}
