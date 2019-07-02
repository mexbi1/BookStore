using System;
using BookStore.Shared;
using Microsoft.AspNetCore.Mvc;

using ViewModels.ViewModels;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AppSettings _appsettings;
        public AuthorController(AppSettings appsettings)
        {
            _appsettings = appsettings;
        }
        [HttpGet]
        public GetAuthorViewModel Get(int Id)
        {
            throw new NotImplementedException();
        }
        public GetAllAuthorViewModel GetAll()
        {
            throw new NotImplementedException();
        }
        public void Create(CreateAuthorViewModel createAuthorViewModel)
        {
            throw new NotImplementedException();
        }
        public void  Delete( int Id)
        {
            throw new NotImplementedException();
        }
        public UpdateAuthorViewModel Update(UpdateAuthorViewModel update)
        {
            throw new NotImplementedException();
        }
         
    }
}