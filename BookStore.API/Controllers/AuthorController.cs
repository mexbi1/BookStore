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
        public async Task<IActionResult> GetId(int id)
        {
            GetByIdAuthorViews getIdAuthor = await _authorService.GetById(id);
            return Ok(getIdAuthor.Name);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllAuthorViews getAllAuthors = await _authorService.GetAll();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetByName(string name)
        {
            GetByNameAuthorViews getByNameAuthor = await _authorService.GetByName(name);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorViews createAuthor)
        {
           var result = await _authorService.Create(createAuthor);
            return Ok(createAuthor);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorViews update)
        {
            await _authorService.Update(update);
            return Ok();
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await  _authorService.Delete(id);
            return Ok();
        }
    }
}