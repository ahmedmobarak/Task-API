using System.Linq.Expressions;

namespace Task.Task.Dal.Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        int Count();
        void RemoveRange(IEnumerable<T> entities);
    }
}
