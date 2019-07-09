using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetId(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(int Id);
    }
}
