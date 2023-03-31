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
    /// Ensures that the specified string argument is not null or empty.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="argumentName">Name of the argument.</param>
    /// <exception cref="ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ArgumentNotNullOrEmpty(string? argument, string argumentName)
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentException("Argument is null or empty", argumentName);
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

    /// <summary>
    /// Tests a value to ensure it's within a permitted range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min">The minimum value acceptable (inclusively).</param>
    /// <param name="max">The maximum value acceptable (inclusively).</param>
    /// <exception cref="InvalidOperationException"></exception>
    [DebuggerStepThrough]
    public static void IsInRange(int value, int minAllowed, int maxAllowed)
    {
        if (value < minAllowed || value > maxAllowed)
        {
            throw new InvalidOperationException($"Value {value} was out of accepted range ({minAllowed}-{maxAllowed})");
        }
    }

    /// <summary>
    /// Tests a value to ensure it's within a permitted range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min">The minimum value acceptable (inclusively).</param>
    /// <param name="max">The maximum value acceptable (inclusively).</param>
    /// <exception cref="InvalidOperationException"></exception>
    [DebuggerStepThrough]
    public static void IsInRange(float value, float minAllowed, float maxAllowed)
    {
        if (value < minAllowed || value > maxAllowed)
        {
            throw new InvalidOperationException($"Value {value} was out of accepted range ({minAllowed}-{maxAllowed})");
        }
    }

    /// <summary>
    /// Ensures that the specified value is null.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="NullReferenceException"></exception>
    [DebuggerStepThrough]
    public static void IsNull(object? value)
    {
        if (value is not null)
        {
            throw new InvalidOperationException();
        }
    }
}