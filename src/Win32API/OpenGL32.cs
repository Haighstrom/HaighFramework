namespace HaighFramework.Win32API;

using System.Security;
using System.Runtime.InteropServices;

[SuppressUnmanagedCodeSecurity]
internal static class OpenGL32
{
    // * * * CLEANED UP ABOVE THIS LINE * * *

    #region --- OpenGL Core Functions ---
    #region glAlphaFunc
    [DllImport("opengl32.dll")]
    internal static extern void glAlphaFunc(Int32 func, Single @ref);
    #endregion

    #region glBegin
    [DllImport("opengl32.dll")]
    internal static extern void glBegin(Int32 mode);
    #endregion

    #region glBindTexture
    [DllImport("opengl32.dll")]
    internal static extern void glBindTexture(Int32 target, UInt32 texture);
    #endregion

    #region glBlendFunc
    [DllImport("opengl32.dll")]
    internal static extern void glBlendFunc(Int32 sfactor, Int32 dfactor);
    #endregion

    #region glClear
    [DllImport("opengl32.dll")]
    internal static extern void glClear(UInt32 mask);
    #endregion

    #region glClearColor
    [DllImport("opengl32.dll")]
    internal static extern void glClearColor(Single red, Single green, Single blue, Single alpha);
    #endregion

    #region glColor3f
    [DllImport("opengl32.dll")]
    internal static extern void glColor3f(Single red, Single green, Single blue);
    #endregion

    #region glColor4f
    [DllImport("opengl32.dll")]
    internal static extern void glColor4f(Single red, Single green, Single blue, Single alpha);
    #endregion

    #region glDeleteTextures
    [DllImport("opengl32.dll")]
    internal static extern void glDeleteTextures(Int32 n, UInt32[] textures);
    #endregion

    #region glDepthMask
    [DllImport("opengl32.dll")]
    internal static extern void glDepthMask(Boolean flag);
    #endregion

    #region glDisable
    [DllImport("opengl32.dll")]
    internal static extern void glDisable(Int32 cap);
    #endregion

    #region glDisableClientState
    [DllImport("opengl32.dll")]
    internal static extern void glDisableClientState(UInt32 array);
    #endregion

    #region glDrawArrays
    [DllImport("opengl32.dll")]
    internal static extern void glDrawArrays(int mode, int first, int count);
    #endregion

    #region glEnable
    [DllImport("opengl32.dll")]
    internal static extern void glEnable(Int32 cap);
    #endregion

    #region glEnableClientState
    [DllImport("opengl32.dll")]
    internal static extern void glEnableClientState(UInt32 array);
    #endregion

    #region glEnd
    [DllImport("opengl32.dll")]
    internal static extern void glEnd();
    #endregion

    #region glFlush
    [DllImport("opengl32.dll")]
    public static extern void glFlush();
    #endregion

    #region glFrontFace
    [DllImport("opengl32.dll")]
    internal static extern void glFrontFace(Int32 mode);
    #endregion

    #region glGetBooleanv
    [DllImport("opengl32.dll")]
    internal static extern void glGetBooleanv(Int32 pname, [Out] out Boolean[] data);
    #endregion

    #region glGetError
    [DllImport("opengl32.dll")]
    internal static extern uint glGetError();
    #endregion

    #region glGetIntegerv
    [DllImport("opengl32.dll")]
    internal static extern void glGetIntegerv(Int32 pname, out Int32 result);
    #endregion

    #region glGetTexImage
    [DllImport("opengl32.dll")]
    internal static extern void glGetTexImage(Int32 target, Int32 level, Int32 format, Int32 type, IntPtr pixels);
    #endregion

    #region glGenTextures
    [DllImport("opengl32.dll")]
    internal static extern void glGenTextures(Int32 n, UInt32[] textures);
    #endregion

    #region glGetString
    [DllImport("opengl32.dll")]
    internal unsafe static extern sbyte* glGetString(uint name);
    #endregion

    #region glIsEnabled
    [DllImport("opengl32.dll")]
    internal static extern Byte glIsEnabled(Int32 cap);
    #endregion

    #region glLightfv
    [DllImport("opengl32.dll")]
    internal static extern void glLightfv(Int32 light, Int32 pname, Single[] @params);
    #endregion

    #region glLineWidth
    [DllImport("opengl32.dll")]
    internal static extern void glLineWidth(Single width);
    #endregion

    #region glLoadIdentity
    [DllImport("opengl32.dll")]
    internal static extern void glLoadIdentity();
    #endregion

    #region glMaterialfv
    [DllImport("opengl32.dll")]
    internal static extern void glMaterialfv(Int32 face, Int32 pname, Single[] @params);
    #endregion

    #region glMatrixMode
    [DllImport("opengl32.dll")]
    internal static extern void glMatrixMode(Int32 mode);
    #endregion

