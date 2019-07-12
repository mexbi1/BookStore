using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViews;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdAuthorView getIdAuthor = await _authorService.GetById(id);
            return Ok(getIdAuthor);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllAuthorView getAllAuthors = await _authorService.GetAll();
            return Ok(getAllAuthors);
        }
        [HttpGet]
        public async Task<IActionResult> GetByTitle(string name)
        {
            GetByNameAuthorView getByNameAuthor = await _authorService.GetByName(name);
            return Ok(getByNameAuthor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorView createAuthor)
        {
            await _authorService.Create(createAuthor);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorView update)
        {
            await _authorService.Update(update);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.Delete(id);
            return Ok();
        }
    }
}