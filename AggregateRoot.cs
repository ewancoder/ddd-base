namespace Oliwan.EBI.Domain
{
    /// <summary>
    /// Aggregate root.
    /// </summary>
    /// <typeparam name="TId">Aggregate root's entity identity.</typeparam>
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
    }
}
