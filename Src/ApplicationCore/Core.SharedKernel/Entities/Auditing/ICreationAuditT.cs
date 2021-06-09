namespace Core.SharedKernel.Entities.Auditing
{
    public interface ICreationAudit<TKey>: IHasCreationTime, IHasCreator<TKey>
    {
    }
}
