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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppSettings _appsettings;

        public BookRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task Create(Book book)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var sqlQuery = "INSERT INTO Books (Title,Price,CreationDate) VALUES(@Title, @Price,@CreationDate)";
                var result = await db.ExecuteAsync(sqlQuery, book);
            }
        }

        public async Task Update(Book book)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
                {
                    var SqlQuery = $"UPDATE[dbo].[Books] SET Title = @Title , Price = @Price  WHERE  Id = @Id";
                    var result = await db.ExecuteAsync(SqlQuery, book);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<Book> GetByTitle(string title)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
                {
                    return await db.QuerySingleAsync<Book>($"SELECT * FROM Books WHERE Title = @Title", new { Title = title });
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
