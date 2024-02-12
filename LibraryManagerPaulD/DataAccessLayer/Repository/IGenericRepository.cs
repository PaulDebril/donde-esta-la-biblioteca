using BusinessObjects;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T : AEntity
    {
        T Get(int TId);
        IEnumerable<T> GetAll();
        T Insert(Book book);
        T Update(Book book);
        T Delete(int id);

    }
}
