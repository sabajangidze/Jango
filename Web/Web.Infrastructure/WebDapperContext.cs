using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Web.Infrastructure;

public class WebDapperContext
{
    private readonly string? _connectionString;

    public WebDapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("WebDb");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}
