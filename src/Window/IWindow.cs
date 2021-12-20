using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HaighFramework.Window
{
    public interface IWindow : IDisposable
    {
        IntPtr WindowHandle { get; }
        bool IsRunning { get; }

        IRect<float> Position { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        IRect<float> ClientPosition { get; set; }
        IRect<float> ClientZeroed { get; }
        IPoint<float> ClientSize { get; set; }

        int MinWidth { get; set; }
        int MaxWidth { get; set; }
        int MinHeight { get; set; }
        int MaxHeight { get; set; }

        string Title { get; set; }
        bool IsFocussed { get; }
        bool Visible { get; set; }
        System.Drawing.Icon Icon { set; }

        BorderStyle WindowBorder { get; set; }
        WindowState WindowState { get; set; }
        Cursor Cursor { get; set; }
        bool CursorVisible { get; set; }
        bool CursorLockedToWindow { get; set; }
        bool CloseWhenXPressed { get; set; }

        void ProcessEvents();
        void SwapBuffers();
        void Centre();
        void Close();
        void MakeFocussed();

        event EventHandler Moved;
        event EventHandler<SizeEventArgs> Resize;
        event EventHandler Closing;
        event EventHandler Closed;
        event EventHandler<BoolEventArgs> FocusChanged;
        event EventHandler<BoolEventArgs> VisibleChanged;
        event EventHandler<BorderChangeEventArgs> BorderChanged;
        event EventHandler<WindowStateChangeEventArgs> StateChanged;
        event EventHandler<Input.KeyboardCharEventArgs> CharEntered;
        event EventHandler<Input.KeyboardKeyEventArgs> KeyDown;
        event EventHandler<Input.KeyboardKeyEventArgs> KeyUp;
        event EventHandler MouseEntered;
        event EventHandler MouseLeft;
        event EventHandler MouseMoved;
        event EventHandler MouseLeftDoubleClicked;
    }
}