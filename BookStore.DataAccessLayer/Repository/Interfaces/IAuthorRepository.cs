using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> Update(Author author);
        Task<Author> Create(Author author);
        Task<Author> GetByName(string name);
    }
}
