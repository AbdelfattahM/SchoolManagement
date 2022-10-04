namespace School.SharedKernel;

public abstract class BaseEntity<T>
{
    public T? Id { get; set; }

    public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}
