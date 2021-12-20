using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaighFramework.Win32API;

namespace HaighFramework
{
    public enum TaskbarPosition
    {
        Unknown = -1,
        Left,
        Top,
        Right,
        Bottom,
    }

    public static class Taskbar
    {
        private const string CLASS_NAME = "Shell_TrayWnd";

        static Taskbar()
        {
            IntPtr taskbarHandle = User32.FindWindow(Taskbar.CLASS_NAME, null);

            APPBARDATA data = new APPBARDATA();
            data.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(APPBARDATA));
            data.hWnd = taskbarHandle;
            IntPtr result = Shell32.SHAppBarMessage(ABM.GetTaskbarPos, ref data);
            if (result == IntPtr.Zero)
                throw new InvalidOperationException();

            Position = (TaskbarPosition)data.uEdge;
            R = new Rect<int>(data.rc.left, data.rc.top, data.rc.right - data.rc.left, data.rc.bottom - data.rc.top);

            data.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(APPBARDATA));
            result = Shell32.SHAppBarMessage(ABM.GetState, ref data);
            int state = result.ToInt32();
            AlwaysOnTop = (state & (int)ABS.AlwaysOnTop) == (int)ABS.AlwaysOnTop;
            AutoHide = (state & (int)ABS.Autohide) == (int)ABS.Autohide;
        }

        public static IRect<int> R { get; set; }
        public static TaskbarPosition Position { get; set; }
        public static bool AlwaysOnTop { get; set; }
        public static bool AutoHide { get; set; }

        public static IPoint<int> P => R.P;
        public static int X => R.X;
        public static int Y => R.Y;
        public static int W => R.W;
        public static int H => R.H;
        public static IPoint<int> Centre => R.Centre;
        public static IPoint<int> Size => R.Size;
    }
}