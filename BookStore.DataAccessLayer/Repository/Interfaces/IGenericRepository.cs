using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static Dapper.SqlMapper;

namespace BookStore.DataAccessLayer.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        void Delete(int Id);
    }
}
