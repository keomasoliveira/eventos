using System;

namespace API.Domain
{
  public class Lote
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Preco { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public int Quantidade { get; set; }
    public int EventoId { get; set; }
    public Eventos Evento { get; set; }

  }
}
