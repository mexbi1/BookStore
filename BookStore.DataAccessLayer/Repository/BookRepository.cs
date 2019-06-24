using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookStore.DataAccessLayer.Repository
{
    class BookRepository : IBookRepository
    {
        string connectionString = null;
        public BookRepository(string conn)
        {
            connectionString = conn;
        }

        public List<Book> GetAllBooks()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT * FROM Books").ToList();
            }
        }
        public Book Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Book>("SELECT * FROM Books WHERE id = @Id", new { id = Id }).FirstOrDefault();
            }
        }

        public void Create(Book book)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Books (Title,Price) VALUES(@Title, @Price)";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Author WHERE Id = @id";
                db.Execute(sqlQuery, new { id = Id });
            }
        }

        
    }
}
