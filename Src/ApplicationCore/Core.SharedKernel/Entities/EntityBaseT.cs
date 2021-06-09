namespace Core.SharedKernel.Entities
{
    public abstract class EntityBase<TKey> : EntityBase, IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
