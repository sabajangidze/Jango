namespace Admin.Domain.Abstractions;

public interface ITransaction : IDisposable
{
    void Commit();

    void RollBack();
}
