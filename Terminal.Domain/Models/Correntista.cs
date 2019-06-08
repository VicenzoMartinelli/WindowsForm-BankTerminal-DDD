using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Core;

namespace Terminal.Domain.Models
{
  public class Correntista : AbstractEntity<int>
  {
    public Correntista()
    {
      this.Contas = new HashSet<Conta>();
    }
    [Required(ErrorMessage = "O C.P.F é obrigatório!")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Informe um cpf válido, o mesmo deve possuir 11 dígitos!")]
    public string CPF { get; set; }
    [Required(ErrorMessage = "Insira o nome do correntista!")]
    public string Nome { get; set; }
    public virtual ICollection<Conta> Contas { get; set; }
  }
}
