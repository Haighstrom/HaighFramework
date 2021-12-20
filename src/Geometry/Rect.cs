using HaighFramework.Win32API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HaighFramework
{
    public struct Rect : IRect<float>
    {
        #region Static
        public static readonly Rect Empty = new Rect(0, 0, 0, 0);
        public static readonly Rect Unit = new Rect(0, 0, 1, 1);
        #endregion

        #region Fields
        [JsonIgnore]
        [XmlIgnore]
        private float _x, _y, _w, _h;
        #endregion

        #region Constructors
        internal Rect(RECT rect)
            : this(rect.left, rect.top, rect.Width, rect.Height)
        {
        }

        public Rect(System.Drawing.Rectangle rect)
            : this(rect.X, rect.Y, rect.Width, rect.Height)
        {
        }

        public Rect(float w, float h)
            : this(0, 0, w, h)
        {
        }

        public Rect(IRect<float> rect)
            : this(rect.X, rect.Y, rect.W, rect.H)
        {
        }

        public Rect(Point position, float w, float h)
            : this(position.X, position.Y, w, h)
        {
        }

        public Rect(Point size)
            : this(0, 0, size.X, size.Y)
        {
        }

        public Rect(System.Drawing.Size size)
            : this(0, 0, size.Width, size.Height)
        {
        }

        public Rect(float x, float y, Point size)
            : this(x, y, size.X, size.Y)
        {
        }

        public Rect(Point position, Point size)
            : this(position.X, position.Y, size.X, size.Y)
        {
        }

        /// <summary>
        /// Generate a rect from the ToString() of another ie "X:" + x + ",Y:" + y + ",W:" + w + ",H:" + h. Useful for saving rects to file.
        /// </summary>
        /// <param name="rectString"></param>
        public Rect(string rectString)
        {
            _x = _y = _w = _h = 0;

            string[] substrings = rectString.Split(',');
            if (substrings.Length != 4)
                throw new HException("Error trying to decode rect string");

            for (int i = 0; i < 4; i++)
            {
                substrings[i] = substrings[i].Substring(2); //Remove "X:" etc
                switch (i)
                {
                    case 0:
                        X = float.Parse(substrings[i]);
                        break;
                    case 1:
                        Y = float.Parse(substrings[i]);
                        break;
                    case 2:
                        W = float.Parse(substrings[i]);
                        break;
                    case 3:
                        H = float.Parse(substrings[i]);
                        break;
                }
            }
        }

        public Rect(float x, float y, float w, float h)
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

        #region W
        public float W
        {
            get => _w;
            set => _w = value;
        }
        #endregion

        #region H
        public float H
        {
            get => _h;
            set => _h = value;
        }
        #endregion

        #region P
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> P
        {
            get => new Point(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        #endregion

        #region R
        public IRect<float> R
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
        public float Left => X;
        #endregion

        #region Right
        [JsonIgnore]
        [XmlIgnore]
        public float Right => X + W;
        #endregion

        #region Top
        [JsonIgnore]
        [XmlIgnore]
        public float Top => Y;
        #endregion

        #region Bottom
        [JsonIgnore]
        [XmlIgnore]
        public float Bottom => Y + H;
        #endregion

        #region Area
        [JsonIgnore]
        [XmlIgnore]
        public float Area => W * H;
        #endregion

        #region Size
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> Size => new Point(W, H);
        #endregion

        #region SmallestSide
        [JsonIgnore]
        [XmlIgnore]
        public float SmallestSide => Math.Min(W, H);
        #endregion

        #region BiggestSide
        [JsonIgnore]
        [XmlIgnore]
        public float BiggestSide => Math.Max(W, H);
        #endregion

        #region TopLeft
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> TopLeft => P;
        #endregion

        #region TopCentre
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> TopCentre => new Point(X + W * 0.5f, Y);
        #endregion

        #region TopRight
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> TopRight => new Point(X + W, Y);
        #endregion

        #region CentreLeft
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> CentreLeft => new Point(X, Y + H * 0.5f);
        #endregion

        #region Centre
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> Centre => new Point(X + W * 0.5f, Y + H * 0.5f);
        #endregion

        #region CentreRight
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> CentreRight => new Point(X + W, Y + H * 0.5f);
        #endregion

        #region BottomLeft
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> BottomLeft => new Point(X, Y + H);
        #endregion

        #region BottomCentre
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> BottomCentre => new Point(X + W * 0.5f, Y + H);
        #endregion

        #region BottomRight
        [JsonIgnore]
        [XmlIgnore]
        public IPoint<float> BottomRight => new Point(X + W, Y + H);
        #endregion
        #endregion

        #region Zeroed/Shift/Scale/Resize/Grow
        #region Zeroed
        [JsonIgnore]
        [XmlIgnore]
        public IRect<float> Zeroed => new Rect(0, 0, W, H);
        #endregion

        #region Shift
        public IRect<float> Shift(Point direction, float distance) => Shift(direction.Normal.Multiply(distance));
        public IRect<float> Shift(Point direction) => Shift(direction.X, direction.Y);
        public IRect<float> Shift(float x, float y = 0, float w = 0, float h = 0) => new Rect(X + x, Y + y, W + w, H + h);
        #endregion

        #region Scale
        /// <summary>
        /// returns a Rect with same x,y, scaled w,h
        /// </summary>
        public IRect<float> Scale(float scaleX, float scaleY) => new Rect(X, Y, W * scaleX, H * scaleY);
        #endregion

        #region Resize
        /// <summary>
        /// Returns a Rect with same x,y, amended dimensions
        /// </summary>
        public IRect<float> Resize(float newW, float newH) => new Rect(X, Y, newW, newH);
        #endregion

        #region ScaleAround
        public IRect<float> ScaleAround(float scaleX, float scaleY, float originX, float originY) => ResizeAround(W * scaleX, H * scaleY, originX, originY);
        #endregion

        #region ResizeAround
        public IRect<float> ResizeAround(float newW, float newH, float originX, float originY)
            => new Rect(
                originX - newW * (originX - X) / W,
                originY - newH * (originY - Y) / H,
                newW, newH);
        #endregion

        #region Grow
        /// <summary>
        /// Returns a new Rect expanded by margin in all four directions. Pass negative value to shrink it.
        /// </summary>
        public Rect Grow(float margin) => Grow(margin, margin, margin, margin);
        /// <summary>
        /// Returns a new Rect with its edges shifted outwards by amounts left,up,right,down 
        /// </summary>
        public Rect Grow(float left, float up, float right, float down) => new Rect(X - left, Y - up, W + left + right, H + up + down);
        #endregion
        #endregion

        #region Intersects/Intersection/Contains/IsContainedBy
        #region Intersects
        public bool Intersects(IRect<float> r, bool touchingCounts = false)
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
        public IRect<float> Intersection(IRect<float> r)
        {
            Rect answer = new Rect();

            if (!Intersects(r))
                return answer;

            answer.X = Math.Max(Left, r.Left);
            answer.Y = Math.Max(Top, r.Top);
            answer.W = Math.Min(Right, r.Right) - answer.X;
            answer.H = Math.Min(Bottom, r.Bottom) - answer.Y;

            return answer;
        }
        #endregion

        #region Contains
        public bool Contains(IRect<float> r) => X <= r.X && Y <= r.Y && Right >= r.Right && Bottom >= r.Bottom;

        public bool Contains(float x, float y, float w, float h) => X <= x && Y <= y && X + H >= x + w && Y + H >= y + h;

        public bool Contains(int x, int y, int w, int h) => X <= x && Y <= y && X + W >= x + w && Y + H >= y + h;

        public bool Contains(Point p, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false)
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

        public bool Contains(float x, float y, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false)
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
        public bool IsContainedBy(IRect<float> r) => X >= r.X && Y >= r.Y && X + W <= r.X + r.W && Y + H <= r.Y + r.H;

        public bool IsContainedBy(float x, float y, float w, float h) => X >= x && Y >= y && X + H <= x + h && Y + H <= y + h;
        #endregion
        #endregion

        #region ToVertices
        public List<IPoint<float>> ToVertices() => new List<IPoint<float>>() { TopLeft, TopRight, BottomRight, BottomLeft };
        #endregion
        #endregion

        #region IEquatable<IRect>
        public bool Equals(IRect<float> other) => X == other.X && Y == other.Y && W == other.W && H == other.H;
        #endregion

        #region Overloads / Overrides
        public static bool operator ==(Rect r1, Rect r2) => r1.X == r2.X && r1.Y == r2.Y && r1.W == r2.W && r1.H == r2.H;

        public static bool operator !=(Rect r1, Rect r2) => r1.X != r2.X || r1.Y != r2.Y || r1.W != r2.W || r1.H != r2.H;

        public static Rect operator +(Rect r, Point p) => new Rect(r.X + p.X, r.Y + p.Y, r.W, r.H);

        public static Rect operator +(Rect left, Rect right) => new Rect(left.X + right.X, left.Y + right.Y, left.W + right.W, left.H + right.H);

        public static Rect operator -(Rect left, Rect right) => new Rect(left.X - right.X, left.Y - right.Y, left.W - right.W, left.H - right.H);

        #region Equals
        public override bool Equals(object o)
        {
            try
            {
                return this == (Rect)o;
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
            float hash = X;
            hash *= 37;
            hash += Y;
            hash *= 37;
            hash += W;
            hash *= 37;
            hash += H;
            hash *= 37;
            return (int)hash;
        }
        #endregion

        public override string ToString() => $"(X:{X},Y:{Y},W:{W},H:{H})";

        public IRect<float> Shift(IPoint<float> direction, float distance)
        {
            throw new NotImplementedException();
        }

        public IRect<float> Shift(IPoint<float> direction)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.Scale(float scaleX, float scaleY)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.Resize(float newW, float newH)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.ScaleAroundCentre(float scale)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.ScaleAroundCentre(float scaleX, float scaleY)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.ScaleAround(float scaleX, float scaleY, float originX, float originY)
        {
            throw new NotImplementedException();
        }

        public IRect<float> ResizeAround(float newW, float newH, IPoint<float> origin)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.ResizeAround(float newW, float newH, float originX, float originY)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.Grow(float margin)
        {
            throw new NotImplementedException();
        }

        IRect<float> IRect<float>.Grow(float left, float up, float right, float down)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IPoint<float> p, bool onLeftAndTopEdgesCount = true, bool onRightAndBottomEdgesCount = false)
        {
            throw new NotImplementedException();
        }

        List<IPoint<float>> IRect<float>.ToVertices()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}