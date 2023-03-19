namespace Web.Domain.Abstractions;

//TODO ჯენერიკის გამოყენება რატო დაგჭირდა?
public interface IGenericRepository<T> where T : class
{
    void Add(T entity);

    Task AddAsync(T entity);

    void Update(T entity);

    void Attach(T entity);

    void Remove(T entity);

    Task<IEnumerable<T>> Query(string table);

    Task<T> GetById<T>(string table, Guid id) where T : class, IEntity<Guid>;
}
