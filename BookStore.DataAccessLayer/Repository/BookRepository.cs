using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using BookStore.Shared;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.DataAccessLayer.Repository
{
   public  class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppSettings _appsettings;

        public BookRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public Book Create(Book book)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var sqlQuery = "INSERT INTO Books (Title,Price) OUTPUT INSERTED * VALUES(@Title, @Price)";
                return db.QuerySingle<Book>(sqlQuery, book);
            }
        }

        public void Update(Book book)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = $"UPDATE[dbo].[Book] SET Title = @Title AND Price = @Price  WHERE  BookId = @Bookd";
                var result = db.Execute(SqlQuery, book);
            }
        }
        public Book GetTitle(string Title)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return db.QuerySingle<Book>($"SELECT * FROM Books WHERE Title = @Title",new {title = Title});
            }
        }

    }
}
