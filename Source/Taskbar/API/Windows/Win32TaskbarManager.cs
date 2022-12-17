using HaighFramework.WinAPI;

namespace HaighFramework.Taskbar.API.Windows;

internal class Win32TaskbarManager : ITaskbarManager
{
    private const string CLASS_NAME = "Shell_TrayWnd";

    public Win32TaskbarManager()
    {
        IntPtr taskbarHandle = User32.FindWindow(CLASS_NAME, null);

        APPBARDATA data = new()
        {
            cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(APPBARDATA)),
            hWnd = taskbarHandle
        };
        IntPtr result = Shell32.SHAppBarMessage(APPBARMESSAGE.ABM_GETTASKBARPOS, ref data);
        if (result == IntPtr.Zero)
            throw new InvalidOperationException();

        X = data.rc.left;
        Y = data.rc.top;
        Width = data.rc.right - data.rc.left;
        Height = data.rc.bottom - data.rc.top;
        Position = (TaskbarPosition)data.uEdge;

        data.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(APPBARDATA));
        result = Shell32.SHAppBarMessage(APPBARMESSAGE.ABM_GETSTATE, ref data);
        ABS state = (ABS)result.ToInt32();

        AlwaysOnTop = state.HasFlag(ABS.AlwaysOnTop);
        AutoHide = state.HasFlag(ABS.Autohide);
    }

    public bool AlwaysOnTop { get; }

    public bool AutoHide { get; }

    public TaskbarPosition Position { get; }

    public int Height { get; }

    public int Width { get; }

    public int X { get; }

    public int Y { get; }
}
