namespace Web.Domain.Abstractions;

public interface ITransaction : IDisposable
{
    void Commit();

    void RollBack();
}
