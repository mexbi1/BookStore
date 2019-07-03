using BookStore.Shared;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookStore.DataAccessLayer.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppSettings _appsettings;

        public GenericRepository(AppSettings appsettings)
        {
            _appsettings = appsettings;
        }   

        public IEnumerable<TEntity> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return db.Query<TEntity>($"SELECT * FROM {typeof(TEntity).Name}s").ToList();
            }
        }
        public TEntity GetId(int Id)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return db.QuerySingle<TEntity>($"SELECT * FROM {typeof(TEntity).Name}s WHERE {typeof(TEntity).Name}s Id = {Id}");
            }
        }
        
        public void Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var sqlQuery = $"DELETE FROM {typeof(TEntity).Name}s WHERE {typeof(TEntity).Name}s Id = {Id}";
                db.Execute(sqlQuery);
            }
        }
    }
}
