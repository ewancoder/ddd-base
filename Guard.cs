namespace Oliwan.EBI.Domain
{
    using System;

    /// <summary>
    /// Helper class to check for null references.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws NullReferenceException if object is null.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="obj">Object.</param>
        /// <param name="paramName">Name of the parameter.</param>
        public static void ThrowIfNull<T>(T obj, string paramName)
            where T : class
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException(paramName);
        }
    }
}
