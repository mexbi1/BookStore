using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        void Update( Book book);
        Book Create( Book book);
        Book GetTitle(string Title);
    }
}
