using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        Task Update( Book book);
        Task Create( Book book);
        Task<Book> GetByTitle(string Title);
    }
}
