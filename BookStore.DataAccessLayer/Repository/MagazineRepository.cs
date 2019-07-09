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

    public class MagazineRepository : GenericRepository<Magazine>, IMagazineRepository
    {

        private readonly AppSettings _appsettings;
        public MagazineRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task<Magazine> Create(Magazine magazine)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery =   "INSERT INTO Magazines (Title,Price) OUTPUT INSERTED * VALUES(@Title,@Price)";
               return await db.QuerySingleAsync<Magazine>(SqlQuery, magazine);
            }
        }
        public async Task Update(Magazine magazine)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = "UPDATE[dbo].[Book] SET Price = @Price AND Title = @Title WHERE MagazineId = @MagazineId";
                var result = await db.ExecuteAsync(SqlQuery, magazine);
            }
        }
        public async Task<Magazine> GetTitle(string Title)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return await db.QuerySingleAsync<Magazine>($"SELECT * FROM Magazines WHERE Title = @Title",new { title = Title});
            }
        }
    }
}
