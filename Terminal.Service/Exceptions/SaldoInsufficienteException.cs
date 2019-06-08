using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Service.Exceptions
{
  [Serializable]
  public class SaldoInsuficienteException : Exception
  {
    public SaldoInsuficienteException()
    {
    }

    public override IDictionary Data => base.Data;

    public override string Message => $"Impossível realizar a operação, o saldo é insuficiente!";
  }
}
