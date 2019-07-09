﻿using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
             //User Create(User user);
             //void Update(User user);

    }
}
