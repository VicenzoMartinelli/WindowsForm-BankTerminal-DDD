using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Models;

namespace Terminal.Service.Interfaces
{
  public interface IServiceOperacoes
  {
    void Sacar(Conta conta, decimal valor);
    Task SacarAsync(Conta conta, decimal valor);

    void Transferir(Conta contaOrigem, Conta contaDestino, decimal valor);
    Task TransferirAsync(Conta contaOrigem, Conta contaDestino, decimal valor);

    IEnumerable<Lancamento> GetExtrato(Conta conta, int margemDias = 30);
    Task<IEnumerable<Lancamento>> GetExtratoAsync(Conta conta, int margemDias = 30);
    Conta GetContaByCpfAndNumConta(string cpf, string numConta);
    Task<Conta> GetContaByCpfAndNumContaAsync(string cpf, string numConta);
  }
}
