﻿using Global_Solution_ADB.Models.Entities;
using Oracle.ManagedDataAccess.Client;
using System.Linq.Expressions;

namespace Global_Solution_ADB.Repositories.Interfaces;

public interface _IRepository<T> where T : _BaseEntity
{
    Task<T> GetByIdAsync(int id); //GET BY ID
    Task<IEnumerable<T>> GetAllAsync(); //GET ALL
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); //FIND
    Task AddAsync(T entity); //CREATE ENTITY
    Task UpdateAsync(T entity); //UPDATE ENTITY
    Task RemoveAsync(int id); //DELETE ENTITY

    Task<T> GetByIdWithRelationsAsync(int id, params Expression<Func<T, object>>[] includes); //GET BY ID WITH RELATIONS
    Task<int> InsertWithProcedureAsync(string procedureName, OracleParameter[] parameters); //CREATE ENTITY BY PROCEDURE
    Task<string> ExecuteToJsonProcedureAsync(string tableName, string idColumn, int idValue); //GENERATE JSON BY PROCEDURE
}
