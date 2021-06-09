namespace Core.SharedKernel.Entities
{
    public abstract class AggregateRootBase<TKey>: EntityBase<TKey>, IAggregateRoot<TKey>
    {
    }
}
