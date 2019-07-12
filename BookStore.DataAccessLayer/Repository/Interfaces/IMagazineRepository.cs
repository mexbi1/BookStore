using BookStore.DataAccessLayer.Models;
using BookStore.DataAccessLayer.Repository.GenericRepository;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository.Interfaces
{
    public interface IMagazineRepository:IGenericRepository<Magazine>
    {
           Task Update(Magazine magazine);
           Task Create(Magazine magazine);
           Task <Magazine> GetByTitle(string Title);
    }
}
