using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Global_Solution_ADB.Repositories.Implementations;

public class _Repository<T> : _IRepository<T> where T : _BaseEntity
{
    protected readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public _Repository(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id) 
    {
        try
        {
            return await _entities.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with {id} not found.");
        }
        catch (Exception ex) 
        {
            //Log exception
            throw new ApplicationException($"Error retrieving entity with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync() 
        => await _entities.ToListAsync();

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _entities.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        var serachId = await GetByIdAsync(entity.Id);
        if (serachId == null) {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveAsync(int id)
    {
        var searchId = await GetByIdAsync(id);
        if (searchId != null) { 
            _entities.Remove(searchId);
            await _context.SaveChangesAsync();
        }
    }
}
