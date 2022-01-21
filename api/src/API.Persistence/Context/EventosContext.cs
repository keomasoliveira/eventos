using API.Domain;
using Microsoft.EntityFrameworkCore;


namespace API.Persistence
{
  public class EventosContext : DbContext
  {
    public EventosContext(DbContextOptions<EventosContext> options) : base(options)
    {

    }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Lote> Lotes { get; set; }
    public DbSet<Atracao> Atracoes { get; set; }
    public DbSet<AtracaoEvento> AtracoesEventos { get; set; }
    public DbSet<RedeSocial> RedesSociais { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AtracaoEvento>()
          .HasKey(AE => new { AE.EventoId, AE.AtracaoId });


      modelBuilder.Entity<Evento>()
        .HasMany(e => e.RedesSociais)
        .WithOne(rs => rs.Evento)
        .OnDelete(DeleteBehavior.Cascade);


      modelBuilder.Entity<Atracao>()
       .HasMany(a => a.RedeSociais)
       .WithOne(rs => rs.Atracao)
       .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
