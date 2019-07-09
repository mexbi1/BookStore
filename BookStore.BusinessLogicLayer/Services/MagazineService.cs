using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AuthorViewsService;
using BookStore.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services
{
    public class MagazineService: IMagazineService
    {
        private readonly MagazineRepository _magazineRepository;
        public async Task<GetAllAuthorViews> GetAll()
        {
            var result = await _magazineRepository.GetAll();

        }
    }
}
