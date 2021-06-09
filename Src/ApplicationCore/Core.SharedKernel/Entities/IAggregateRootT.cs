namespace Core.SharedKernel.Entities
{
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {
    }
}
