namespace Entities;

public class BaseEntity : BaseEntity<long> {}
public class BaseEntity<TKey> : IBaseEntity
{
    public TKey Id { get; set; }
}