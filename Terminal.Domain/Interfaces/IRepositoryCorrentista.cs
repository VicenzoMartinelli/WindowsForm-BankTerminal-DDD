﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Models;

namespace Terminal.Domain.Interfaces
{
  public interface IRepositoryConta : IRepository<Conta, Guid>
  {
    Conta GetByCpfAndNumConta(string cpf, string numConta);
  }
}