    #region glNormal3f
    [DllImport("opengl32.dll")]
    internal static extern void glNormal3f(Single nx, Single ny, Single nz);
    #endregion

    #region glOrtho
    [DllImport("opengl32.dll")]
    internal static extern void glOrtho(Double left, Double right, Double bottom, Double top, Double zNear, Double zFar);
    #endregion

    #region glReadPixels
    [DllImport("opengl32.dll")]
    internal static extern void glReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, Int32 format, Int32 type, [Out] IntPtr data);
    #endregion

    #region glPixelStore
    [DllImport("opengl32.dll")]
    internal static extern void glPixelStorei(Int32 pname, Int32 param);
    #endregion

    #region glPointSize
    [DllImport("opengl32.dll")]
    internal static extern void glPointSize(Single size);
    #endregion

    #region glPolygonMode
    [DllImport("opengl32.dll")]
    internal static extern void glPolygonMode(Int32 face, Int32 mode);
    #endregion

    #region glPopMatrix
    [DllImport("opengl32.dll")]
    internal static extern void glPopMatrix();
    #endregion

    #region glPushMatrix
    [DllImport("opengl32.dll")]
    internal static extern void glPushMatrix();
    #endregion

    #region glRotatef
    [DllImport("opengl32.dll")]
    internal static extern void glRotatef(Single angle, Single x, Single y, Single z);
    #endregion

    #region glScalef
    [DllImport("opengl32.dll")]
    internal static extern void glScalef(Single x, Single y, Single z);
    #endregion

    #region glShadeModel
    [DllImport("opengl32.dll")]
    internal static extern void glShadeModel(Int32 mode);
    #endregion

    #region glTexCoord2f
    [DllImport("opengl32.dll")]
    internal static extern void glTexCoord2f(Single s, Single t);
    #endregion

    #region glTexImage1D
    [DllImport("opengl32.dll")]
    internal static extern void glTexImage1D(Int32 target, Int32 level, Int32 internalformat, Int32 width, Int32 border, Int32 format, Int32 type, IntPtr pixels);
    #endregion

    #region glTexImage2D
    [DllImport("opengl32.dll")]
    internal static extern void glTexImage2D(Int32 target, Int32 level, Int32 internalformat, Int32 width, Int32 height, Int32 border, Int32 format, Int32 type, IntPtr pixels);
    #endregion

    #region glTexSubImage2D
    [DllImport("opengl32.dll")]
    internal static extern void glTexSubImage2D(Int32 target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, Int32 format, Int32 type, IntPtr pixels);
    #endregion

    #region glTexParameteri
    [DllImport("opengl32.dll")]
    internal static extern void glTexParameteri(Int32 target, Int32 pname, Int32 param);
    #endregion

    #region glTranslatef
    [DllImport("opengl32.dll")]
    internal static extern void glTranslatef(Single x, Single y, Single z);
    #endregion

    #region glVertex2f
    [DllImport("opengl32.dll")]
    internal static extern void glVertex2f(Single x, Single y);
    #endregion

    #region glVertex3f
    [DllImport("opengl32.dll")]
    internal static extern void glVertex3f(Single x, Single y, Single z);
    #endregion

    #region glVertexPointer
    [DllImport("opengl32.dll")]
    internal static extern void glVertexPointer(Int32 size, UInt32 type, Int32 stride, Single[] pointer);
    #endregion

    #region glViewport
    [DllImport("opengl32.dll")]
    internal static extern void glViewport(Int32 x, Int32 y, Int32 width, Int32 height);
    #endregion
    #endregion

    #region --- WGL Functions ---
    #region wglCreateContext
    [DllImport("opengl32.dll")]
    internal extern static IntPtr wglCreateContext(IntPtr hDc);
    #endregion

    #region wglDeleteContext
    [DllImport("opengl32.dll")]
    internal extern static Boolean wglDeleteContext(IntPtr hRC);
    #endregion

    #region wglDescribePixelFormat
    [DllImport("opengl32.dll")]
    internal static extern Int32 wglDescribePixelFormat(IntPtr hdc, Int32 ipfd, UInt32 cjpfd, [In, MarshalAs(UnmanagedType.LPStruct)] PIXELFORMATDESCRIPTOR ppfd);
    #endregion

    #region wglGetCurrentContext
    [DllImport("opengl32.dll")]
    internal extern static IntPtr wglGetCurrentContext();
    #endregion

    #region wglGetProcAddress
    [DllImport("opengl32.dll")]
    internal extern static IntPtr wglGetProcAddress(String lpszProc);
    #endregion

    #region wglMakeCurrent
    [DllImport("opengl32.dll")]
    internal extern static Boolean wglMakeCurrent(IntPtr hDc, IntPtr hRC);
    #endregion

    #region wglShareLists
    [DllImport("opengl32.dll")]
    internal extern static Boolean wglShareLists(IntPtr hglrc1, IntPtr hglrc2);
    #endregion
    #endregion
}