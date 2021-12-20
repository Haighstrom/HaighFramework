using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime;

namespace HaighFramework
{
    public interface IRect<T> : IEquatable<IRect<T>>
        where T : struct, INumber<T>
    {
        #region X/Y/W/H/P/R
        T X { get; set; }
        T Y { get; set; }
        T W { get; set; }
        T H { get; set; }
        IPoint<T> P { get; set; }
        IRect<T> R { set; }
        #endregion

        #region Left/../Bottom/Area/Size/SmallestSide/TopLeft/../BottomRight
        T Left { get; }
        T Right { get; }
        T Top { get; }
        T Bottom { get; }
        T Area { get; }
        IPoint<T> Size { get; }
        T SmallestSide { get; }
        T BiggestSide { get; }
        IPoint<T> TopLeft { get; }
        IPoint<T> TopCentre { get; }
        IPoint<T> TopRight { get; }
        IPoint<T> CentreLeft { get; }
        IPoint<T> Centre { get; }
        IPoint<T> CentreRight { get; }
        IPoint<T> BottomLeft { get; }
        IPoint<T> BottomCentre { get; }
        IPoint<T> BottomRight { get; }
        #endregion

        #region Zeroed/Shift/Scale/Resize/Grow
        IRect<T> Zeroed { get; }
        IRect<T> Shift(IPoint<T> direction, T distance);
        IRect<T> Shift(IPoint<T> direction);
        IRect<T> Shift(T x, T y, T w = default, T h = default);
        IRect<T> Scale(T scaleX, T scaleY);
        IRect<T> Resize(T newW, T newH);
        IRect<T> ScaleAroundCentre(T scale);
        IRect<T> ScaleAroundCentre(T scaleX, T scaleY);
        IRect<T> ScaleAround(T scaleX, T scaleY, T originX, T originY);
        IRect<T> ResizeAround(T newW, T newH, IPoint<T> origin);
        IRect<T> ResizeAround(T newW, T newH, T originX, T originY);
        IRect<T> Grow(T margin);
        IRect<T> Grow(T left, T up, T right, T down);
        #endregion

        #region Intersects/Intersection/Contains/IsContainedBy
        bool Intersects(IRect<T> r, bool touchingCounts = false);
        IRect<T> Intersection(IRect<T> r);
        bool Contains(IRect<T> r);
        bool Contains(T x, T y, T w, T h);
        bool Contains(IPoint<T> p, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false);
        bool Contains(T x, T y, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false);
        bool IsContainedBy(IRect<T> r);
        bool IsContainedBy(T x, T y, T w, T h);
        #endregion

        List<IPoint<T>> ToVertices();
    }
}