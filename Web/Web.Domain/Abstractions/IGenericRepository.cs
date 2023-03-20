namespace Web.Domain.Abstractions;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(string table, Guid id, CancellationToken cancellationToken = default);

    void Add(T entity);

    Task AddAsync(T entity);

    void Update(T entity);

    void Attach(T entity);

    void Remove(T entity);

    Task<IEnumerable<T>> Query(string table);

    Task<T> GetById(string table, Guid id);
}
