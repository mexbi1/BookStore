using BookStore.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Delete(int Id);
        Author Get(int Id );
        List<Author> GetAuthors();
        void Update(int Id,Author Name);
    }
}
