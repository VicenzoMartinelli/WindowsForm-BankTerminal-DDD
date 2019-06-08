using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Domain.Core
{
  public abstract class EntityBase
  {
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataAlteracao { get; set; }
  }
}
