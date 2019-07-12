using BookStore.BusinessLogicLayer.Views.MagazineViews;
using BookStore.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IMagazineService
    {
        Task Delete(int id);
        Task Create(CreateMagazineView createMagazine);
        Task Update(UpdateMagazineView updateMagazine);
        Task<GetAllMagazineView> GetAll();
        Task<GetByIdMagazineView> GetById(int id);
        Task<GetByTitleMagazineView> GetByTitle(string name);
    }
}
