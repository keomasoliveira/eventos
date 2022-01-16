using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Domain
{

  public class Eventos

  {
    public int Id { get; set; }
    public int EventoId { get; set; }
    public string Tema { get; set; }
    public string Local { get; set; }
    public string Foto { get; set; }
    public int QtdPessoas { get; set; }
    public DateTime DataEvento { get; set; }

    public string Telefone { get; set; }
    public string Email { get; set; }

    public IEnumerable<Lote> Lote { get; set; }
    public IEnumerable<RedeSocial> RedesSociais { get; set; }
    public IEnumerable<AtracaoEvento> AtracoesEventos { get; set; }




  }
}