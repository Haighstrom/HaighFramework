namespace HaighFramework.Win32API;

using System.Security;
using System.Runtime.InteropServices;

[SuppressUnmanagedCodeSecurity]
internal static class OpenGL32
{
    #region --- OpenGL Core Functions ---
    #region glAlphaFunc
    [DllImport("opengl32.dll")]
    internal static extern void glAlphaFunc(int func, float @ref);
    #endregion

    #region glBegin
    [DllImport("opengl32.dll")]
    internal static extern void glBegin(int mode);
    #endregion

    #region glBindTexture
    [DllImport("opengl32.dll")]
    internal static extern void glBindTexture(int target, uint texture);
    #endregion

    #region glBlendFunc
    [DllImport("opengl32.dll")]
    internal static extern void glBlendFunc(int sfactor, int dfactor);
    #endregion

    #region glClear
    [DllImport("opengl32.dll")]
    internal static extern void glClear(uint mask);
    #endregion

    #region glClearColor
    [DllImport("opengl32.dll")]
    internal static extern void glClearColor(float red, float green, float blue, float alpha);
    #endregion

    #region glColor3f
    [DllImport("opengl32.dll")]
    internal static extern void glColor3f(float red, float green, float blue);
    #endregion

    #region glColor4f
    [DllImport("opengl32.dll")]
    internal static extern void glColor4f(float red, float green, float blue, float alpha);
    #endregion

    #region glDeleteTextures
    [DllImport("opengl32.dll")]
    internal static extern void glDeleteTextures(int n, uint[] textures);
    #endregion

    #region glDepthMask
    [DllImport("opengl32.dll")]
    internal static extern void glDepthMask(bool flag);
    #endregion

    #region glDisable
    [DllImport("opengl32.dll")]
    internal static extern void glDisable(int cap);
    #endregion

    #region glDisableClientState
    [DllImport("opengl32.dll")]
    internal static extern void glDisableClientState(uint array);
    #endregion

    #region glDrawArrays
    [DllImport("opengl32.dll")]
    internal static extern void glDrawArrays(int mode, int first, int count);
    #endregion

    #region glEnable
    [DllImport("opengl32.dll")]
    internal static extern void glEnable(int cap);
    #endregion

    #region glEnableClientState
    [DllImport("opengl32.dll")]
    internal static extern void glEnableClientState(uint array);
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
    internal static extern void glFrontFace(int mode);
    #endregion

    #region glGetBooleanv
    [DllImport("opengl32.dll")]
    internal static extern void glGetBooleanv(int pname, [Out] out bool[] data);
    #endregion

    #region glGetError
    [DllImport("opengl32.dll")]
    internal static extern uint glGetError();
    #endregion

    #region glGetIntegerv
    [DllImport("opengl32.dll")]
    internal static extern void glGetIntegerv(int pname, out int result);
    #endregion

    #region glGetIntegerv
    [DllImport("opengl32.dll")]
    internal static extern void glGetIntegerv(int pname, int[] result);
    #endregion

    #region glGetTexImage
    [DllImport("opengl32.dll")]
    internal static extern void glGetTexImage(int target, int level, int format, int type, IntPtr pixels);
    #endregion

    #region glGenTextures
    [DllImport("opengl32.dll")]
    internal static extern void glGenTextures(int n, uint[] textures);
    #endregion

    #region glGetString
    [DllImport("opengl32.dll")]
    internal unsafe static extern sbyte* glGetString(uint name);
    #endregion

    #region glIsEnabled
    [DllImport("opengl32.dll")]
    internal static extern byte glIsEnabled(int cap);
    #endregion

    #region glLightfv
    [DllImport("opengl32.dll")]
    internal static extern void glLightfv(int light, int pname, float[] @params);
    #endregion

    #region glLineWidth
    [DllImport("opengl32.dll")]
    internal static extern void glLineWidth(float width);
    #endregion

    #region glLoadIdentity
    [DllImport("opengl32.dll")]
    internal static extern void glLoadIdentity();
    #endregion

    #region glMaterialfv
    [DllImport("opengl32.dll")]
    internal static extern void glMaterialfv(int face, int pname, float[] @params);
    #endregion

