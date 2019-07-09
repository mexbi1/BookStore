using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using BookStore.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            GetByIdAuthorViews getIdAuthor = _authorService.GetById(id);
            return Ok(_authorService.GetById(id));
        }
        [HttpGet]
        public  IActionResult GetAll()
        {
            GetAllAuthorViews getAllAuthors = _authorService.GetAll();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            GetByNameAuthorViews getByNameAuthor = _authorService.GetByName(name);
            return Ok();
        }
        [HttpPost]
        public void Create(CreateAuthorViews createAuthor)
        {
           _authorService.Create(createAuthor);
        }
        [HttpPut]
        public  IActionResult Update(UpdateAuthorViews update)
        {
            _authorService.Update(update);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);
            return Ok();
        }
    }
}