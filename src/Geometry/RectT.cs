using HaighFramework.Win32API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace HaighFramework
{
    public struct Rect<T> : IRect<T>
        where T : struct, INumber<T>
    {
        #region Static
        public static readonly Rect<T> Empty = new();
        public static readonly Rect<T> Unit = new(T.Zero, T.Zero, T.One, T.One);
        #endregion

        #region Fields
        [JsonIgnore]
        [XmlIgnore]
        private T _x, _y, _w, _h;
        #endregion

        #region Constructors

        public Rect(T w, T h)
            : this(T.Zero, T.Zero, w, h)
        {
        }

        public Rect(IPoint<T> position, T w, T h)
            : this(position.X, position.Y, w, h)
        {
        }

        public Rect(IPoint<T> size)
            : this(T.Zero, T.Zero, size.X, size.Y)
        {
        }

        public Rect(T x, T y, Point<T> size)
            : this(x, y, size.X, size.Y)
        {
        }

        public Rect(Point<T> position, Point<T> size)
            : this(position.X, position.Y, size.X, size.Y)
        {
        }

        public Rect(T x, T y, T w, T h)
        {
            _x = x;
            _y = y;
            _w = w;
            _h = h;
        }
        #endregion

        #region IRect
        #region X/Y/W/H/P
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

        #region W
        public T W
        {
            get => _w;
            set => _w = value;
        }
        #endregion

        #region H
        public T H
        {
            get => _h;
            set => _h = value;
        }
        #endregion

        #region P
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> P
        {
            get => new Point<T>(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        #endregion

        #region R
        public IRect<T> R
        {
            set
            {
                X = value.X;
                Y = value.Y;
                W = value.W;
                H = value.H;
            }
        }
        #endregion
        #endregion

        #region Left/../Bottom/Area/Size/SmallestSide/TopLeft/../BottomRight
        #region Left
        [JsonIgnore]
        [XmlIgnore]
        public T Left => X;
        #endregion

        #region Right
        [JsonIgnore]
        [XmlIgnore]
        public T Right => X + W;
        #endregion

        #region Top
        [JsonIgnore]
        [XmlIgnore]
        public T Top => Y;
        #endregion

        #region Bottom
        [JsonIgnore]
        [XmlIgnore]
        public T Bottom => Y + H;
        #endregion

        #region Area
        [JsonIgnore]
        [XmlIgnore]
        public T Area => W * H;
        #endregion

        #region Size
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> Size => new Point<T>(W, H);
        #endregion

        #region SmallestSide
        [JsonIgnore]
        [XmlIgnore]
        public T SmallestSide => Maths.Min(W, H);
        #endregion

        #region BiggestSide
        [JsonIgnore]
        [XmlIgnore]
        public T BiggestSide => Maths.Max(W, H);
        #endregion

        #region TopLeft
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> TopLeft => P;
        #endregion

        #region TopCentre
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> TopCentre => new Point<T>(X + W / (T)(object)2, Y);
        #endregion

        #region TopRight
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> TopRight => new Point<T>(X + W, Y);
        #endregion

        #region CentreLeft
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> CentreLeft => new Point<T>(X, Y + H / (T)(object)2);
        #endregion

        #region Centre
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> Centre => new Point<T>(X + W / (T)(object)2, Y + H / (T)(object)2);
        #endregion

        #region CentreRight
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> CentreRight => new Point<T>(X + W, Y + W / (T)(object)2);
        #endregion

        #region BottomLeft
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> BottomLeft => new Point<T>(X, Y + H);
        #endregion

        #region BottomCentre
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> BottomCentre => new Point<T>(X + W / (T)(object)2, Y + H);
        #endregion

        #region BottomRight
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<T> BottomRight => new Point<T>(X + W, Y + H);
        #endregion
        #endregion

        #region Zeroed/Shift/Scale/Resize/Grow
        #region Zeroed
        [JsonIgnore]
        [XmlIgnore]
        public IRect<T> Zeroed => new Rect<T>(T.Zero, T.Zero, W, H);
        #endregion

        #region Shift
        public IRect<T> Shift(IPoint<T> direction, T distance) => Shift(direction.Normal.Multiply(distance));
        public IRect<T> Shift(IPoint<T> direction) => Shift(direction.X, direction.Y);
        public IRect<T> Shift(T x, T y = default, T w = default, T h = default) => new Rect<T>(X + x, Y + y, W + w, H + h);
        #endregion

        #region Scale
        /// <summary>
        /// returns a Rect with same x,y, scaled w,h
        /// </summary>
        public IRect<T> Scale(T scaleX, T scaleY) => new Rect<T>(X, Y, W * scaleX, H * scaleY);
        #endregion

        #region Resize
        /// <summary>
        /// Returns a Rect with same x,y, amended dimensions
        /// </summary>
        public IRect<T> Resize(T newW, T newH) => new Rect<T>(X, Y, newW, newH);
        #endregion

        #region ScaleAround
        public IRect<T> ScaleAroundCentre(T scale) => ScaleAroundCentre(scale, scale);
        public IRect<T> ScaleAroundCentre(T scaleX, T scaleY) => ScaleAround(scaleX, scaleY, Centre.X, Centre.Y);
        public IRect<T> ScaleAround(T scaleX, T scaleY, T originX, T originY) => ResizeAround(W * scaleX, H * scaleY, originX, originY);
        #endregion

        #region ResizeAround
        public IRect<T> ResizeAround(T newW, T newH, IPoint<T> origin) => ResizeAround(newW, newH, origin.X, origin.Y);
        public IRect<T> ResizeAround(T newW, T newH, T originX, T originY)
            => new Rect<T>(
                originX - newW * (originX - X) / W,
                originY - newH * (originY - Y) / H,
                newW, newH);
        #endregion

        #region Grow
        /// <summary>
        /// Returns a new Rect expanded by margin in all four directions. Pass negative value to shrink it.
        /// </summary>
        public IRect<T> Grow(T margin) => Grow(margin, margin, margin, margin);
        /// <summary>
        /// Returns a new Rect with its edges shifted outwards by amounts left,up,right,down 
        /// </summary>
        public IRect<T> Grow(T left, T up, T right, T down) => new Rect<T>(X - left, Y - up, W + left + right, H + up + down);
        #endregion
        #endregion

        #region Intersects/Intersection/Contains/IsContainedBy
        #region Intersects
        public bool Intersects(IRect<T> r, bool touchingCounts = false)
        {
            if (touchingCounts)
                return
                    Left <= r.Right &&
                    Right >= r.Left &&
                    Top <= r.Bottom &&
                    Bottom >= r.Top;
            else
                return
                    Left < r.Right &&
                    Right > r.Left &&
                    Top < r.Bottom &&
                    Bottom > r.Top;
        }
        #endregion

        #region Intersection
        public IRect<T> Intersection(IRect<T> r)
        {
            Rect<T> answer = new();

            if (!Intersects(r))
                return answer;

            answer.X = Left > r.Left ? Left : r.Left; Maths.Max(Left, r.Left);
            answer.Y = Maths.Max(Top, r.Top);
            answer.W = Maths.Min(Right, r.Right) - answer.X;
            answer.H = Maths.Min(Bottom, r.Bottom) - answer.Y;

            return answer;
        }
        #endregion

        #region Contains
        public bool Contains(IRect<T> r) => X <= r.X && Y <= r.Y && Right >= r.Right && Bottom >= r.Bottom;

        public bool Contains(T x, T y, T w, T h) => X <= x && Y <= y && X + H >= x + w && Y + H >= y + h;

        public bool Contains(IPoint<T> p, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false)
        {
            if (onLeftAndTopEdgesCount && onRightAndBottomEdgesCount)
                return X <= p.X && Y <= p.Y && X + W >= p.X && Y + H >= p.Y;
            else if (onLeftAndTopEdgesCount && !onRightAndBottomEdgesCount)
                return X <= p.X && Y <= p.Y && X + W > p.X && Y + H > p.Y;
            else if (!onLeftAndTopEdgesCount && onRightAndBottomEdgesCount)
                return X < p.X && Y < p.Y && X + W >= p.X && Y + H >= p.Y;
            else
                return X < p.X && Y < p.Y && X + W > p.X && Y + H > p.Y;
        }

        public bool Contains(T x, T y, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false)
        {
            if (onLeftAndTopEdgesCount && onRightAndBottomEdgesCount)
                return X <= x && Y <= y && X + W >= x && Y + H >= y;
            else if (onLeftAndTopEdgesCount && !onRightAndBottomEdgesCount)
                return X <= x && Y <= y && X + W > x && Y + H > y;
            else if (!onLeftAndTopEdgesCount && onRightAndBottomEdgesCount)
                return X < x && Y < y && X + W >= x && Y + H >= y;
            else
                return X < x && Y < y && X + W > x && Y + H > y;
        }
        #endregion

        #region IsContainedBy
        public bool IsContainedBy(IRect<T> r) => X >= r.X && Y >= r.Y && X + W <= r.X + r.W && Y + H <= r.Y + r.H;

        public bool IsContainedBy(T x, T y, T w, T h) => X >= x && Y >= y && X + H <= x + h && Y + H <= y + h;
        #endregion
        #endregion

        #region ToVertices
        public List<IPoint<T>> ToVertices() => new List<IPoint<T>>() { TopLeft, TopRight, BottomRight, BottomLeft };
        #endregion
        #endregion

        #region IEquatable<IRect>
        public bool Equals(IRect<T>? other)
        {
            if (other == null)
                return false;
            return X == other.X && Y == other.Y && W == other.W && H == other.H;
        }
        #endregion

        #region Overloads / Overrides
        public static bool operator ==(Rect<T> r1, Rect<T> r2) => r1.X == r2.X && r1.Y == r2.Y && r1.W == r2.W && r1.H == r2.H;

        public static bool operator !=(Rect<T> r1, Rect<T> r2) => r1.X != r2.X || r1.Y != r2.Y || r1.W != r2.W || r1.H != r2.H;

        #region +
        public static Rect<T> operator +(Rect<T> r, Point<T> p) => new(r.X + p.X, r.Y + p.Y, r.W, r.H);

        public static Rect<T> operator +(Rect<T> left, Rect<T> right) => new(left.X + right.X, left.Y + right.Y, left.W + right.W, left.H + right.H);
        #endregion

        public static Rect<T> operator -(Rect<T> left, Rect<T> right) => new(left.X - right.X, left.Y - right.Y, left.W - right.W, left.H - right.H);

        #region Equals
        public override bool Equals(object? o)
        {
            if (o == null)
                return false;

            try
            {
                return this == (Rect<T>)o;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            T hash = X;
            hash *= (T)(object)37;
            hash += Y;
            hash *= (T)(object)37;
            hash += W;
            hash *= (T)(object)37;
            hash += H;
            hash *= (T)(object)37;
            return (int)(object)hash;
        }
        #endregion

        public override string ToString() => "X:" + X + ",Y:" + Y + ",W:" + W + ",H:" + H;
        #endregion
    }
}