    #region glMatrixMode
    [DllImport("opengl32.dll")]
    internal static extern void glMatrixMode(int mode);
    #endregion

    #region glNormal3f
    [DllImport("opengl32.dll")]
    internal static extern void glNormal3f(float nx, float ny, float nz);
    #endregion

    #region glOrtho
    [DllImport("opengl32.dll")]
    internal static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);
    #endregion

    #region glReadPixels
    [DllImport("opengl32.dll")]
    internal static extern void glReadPixels(int x, int y, int width, int height, int format, int type, [Out] IntPtr data);
    #endregion

    #region glPixelStore
    [DllImport("opengl32.dll")]
    internal static extern void glPixelStorei(int pname, int param);
    #endregion

    #region glPointSize
    [DllImport("opengl32.dll")]
    internal static extern void glPointSize(float size);
    #endregion

    #region glPolygonMode
    [DllImport("opengl32.dll")]
    internal static extern void glPolygonMode(int face, int mode);
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
    internal static extern void glRotatef(float angle, float x, float y, float z);
    #endregion

    #region glScalef
    [DllImport("opengl32.dll")]
    internal static extern void glScalef(float x, float y, float z);
    #endregion

    #region glShadeModel
    [DllImport("opengl32.dll")]
    internal static extern void glShadeModel(int mode);
    #endregion

    #region glTexCoord2f
    [DllImport("opengl32.dll")]
    internal static extern void glTexCoord2f(float s, float t);
    #endregion

    #region glTexImage1D
    [DllImport("opengl32.dll")]
    internal static extern void glTexImage1D(int target, int level, int internalformat, int width, int border, int format, int type, IntPtr pixels);
    #endregion

    #region glTexImage2D
    [DllImport("opengl32.dll")]
    internal static extern void glTexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels);
    #endregion

    #region glTexSubImage2D
    [DllImport("opengl32.dll")]
    internal static extern void glTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, IntPtr pixels);
    #endregion

    #region glTexParameteri
    [DllImport("opengl32.dll")]
    internal static extern void glTexParameteri(int target, int pname, int param);
    #endregion

    #region glTranslatef
    [DllImport("opengl32.dll")]
    internal static extern void glTranslatef(float x, float y, float z);
    #endregion

    #region glVertex2f
    [DllImport("opengl32.dll")]
    internal static extern void glVertex2f(float x, float y);
    #endregion

    #region glVertex3f
    [DllImport("opengl32.dll")]
    internal static extern void glVertex3f(float x, float y, float z);
    #endregion

    #region glVertexPointer
    [DllImport("opengl32.dll")]
    internal static extern void glVertexPointer(int size, uint type, int stride, float[] pointer);
    #endregion

    #region glViewport
    [DllImport("opengl32.dll")]
    internal static extern void glViewport(int x, int y, int width, int height);
    #endregion
    #endregion

    #region --- WGL Functions ---
    #region wglCreateContext
    [DllImport("opengl32.dll")]
    internal extern static IntPtr wglCreateContext(IntPtr hDc);
    #endregion

    #region wglDeleteContext
    [DllImport("opengl32.dll")]
    internal extern static bool wglDeleteContext(IntPtr hRC);
    #endregion

    #region wglDescribePixelFormat
    [DllImport("opengl32.dll")]
    internal static extern int wglDescribePixelFormat(IntPtr hdc, int ipfd, uint cjpfd, [In, MarshalAs(UnmanagedType.LPStruct)] PIXELFORMATDESCRIPTOR ppfd);
    #endregion

    #region wglGetCurrentContext
    [DllImport("opengl32.dll")]
    internal extern static IntPtr wglGetCurrentContext();
    #endregion

    #region wglGetProcAddress
    [DllImport("opengl32.dll")]
    internal extern static IntPtr wglGetProcAddress(string lpszProc);
    #endregion

    #region wglMakeCurrent
    [DllImport("opengl32.dll")]
    internal extern static bool wglMakeCurrent(IntPtr hDc, IntPtr hRC);
    #endregion

    #region wglShareLists
    [DllImport("opengl32.dll")]
    internal extern static bool wglShareLists(IntPtr hglrc1, IntPtr hglrc2);
    #endregion
    #endregion
}