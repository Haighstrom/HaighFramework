using HaighFramework.OpenGL;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HaighFramework.Window;

internal class OpenGLWindowsRenderContext
{
    private static IntPtr CreateRenderContext(IntPtr deviceContext, (int major, int minor) openGLversion)
    {
        int[] attribs = {
            (int)ArbCreateContext.MajorVersion, openGLversion.major,
            (int)ArbCreateContext.MinorVersion, openGLversion.minor,
            (int)ArbCreateContext.ProfileMask, (int)ArbCreateContext.ForwardCompatibleBit,
            0 };

        var rC = WGLExtensions.wglCreateContextAttribsARB(deviceContext, sharedContext: IntPtr.Zero, attribs);

        if (rC == IntPtr.Zero)
            throw new Win32Exception($"Something went wrong with wglCreateContextAttribsARB: {Marshal.GetLastWin32Error()}");

        return rC;
    }

    public OpenGLWindowsRenderContext(IntPtr deviceContext, int glVersionMajor, int glVersionMinor)
    {
        if (glVersionMajor < 1 || glVersionMinor < 0)
            throw new Exception($"invalid GL version to create: {glVersionMajor}.{glVersionMinor}.");

        Log.Information($"Creating GL Context: Requested Version {glVersionMajor}.{glVersionMinor}");

        //create temp context to be able to call wglGetProcAddress
        IntPtr tempContext = OpenGL32.wglCreateContext(deviceContext);
        if (tempContext == IntPtr.Zero)
            throw new Exception("tempContext failed to create.");
        if (!OpenGL32.wglMakeCurrent(deviceContext, tempContext))
            throw new Exception("wglMakeCurrent Failed");
        WGLExtensions.LoadWGLExtensions();

        Handle = CreateRenderContext(deviceContext, (glVersionMajor, glVersionMinor));

        OpenGL32.LoadOpenGL3Extensions();

        OpenGL32.wglDeleteContext(tempContext);
    }

    public IntPtr Handle { get; }
}