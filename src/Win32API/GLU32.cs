namespace HaighFramework.Win32API;

using System.Runtime.InteropServices;
using System.Security;

[SuppressUnmanagedCodeSecurity]
internal static class GLU32
{

    // * * * CLEANED UP ABOVE THIS LINE * * *

    #region gluBuild2DMipmaps
    [DllImport("glu32.dll")]
    internal extern static Int32 gluBuild2DMipmaps(Int32 target, Int32 internalFormat, Int32 width, Int32 height, Int32 format, Int32 type, IntPtr data);
    #endregion

    #region gluLookAt
    [DllImport("glu32.dll")]
    internal static extern void gluLookAt(Double eyex, Double eyey, Double eyez, Double centerx, Double centery, Double centerz, Double upx, Double upy, Double upz);
    #endregion

    #region gluPerspective
    [DllImport("glu32.dll")]
    internal static extern void gluPerspective(Double fovy, Double aspect, Double zNear, Double zFar);
    #endregion
}