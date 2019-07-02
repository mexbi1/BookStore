using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels.ViewModels;

namespace BookStore.BusinessLogicLayer.Services
{
    public class AuthorService:IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {  
            _authorRepository = authorRepository;
        }

        public GetAuthorViewModel Get(int Id)
        {
            Author author1 = _authorRepository.Get(Id);
            GetAuthorViewModel getAuthor = new GetAuthorViewModel();
            getAuthor.Name = author1.Name;
            return getAuthor;
        }

        public GetAllAuthorViewModel GetAll()
        {
            var authors = _authorRepository.GetAll().Select(x => new AuthorGetAllAuthorViewModelItem { Name = x.Name }).ToList();
            return new GetAllAuthorViewModel() { authorGetAllAuthor = authors };
        }
        public void Create(CreateAuthorViewModel createAuthor)
        {
            {
                _authorRepository.Create(new Author() { Name = createAuthor.Name });
            }
        }

        public UpdateAuthorViewModel Update(UpdateAuthorViewModel authorViewModel)
        {
            _authorRepository.Update(new Author { Name = authorViewModel.Name });
            return authorViewModel;
        }

        public void Delete(int Id)
        {
            _authorRepository.Delete(Id);
        }
        public GetNameAuthorViewModel GetByName(GetNameAuthorViewModel getNameAuthor)
        {
            Author authors = _authorRepository.GetByName(getNameAuthor.Name);
            GetNameAuthorViewModel getName = new GetNameAuthorViewModel();
            return getName;

        }

    }
}
