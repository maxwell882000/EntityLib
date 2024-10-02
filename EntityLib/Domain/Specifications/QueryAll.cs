using EntityLib.Domain.Entities;

namespace EntityLib.Domain.Specifications;

public class QueryAll : ISpecification<BaseEntity>
{
    public IQueryable<BaseEntity> Apply(IQueryable<BaseEntity> query)
    {
        return query;
    }
}