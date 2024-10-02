using EntityLib.Domain.Entities;
using EntityLib.Domain.Specifications;

namespace EntityLib.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task<T> Create(T entity);
    public Task<T> Update(T entity);
    public Task<bool> Delete(T entity);
    public Task<List<T>> FindAll(ISpecification<T>? specification = null);
    public Task<T?> FindFirst(ISpecification<T>? specification = null);
}