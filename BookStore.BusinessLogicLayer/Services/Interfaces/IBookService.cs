using BookStore.BusinessLogicLayer.Views.BookViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task<GetByIdBookView> GetById(int id);
        Task<GetByTitleBookView> GetByTitle(string title);
        Task<GetAllBookView> GetAll();
        Task Create(CreateBookView createBook);
        Task Delete(int id);
        Task Update(UpdateBookView updateBook);
    }
}
