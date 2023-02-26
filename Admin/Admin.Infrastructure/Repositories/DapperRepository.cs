using Admin.Domain.Abstractions;
using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace Admin.Infrastructure.Repositories;

public class DapperRepository : IDapperRepository
{
    private readonly DapperContext _context;

    public DapperRepository(DapperContext context) => _context = context;

    public async Task<T> GetById<T>(string table, Guid id) where T : class
    {
        var query = $"SELECT * FROM {table} WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<T>(query, new {id});

            return result;
        }
    }

    public async Task<IEnumerable<T>> Query<T>(string table) where T : class
    {
        var query = $"SELECT * FROM {table}";

        using (var connection = _context.CreateConnection())
        {
            var results = await connection.QueryAsync<T>(query);

            return results.ToList();
        }
    }
}
