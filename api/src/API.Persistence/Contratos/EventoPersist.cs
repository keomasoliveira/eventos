using System.Threading.Tasks;
using API.Domain;

namespace API.Persistence
{
  public interface EventoPesist
  {


    //EVENTOS
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includeAtracao);
    Task<Evento[]> GetAllEventosAsync(bool includeAtracao);
    Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includeAtracao);

  }
}
