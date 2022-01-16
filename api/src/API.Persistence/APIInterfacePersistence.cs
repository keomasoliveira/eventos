using System.Threading.Tasks;
using API.Domain;

namespace API.Persistence
{
  public interface APIInterfacePersistence
  {
    void add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void DeleteRange<T>(T entity) where T : class;

    Task<bool> SaveChangesAsync();

    //EVENTOS
    Task<Eventos[]> GetAllEventosByTemaAsync(string tema, bool includeAtracao);
    Task<Eventos[]> GetAllEventosByAsync(bool includeAtracao);
    Task<Eventos> GetAllEventosByIdAsync(string EventoId, bool includeAtracao);
    //ATRAÇÃO
    Task<Atracao[]> GetAllAtracaoByTemaAsync(string tema, bool IncludeEventos);
    Task<Atracao[]> GetAllAtracaoByAsync(bool IncludeEventos);
    Task<Atracao> GetAllAtracaoByIdAsync(string AtracaoId, bool IncludeEventos);
  }
}
