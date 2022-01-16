using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{

  public class EventosList

  {
    [Key]
    public int EventoId { get; set; }
    public string Tema { get; set; }
    public string Local { get; set; }
    public string Foto { get; set; }
    public string Lote { get; set; }
    public int QtdPessoas { get; set; }
    public DateTime DataEvento { get; set; }

  }
}
