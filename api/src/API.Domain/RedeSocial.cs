namespace API.Domain
{
  public class RedeSocial
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string URL { get; set; }
    public int? EventoId { get; set; }
    public EventosList Evento { get; set; }
    public int? AtracaoId { get; set; }
    public Atracao Atracao { get; set; }
  }
}
