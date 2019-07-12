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

    public class MagazineRepository : GenericRepository<Magazine>, IMagazineRepository
    {

        private readonly AppSettings _appsettings;
        public MagazineRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        public async Task Create(Magazine magazine)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                var SqlQuery = "INSERT INTO Magazines (Title,Price,CreationDate) VALUES(@Title,@Price,@CreationDate)";
                var result = await db.ExecuteAsync(SqlQuery, magazine);
            }
        }
        public async Task Update(Magazine magazine)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
                {
                    var SqlQuery = "UPDATE[dbo].[Magazines] SET Price = @Price , Title = @Title WHERE Id = @Id";
                    var result = await db.ExecuteAsync(SqlQuery, magazine);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<Magazine> GetByTitle(string Title)
        {
            using (IDbConnection db = new SqlConnection(_appsettings.ConnectionString))
            {
                return await db.QuerySingleAsync<Magazine>($"SELECT * FROM Magazines WHERE Title = @Title", new { title = Title });
            }
        }
    }
}
