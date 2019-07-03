using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Enumerators;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Models;
using Terminal.Service.Exceptions;
using Terminal.Service.Interfaces;

namespace Terminal.Service.Services
{
  public class ServiceOperacoes : IServiceOperacoes
  {
    private readonly IRepositoryConta _repositoryConta;
    private readonly IRepositoryLancamento _repositoryLancamento;
    private readonly IRepositoryCorrentista _repositoryCorrentista;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceOperacoes(
      IRepositoryConta repositoryConta,
      IRepositoryLancamento repositoryLancamento,
      IRepositoryCorrentista repositoryCorrentista,
      IUnitOfWork unitOfWork)
    {
      _repositoryConta       = repositoryConta;
      _repositoryLancamento  = repositoryLancamento;
      _repositoryCorrentista = repositoryCorrentista;
      _unitOfWork            = unitOfWork;
    }

    public Conta GetContaByCpfAndNumConta(string cpf, string numConta)
    {
      return _repositoryConta.GetByCpfAndNumConta(cpf, numConta);
    }

    public Task<Conta> GetContaByCpfAndNumContaAsync(string cpf, string numConta)
    {
      return Task.FromResult(_repositoryConta.GetByCpfAndNumConta(cpf, numConta));
    }

    public IEnumerable<Lancamento> GetExtrato(Conta conta, int margemDias = 30)
    {
      var d1 = DateTime.Now.AddDays(-margemDias).Date;
      var d2 = (DateTime.Now.AddDays(1)).Date;

      return _repositoryLancamento.GetAll()
        .Where(x => x.Conta.Id == conta.Id)
        .Where(x => x.Data >= d1 && x.Data <= d2);
    }

    public Task<IEnumerable<Lancamento>> GetExtratoAsync(Conta conta, int margemDias = 30)
    {
      return Task.FromResult(GetExtrato(conta, margemDias));
    }

    public void Sacar(Conta conta, decimal valor)
    {
      if (valor > conta.Saldo + conta.LimiteCredito)
        throw new SaldoInsuficienteException();

      conta.Saldo -= valor;

      _repositoryConta.Update(conta);

      _repositoryLancamento.Add(new Lancamento
      {
        Conta    = conta,
        Data     = DateTime.Now,
        Operacao = ETipoOperacao.Debito,
        Valor    = valor,
        Descricao= $"Saque de R$ {valor.ToString("0.00")}"
      });

      _unitOfWork.Commit();
    }

    public Task SacarAsync(Conta conta, decimal valor)
    {
      return Task.Run(() => { Sacar(conta, valor); });
    }

    public void Transferir(Conta contaOrigem, Conta contaDestino, decimal valor)
    {
      if (valor > contaOrigem.Saldo + contaOrigem.LimiteCredito)
        throw new SaldoInsuficienteException();

      contaOrigem.Saldo  -= valor;
      contaDestino.Saldo += valor;

      _repositoryConta.Update(contaOrigem);
      _repositoryConta.Update(contaDestino);

      _repositoryLancamento.Add(new Lancamento
      {
        Conta     = contaOrigem,
        Data      = DateTime.Now,
        Operacao  = ETipoOperacao.Debito,
        Valor     = valor,
        Descricao = $"Transferência efetuada de R$ ${valor.ToString("0.00")}"
      });

      _repositoryLancamento.Add(new Lancamento
      {
        Conta     = contaDestino,
        Data      = DateTime.Now,
        Operacao  = ETipoOperacao.Credito,
        Valor     = valor,
        Descricao = $"Transferência recebida de R$ ${valor.ToString("0.00")}"
      });

      _unitOfWork.Commit();
    }

    public Task TransferirAsync(Conta contaOrigem, Conta contaDestino, decimal valor)
    {
      return Task.Run(() => { Transferir(contaOrigem, contaDestino, valor); });
    }
  }
}
