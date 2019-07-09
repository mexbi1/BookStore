using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<GetByIdAuthorViews> GetById(int Id);
        Task<GetAllAuthorViews> GetAll();
        Task Create(CreateAuthorViews createAuthorViews);
        Task Delete(int Id);
        Task<UpdateAuthorViews> Update(UpdateAuthorViews updateAuthorView);
        Task<GetByNameAuthorViews> GetByName(string name);
    }
}
