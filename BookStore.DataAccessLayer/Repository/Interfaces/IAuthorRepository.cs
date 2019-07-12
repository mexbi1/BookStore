using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task Update(Author author);
        Task Create(Author author);
        Task<Author> GetByName(string name);
    }
}
