using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using BookStore.Shared;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {

        private readonly AppSettings _appsettings;
        public AuthorRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task Create(Author author)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
                {
                    var SqlQuery = "INSERT INTO Authors (Name, CreationDate)  VALUES(@Name,@CreationDate)";
                    var result = await db.ExecuteAsync(SqlQuery, author);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(Author author)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = (@"UPDATE [dbo].[Authors] SET Name = @Name Where Id = @Id");
                var result = await db.ExecuteAsync(SqlQuery, author);
            }
        }
        public async Task<Author> GetByName(string name)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return await db.QuerySingleAsync<Author>($"SELECT * FROM Authors WHERE Name = @Name", new { Name = name });
            }
        }

    }
}
