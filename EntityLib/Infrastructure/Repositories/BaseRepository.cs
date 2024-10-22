using EntityLib.Domain.Dtos;
using EntityLib.Domain.Entities;
using EntityLib.Domain.Repositories;
using EntityLib.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EntityLib.Infrastructure.Repositories
{
    public class BaseRepository<TEntity, TContext>(TContext context) : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

        public async Task<TEntity> Create(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Attach(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            var rows = await DbSet.Where(e => e.Id == entity.Id)
                .ExecuteUpdateAsync(setPropertyCalls => setPropertyCalls.SetProperty(e => e.IsDeleted, true));
            return rows >= 1;
        }

        public async Task<List<TEntity>> FindAll(ISpecification<TEntity>? specification = null)
        {
            if (specification != null)
                return await specification.Apply(context.Set<TEntity>()).ToListAsync();
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Paginated<TEntity>> FindPaginated(ISpecification<TEntity> specification, int page = 1,
            int pageSize = 10)
        {
            var total = await specification.Apply(context.Set<TEntity>()).AsNoTracking().CountAsync();
            var items = await specification.Apply(context.Set<TEntity>()).Skip((page - 1) * pageSize).Take(pageSize)
                .ToListAsync();
            return new Paginated<TEntity>()
            {
                Total = total,
                Items = items,
            };
        }

        public async Task<TEntity?> FindFirst(ISpecification<TEntity>? specification = null)
        {
            if (specification != null)
                return await specification.Apply(context.Set<TEntity>()).AsNoTracking().FirstOrDefaultAsync();
            return await DbSet.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}