namespace Admin.Domain.Abstractions;

public interface IRedisCacheService
{
    Task<T> Get<T>(string key, CancellationToken cancellationToken);
    Task<T> Set<T>(string key, T value);
}