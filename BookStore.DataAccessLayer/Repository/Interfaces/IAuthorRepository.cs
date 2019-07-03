using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        void Update(Author author);
        Author Create(Author author);
        Author GetByName(string name);
    }
}
