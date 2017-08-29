namespace Oliwan.EBI.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Domain object base for basic types.
    /// </summary>
    public abstract class DomainObject
        : IEquatable<DomainObject>, IEqualityComparer<DomainObject>
    {
        /// <summary>
        /// Gets list of all values of object fields that should be involved in
        /// equality process. It's all properties for value objects and identity
        /// for entity.
        /// </summary>
        /// <returns>List of all values of object fields.</returns>
        protected abstract IEnumerable<object> GetFieldValues();

        /// <summary>
        /// Tests equality with another domain object.
        /// </summary>
        /// <param name="other">Other domain object.</param>
        /// <returns>Equality test result.</returns>
        public bool Equals(DomainObject other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(other, this))
                return true;

            if (other.GetType() != GetType())
                return false;

            return DataEquals(other);
        }

        /// <summary>
        /// Tests equality between two domain objects.
        /// </summary>
        /// <param name="x">First domain object.</param>
        /// <param name="y">Second domain object.</param>
        /// <returns>Equality test result.</returns>
        public bool Equals(DomainObject x, DomainObject y)
        {
            return Equals(x, (object)y);
        }

        /// <summary>
        /// Gets hash code for the domain object.
        /// </summary>
        /// <param name="obj">Domain object.</param>
        /// <returns>Hash code.</returns>
        public int GetHashCode(DomainObject obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Tests equality with another object.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>Equality test result.</returns>
        public sealed override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (ReferenceEquals(obj, this))
                return true;

            if (obj.GetType() != GetType())
                return false;

            if (obj is DomainObject other)
                return Equals(other);

            // Never gets called. Is here for method to work.
            // Can be removed if above condition is refactored.
            return false;
        }

        /// <summary>
        /// Gets hash code for this domain object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public sealed override int GetHashCode()
        {
            var code = 31;

            var inc = 0;
            foreach (var property in GetFieldValues())
            {
                if (property == null)
                {
                    code ^= 13;
                    continue;
                }

                code ^= property.GetHashCode() * ++inc;
            }

            return code;
        }

        /// <summary>
        /// Checks that all fields that are involved in comparison process are
        /// actually equal.
        /// </summary>
        /// <param name="other">Other domain object.</param>
        /// <returns>Result of the check.</returns>
        private bool DataEquals(DomainObject other)
        {
            var thisFields = GetFieldValues().ToArray();
            var otherFields = other.GetFieldValues().ToArray();

            // Useless now.
            if (thisFields.Length != otherFields.Length)
                return false;

            for (var i = 0; i < thisFields.Length; i++)
            {
                if (!Equals(thisFields[i], otherFields[i]))
                    return false;
            }

            return true;
        }
    }
}
