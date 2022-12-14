﻿using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HaighFramework;

[StructLayout(LayoutKind.Sequential)]
public struct Point : IPosition, IEquatable<Point>
{
    private const double RadianConversion = Math.PI / 180;

    public static readonly Point Zero = new();
    

    [JsonIgnore]
    [XmlIgnore]
    private float _x, _y;
    

    public Point(System.Drawing.Point point)
        : this(point.X, point.Y)
    {
    }

    public Point(float x, float y)
    {
        _x = x;
        _y = y;
    }
    

    public float X
    {
        get => _x;
        set => _x = value;
    }
    

    public float Y
    {
        get => _y;
        set => _y = value;
    }
    

    [JsonIgnore]
    [XmlIgnore]
    public float Length => (float)Math.Sqrt(LengthSquared);
    

    [JsonIgnore]
    [XmlIgnore]
    public float LengthSquared => X * X + Y * Y;
    

    [JsonIgnore]
    [XmlIgnore]
    public Point Normal => (X == 0 && Y == 0) ? new Point() : new Point(X / Length, Y / Length);
    

    [JsonIgnore]
    [XmlIgnore]
    /// <summary>
    /// Returns a vector of equal magnitude at right angle to this point
    /// </summary>
    public Point Perpendicular => new(-Y, X);
    
    

    /// <summary>
    /// Preserves direction of the point but clamps its magnitude between the values specified (inclusive)
    /// </summary>
    public Point Clamp(float minLength, float maxLength)
    {
        Point point = new(X, Y);

        float scale = Math.Min(Math.Max(Length, minLength), maxLength) / Length;

        point.X *= scale;
        point.Y *= scale;

        return point;
    }
    

    /// <summary>
    /// Returns dot (scalar) product with another point
    /// </summary>
    public float DotProduct(Point other) => X * other.X + Y * other.Y;
    

    /// <summary>
    /// Rotate this Point around 0,0
    /// </summary>
    /// <param name="rotationAngleInDegrees"></param>
    public Point Rotate(float rotationAngleInDegrees) => Rotate(rotationAngleInDegrees, Zero);

    /// <summary>
    /// Rotate this point around another point
    /// </summary>
    /// <param name="angle">Rotation Angle in Degrees.</param>
    /// <param name="centre">The rotation centre.</param>
    public Point Rotate(float angle, Point centre)
    {
        var angleRadians = angle * RadianConversion;

        float rotatedX = (float)(Math.Cos(angleRadians) * (X - centre.X) - Math.Sin(angleRadians) * (Y - centre.Y) + centre.X);
        float rotatedY = (float)(Math.Sin(angleRadians) * (X - centre.X) + Math.Cos(angleRadians) * (Y - centre.Y) + centre.Y);

        return new Point(rotatedX, rotatedY);
    }
    

    public Point Scale(float xScale, float yScale) => new(X * xScale, Y * yScale);

    public Point Shift(float x, float y = 0) => new(X + x, Y + y);

    public bool Equals(Point other) => X == other.X && Y == other.Y;

    public bool Equals(IPosition? other) => X == other?.X && Y == other?.Y;
    

    public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);

    public static Point operator -(Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);

    public static Point operator *(float f, Point p) => new(p.X * f, p.Y * f);
    public static Point operator *(double f, Point p) => new((float)(p.X * f), (float)(p.Y * f));

    public static Point operator *(Point p, float f) => new(p.X * f, p.Y * f);
    public static Point operator *(Point p, double f) => new((float)(p.X * f), (float)(p.Y * f));

    public static Point operator /(Point p, float f) => new(p.X / f, p.Y / f);
    public static Point operator /(Point p, double f) => new((float)(p.X / f), (float)(p.Y / f));

    public static bool operator ==(Point p1, Point p2) => p1.X == p2.X && p1.Y == p2.Y;

    public static bool operator !=(Point p1, Point p2) => p1.X != p2.X || p1.Y != p2.Y;

    public static Point operator -(Point p) => new(-p.X, -p.Y);

    public override bool Equals(object? o)
    {
        if (o is not Point)
            return false;

        return Equals((Point)o);
    }
    

    public override int GetHashCode() => (int)(X + 17 * Y);

    public override string ToString() => $"(X:{X},Y:{Y})";

    public Rect ToRect() => new(X, Y);
    
}
