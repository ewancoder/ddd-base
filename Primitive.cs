namespace Oliwan.EBI.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Primitive.
    /// </summary>
    /// <typeparam name="TValue">Primitive value type.</typeparam>
    public abstract class Primitive<TValue> : DomainObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Primitive{TValue}"/>
        /// class.
        /// </summary>
        /// <param name="value">Primitive value.</param>
        protected Primitive(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// Value.
        /// </summary>
        public TValue Value { get; }

        /// <summary>
        /// Gets single primitive value.
        /// </summary>
        /// <returns>Primitive value.</returns>
        protected sealed override IEnumerable<object> GetFieldValues()
            => new object[] { Value };

        /// <summary>
        /// Converts primitive value to string.
        /// </summary>
        /// <returns>String representation of primitive value.</returns>
        public sealed override string ToString()
        {
            return Value.ToString();
        }
    }
}
