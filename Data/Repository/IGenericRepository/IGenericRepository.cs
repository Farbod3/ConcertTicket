using Entities.BaseEntity;

namespace Data.Repository.IGenericRepository;

public interface IGenericRepository<T> where T : IBaseEntity
{
    void Add(T entity);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    T? GetById(int id);
    IEnumerable<T> GetAll ();
    Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken);
    void Update(T entity);
    Task UpdateAsync(T entity,CancellationToken cancellationToken);
    void Delete(T entity);
    Task DeleteAsync(T entity);
}