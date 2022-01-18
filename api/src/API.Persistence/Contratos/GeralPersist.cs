using System.Threading.Tasks;
using API.Domain;

namespace API.Persistence
{
  public interface GeralPesist
  {
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void DeleteRange<T>(T entity) where T : class;

    Task<bool> SaveChangesAsync();

  }
}
