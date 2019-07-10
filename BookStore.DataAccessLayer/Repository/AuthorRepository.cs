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
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {

        private readonly AppSettings _appsettings;
        public AuthorRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task<Author> Create(Author author)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = ("INSERT INTO Authors (Name) UOTPUT INSERTED * VALUES(@Name)");
                return await db.QuerySingleAsync<Author>(SqlQuery, author);
            }
        }
        public async Task<Author> Update(Author author)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = ("@UPDATE[dbo].[Book] SET Name = @Name Where Authorid = @AuthorId");
                return await db.QuerySingleAsync<Author>(SqlQuery, author);
            }
        }
        public async Task<Author> GetByName(string name)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return await db.QuerySingleAsync<Author>($"SELECT * FROM Authors WHERE Name = @Name", new { Name = name});
            }
        }

    }
}
