using System.Threading.Tasks;
using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.MagazineViews;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MagazineController : Controller
    {
        private readonly IMagazineService _magazineService;

        public MagazineController(IMagazineService magazineService)
        {
            _magazineService = magazineService;
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdMagazineView getById = await _magazineService.GetById(id);
            return Ok(getById);
        }
        [HttpGet]
        public async Task<IActionResult> GetByTitle(string title)
        {
            GetByTitleMagazineView getByTitle = await _magazineService.GetByTitle(title);
            return Ok(getByTitle);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllMagazineView getMagazine = await _magazineService.GetAll();
            return Ok(getMagazine);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateMagazineView createMagazine)
        {
            await _magazineService.Create(createMagazine);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMagazineView updateMagazine)
        {
            await _magazineService.Update(updateMagazine);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _magazineService.Delete(id);
            return Ok();
        }
    }
}