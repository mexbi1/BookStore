using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System.Linq;

namespace BookStore.BusinessLogicLayer.Services
{
    public class AuthorService:IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {  
            _authorRepository = authorRepository;
        }

        public GetIdAuthorViews GetId(int Id)
        {
            Author author1 = _authorRepository.GetId(Id);
            GetIdAuthorViews getAuthor = new GetIdAuthorViews();
            getAuthor.Name = author1.Name;
            return getAuthor;
        }
        public GetByNameAuthorViews GetByName(string name)
        {
            Author authors = _authorRepository.GetByName(name);
            GetByNameAuthorViews getByName = new GetByNameAuthorViews();
            return getByName;
        }
        public GetAllAuthorViews GetAll()
        {
            var authors = _authorRepository.GetAll().Select(x => new AuthorGetAllAuthorViewsItem { Name = x.Name }).ToList();
            return new GetAllAuthorViews() { AllAuthorViews = authors };
        }
        public void Create(CreateAuthorViews createAuthor)
        {
            {
                _authorRepository.Create(new Author() { Name = createAuthor.Name });
            }
        }
        public UpdateAuthorViews Update(UpdateAuthorViews authorViews)
        {
            _authorRepository.Update(new Author { Name = authorViews.Name });
            return authorViews;
        }
        public void Delete(int Id)
        {
            _authorRepository.Delete(Id);
        }
      }
}
