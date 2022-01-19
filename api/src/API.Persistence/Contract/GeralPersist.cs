using System.Threading.Tasks;

namespace API.Persistence
{
  public interface GeralPersist
  {
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void DeleteRange<T>(T entity) where T : class;

    Task<bool> SaveChangesAsync();

  }
}
