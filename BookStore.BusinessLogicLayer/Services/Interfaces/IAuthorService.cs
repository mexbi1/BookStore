using BookStore.BusinessLogicLayer.Views.AuthorViewsService;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public  interface IAuthorService
    {
        GetIdAuthorViews GetId(int Id);
        GetAllAuthorViews GetAll();
        void Create(CreateAuthorViews createAuthorViews);
        void Delete(int Id);
        UpdateAuthorViews Update(UpdateAuthorViews updateAuthorView);
        GetByNameAuthorViews GetByName(string name);
    }
}
