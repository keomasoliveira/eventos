namespace API.Domain
{
  public class AtracaoEvento
  {
    public int AtracaoId { get; set; }
    public Atracao Atracao { get; set; }
    public int EventoId { get; set; }
    public EventosList Evento { get; set; }
  }
}
