using System.Collections.Generic;

namespace BookStore.DataAccessLayer.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetId(int Id);
        IEnumerable<TEntity> GetAll();
        void Delete(int Id);
    }
}
