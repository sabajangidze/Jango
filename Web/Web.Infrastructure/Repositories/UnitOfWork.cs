using Microsoft.EntityFrameworkCore;
using System.Data;
using Web.Domain.Abstractions;

namespace Web.Infrastructure.Repositories;

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
