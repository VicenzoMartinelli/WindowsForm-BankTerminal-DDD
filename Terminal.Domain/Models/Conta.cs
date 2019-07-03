namespace Terminal.Domain.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using Terminal.Domain.Core;

  public class Conta : AbstractEntity<Guid>
  {
    public Conta()
    {
      this.Lancamentos = new HashSet<Lancamento>();
      this.Id          = Guid.NewGuid();
    }
    [Required(ErrorMessage = "Preencha o limite de crédito!")]
    [DataType(DataType.Currency, ErrorMessage = "Informe um limite de crédito válido!")]
    public decimal LimiteCredito { get; set; }
    public decimal Saldo { get; set; }
    [Required(ErrorMessage = "Preencha o limite de crédito!")]
    [DataType(DataType.DateTime, ErrorMessage = "Informe uma data válida!")]
    public DateTime DataAbertura { get; set; }

    public string Observacoes { get; set; }
    [Required(ErrorMessage = "Preencha o número da conta!")]
    public string NumConta { get; set; }

    [Required(ErrorMessage = "Informe o correntista da conta")]
    public virtual Correntista Correntista { get; set; }
    public virtual ICollection<Lancamento> Lancamentos { get; set; }
  }
}
