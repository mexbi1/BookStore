using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using BookStore.Shared;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository
{
   public  class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppSettings _appsettings;

        public BookRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task<Book> Create(Book book)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var sqlQuery = "INSERT INTO Books (Title,Price) OUTPUT INSERTED * VALUES(@Title, @Price)";
                return await db.QuerySingleAsync<Book>(sqlQuery, book);
            }
        }

        public async Task Update(Book book)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = $"UPDATE[dbo].[Book] SET Title = @Title AND Price = @Price  WHERE  BookId = @Bookd";
                var result = await db.ExecuteAsync(SqlQuery, book);
            }
        }
        public async Task<Book> GetTitle(string Title)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return await db.QuerySingleAsync<Book>($"SELECT * FROM Books WHERE Title = @Title",new {title = Title});
            }
        }

    }
}
