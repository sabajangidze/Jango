using Admin.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Admin.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        return new DbTransaction(_context.Database.BeginTransaction());
    }

    public void Add<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit
    {
        var set = _context.Set<T>();
        set.Add(entity);
    }

    public async Task AddAsync<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit
    {
        var set = _context.Set<T>();
        await set.AddAsync(entity);
    }

    public void Attach<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit
    {
        var set = _context.Set<T>();
        set.Attach(entity);
    }

    void IUnitOfWork.Remove<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit
    {
        var set = _context.Set<T>();
        set.Remove(entity);
    }

    public void Update<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit
    {
        var set = _context.Set<T>();
        set.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public IQueryable<T> Query<T>() where T : class, IEntity<Guid>, IEntityAudit
    {
        return _context.Set<T>();
    }

    public async Task<T> GetById<T>(Guid id) where T : class, IEntity<Guid>, IEntityAudit
    {
        var value = _context.Set<T>();
        var entity = await value.FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context = null;
    }
}
