using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace HaighFramework
{
    public interface IPoint<T> : IEquatable<IPoint<T>>
        where T : struct, INumber<T>
    {
        T X { get; set; }
        T Y { get; set; }
        T Length { get; }
        T LengthSquared { get; }
        IPoint<T> Normal { get; }
        IPoint<T> Perpendicular { get; }

        IPoint<T> Add(IPoint<T> other);
        IPoint<T> Subtract(IPoint<T> other);
        IPoint<T> Multiply(T value);

        #region DotProduct
        /// <summary>
        /// Returns dot product (scalar product) with another point
        /// </summary>
        T DotProduct(IPoint<T> other);
        #endregion

        #region Clamp
        /// <summary>
        /// Preserves direction of the point but clamps its magnitude between the values specified (inclusive)
        /// </summary>
        IPoint<T> Clamp(T minLength, T maxLength);
        #endregion

        IPoint<T> Rotate(float RotationAngleInDegrees, IPoint<T> RotationCentre);

        IPoint<T> Scale(T xScale, T yScale);

        IPoint<T> Shift(T x, T y);

        IRect<T> ToRect();
    }
}