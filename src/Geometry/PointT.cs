using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace HaighFramework
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point<T> : IPoint<T>
        where T : struct, INumber<T>
    {
        #region Static
        public static readonly Point<T> Zero = new();
        #endregion

        #region Fields
        [JsonIgnore]
        [XmlIgnore]
        private T _x, _y;
        #endregion

        #region Constructors
        public Point(T x, T y)
        {
            _x = x;
            _y = y;
        }
        #endregion

        #region Properties
        #region X
        public T X
        {
            get => _x;
            set => _x = value;
        }
        #endregion

        #region Y
        public T Y
        {
            get => _y;
            set => _y = value;
        }
        #endregion

        #region Length
        [JsonIgnore]
        [XmlIgnore]
        //todo: is there a need to test T is OK for conversion?
        public T Length => (T)(object)Math.Sqrt(Convert.ToDouble(LengthSquared));
        #endregion

        #region LengthSquared
        [JsonIgnore]
        [XmlIgnore]
        public T LengthSquared => X * X + Y * Y;
        #endregion

        #region Normal
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> Normal => (X == default && Y == default) ? new Point<T>() : new Point<T>(X / Length, Y / Length);
        #endregion

        #region Perpendicular
        [JsonIgnore]
        [XmlIgnore]
        /// <summary>
        /// Returns a vector of equal magnitude at right angle to this point
        /// </summary>
        public IPoint<T> Perpendicular => new Point<T>(-Y, X);
        #endregion
        #endregion

        #region Methods
        public IPoint<T> Add(IPoint<T> other) => new Point<T>(X + other.X, Y + other.Y);
        public IPoint<T> Subtract(IPoint<T> other) => new Point<T>(X - other.X, Y - other.Y);
        public IPoint<T> Multiply(T value) => new Point<T>(X * value, Y * value);

        #region DotProduct
        /// <summary>
        /// Returns dot (scalar) product with another point
        /// </summary>
        public T DotProduct(IPoint<T> other) => X * other.X + Y * other.Y;
        #endregion

        #region Clamp
        /// <summary>
        /// Returns a new point in the same direction but with magnitude clamped between the values specified (inclusive)
        /// </summary>
        public IPoint<T> Clamp(T minLength, T maxLength)
        {
            Point<T> point = new(X, Y);

            T length = Length;
            T scale = Maths.Clamp(length, minLength, maxLength) / length;

            point *= scale;

            return point;
        }
        #endregion

        #region Rotate
        /// <summary>
        /// Rotate this Point around a rotation axis given by Point RotationCentre
        /// </summary>
        /// <param name="RotationCentre"></param>
        /// <param name="RotationAngleInDegrees"></param>
        /// <returns></returns>
        public IPoint<T> Rotate(float RotationAngleInDegrees, IPoint<T> RotationCentre)
        {
            IPoint<T> answer = new Point<T>(X - RotationCentre.X, Y - RotationCentre.Y);
            answer = Matrix2<T>.CreateRotation(-RotationAngleInDegrees) * answer;
            answer.X += RotationCentre.X;
            answer.Y += RotationCentre.Y;
            return answer;
        }
        #endregion

        public IPoint<T> Scale(T xScale, T yScale) => new Point<T>(X * xScale, Y * yScale);

        public IPoint<T> Shift(T x, T y) => new Point<T>(X + x, Y + y);

        public bool Equals(IPoint<T>? other) => X == other?.X && Y == other.Y;
        #endregion

        #region Overloads / Overrides
        public static Point<T> operator +(Point<T> p1, Point<T> p2) => new(p1.X + p2.X, p1.Y + p2.Y);

        public static Point<T> operator -(Point<T> p1, Point<T> p2) => new(p1.X - p2.X, p1.Y - p2.Y);

        public static Point<T> operator *(T f, Point<T> p) => new(p.X * f, p.Y * f);

        public static Point<T> operator *(Point<T> p, T f) => new(p.X * f, p.Y * f);

        public static Point<T> operator /(Point<T> p, T f) => new(p.X / f, p.Y / f);

        public static bool operator ==(Point<T> p1, Point<T> p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool operator !=(Point<T> p1, Point<T> p2) => p1.X != p2.X || p1.Y != p2.Y;

        public static Point<T> operator -(Point<T> p) => new(-p.X, -p.Y);

        #region Equals
        public override bool Equals(object? o)
        {
            if (o is not Point<T>)
                return false;

            return Equals((Point<T>)o);
        }
        #endregion

        public override int GetHashCode() => Convert.ToInt32(X + Y * (T)(object)17);

        public override string ToString() => $"(X : {X} Y : {Y})";

        public IRect<T> ToRect()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}