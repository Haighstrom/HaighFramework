﻿namespace HaighFramework.Window;

using HaighFramework.Win32API;

public class WindowSettings
{
    #region Basic
    /// <summary>
    /// Whether the window is created initially visible. True by default.
    /// </summary>
    public bool Visible { get; set; } = true;

    /// <summary>
    /// Whether when Close events happen (e.g. X pressed, Close() called) the window will be destroyed. True by default.
    /// Change this to false to allow custom behaviour when closing the window (e.g. popup saying there are unsaved changes).
    /// </summary>
    public bool ExitOnClose { get; set; } = true;
    #endregion

    #region Window Frame
    /// <summary>
    /// The title of the window
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// The Window Icon (on the window and taskbar)
    /// </summary>
    public Icon Icon { get; set; } = Icon.Default;

    /// <summary>
    /// Type of border for the window. Defaults to a sizing border.
    /// </summary>
    public BorderStyle Border { get; set; } = BorderStyle.SizingBorder;

    /// <summary>
    /// State of the window.
    /// </summary>
    public WindowState State { get; set; } = WindowState.Normal;
    #endregion

    #region Position
    /// <summary>
    /// The desired position of the window (X,Y are the top left of the window, W, H are the size of the client)
    /// </summary>
    public IRect<int> Position
    {
        get => new Rect<int>(X, Y, Width, Height);
        set
        {
            X = value.X;
            Y = value.Y;
            Width = value.W;
            Height = value.H;
        }
    }

    /// <summary>
    /// The desired X (left) position of the window
    /// </summary>
    public int X { get; set; } = 100;

    /// <summary>
    /// The desired Y (top) position of the window
    /// </summary>
    public int Y { get; set; } = 100;

    /// <summary>
    /// The desired Width of the window client
    /// </summary>
    public int Width { get; set; } = 400;

    /// <summary>
    /// The desired Height of the window client
    /// </summary>
    public int Height { get; set; } = 400;

    /// <summary>
    /// Restricts the minimum size of the Window
    /// </summary>
    public Point<int> MinClientSize { get; set; } = new();

    /// <summary>
    /// Restricts the maximum size of the Window
    /// </summary>
    public Point<int> MaxClientSize { get; set; } = new();

    /// <summary>
    /// Whether the window should be created centred on the screen on creation - ignores X,Y
    /// </summary>
    public bool Centre { get; set; } = false;
    #endregion

    #region Cursor
    public Cursor Cursor { get; set; } = Cursor.Default;
    /// <summary>
    /// Whether the mouse is initially visible. Defaults to true.
    /// </summary>
    public bool CursorVisible { get; set; } = true;
    /// <summary>
    /// Whether the mouse cursor is locked within the window. Defaults to false.
    /// </summary>
    public bool CursorLockedToWindow { get; set; } = false;
    #endregion
}