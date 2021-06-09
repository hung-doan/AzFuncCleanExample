namespace Core.SharedKernel.Entities
{
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
}
