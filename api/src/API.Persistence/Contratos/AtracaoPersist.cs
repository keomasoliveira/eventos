using System.Threading.Tasks;
using API.Domain;

namespace API.Persistence
{
  public interface AtracaoPersist
  {
    //ATRAÇÃO
    Task<Atracao[]> GetAllAtracaoByNomeAsync(string tema, bool IncludeEventos);
    Task<Atracao[]> GetAllAtracaoAsync(bool IncludeEventos);
    Task<Atracao> GetAllAtracaoByIdAsync(int AtracaoId, bool IncludeEventos);
  }
}
