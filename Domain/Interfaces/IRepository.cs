using Domain.Primitives;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> List();
        IEnumerable<T> List(ISpecification<T> specification);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
