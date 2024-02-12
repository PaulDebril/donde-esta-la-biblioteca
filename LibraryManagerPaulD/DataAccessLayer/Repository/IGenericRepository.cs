using BusinessObjects;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T : AEntity
    {
        T Get(int TId);
        IEnumerable<T> GetAll();
    }
}
