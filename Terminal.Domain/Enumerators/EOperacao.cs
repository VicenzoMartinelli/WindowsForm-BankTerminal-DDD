using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Domain.Enumerators
{
  public enum ETipoOperacao
  {
    [Display(Name = "Crédito")]
    Credito = 1,
    [Display(Name = "Débito")]
    Debito = 2
  }
}
