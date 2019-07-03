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
    [Required(ErrorMessage = "Preencha o limite de cr�dito!")]
    [DataType(DataType.Currency, ErrorMessage = "Informe um limite de cr�dito v�lido!")]
    public decimal LimiteCredito { get; set; }
    public decimal Saldo { get; set; }
    [Required(ErrorMessage = "Preencha o limite de cr�dito!")]
    [DataType(DataType.DateTime, ErrorMessage = "Informe uma data v�lida!")]
    public DateTime DataAbertura { get; set; }

    public string Observacoes { get; set; }
    [Required(ErrorMessage = "Preencha o n�mero da conta!")]
    public string NumConta { get; set; }

    [Required(ErrorMessage = "Informe o correntista da conta")]
    public virtual Correntista Correntista { get; set; }
    public virtual ICollection<Lancamento> Lancamentos { get; set; }
  }
}
