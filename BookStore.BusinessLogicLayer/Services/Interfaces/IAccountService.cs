using BookStore.BusinessLogicLayer.Views.AccountViews;
using BookStore.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
   public interface IAccountService
    {
        Task<User> Register(RegisterAccountViews model);
        Task<object> Login(LoginAccountViews model);
    }
}
