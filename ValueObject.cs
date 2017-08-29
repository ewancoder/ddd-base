namespace Oliwan.EBI.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Value object.
    /// </summary>
    public abstract class ValueObject : DomainObject
    {
        /// <summary>
        /// All fields of value object. Uses reflection. Override for
        /// performance.
        /// </summary>
        /// <returns>List of all fields of value object.</returns>
        protected override IEnumerable<object> GetFieldValues()
            => GetType().GetProperties().Select(p => p.GetValue(this));
    }
}
