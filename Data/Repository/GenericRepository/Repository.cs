﻿using System.Linq.Expressions;
using Data.Repository.IGenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.GenericRepository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ConcertTicketDbContext DbContext;
    public DbSet<TEntity?> Entities { get; }
    public virtual IQueryable<TEntity?> Table => Entities;
    public virtual IQueryable<TEntity?> TableNoTracking => Entities.AsNoTracking();

    public Repository(ConcertTicketDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = DbContext.Set<TEntity>();
    }

    #region Async Method

    public virtual async Task<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        return await Entities.FindAsync(ids, cancellationToken);
    }

    public virtual async Task AddAsync(TEntity? entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        if (entity != null) await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken,
        bool saveNow = true)
    {
        await Entities.AddRangeAsync(entities!, cancellationToken).ConfigureAwait(false);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task UpdateAsync(TEntity? entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        if (entity != null) Entities.Update(entity);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken,
        bool saveNow = true)
    {
        Entities.UpdateRange(entities!);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(TEntity? entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        if (entity != null) Entities.Remove(entity);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken,
        bool saveNow = true)
    {
        Entities.RemoveRange(entities!);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Sync Methods

    public virtual TEntity? GetById(params object[] ids)
    {
        return Entities.Find(ids);
    }

    public virtual void Add(TEntity? entity, bool saveNow = true)
    {
        Entities.Add(entity);
        if (saveNow)
            DbContext.SaveChanges();
    }

    public virtual void AddRange(IEnumerable<TEntity?> entities, bool saveNow = true)
    {
        Entities.AddRange(entities);
        if (saveNow)
            DbContext.SaveChanges();
    }

    public virtual void Update(TEntity? entity, bool saveNow = true)
    {
        Entities.Update(entity);
        DbContext.SaveChanges();
    }

    public virtual void UpdateRange(IEnumerable<TEntity?> entities, bool saveNow = true)
    {
        Entities.UpdateRange(entities);
        if (saveNow)
            DbContext.SaveChanges();
    }

    public virtual void Delete(TEntity? entity, bool saveNow = true)
    {
        Entities.Remove(entity);
        if (saveNow)
            DbContext.SaveChanges();
    }

    public virtual void DeleteRange(IEnumerable<TEntity?> entities, bool saveNow = true)
    {
        Entities.RemoveRange(entities);
        if (saveNow)
            DbContext.SaveChanges();
    }

    #endregion

    #region Attach & Detach

    public virtual void Detach(TEntity entity)
    {
        var entry = DbContext.Entry(entity);
        if (entry != null)
            entry.State = EntityState.Detached;
    }

    public virtual void Attach(TEntity? entity)
    {
        if (DbContext.Entry(entity).State == EntityState.Detached)
            Entities.Attach(entity);
    }

    #endregion

    #region Explicit Loading

    public virtual async Task LoadCollectionAsync<TProperty>(TEntity? entity,
        Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken)
        where TProperty : class
    {
        Attach(entity);

        var collection = DbContext.Entry(entity).Collection(collectionProperty);
        if (!collection.IsLoaded)
            await collection.LoadAsync(cancellationToken).ConfigureAwait(false);
    }

    public virtual void LoadCollection<TProperty>(TEntity? entity,
        Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
        where TProperty : class
    {
        Attach(entity);
        var collection = DbContext.Entry(entity).Collection(collectionProperty);
        if (!collection.IsLoaded)
            collection.Load();
    }

    public virtual async Task LoadReferenceAsync<TProperty>(TEntity? entity,
        Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken)
        where TProperty : class
    {
        Attach(entity);
        var reference = DbContext.Entry(entity).Reference(referenceProperty);
        if (!reference.IsLoaded)
            await reference.LoadAsync(cancellationToken).ConfigureAwait(false);
    }

    public virtual void LoadReference<TProperty>(TEntity? entity,
        Expression<Func<TEntity, TProperty>> referenceProperty)
        where TProperty : class
    {
        Attach(entity);
        var reference = DbContext.Entry(entity).Reference(referenceProperty);
        if (!reference.IsLoaded)
            reference.Load();
    }

    #endregion

    public void Dispose()
    {
        DbContext.Dispose();
    }
}