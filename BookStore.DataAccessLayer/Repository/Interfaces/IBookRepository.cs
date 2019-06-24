using BookStore.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
   public interface IBookRepository
    {
        void Create(Book book);
        void Delete(int Id);
        Book Get(int Id);
        List<Book> GetAllBooks();
        void Update(int Id, Book Title, Book Price);
    }
}
