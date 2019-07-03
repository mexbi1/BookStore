using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using BookStore.Shared;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.DataAccessLayer.Repository
{

    public class MagazineRepository : GenericRepository<Magazine>, IMagazineRepository
    {

        private readonly AppSettings _appsettings;
        public MagazineRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public Magazine Create(Magazine magazine)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = "INSERT INTO Magazines (Title,Price) OUTPUT INSERTED * VALUES(@Title,@Price)";
                return db.QuerySingle<Magazine>(SqlQuery, magazine);
            }
        }
        public void Update(Magazine magazine)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = "UPDATE[dbo].[Book] SET Price = @Price AND Title = @Title WHERE MagazineId = @MagazineId";
                var result = db.Execute(SqlQuery, magazine);
            }
        }
        public Magazine GetTitle(string Title)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return db.QuerySingle<Magazine>($"SELECT * FROM Magazines WHERE Title = @Title",new { title = Title});
            }
        }
    }
}
