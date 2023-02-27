using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Admin.Infrastructure;

public class DapperContext
{
    private readonly string? _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionString");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
