using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using BookStore.BusinessLogicLayer.Views.MagazineViewsService;
using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class MagazineService : IMagazineService
    { 
        private readonly IMagazineRepository _magazineRepository;

        public async Task<GetByIdMagazineViews> GetById(int id)
        {
            Magazine magazine = await _magazineRepository.GetById(id);
            GetByIdMagazineViews result = new GetByIdMagazineViews();
            result.Id = magazine.MagazineId;
            return result;

        }
        public async Task<GetByNameMagazineViews> GetTitle(string title)
        {
            Magazine magazine = await _magazineRepository.GetTitle(title);
            GetByNameMagazineViews result = new GetByNameMagazineViews();
            result.Title = magazine.Title;
            return result;
        }

        public async Task<GetAllMagazineViews> GetAll()
        {
           var magazines = (await _magazineRepository.GetAll()).Select(x => new MagazineGetAllMagazineViewItem { Title = x.Title,Price = x.Price }).ToList();
            GetAllMagazineViews result = new GetAllMagazineViews();
            result.MagazineItem = magazines;
            return new GetAllMagazineViews() { MagazineItem = magazines };
        }
        public async Task Delete(int id)
        {
            await _magazineRepository.Delete(id);
        }
        public async Task<CreateMagazineViews> Create(CreateMagazineViews createMagazine)
        {
           await _magazineRepository.Create(new Magazine { Title = createMagazine.Title, Price = createMagazine.Price }); ;
            return createMagazine;
        }

        public async Task<UpdateMagazineViews> Update(UpdateMagazineViews updateMagazine)
        {
            await _magazineRepository.Update(new Magazine { Title = updateMagazine.Title, Price = updateMagazine.Price });
            return updateMagazine;
        }
    }
}
