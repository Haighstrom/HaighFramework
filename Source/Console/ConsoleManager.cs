﻿using HaighFramework.WinAPI;

namespace HaighFramework;

public class ConsoleManager : IConsoleManager
{
    private static IntPtr Handle => Kernal32.GetConsoleWindow();

    internal static RECT GetMaxSize()
    {
        IntPtr monitor = User32.MonitorFromWindow(Handle, MONITORFROMWINDOWFLAGS.MONITOR_DEFAULTTONEAREST);

        var mInfo = new MONITORINFO() { Size = MONITORINFO.UnmanagedSize };

        User32.GetMonitorInfo(monitor, ref mInfo);

        return mInfo.Work;
    }

    public bool IsOpen { get; private set; }

    public int MaxHeight => GetMaxSize().Height;

    public int MaxWidth => GetMaxSize().Width;

    public void HideConsole()
    {
        if (!IsOpen)
        {
            Log.Warning("Tried to hide console when it is not currently shown.");
            return;
        }

        Kernal32.FreeConsole();
        IsOpen = false;
    }

    public void MoveConsoleTo(int topLeftX, int topLeftY, int width, int height)
    {
        User32.MoveWindow(Handle, topLeftX, topLeftY, width, height, true);
    }

    public void ShowConsole()
    {
        if (IsOpen)
        {
            Log.Warning("Tried to show console when it is already shown.");
                return;
        }

        Kernal32.AllocConsole();
        IsOpen = true;
    }

    public void ShowConsole(int topLeftX, int topLeftY, int width, int height)
    {
        if (IsOpen)
        {
            Log.Warning("Tried to show console when it is already shown.");
            return;
        }

        ShowConsole();

        MoveConsoleTo(topLeftX, topLeftY, width, height);
    }
}