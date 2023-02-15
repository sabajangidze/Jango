namespace Admin.Domain.Abstractions;

public interface IEntity<T>
{
    T Id { get; set; }
}
