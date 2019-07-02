using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using BookStore.DataAccessLayer.Repository.Interfaces;
using BookStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStore.DataAccessLayer.Repository
{
    
    public class UserRepository: GenericRepository<User>
    {
        private readonly AppSettings _appsettings;
        public UserRepository(AppSettings appsettings) : base(appsettings)
        {
            _appsettings = appsettings;
        }

        //public User Create(User user)
        //{
        //    return
        ////}
        //public void Update(User user)
        //{

        //}
    }
}
