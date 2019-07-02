using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
   public interface IMagazineRepository:IGenericRepository<Magazine>
    {
           void Update(Magazine magazine);
           Magazine Create(Magazine magazine);
           Magazine GetTitle(Magazine magazine);
    }
}
