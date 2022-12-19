using System.Linq.Expressions;

namespace Task.Task.Dal.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        void IBaseRepository<T>.Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        void IBaseRepository<T>.AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        IEnumerable<T> IBaseRepository<T>.Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        IEnumerable<T> IBaseRepository<T>.GetAll()
        {
            return _context.Set<T>().ToList();
        }

        T IBaseRepository<T>.GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        void IBaseRepository<T>.Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        void IBaseRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        int IBaseRepository<T>.Count()
        {
            return _context.Set<T>().Count();
        }
    }
}
