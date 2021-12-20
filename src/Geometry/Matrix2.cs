using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace HaighFramework
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix2<T>
        where T : struct, INumber<T>
    {
        //Matrix Layout
        //(0  2)
        //(1  3)

        #region Static
        #region Premade Matrices
        public static Matrix2<T> Identity = new(T.One, T.Zero, T.Zero, T.One);
        public static Matrix2<T> Zero = new();

        public static Matrix2<T> CreateRotation(float angleInDegrees)
        {
            double radians = Math.PI * angleInDegrees / 180.0;
            return new Matrix2<T>((T)(object)Math.Cos(radians), (T)(object)Math.Sin(radians), -(T)(object)Math.Sin(radians), (T)(object)Math.Cos(radians));
        }

        public static Matrix2<T> CreateScale(T scaleX, T scaleY)
        {
            return new Matrix2<T>(scaleX, T.Zero, T.Zero, scaleY);
        }
        #endregion

        #region Add
        public static Matrix2<T> Add(ref Matrix2<T> mat1, ref Matrix2<T> mat2)
        {
            T[] values = mat1._values.Zip(mat2._values, (a, b) => a + b).ToArray();
            return new Matrix2<T>(values);
        }
        #endregion

        #region Subtract
        public static Matrix2<T> Subtract(ref Matrix2<T> mat1, ref Matrix2<T> mat2)
        {
            T[] values = mat1._values.Zip(mat2._values, (a, b) => a - b).ToArray();
            return new Matrix2<T>(values);
        }
        #endregion

        #region Multiply
        public static Matrix2<T> Multiply(ref Matrix2<T> mat1, ref Matrix2<T> mat2)
        {
            return new Matrix2<T>
                (
                    mat1._values[0] * mat2._values[0] + mat1._values[2] * mat2._values[1],
                    mat1._values[1] * mat2._values[0] + mat1._values[3] * mat2._values[1], 
                    mat1._values[0] * mat2._values[2] + mat1._values[2] * mat2._values[3],
                    mat1._values[1] * mat2._values[2] + mat1._values[3] * mat2._values[3]

                );
        }

        /// <summary>
        /// Muplication by scalar - multiplies each matrix element by the scalar value.
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Matrix2<T> Multiply(ref Matrix2<T> mat, T f)
        {
            return new Matrix2<T>
                (
                    mat._values[0] * f,
                    mat._values[1] * f,
                    mat._values[2] * f,
                    mat._values[3] * f
                );
        }

        /// <summary>
        /// Apply a Matrix2 mat to a Point p, returning a transformed Point
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IPoint<T> Multiply(ref Matrix2<T> mat, IPoint<T> p)
        {
            return new Point<T>
                (
                    p.X * mat._values[0] + p.Y * mat._values[2],
                    p.X * mat._values[1] + p.Y * mat._values[3]
                );
        }
        #endregion                         

        #region Rotate
        public static Matrix2<T> RotateAroundZ(ref Matrix2<T> mat, float angleInDegrees)
        {
            Matrix2<T> rotMat = Matrix2<T>.CreateRotation(angleInDegrees);
            return Matrix2<T>.Multiply(ref mat, ref rotMat);
        }        
        #endregion

        #region Scale
        public static Matrix2<T> ScaleAroundOrigin(ref Matrix2<T> mat, T scaleX, T scaleY)
        {
            Matrix2<T> scaleMat = Matrix2<T>.CreateScale(scaleX, scaleY);
            return Multiply(ref mat, ref scaleMat);
        }
        #endregion

        #region Invert
        public static Matrix2<T> Inverse(ref Matrix2<T> mat)
        {
            T det = mat.Determinant;

            if (det == T.Zero)
                return mat;
            
            T invDet = T.One / det;

            return new Matrix2<T>
                (
                    mat._values[3] * invDet,
                    -mat._values[1] * invDet,
                    -mat._values[2] * invDet,
                    mat._values[0] * invDet
                );
        }
        #endregion
        #endregion

        #region Fields
        private T[] _values;
        #endregion

        #region Constructors
        public Matrix2(T m0, T m1, T m2, T m3)
        {
            _values = new T[4] { m0, m1, m2, m3 };
        }
        public Matrix2(T[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (values.Length != 4)
                throw new ArgumentException($"Did not supply 4 values, but {values.Length}.", nameof(values));

            _values = values;
        }
        #endregion

        #region Indexers
        public T this[int x, int y]
        {
            get
            {
                if (x < 0 || x > 1 || y < 0 || y > 1)
                    throw new HException("Requested an invalid Matrix2 index:{0},{1}", x, y);
                return _values[x * 2 + y];
            }
            set
            {
                if (x < 0 || x > 1 || y < 0 || y > 1)
                    throw new HException("Requested an invalid Matrix2 index:{0},{1}", x, y);
                _values[x * 2 + y] = value;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Matrix elements, a 4 element array indexed as
        /// (0 2)
        /// (1 3)
        /// </summary>
        public T[] Values
        {
            get => _values;
            set => _values = value;
        }

        /// <summary>
        /// Gets the determinant of this matrix
        /// </summary>
        public T Determinant
        {
            get
            {
                return _values[0] * _values[3] - _values[1] * _values[2];
            }
        }
        #endregion

        #region Methods
        #region Transpose
        /// <summary>
        /// Returns the transpose of this Matrix2 - all elements mirrored in [1 1] diagonal. The values of this instance will not be altered, returns a new matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix2<T> Transpose()
        {
            return new Matrix2<T>
                (
                    _values[0],
                    _values[2],
                    _values[1],
                    _values[3]
                );
        }
        #endregion
        #endregion

        #region Operators
        /// <summary>
        /// Scalar multiplication.
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix2 which holds the result of the multiplication</returns>
        public static Matrix2<T> operator *(T left, Matrix2<T> right) => Multiply(ref right, left);

        /// <summary>
        /// Scalar multiplication.
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix2 which holds the result of the multiplication</returns>
        public static Matrix2<T> operator *(Matrix2<T> left, T right) => Multiply(ref left, right);

        public static IPoint<T> operator *(Matrix2<T> left, IPoint<T> right) => Multiply(ref left, right);

        /// <summary>
        /// Matrix multiplication
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix2 which holds the result of the multiplication</returns>
        public static Matrix2<T> operator *(Matrix2<T> left, Matrix2<T> right) => Multiply(ref left, ref right);

        /// <summary>
        /// Matrix addition
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix2 which holds the result of the addition</returns>
        public static Matrix2<T> operator +(Matrix2<T> left, Matrix2<T> right) => Add(ref left, ref right);

        /// <summary>
        /// Matrix subtraction
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix2 which holds the result of the subtraction</returns>
        public static Matrix2<T> operator -(Matrix2<T> left, Matrix2<T> right) => Subtract(ref left, ref right);
        #endregion
    }
}