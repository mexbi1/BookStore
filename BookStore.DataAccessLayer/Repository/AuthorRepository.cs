﻿using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookStore.DataAccessLayer.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
         
        string connectionString = null;

        public AuthorRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Author> GetAuthors()
        {
            using (IDbConnection db = new SqlConnection(connectionString) )
            {
                return db.Query<Author>("SELECT*FROM Authors").ToList();
            }
        }

        public Author Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Author>("Select * FROM Authors Where Id = @id", new { id = Id }).FirstOrDefault();
            }
        }

        public void  Create(Author author)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Authors (Title) VALUES(@Name,@Age Where id = @Id";
                db.Execute(sqlQuery, author);
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id =@id";
                    db.Execute(sqlQuery, new { id = Id });
            }

        }

       
    }
}
