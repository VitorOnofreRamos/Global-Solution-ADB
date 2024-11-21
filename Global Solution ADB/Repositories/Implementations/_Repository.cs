using Global_Solution_ADB.Infraestructure;
using Global_Solution_ADB.Models.Entities;
using Global_Solution_ADB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
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
        if (serachId != null) {
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

    public async Task<T> GetByIdWithRelationsAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _entities;

        foreach (var include in includes)
        { 
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public async Task<int> InsertWithProcedureAsync(string procedureName, OracleParameter[] parameters)
    {
        using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
        {
            await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = procedureName;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adicionar os parâmetros
                command.Parameters.AddRange(parameters);

                // Parâmetro para capturar o ID gerado
                var outputId = new OracleParameter("p_id", OracleDbType.Int32)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(outputId);

                // Executar a Procedure
                await command.ExecuteNonQueryAsync();

                //Capturar o valor do ID retornado
                if (outputId.Value is Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal)
                {
                    return oracleDecimal.ToInt32(); //Converte para int
                }

                throw new InvalidCastException("Falha ao converter o valor retornado para int.");
            }
        }
    }

    public async Task<string> ExecuteToJsonProcedureAsync(string tableName, string idColumn, int idValue)
    {
        using (var connection = _context.Database.GetDbConnection())
        {
            await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "TO_JSON";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Adiciona os parâmetros da procedure
                command.Parameters.Add(new OracleParameter("p_table_name", tableName));
                command.Parameters.Add(new OracleParameter("p_id_column", idColumn));
                command.Parameters.Add(new OracleParameter("p_id_value", idValue));

                // Define o parâmetro de saída
                var outputJson = new OracleParameter("p_json_output", OracleDbType.Clob)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(outputJson);

                // Executa a procedure
                await command.ExecuteNonQueryAsync();

                // Captura e converte o CLOB para string
                if (outputJson.Value is Oracle.ManagedDataAccess.Types.OracleClob clob)
                {
                    return clob.IsNull ? string.Empty : clob.Value.ToString();
                }

                throw new InvalidOperationException("Erro ao processar o retorno da procedure TO_JSON.");
            }
        }
    }
}
