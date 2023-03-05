using Dapper;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Abstractions;

namespace Web.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly WebDapperContext _dpContext;

    public GenericRepository(WebDbContext context)
    {
       _context = context;
        //_dpContext = dpContext;
    }

    public void Add(T entity)
    {
        var set = _context.Set<T>();
        set.Add(entity);
    }

    public async Task AddAsync(T entity)
    {
        var set = _context.Set<T>();
        await set.AddAsync(entity);
    }

    public void Attach(T entity)
    {
        var set = _context.Set<T>();
        set.Attach(entity);

    }

    public void Remove(T entity)
    {
        var set = _context.Set<T>();
        set.Remove(entity);
    }

    public void Update(T entity)
    {
        var set = _context.Set<T>();
        set.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<IEnumerable<T>> Query(string table)
    {
        var query = $"SELECT * FROM {table}";

        using (var connection = _dpContext.CreateConnection())
        {
            var results = await connection.QueryAsync<T>(query);

            return results.ToList();
        }
    }

    public async Task<T> GetById<T>(string table, Guid id) where T : class, IEntity<Guid>
    {
        var query = $"SELECT * FROM {table} WHERE Id = @Id";

        using (var connection = _dpContext.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<T>(query, new { id });

            return result;
        }
    }
}
