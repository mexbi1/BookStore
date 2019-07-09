using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class AuthorService:IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {  
            _authorRepository = authorRepository;
        }

        public async Task<GetByIdAuthorViews> GetById(int Id)
        {
            Author result = await _authorRepository.GetId(Id);
            GetByIdAuthorViews getAuthor = new GetByIdAuthorViews();
            getAuthor.Name =  result.Name;
            return getAuthor;
        }
        public async Task<GetByNameAuthorViews> GetByName(string name)
        {
            Author result = await _authorRepository.GetByName(name);
            GetByNameAuthorViews getByName = new GetByNameAuthorViews();
            getByName.Name = result.Name;
            return getByName;
        }
        public async Task <GetAllAuthorViews> GetAll()
        {
            var result = await _authorRepository.GetAll().Select(x => new AuthorGetAllAuthorViewsItem { Name = x.Name }).ToList();
            return new GetAllAuthorViews() { AllAuthorViews = result };
        }
        public async Task Create(CreateAuthorViews createAuthor)
        {
            {
               await  _authorRepository.Create(new Author() { Name = createAuthor.Name });
            }
        }
        public async Task<UpdateAuthorViews> Update(UpdateAuthorViews authorViews)
        {
           await _authorRepository.Update(new Author { Name = authorViews.Name });
            return authorViews;
        }
        public async Task Delete(int Id)
        {
          await  _authorRepository.Delete(Id);
        }
      }
}
