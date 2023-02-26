using System.Data;

namespace Admin.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

    void Add<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit;

    Task AddAsync<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit;

    void Update<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit;

    void Attach<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit;

    void Remove<T>(T entity) where T : class, IEntity<Guid>, IEntityAudit;

    void Commit();

    Task CommitAsync();
}
