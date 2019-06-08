using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Terminal.Domain.Core;
using Terminal.Domain.Enumerators;

namespace Terminal.Domain.Models
{
  public class Lancamento : AbstractEntity<int>
  {
    [Required(ErrorMessage = "Preencha o limite de crédito!")]
    [DataType(DataType.DateTime, ErrorMessage = "Informe uma data válida!")]
    public DateTime Data { get; set; }
    public ETipoOperacao Operacao { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public virtual Conta Conta { get; set; }
  }
}
