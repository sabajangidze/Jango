using Admin.Domain.Abstractions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Admin.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public DbContext _context;
    public readonly DapperContext _dpContext;

    public UnitOfWork(DbContext context, DapperContext dpContext)
    {
        _context = context;
        _dpContext = dpContext;
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

    public void Remove<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit
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

    public async Task<IEnumerable<T>> Query<T>(string table) where T : class
    {
        var query = $"SELECT * FROM {table}";

        using (var connection = _dpContext.CreateConnection())
        {
            var results = await connection.QueryAsync<T>(query);

            return results.ToList();
        }
    }

    public async Task<T> GetById<T>(string table, Guid id) where T : class
    {
        var query = $"SELECT * FROM {table} WHERE Id = @Id";

        using (var connection = _dpContext.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<T>(query, new { id });

            return result;
        }
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
