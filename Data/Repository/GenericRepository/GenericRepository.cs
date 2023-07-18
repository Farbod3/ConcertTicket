using Data.MyAppDbContext;
using Data.Repository.IGenericRepository;
using Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _entities;
    public GenericRepository(AppDbContext context) 
    {
        this._context = context;
        this._entities = context.Set<T>();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public T? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}