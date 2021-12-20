using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace HaighFramework
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point : IPoint<float>, IPosition
    {
        #region Static
        public static readonly Point Zero = new();
        /// <summary>
        /// Scalar or dot product
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static float DotProduct(IPoint<float> p1, IPoint<float> p2) => p1.DotProduct(p2);
        #endregion

        #region Fields
        [JsonIgnore]
        [XmlIgnore]
        private float _x, _y;
        #endregion

        #region Constructors
        public Point(System.Drawing.Point point) 
            : this(point.X, point.Y)
        {
        }

        public Point(float x, float y)
        {
            _x = x;
            _y = y;
        }
        #endregion

        #region Properties
        #region X
        public float X
        {
            get => _x;
            set => _x = value;
        }
        #endregion

        #region Y
        public float Y
        {
            get => _y;
            set => _y = value;
        }
        #endregion

        #region Length
        [JsonIgnore]
        [XmlIgnore]
        public float Length => (float)Math.Sqrt(LengthSquared);
        #endregion

        #region LengthSquared
        [JsonIgnore]
        [XmlIgnore]
        public float LengthSquared => X * X + Y * Y;
        #endregion

        #region Normal
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> Normal => (X == 0 && Y == 0) ? new Point() : new Point(X / Length, Y / Length);
        #endregion

        #region Perpendicular
        [JsonIgnore]
        [XmlIgnore]
        /// <summary>
        /// Returns a vector of equal magnitude at right angle to this point
        /// </summary>
        public IPoint<float> Perpendicular => new Point(-Y, X);
        #endregion
        #endregion

        #region Methods
        #region Clamp
        /// <summary>
        /// Preserves direction of the point but clamps its magnitude between the values specified (inclusive)
        /// </summary>
        public IPoint<float> Clamp(float minLength, float maxLength)
        {
            Point point = new(X, Y);

            float scale = Math.Min(Math.Max(Length, minLength), maxLength) / Length;

            point.X *= scale;
            point.Y *= scale;
            
            return point;
        }
        #endregion

        #region DotProduct
        /// <summary>
        /// Returns dot (scalar) product with another point
        /// </summary>
        public float DotProduct(IPoint<float> other) => X * other.X + Y * other.Y;
        #endregion

        #region Rotate
        /// <summary>
        /// Rotate this Point around a rotation axis given by Point RotationCentre
        /// </summary>
        /// <param name="RotationCentre"></param>
        /// <param name="RotationAngleInDegrees"></param>
        /// <returns></returns>
        public IPoint<float> Rotate(float RotationAngleInDegrees, IPoint<float> RotationCentre)
        {
            IPoint<float> answer = new Point<float>(X - RotationCentre.X, Y - RotationCentre.Y);
            answer = Matrix2<float>.CreateRotation(-RotationAngleInDegrees) * answer;
            answer.X += RotationCentre.X;
            answer.Y += RotationCentre.Y;
            return answer;
        }
        #endregion

        public IPoint<float> Scale(float xScale, float yScale) => new Point(X * xScale, Y * yScale);

        public IPoint<float> Shift(float x, float y = 0) => new Point(X + x, Y + y);

        public bool Equals(IPoint<float>? other) => X == other?.X && Y == other.Y;
        #endregion

        #region Overloads / Overrides
        public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);

        public static Point operator -(Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator *(float f, Point p) => new(p.X * f, p.Y * f);

        public static Point operator *(Point p, float f) => new(p.X * f, p.Y * f);

        public static Point operator /(Point p, float f) => new(p.X / f, p.Y / f);

        public static bool operator ==(Point p1, Point p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool operator !=(Point p1, Point p2) => p1.X != p2.X || p1.Y != p2.Y;

        public static Point operator -(Point p) => new(-p.X, -p.Y);

        #region Equals
        public override bool Equals(object? o)
        {
            if (o is not IPoint <float>)
                return false;

            return Equals((Point)o);
        }
        #endregion

        public override int GetHashCode() => (int)(X + 17 * Y);

        public override string ToString() => $"(X:{X},Y:{Y})";

        public IPoint<float> Add(IPoint<float> other)
        {
            throw new NotImplementedException();
        }

        public IPoint<float> Multiply(float value)
        {
            throw new NotImplementedException();
        }

        public IRect<float> ToRect()
        {
            throw new NotImplementedException();
        }

        public IPoint<float> Subtract(IPoint<float> other)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}