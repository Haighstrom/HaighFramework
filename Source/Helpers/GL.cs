using HaighFramework.OpenGL;
using HaighFramework.WinAPI;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HaighFramework;

internal static class GL
{
    public static List<string> GetAvailableExtensions()
    {
        string s = WGLExtensions.wglGetExtensionsStringARB(User32.GetDC(IntPtr.Zero));

        return s == null ? new List<string>() : s.Split(' ').ToList();
    }

    public static void GetProcAddress<T>(string functionName, out T functionPointer)
    {
        IntPtr procAddress = OpenGL32.wglGetProcAddress(functionName);

        if (procAddress == IntPtr.Zero)
            throw new Win32Exception($"Failed to load entrypoint for {functionName}.");

        functionPointer = (T)(object)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T));
    }
}