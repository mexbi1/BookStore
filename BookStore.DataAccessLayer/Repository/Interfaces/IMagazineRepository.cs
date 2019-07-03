using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IMagazineRepository:IGenericRepository<Magazine>
    {
           void Update(Magazine magazine);
           Magazine Create(Magazine magazine);
           Magazine GetTitle(string Title);
    }
}
