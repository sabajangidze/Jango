using System.Data;

namespace Admin.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

    void Commit();

    Task CommitAsync();
}
