﻿using BookStore.Shared;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppSettings _appsettings;

        public GenericRepository(AppSettings appsettings)
        {
            _appsettings = appsettings;
        }   

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return (await db.QueryAsync<TEntity>($"SELECT * FROM {typeof(TEntity).Name}s")).ToList();
            }
        }
        public async Task<TEntity> GetById(int Id)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return await db.QuerySingleAsync<TEntity>($"SELECT * FROM {typeof(TEntity).Name}s WHERE {typeof(TEntity).Name}s Id = {Id}");
            }
        }
        
        public async Task Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var sqlQuery = $"DELETE FROM {typeof(TEntity).Name}s WHERE {typeof(TEntity).Name}s Id = {Id}";
                var result = await db.ExecuteAsync(sqlQuery);
            }
        }
    }
}
