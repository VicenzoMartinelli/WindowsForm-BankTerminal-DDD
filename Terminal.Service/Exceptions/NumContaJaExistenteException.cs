using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Service.Exceptions
{
  [Serializable]
  public class NumContaJaExistenteException : Exception
  {
    private readonly string _numConta;
    public NumContaJaExistenteException(string numConta)
    {
      _numConta = numConta;
    }

    public override IDictionary Data => base.Data;

    public override string Message => $"O número da conta {_numConta} já existe!";
  }
}
