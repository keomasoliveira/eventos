using API.Domain;
using Microsoft.EntityFrameworkCore;


namespace API.Persistence
{
  public class EventosContext : DbContext
  {
    public EventosContext(DbContextOptions<EventosContext> options) : base(options)
    {

    }
    public DbSet<Evento> Eventos { get; private set; }
    public DbSet<Lote> Lotes { get; private set; }
    public DbSet<Atracao> Atracoes { get; private set; }
    public DbSet<AtracaoEvento> AtracoesEventos { get; private set; }
    public DbSet<RedeSocial> RedesSociais { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AtracaoEvento>()
          .HasKey(AE => new { AE.EventoId, AE.AtracaoId });
    }




  }
}
