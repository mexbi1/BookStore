using BookStore.BusinessLogicLayer.Views.AuthorViews;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<GetByIdAuthorView> GetById(int id);
        Task<GetAllAuthorView> GetAll();
        Task<GetByNameAuthorView> GetByName(string name);
        Task Create(CreateAuthorView createAuthorViews);
        Task Delete(int Id);
        Task Update(UpdateAuthorView updateAuthorView);
    }
}
