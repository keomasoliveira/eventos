using System.Threading.Tasks;
using API.Domain;

namespace API.Persistence
{
  public interface EventoPersist
  {


    //EVENTOS
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includeAtracao);
    Task<Evento[]> GetAllEventosAsync(bool includeAtracao);
    Task<Evento> GetEventoByIdAsync(int EventoId, bool includeAtracao);

  }
}
