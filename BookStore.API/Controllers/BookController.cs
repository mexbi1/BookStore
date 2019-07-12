using System.Threading.Tasks;
using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.BookViews;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookService.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var result = await _bookService.GetByTitle(title);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookView createBook)
        {
            await _bookService.Create(createBook);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookView updateBook)
        {
            await _bookService.Update(updateBook);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Detele(int id)
        {
            await _bookService.Delete(id);
            return Ok();
        }
    }
}