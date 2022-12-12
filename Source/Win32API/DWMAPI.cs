using System.Runtime.InteropServices;

namespace HaighFramework.Win32API;

internal static class DWMAPI
{
    [DllImport("dwmapi.dll")]
    internal static extern int DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out bool pvAttribute, int cbAttribute);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out RECT pvAttribute, int cbAttribute);
    internal static int DwmGetWindowAttribute(IntPtr hwnd, out RECT pvAttribute) => DwmGetWindowAttribute(hwnd, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, out pvAttribute, RECT.UnmanagedSize);
}