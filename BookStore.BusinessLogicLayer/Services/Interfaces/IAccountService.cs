using BookStore.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
   public interface IAccountService
    {
        User Authenticate(string name, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
