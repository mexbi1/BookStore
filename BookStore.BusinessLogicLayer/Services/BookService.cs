using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.BookViews;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using BookStore.DataAccessLayer.Models;

namespace BookStore.BusinessLogicLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookrepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookrepository = bookRepository;
        }

        public async Task<GetByIdBookView> GetById(int id)
        {
            var book = await _bookrepository.GetById(id);
            var result = new GetByIdBookView();
            result.Id = book.Id;
            result.Title = book.Title;
            result.Price = book.Price;
            return result;
        }
        public async Task<GetAllBookView> GetAll()
        {
            var allbooks = (await _bookrepository.GetAll()).Select(x => new BookGetAllBookItemView { Id = x.Id, Title = x.Title, Price = x.Price }).ToList();
            var result = new GetAllBookView() { books = allbooks };
            return result;
        }
        public async Task<GetByTitleBookView> GetByTitle(string title)
        {
            var book = await _bookrepository.GetByTitle(title);
            var result = new GetByTitleBookView();
            result.Id = book.Id;
            result.Title = book.Title;
            result.Price = book.Price;
            return result;
        }
        public async Task Create(CreateBookView createBook)
        {
            await _bookrepository.Create(new Book() { Title = createBook.Title, Price = createBook.Price});
        }
        public async Task Update(UpdateBookView updateBook)
        {
            await _bookrepository.Update(new Book() { Title = updateBook.Title, Price = updateBook.Price, Id = updateBook.Id });
        }
        public async Task Delete(int id)
        {
            await _bookrepository.Delete(id);
        }
    }
}
