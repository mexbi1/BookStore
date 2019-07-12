using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.MagazineViews;
using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly IMagazineRepository _magazineRepository;

        public MagazineService(IMagazineRepository magazineRepository)
        {
            _magazineRepository = magazineRepository;
        }

        public async Task<GetByIdMagazineView> GetById(int id)
        {
            Magazine magazine = await _magazineRepository.GetById(id);
            GetByIdMagazineView result = new GetByIdMagazineView();
            result.Id = magazine.Id;
            result.Title = magazine.Title;
            result.Price = magazine.Price;
            return result;
        }
        public async Task<GetByTitleMagazineView> GetByTitle(string title)
        {
            Magazine magazine = await _magazineRepository.GetByTitle(title);
            GetByTitleMagazineView result = new GetByTitleMagazineView();
            result.Id = magazine.Id;
            result.Title = magazine.Title;
            result.Price = magazine.Price;
            return result;
        }

        public async Task<GetAllMagazineView> GetAll()
        {
            var magazines = (await _magazineRepository.GetAll()).Select(x => new MagazineGetAllMagazineViewItem {Id = x.Id, Title = x.Title, Price = x.Price }).ToList();
            GetAllMagazineView result = new GetAllMagazineView();
            result.MagazineItem = magazines;
            return result;
        }
        public async Task Delete(int id)
        {
            await _magazineRepository.Delete(id);
        }
        public async Task Create(CreateMagazineView createMagazine)
        {
            await _magazineRepository.Create(new Magazine { Title = createMagazine.Title, Price = createMagazine.Price }); ;
        }

        public async Task Update(UpdateMagazineView updateMagazine)
        {
            await _magazineRepository.Update(new Magazine {Id = updateMagazine.Id,  Title = updateMagazine.Title, Price = updateMagazine.Price });
        }
    }
}
