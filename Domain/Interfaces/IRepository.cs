using Domain.Primitives;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> ListAsync(CancellationToken token);
        Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken token);
        Task AddAsync(T entity, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);
        Task EditAsync(T entity, CancellationToken token);
    }
}
