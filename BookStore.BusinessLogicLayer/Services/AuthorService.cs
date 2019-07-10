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
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {  
            _authorRepository = authorRepository;
        }

        public async Task<GetByIdAuthorViews> GetById(int Id)
        {
            Author author1 = await _authorRepository.GetById(Id);
            GetByIdAuthorViews result = new GetByIdAuthorViews();
            result.Name = author1.Name;
            return  result;
        }
        public async Task<GetByNameAuthorViews> GetByName(string name)
        {
            Author author = await _authorRepository.GetByName(name);
            GetByNameAuthorViews result = new GetByNameAuthorViews();
            result.Name = author.Name;
            return result;
        }
        public async Task<GetAllAuthorViews> GetAll()
        {
            var authors = (await _authorRepository.GetAll()).Select(x => new AuthorGetAllAuthorViewsItem { Name = x.Name }).ToList();
            return new GetAllAuthorViews() { Authors = authors };
        }
        public async Task<CreateAuthorViews> Create(CreateAuthorViews createAuthor)
        {
            {
              Author author = await _authorRepository.Create(new Author() { Name = createAuthor.Name });
                CreateAuthorViews result = new CreateAuthorViews();
                result.Name = author.Name;

                return result;
            }
        }
        public async Task<UpdateAuthorViews> Update(UpdateAuthorViews authorViews)
        {
           Author author = await _authorRepository.Update(new Author { Name = authorViews.Name });
            UpdateAuthorViews result = new UpdateAuthorViews();
            result.Name = author.Name;
            return result;
        }
        public async Task Delete(int Id)
        {
           await _authorRepository.Delete(Id);
        }
      }
}
