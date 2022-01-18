using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
  public class AtracaoInterfacePersistence : AtracaoPersist
  {
    private readonly EventosContext _context;
    public AtracaoInterfacePersistence(EventosContext context)
    {
      _context = context;

    }

    public async Task<Atracao[]> GetAllAtracaoAsync(bool includeEventos)
    {
      IQueryable<Atracao> query = _context.Atracoes
        .Include(e => e.RedeSociais);


      if (includeEventos)
      {
        query
        .Include(e => e.AtracoesEventos)
        .ThenInclude(ae => ae.Evento);
      }

      query = query.OrderBy(e => e.Id);

      return await query.ToArrayAsync();
    }

    public async Task<Atracao> GetAllAtracaoByIdAsync(int atracaoId, bool includeEventos)
    {
      IQueryable<Atracao> query = _context.Atracoes
           .Include(e => e.RedeSociais);

      if (includeEventos)
      {
        query
        .Include(e => e.AtracoesEventos)
        .ThenInclude(ae => ae.Evento);
      }

      query = query
      .OrderBy(e => e.Id)
      .Where(e => e.Id == atracaoId);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<Atracao[]> GetAllAtracaoByNomeAsync(string nome, bool IncludeEventos)
    {
      IQueryable<Atracao> query = _context.Atracoes
            .Include(e => e.RedeSociais);

      if (IncludeEventos)
      {
        query
        .Include(e => e.AtracoesEventos)
        .ThenInclude(ae => ae.Atracao);
      }

      query = query
      .OrderBy(e => e.Id)
      .Where(e => e.Nome.ToLower()
      .Contains(nome.ToLower()));

      return await query.ToArrayAsync();
    }
  }
}
