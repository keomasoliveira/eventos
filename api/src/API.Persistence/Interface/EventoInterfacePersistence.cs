using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
  public class EventoInterfacePersistence : EventoPersist
  {
    private readonly EventosContext _context;
    public EventoInterfacePersistence(EventosContext context)
    {
      _context = context;
      _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }

    public async Task<Evento[]> GetAllEventosAsync(bool includeAtracao = false)
    {
      IQueryable<Evento> query = _context.Eventos
      .Include(e => e.Lotes)
      .Include(e => e.RedesSociais);


      if (includeAtracao)
      {
        query
        .Include(e => e.AtracoesEventos)
        .ThenInclude(ae => ae.Atracao);
      }

      query = query.OrderBy(e => e.Id);

      return await query.ToArrayAsync();
    }
    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includeAtracao = false)
    {
      IQueryable<Evento> query = _context.Eventos
    .Include(e => e.Lotes)
    .Include(e => e.RedesSociais);


      if (includeAtracao)
      {
        query
        .Include(e => e.AtracoesEventos)
        .ThenInclude(ae => ae.Atracao);
      }

      query = query
      .OrderBy(e => e.Id)
      .Where(e => e.Tema.ToLower()
      .Contains(tema.ToLower()));

      return await query.ToArrayAsync();
    }
    public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includeAtracao = false)
    {
      {
        IQueryable<Evento> query = _context.Eventos
      .Include(a => a.Lotes)
      .Include(a => a.RedesSociais);


        if (includeAtracao)
        {
          query
          .Include(a => a.AtracoesEventos)
          .ThenInclude(ae => ae.Atracao);
        }

        query = query
        .OrderBy(e => e.Id)
        .Where(e => e.Id == eventoId);

        return await query.FirstOrDefaultAsync();
      }
    }
  }
}
