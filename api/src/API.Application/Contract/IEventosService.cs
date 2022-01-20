using System.Threading.Tasks;
using API.Domain;

namespace API.Application.Contract
{
  public interface IEventosService
  {
    Task<Evento> AddEvento(Evento model);
    Task<Evento> UpdateEvento(int eventoId, Evento model);
    Task<bool> DeleteEvento(int eventoId);

    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includeAtracao = false);
    Task<Evento[]> GetAllEventosAsync(bool includeAtracao = false);
    Task<Evento> GetEventoByIdAsync(int eventoId, bool includeAtracao = false);
  }
}
