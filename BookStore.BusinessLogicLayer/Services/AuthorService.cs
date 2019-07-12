using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViews;
using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<GetByIdAuthorView> GetById(int id)
        {
            Author author1 = await _authorRepository.GetById(id);
            GetByIdAuthorView result = new GetByIdAuthorView();
            result.Id = author1.Id;
            result.Name = author1.Name;
            return result;
        }
        public async Task<GetByNameAuthorView> GetByName(string name)
        {
            Author author = await _authorRepository.GetByName(name);
            var result = new GetByNameAuthorView();
            result.Id = author.Id;
            result.Name = author.Name;
            return result;
        }
        public async Task<GetAllAuthorView> GetAll()
        {
            var authors = (await _authorRepository.GetAll()).Select(x => new AuthorGetAllAuthorViewsItem { Name = x.Name, Id = x.Id }).ToList();
            var result = new GetAllAuthorView() { Authors = authors };
            result.Authors = authors;
            return result;
        }
        public async Task Create(CreateAuthorView createAuthor)
        {
            await _authorRepository.Create(new Author() { Name = createAuthor.Name });
        }
        public async Task Update(UpdateAuthorView authorViews)
        {
            await _authorRepository.Update(new Author { Name = authorViews.Name, Id = authorViews.Id });
        }
        public async Task Delete(int id)
        {
            await _authorRepository.Delete(id);
        }
    }
}
