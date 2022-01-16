using System.Collections.Generic;

namespace API.Domain
{
  public class Atracao
  {
    public int Id { get; set; }
    public string Nome { get; set; }

    public string TipoAtracao { get; set; }

    public string ImagemURL { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public IEnumerable<RedeSocial> RedeSociais { get; set; }

    public IEnumerable<AtracaoEvento> AtracoesEventos { get; set; }
  }
}
