using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HaighFramework;

public class ConsoleSettings
{
    private const int DefaultWidth = 450;

    private static int GetInvisibleLeftBorder() //Don't even fucking ask. Fuck you Windows 10.
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && Environment.OSVersion.Version.Major == 10)
            return 7;
        else
            return 0;
    }

    /// <summary>
    /// The default console settings.
    /// </summary>
    public static ConsoleSettings Default => new();

    /// <summary>
    /// Whether the console should be shown. Defaults to true if a debugger is being used, false otherwise.
    /// </summary>
    public bool ShowConsoleWindow { get; set; } = Debugger.IsAttached; //better than #if DEBUG because may be using Release version of this dll even if Debug in the application

    /// <summary>
    /// The x-coordinate of the top left position of the console. Defaults to the top left of the screen.
    /// </summary>
    public int X { get; set; } = 0 - GetInvisibleLeftBorder();

    /// <summary>
    /// The y-coordinate of the top left position of the console. Defaults to the top left of the screen.
    /// </summary>
    public int Y { get; set; } = 0;

    /// <summary>
    /// The width of the console in pixels. Defaults to 450.
    /// </summary>
    public int Width { get; set; } = DefaultWidth;

    /// <summary>
    /// The height of the console in pixels. Defaults to the height of the window.
    /// </summary>
    public int Height { get; set; } = ConsoleManager.GetMaxSize().Height;
}