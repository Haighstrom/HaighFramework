using System.Collections;
using System.Diagnostics;

namespace HaighFramework;

public static class Ensure
{
    /// <summary>
    /// Ensures that the specified argument is not less than zero.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="argumentName">Name of the argument.</param>
    /// <exception cref="ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ArgumentNotNegative(float argument, string argumentName)
    {
        if (argument < 0)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }
    }

    /// <summary>
    /// Ensures that the specified argument is not null.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="argumentName">Name of the argument.</param>
    /// <exception cref="ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ArgumentNotNull(object? argument, string argumentName)
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName);
        }
    }

    /// <summary>
    /// Ensures that the specified collection is not null or empty.
    /// </summary>
    /// <typeparam name="T">The type of element in the collection.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <exception cref="InvalidOperationException"></exception>
    [DebuggerStepThrough]
    public static void CollectionNotEmpty<T>(IEnumerable<T> collection)
    {
        if (collection is null || !collection.Any())
            throw new InvalidOperationException();
    }

    /// <summary>
    /// Ensures that the specified value is not null.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="NullReferenceException"></exception>
    [DebuggerStepThrough]
    public static void NotNull(object? value)
    {
        if (value is null)
        {
            throw new NullReferenceException();
        }
    }
}