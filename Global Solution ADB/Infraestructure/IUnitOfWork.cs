namespace Global_Solution_ADB.Infraestructure;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}
