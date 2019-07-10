using BookStore.BusinessLogicLayer.Views.MagazineViewsService;
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
        Task<CreateMagazineViews> Create(CreateMagazineViews createMagazine);
        Task<UpdateMagazineViews> Update(UpdateMagazineViews updateMagazine);
        Task<GetAllMagazineViews> GetAll();
        Task<GetByIdMagazineViews> GetById(int id);
        Task<GetByNameMagazineViews> GetTitle(string name);
    }
}
