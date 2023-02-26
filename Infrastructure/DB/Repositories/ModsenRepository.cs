using Domain.Interfaces;
using Domain.Primitives;
using Infrastructure.DB.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Repositories
{
    public class ModsenRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ModsenDbContext _dbContext;

        public ModsenRepository(ModsenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity, CancellationToken token = default)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token = default)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity is not null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync(token);
            }
            else
            {
                throw new Exception();
            }

        }

        public async Task EditAsync(T entity, CancellationToken token = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<T>> ListAsync(CancellationToken token = default)
        {
            return await _dbContext.Set<T>().ToListAsync(token);
        }

        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken token = default)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return await secondaryResult
                            .Where(specification.Criteria)
                            .ToListAsync(token);
        }
    }
}
