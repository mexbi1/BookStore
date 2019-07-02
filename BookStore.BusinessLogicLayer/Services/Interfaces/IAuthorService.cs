using BookStore.DataAccessLayer.Models;
using System.Collections.Generic;
using ViewModels.ViewModels;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
  public  interface IAuthorService
    {
        GetAuthorViewModel Get(int Id);
        GetAllAuthorViewModel  GetAll();
        void Create(CreateAuthorViewModel createAuthorViewModel);
        void Delete(int Id);
        UpdateAuthorViewModel Update(UpdateAuthorViewModel updateAuthorView);
    }
}
