namespace Global_Solution_ADB.Infraestructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<int> CompleteAsync() 
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var result = await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return result;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public void Dispose() 
    { 
        _context.Dispose();
    }
}
