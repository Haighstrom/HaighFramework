namespace HaighFramework;

public static class Maths
{
    public static T Min<T>(T first, T second)
        where T : IComparisonOperators<T, T>
    {
        return first < second ? first : second;
    }
    public static T Max<T>(T first, T second)
        where T : IComparisonOperators<T, T>
    {
        return first > second ? first : second;
    }
    public static T Clamp<T>(T value, T min, T max)
        where T : IComparisonOperators<T, T>
    {
        if (min > max)
            throw new ArgumentOutOfRangeException(nameof(min), $"min value ({min}) was greater than max ({max})");

        return value < min ? min : value > max ? max : value;
    }
}