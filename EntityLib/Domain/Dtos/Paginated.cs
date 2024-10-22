using EntityLib.Domain.Entities;

namespace EntityLib.Domain.Dtos;

public class Paginated<T> where T : BaseEntity
{
    public int Total { get; set; }
    public List<T> Items { get; set; }
}