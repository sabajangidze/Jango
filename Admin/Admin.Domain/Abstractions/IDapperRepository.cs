namespace Admin.Domain.Abstractions;

public interface IDapperRepository
{
    Task<IEnumerable<T>> Query<T>(string table) where T : class;

    Task<T> GetById<T>(string table, Guid id) where T : class;
}
