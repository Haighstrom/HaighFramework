using System.Runtime.InteropServices;

namespace HaighFramework.Win32API;

internal static class Shell32
{

    // * * * CLEANED UP ABOVE THIS LINE * * *
    #region SHAppBarMessage
    [DllImport("shell32.dll")]
    internal static extern IntPtr SHAppBarMessage(ABM dwMessage, [In] ref APPBARDATA pData);
    #endregion
}