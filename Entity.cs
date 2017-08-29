namespace Oliwan.EBI.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Entity.
    /// </summary>
    /// <typeparam name="TId">Identity type of the entity.</typeparam>
    public abstract class Entity<TId> : DomainObject
    {
        /// <summary>
        /// Gets identity.
        /// </summary>
        /// <returns>Entity identity.</returns>
        protected abstract TId GetIdentity();

        /// <summary>
        /// Gets single value of the entity identity.
        /// </summary>
        /// <returns>Entity identity.</returns>
        protected sealed override IEnumerable<object> GetFieldValues()
            => new object[] { GetIdentity() };
    }
}
