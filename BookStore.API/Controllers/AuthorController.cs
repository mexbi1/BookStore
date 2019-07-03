using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using BookStore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly AppSettings _appsettings;
        public AuthorController(AppSettings appsettings)
        {
            _appsettings = appsettings;
        }

        private readonly IAuthorService _authorService;

        [HttpGet("{id?}")]
        public IActionResult GetId(int Id)
        {
            GetIdAuthorViews getIdAuthor =  _authorService.GetId(Id);
            return Ok(_authorService.GetId(Id));
        }   
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllAuthorViews getAllAuthors = _authorService.GetAll();  
            return Ok();
        }
        [HttpGet]
        public IActionResult GetByName(string Name)
        {
            GetByNameAuthorViews getByNameAuthor = _authorService.GetByName(Name);
            return Ok();
        }
        [HttpPost]
        public void Create(CreateAuthorViews createAuthor)
        {
           _authorService.Create(createAuthor);
        }
        [HttpPut]
        public IActionResult Update(UpdateAuthorViews update)
        {
            _authorService.Update(update);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _authorService.Delete(Id);
            return Ok();
        }
    }
}