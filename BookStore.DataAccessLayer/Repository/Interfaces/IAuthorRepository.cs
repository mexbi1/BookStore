using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        void Update(Author author);
        Author Create(Author author);
        Author GetName(Author author);
    }
}
