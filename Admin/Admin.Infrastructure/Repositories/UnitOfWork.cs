using Admin.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

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

    public void Commit()
    {
    }

    public Task CommitAsync()
    {
    }

    public void Dispose()
    {
    }
}
