using EntityLib.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLib.Infrastructure.Persistence.Configurations;

public class BaseValueObjectConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseValueObject
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasNoKey();
    }
}