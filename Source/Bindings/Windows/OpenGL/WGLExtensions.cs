using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HaighFramework.OpenGL;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "OpenGL functions have dumb naming conventions but I'm keeping these APIs pure.")]
public static class WGLExtensions
{
    private delegate string Delegate_wglGetExtensionsStringARB(IntPtr hDc);
    private delegate bool Delegate_wglGetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, [Out] int[] piValues);

    private static Delegate_wglGetExtensionsStringARB? _wglGetExtensionsStringARB;
    private static Delegate_wglGetPixelFormatAttribivARB _wglGetPixelFormatAttribivARB;

    internal static void LoadExtensions()
    {
        OpenGL32.GetProcAddress("wglGetExtensionsStringARB", out _wglGetExtensionsStringARB);
        OpenGL32.GetProcAddress("wglCreateContextAttribsARB", out _wglCreateContextAttribsARB);
        OpenGL32.GetProcAddress("wglSwapIntervalEXT", out _wglSwapIntervalEXT);
        OpenGL32.GetProcAddress("wglGetSwapIntervalEXT", out _wglGetSwapIntervalEXT);
        OpenGL32.GetProcAddress("wglChoosePixelFormatARB", out _wglChoosePixelFormatARB);
        OpenGL32.GetProcAddress("wglGetPixelFormatAttribivARB", out _wglGetPixelFormatAttribivARB);
    }

    public static string wglGetExtensionsStringARB(IntPtr hDc)
    {
        if (_wglGetExtensionsStringARB is null)
            throw new EntryPointNotFoundException($"{nameof(wglGetExtensionsStringARB)} was called but the entrypoint was not loaded.");

        return _wglGetExtensionsStringARB(hDc);
    }

    public static bool wglGetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, [Out] int[] piValues)
    {
        return _wglGetPixelFormatAttribivARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes, piValues);
    }

    internal delegate bool wglChoosePixelFormatARB(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, [Out] int[] piFormats, out int nNumFormats);
    internal static wglChoosePixelFormatARB _wglChoosePixelFormatARB;
    public static bool ChoosePixelFormatARB(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, [Out] int[] piFormats, out int nNumFormats)
        => _wglChoosePixelFormatARB(hdc, piAttribIList, pfAttribFList, nMaxFormats, piFormats, out nNumFormats);


    //note that this is necessarily created before LoadOpenGLExtensions is called
    internal delegate IntPtr wglCreateContextAttribsARB(IntPtr hDc, IntPtr sharedContext, int[] attribList);
    internal static wglCreateContextAttribsARB _wglCreateContextAttribsARB;

    public static IntPtr CreateContextAttribsARB(IntPtr hDc, IntPtr sharedContext, int[] attribList)
        => _wglCreateContextAttribsARB(hDc, sharedContext, attribList);


    internal delegate bool wglSwapIntervalEXT(int value);
    internal static wglSwapIntervalEXT _wglSwapIntervalEXT;
    /// <summary>
    /// Set VSync options, -1, 0 or 1
    /// https://stackoverflow.com/questions/589064/how-to-enable-vertical-sync-in-opengl
    /// </summary>
    /// <param name="value"></param>
    public static bool SwapIntervalEXT(int value) => _wglSwapIntervalEXT(value);


    internal delegate int wglGetSwapIntervalEXT();
    internal static wglGetSwapIntervalEXT _wglGetSwapIntervalEXT;
    public static int GetSwapIntervalEXT() => _wglGetSwapIntervalEXT();

}