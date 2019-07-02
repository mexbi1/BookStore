using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using BookStore.Shared;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookStore.DataAccessLayer.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {

        private readonly AppSettings _appsettings;
        public AuthorRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public Author Create(Author author)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = ("INSERT INTO Authors (Name) UOTPUT INSERTED * VALUES(@Name)");
                return db.QuerySingle<Author>(SqlQuery, author);
            }
        }
        public void Update(Author author)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = ("@UPDATE[dbo].[Book] SET Name = @Name Where Authorid = @AuthorId");
                var result = db.Execute(SqlQuery, author);
            }
        }
        public Author GetName(Author author)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return db.QuerySingle<Author>($"SELECT * FROM Authors WHERE Name = @Name");
            }
        }

    }
}
