using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Web.Domain.Abstractions;

namespace Web.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly WebDapperContext _dpContext;
    private readonly IRedisCacheService _redisCacheService;

    public GenericRepository(WebDbContext context, WebDapperContext dpContext, IRedisCacheService redisCacheService)
    {
        _redisCacheService = redisCacheService;
       _context = context;
       _dpContext = dpContext;
    }

    public async Task<T> GetByIdAsync(string table, Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"member-{id}";

        var cachedMember = await _redisCacheService.Get<T>(key, cancellationToken);
        T value;

        if (cachedMember == null)
        {
            value = await GetById(table, id);

            if (value is null)
            {
                return value;
            }

            await _redisCacheService.Set(key, value);

            return value;
        }

        return cachedMember;
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

    public async Task<T> GetById(string table, Guid id)
    {
        var query = $"SELECT * FROM {table} WHERE {table}.\"Id\" = @Id";

        using (var connection = _dpContext.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<T>(query, new { id });

            return result;
        }
    }
}
