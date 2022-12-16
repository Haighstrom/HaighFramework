using HaighFramework.WinAPI;

namespace HaighFramework.Console.Windows;

/// <summary>
/// A class for managing the Console Window
/// </summary>
internal class WinAPIConsoleWindow : IConsoleWindow
{
    private static IntPtr Handle => Kernal32.GetConsoleWindow();

    internal static RECT GetMaxSize()
    {
        IntPtr monitor = User32.MonitorFromWindow(Handle, MONITORFROMWINDOWFLAGS.MONITOR_DEFAULTTONEAREST);

        var mInfo = new MONITORINFO() { Size = MONITORINFO.UnmanagedSize };

        User32.GetMonitorInfo(monitor, ref mInfo);

        return mInfo.Work;
    }

    /// <summary>
    /// Create a default console, which is not visible
    /// </summary>
    public WinAPIConsoleWindow()
    {
    }

    /// <summary>
    /// Create a console with the specified settings
    /// </summary>
    /// <param name="settings"></param>
    public WinAPIConsoleWindow(ConsoleSettings settings)
    {
        if (settings.ShowConsoleWindow)
        {
            ShowConsole(settings.X, settings.Y, settings.Width, settings.Height);
        }
    }

    /// <summary>
    /// Whether the console is currently open/visible
    /// </summary>
    public bool Visible { get; private set; } = false;

    /// <summary>
    /// The maximum height the console can be without exceeding the screen height.
    /// </summary>
    public int MaxHeight => GetMaxSize().Height;

    /// <summary>
    /// The maximum width the console can be without exceeding the screen height.
    /// </summary>
    public int MaxWidth => GetMaxSize().Width;

    /// <summary>
    /// Hides/closes the console.
    /// </summary>
    public void HideConsole()
    {
        if (!Visible)
        {
            Log.Warning("Tried to hide console when it is not currently shown.");
            return;
        }

        Kernal32.FreeConsole();
        Visible = false;
    }

    /// <summary>
    /// Moves the console to a specified location on screen.
    /// </summary>
    /// <param name="x">The new x-coordinate of the top left of the console, relative to the top left of the main display.</param>
    /// <param name="y">The new y-coordinate of the top left of the console, relative to the top left of the main display.</param>
    /// <param name="width">The new width of the console in pixels.</param>
    /// <param name="height">The new height of the console in pixels.</param>
    public void MoveConsoleTo(int topLeftX, int topLeftY, int width, int height)
    {
        User32.MoveWindow(Handle, topLeftX, topLeftY, width, height, true);
    }

    /// <summary>
    /// Shows/opens the console.
    /// </summary>
    public void ShowConsole()
    {
        if (Visible)
        {
            Log.Warning("Tried to show console when it is already shown.");
                return;
        }

        Kernal32.AllocConsole();
        Visible = true;
    }

    /// <summary>
    /// Shows/opens the console at the location specified.
    /// </summary>
    /// <param name="x">The x-coordinate of the top left of the console, relative to the top left of the main display.</param>
    /// <param name="y">The y-coordinate of the top left of the console, relative to the top left of the main display.</param>
    /// <param name="width">The desired width of the console in pixels.</param>
    /// <param name="height">The desired height of the console in pixels.</param>
    public void ShowConsole(int topLeftX, int topLeftY, int width, int height)
    {
        if (Visible)
        {
            Log.Warning("Tried to show console when it is already shown.");
            return;
        }

        ShowConsole();

        MoveConsoleTo(topLeftX, topLeftY, width, height);
    }
}