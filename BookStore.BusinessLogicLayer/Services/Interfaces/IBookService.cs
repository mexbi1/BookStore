using BookStore.BusinessLogicLayer.Views.BookViewsService;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IBookService
    {
        GetIdBookViews GetId(int id);
        GetByTitleBookViews GetByTitle(string title);
        GetAllBookViews GetAll();
        void Create(CreateBookViews createBook);
        void Delete(int id);
        UpdateBookViews Update(UpdateBookViews updateBook);
    }
}
