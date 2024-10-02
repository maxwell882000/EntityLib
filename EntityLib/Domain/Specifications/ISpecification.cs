using EntityLib.Domain.Entities;

namespace EntityLib.Domain.Specifications;

public interface ISpecification<T> where T : BaseEntity
{
    public IQueryable<T> Apply(IQueryable<T> query);
}