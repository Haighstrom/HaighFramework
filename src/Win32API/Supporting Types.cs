namespace HaighFramework.Win32API;

using System;
using System.Runtime.InteropServices;

#region DLLResources
#region User32Cursors
internal enum User32Cursors : ushort
{
    StandardArrow = 100,
    IBeam = 101,
    Hourglass = 102,
    CrossHair = 103,
    UpArrow = 104,
    ArrowUpLeftAndDownRight = 105,
    ArrowUpRightAndDownLeft = 106,
    ArrowLeftAndRight = 107,
    ArrowUpAndDown = 108,
    ArrowAll = 109,
    NotAllowed = 110,
    ArrowAndHourglass = 111,
    ArrowAndQuestionMark = 112,
    Pen = 113,
    Hand = 114,
    Frame = 115,
    CD = 116,
    Location = 117,
    User = 118,
    ScrollingUpAndDown = 32652,
    ScrollingLeftAndRight = 32653,
    ScrollingAll = 32654,
    ScrollingUp = 32655,
    ScrollingDown = 32656,
    ScrollingLeft = 32657,
    ScrollingRight = 32658,
    ScrollingUpLeft = 32659,
    ScrollingUpRight = 32660,
    ScrollingDownLeft = 32661,
    ScrollingDownRight = 32662,
    SmallStar = 32664,
    SmallStarLeftQuestionMark = 32667,
    SmallStarRightQuestionMark = 32668,
    Dot = 32670,
}
#endregion

#region User32Icons
internal enum User32Icons : ushort
{
    APPLICATION = 100,
    EXCLAMATION = 101,
    QUESTION = 102,
    ERROR = 103,
    INFORMATION = 104,
    SHIELD = 106,
}
#endregion
#endregion

#region Enums
#region DeviceBroadcastType
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/dbt/ns-dbt-dev_broadcast_hdr
/// For use with RegisterDeviceNotification
/// </summary>
internal enum DEV_BROADCAST_HDR_dbch_devicetype
{
    /// <summary>
    /// Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.
    /// </summary>
    DBT_DEVTYP_DEVICEINTERFACE = 0x00000005,
    /// <summary>
    /// File system handle. This structure is a DEV_BROADCAST_HANDLE structure.
    /// </summary>
    DBT_DEVTYP_HANDLE = 0x00000006,
    /// <summary>
    /// OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.
    /// </summary>
    DBT_DEVTYP_OEM = 0x00000000,
    /// <summary>
    /// Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.
    /// </summary>
    DBT_DEVTYP_PORT = 0x00000003,
    /// <summary>
    /// Logical volume. This structure is a DEV_BROADCAST_VOLUME structure.
    /// </summary>
    DBT_DEVTYP_VOLUME = 0x00000002,
}
#endregion

#region DWMWINDOWATTRIBUTE
//https://docs.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute
internal enum DWMWINDOWATTRIBUTE : uint
{
    DWMWA_NCRENDERING_ENABLED = 1,
    DWMWA_NCRENDERING_POLICY,
    DWMWA_TRANSITIONS_FORCEDISABLED,
    DWMWA_ALLOW_NCPAINT,
    DWMWA_CAPTION_BUTTON_BOUNDS,
    DWMWA_NONCLIENT_RTL_LAYOUT,
    DWMWA_FORCE_ICONIC_REPRESENTATION,
    DWMWA_FLIP3D_POLICY,
    DWMWA_EXTENDED_FRAME_BOUNDS,
    DWMWA_HAS_ICONIC_BITMAP,
    DWMWA_DISALLOW_PEEK,
    DWMWA_EXCLUDED_FROM_PEEK,
    DWMWA_CLOAK,
    DWMWA_CLOAKED,
    DWMWA_FREEZE_REPRESENTATION,
    DWMWA_PASSIVE_UPDATE_MODE,
    DWMWA_USE_HOSTBACKDROPBRUSH,
    DWMWA_USE_IMMERSIVE_DARK_MODE,
    DWMWA_WINDOW_CORNER_PREFERENCE,
    DWMWA_BORDER_COLOR,
    DWMWA_CAPTION_COLOR,
    DWMWA_TEXT_COLOR,
    DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
    DWMWA_LAST
}
#endregion

#region LoadImage_Type
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadimagew
/// The type of image to be loaded. For use in User32 LoadImage.
/// </summary>
internal enum LoadImage_Type : uint
{
    /// <summary>
    /// Loads a bitmap.
    /// </summary>
    IMAGE_BITMAP = 0,
    /// <summary>
    /// Loads a cursor.
    /// </summary>
    IMAGE_CURSOR = 2,
    /// <summary>
    /// Loads an icon.
    /// </summary>
    IMAGE_ICON = 1,
}
#endregion

#region LoadImage_FULoad
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadimagew
/// For use in User32 LoadImage
/// </summary>
internal enum LoadImage_FULoad : uint
{
    /// <summary>
    /// When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section bitmap rather than a compatible bitmap. This flag is useful for loading a bitmap without mapping it to the colors of the display device.
    /// </summary>
    LR_CREATEDIBSECTION = 0x00002000,
    /// <summary>
    /// The default flag; it does nothing. All it means is "not LR_MONOCHROME".
    /// </summary>
    LR_DEFAULTCOLOR = 0x00000000,
    /// <summary>
    /// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size. If the resource contains multiple images, the function uses the size of the first image.
    /// </summary>
    LR_DEFAULTSIZE = 0x00000040,
    /// <summary>
    /// Loads the stand-alone image from the file specified by lpszName (icon, cursor, or bitmap file).
    /// </summary>
    LR_LOADFROMFILE = 0x00000010,
    /// <summary>
    /// Searches the color table for the image and replaces the following shades of gray with the corresponding 3-D color.
    /// Dk Gray, RGB(128,128,128) with COLOR_3DSHADOW
    /// Gray, RGB(192,192,192) with COLOR_3DFACE
    /// Lt Gray, RGB(223,223,223) with COLOR_3DLIGHT
    /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
    /// </summary>
    LR_LOADMAP3DCOLORS = 0x00001000,
    /// <summary>
    /// Retrieves the color value of the first pixel in the image and replaces the corresponding entry in the color table with the default window color (COLOR_WINDOW). All pixels in the image that use that entry become the default window color. This value applies only to images that have corresponding color tables.
    /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
    /// If fuLoad includes both the LR_LOADTRANSPARENT and LR_LOADMAP3DCOLORS values, LR_LOADTRANSPARENT takes precedence. However, the color table entry is replaced with COLOR_3DFACE rather than COLOR_WINDOW.
    /// </summary>
    LR_LOADTRANSPARENT = 0x00000020,
    /// <summary>
    /// Loads the image in black and white.
    /// </summary>
    LR_MONOCHROME = 0x00000001,
    /// <summary>
    /// Shares the image handle if the image is loaded multiple times. If LR_SHARED is not set, a second call to LoadImage for the same resource will load the image again and return a different handle.
    /// When you use this flag, the system will destroy the resource when it is no longer needed.
    /// Do not use LR_SHARED for images that have non-standard sizes, that may change after loading, or that are loaded from a file.
    /// When loading a system icon or cursor, you must use LR_SHARED or the function will fail to load the resource.
    /// This function finds the first image in the cache with the requested resource name, regardless of the size requested.
    /// </summary>
    LR_SHARED = 0x00008000,
    /// <summary>
    /// Uses true VGA colors.
    /// </summary>
    LR_VGACOLOR = 0x00000080,
}
#endregion

enum MonitorDpiType
{
    MDT_EFFECTIVE_DPI = 0,
    MDT_ANGULAR_DPI = 1,
    MDT_RAW_DPI = 2,
    MDT_DEFAULT = MDT_EFFECTIVE_DPI,
}
internal enum PROCESS_DPI_AWARENESS
{
    Process_DPI_Unaware = 0,
    Process_System_DPI_Aware = 1,
    Process_Per_Monitor_DPI_Aware = 2
}

internal enum DPI_AWARENESS_CONTEXT
{
    DPI_AWARENESS_CONTEXT_UNAWARE = -1,
    DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = -2,
    DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = -3,
    DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4,
    DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = -5,
}

#region WindowClassStyle
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/winmsg/window-class-styles
/// The class styles define additional elements of the window class. Two or more styles can be combined by using the bitwise OR (|) operator. To assign a style to a window class, assign the style to the style member of the WNDCLASSEX structure.
/// </summary>
[Flags]
internal enum WindowClassStyle : uint
{
    /// <summary>
    /// Aligns the window's client area on a byte boundary (in the x direction). This style affects the width of the window and its horizontal placement on the display.
    /// </summary>
    CS_BYTEALIGNCLIENT = 0x1000,
    /// <summary>
    /// Aligns the window on a byte boundary (in the x direction). This style affects the width of the window and its horizontal placement on the display.
    /// </summary>
    CS_BYTEALIGNWINDOW = 0x2000,
    /// <summary>
    /// Allocates one device context to be shared by all windows in the class. Because window classes are process specific, it is possible for multiple threads of an application to create a window of the same class. It is also possible for the threads to attempt to use the device context simultaneously. When this happens, the system allows only one thread to successfully finish its drawing operation.
    /// </summary>
    CS_CLASSDC = 0x0040,
    /// <summary>
    /// Sends a double-click message to the window procedure when the user double-clicks the mouse while the cursor is within a window belonging to the class.
    /// </summary>
    CS_DBLCLKS = 0x0008,
    /// <summary>
    /// Enables the drop shadow effect on a window. The effect is turned on and off through SPI_SETDROPSHADOW. Typically, this is enabled for small, short-lived windows such as menus to emphasize their Z-order relationship to other windows. Windows created from a class with this style must be top-level windows; they may not be child windows.
    /// </summary>
    CS_DROPSHADOW = 0x00020000,
    /// <summary>
    /// Indicates that the window class is an application global class. For more information, see the "Application Global Classes" section of About Window Classes.
    /// </summary>
    CS_GLOBALCLASS = 0x4000,
    /// <summary>
    /// Redraws the entire window if a movement or size adjustment changes the width of the client area.
    /// </summary>
    CS_HREDRAW = 0x0002,
    /// <summary>
    /// Disables Close on the window menu.
    /// </summary>
    CS_NOCLOSE = 0x0200,
    /// <summary>
    /// Allocates a unique device context for each window in the class.
    /// </summary>
    CS_OWNDC = 0x0020,
    /// <summary>
    /// Sets the clipping rectangle of the child window to that of the parent window so that the child can draw on the parent. A window with the CS_PARENTDC style bit receives a regular device context from the system's cache of device contexts. It does not give the child the parent's device context or device context settings. Specifying CS_PARENTDC enhances an application's performance.
    /// </summary>
    CS_PARENTDC = 0x0080,
    /// <summary>
    /// Saves, as a bitmap, the portion of the screen image obscured by a window of this class. When the window is removed, the system uses the saved bitmap to restore the screen image, including other windows that were obscured. Therefore, the system does not send WM_PAINT messages to windows that were obscured if the memory used by the bitmap has not been discarded and if other screen actions have not invalidated the stored image.
    /// This style is useful for small windows (for example, menus or dialog boxes) that are displayed briefly and then removed before other screen activity takes place. This style increases the time required to display the window, because the system must first allocate memory to store the bitmap.
    /// </summary>
    CS_SAVEBITS = 0x0800,
    /// <summary>
    /// Redraws the entire window if a movement or size adjustment changes the height of the client area.
    /// </summary>
    CS_VREDRAW = 0x0001,
}
#endregion

#region RegisterDeviceNotification_Flags
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerdevicenotificationa
/// For use with User32 RegisterDeviceNotification
/// </summary>
internal enum RegisterDeviceNotification_Flags
{
    /// <summary>
    /// The hRecipient parameter is a window handle.
    /// </summary>
    DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000,
    /// <summary>
    /// The hRecipient parameter is a service status handle.
    /// </summary>
    DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001,
    /// <summary>
    /// Notifies the recipient of device interface events for all device interface classes. (The dbcc_classguid member is ignored.)
    /// This value can be used only if the dbch_devicetype member is DBT_DEVTYP_DEVICEINTERFACE.
    /// </summary>
    DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004,
}
#endregion

#region ExtendedWindowStyle
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/winmsg/extended-window-styles
/// </summary>
[Flags]
internal enum ExtendedWindowStyle : uint
{
    /// <summary>
    /// The window accepts drag-drop files.
    /// </summary>
    WS_EX_ACCEPTFILES = 0x00000010,
    /// <summary>
    /// Forces a top-level window onto the taskbar when the window is visible.
    /// </summary>
    WS_EX_APPWINDOW = 0x00040000,
    /// <summary>
    /// The window has a border with a sunken edge.
    /// </summary>
    WS_EX_CLIENTEDGE = 0x00000200,
    /// <summary>
    /// Paints all descendants of a window in bottom-to-top painting order using double-buffering. Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects, but only if the descendent window also has the WS_EX_TRANSPARENT bit set. Double-buffering allows the window and its descendents to be painted without flicker. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
    /// Windows 2000: This style is not supported.
    /// </summary>
    WS_EX_COMPOSITED = 0x02000000,
    /// <summary>
    /// The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
    /// WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
    /// </summary>
    WS_EX_CONTEXTHELP = 0x00000400,
    /// <summary>
    /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
    /// </summary>
    WS_EX_CONTROLPARENT = 0x00010000,
    /// <summary>
    /// The window has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
    /// </summary>
    WS_EX_DLGMODALFRAME = 0x00000001,
    /// <summary>
    /// The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
    /// Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.
    /// </summary>
    WS_EX_LAYERED = 0x00080000,
    /// <summary>
    /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left.
    /// </summary>
    WS_EX_LAYOUTRTL = 0x00400000,
    /// <summary>
    /// The window has generic left-aligned properties. This is the default.
    /// </summary>
    WS_EX_LEFT = 0x00000000,
    /// <summary>
    /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
    /// </summary>
    WS_EX_LEFTSCROLLBAR = 0x00004000,
    /// <summary>
    /// The window text is displayed using left-to-right reading-order properties. This is the default.
    /// </summary>
    WS_EX_LTRREADING = WS_EX_LEFT,
    /// <summary>
    /// The window is a MDI child window.
    /// </summary>
    WS_EX_MDICHILD = 0x00000040,
    /// <summary>
    /// A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window.
    /// The window should not be activated through programmatic access or via keyboard navigation by accessible technology, such as Narrator.
    /// To activate the window, use the SetActiveWindow or SetForegroundWindow function.
    /// The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
    /// </summary>
    WS_EX_NOACTIVATE = 0x08000000,
    /// <summary>
    /// The window does not pass its window layout to its child windows.
    /// </summary>
    WS_EX_NOINHERITLAYOUT = 0x00100000,
    /// <summary>
    /// The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
    /// </summary>
    WS_EX_NOPARENTNOTIFY = 0x00000004,
    /// <summary>
    /// The window does not render to a redirection surface. This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.
    /// </summary>
    WS_EX_NOREDIRECTIONBITMAP = 0x00200000,
    /// <summary>
    /// The window is an overlapped window.
    /// </summary>
    WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
    /// <summary>
    /// The window is palette window, which is a modeless dialog box that presents an array of commands.
    /// </summary>
    WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
    /// <summary>
    /// The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
    /// Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
    /// </summary>
    WS_EX_RIGHT = 0x00001000,
    /// <summary>
    /// The vertical scroll bar (if present) is to the right of the client area. This is the default.
    /// </summary>
    WS_EX_RIGHTSCROLLBAR = WS_EX_LEFT,
    /// <summary>
    /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
    /// </summary>
    WS_EX_RTLREADING = 0x00002000,
    /// <summary>
    /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
    /// </summary>
    WS_EX_STATICEDGE = 0x00020000,
    /// <summary>
    /// The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE.
    /// </summary>
    WS_EX_TOOLWINDOW = 0x00000080,
    /// <summary>
    /// The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
    /// </summary>
    WS_EX_TOPMOST = 0x00000008,
    /// <summary>
    /// The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.
    /// To achieve transparency without these restrictions, use the SetWindowRgn function.
    /// </summary>
    WS_EX_TRANSPARENT = 0x00000020,
    /// <summary>
    /// The window has a border with a raised edge.
    /// </summary>
    WS_EX_WINDOWEDGE = 0x00000100,
}
#endregion

#region GetQueueStatus_Flags
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getqueuestatus
/// For use with User32 GetQueueStatus
/// </summary>
[Flags]
internal enum GetQueueStatus_Flags : uint
{
    /// <summary>
    /// An input, WM_TIMER, WM_PAINT, WM_HOTKEY, or posted message is in the queue.
    /// </summary>
    QS_ALLEVENTS = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY,
    /// <summary>
    /// Any message is in the queue.
    /// </summary>
    QS_ALLINPUT = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE,
    /// <summary>
    /// A posted message (other than those listed here) is in the queue.
    /// </summary>
    QS_ALLPOSTMESSAGE = 0x0100,
    /// <summary>
    /// A WM_HOTKEY message is in the queue.
    /// </summary>
    QS_HOTKEY = 0x0080,
    /// <summary>
    /// An input message is in the queue.
    /// </summary>
    QS_INPUT = QS_MOUSE | QS_KEY | QS_RAWINPUT,
    /// <summary>
    /// A WM_KEYUP, WM_KEYDOWN, WM_SYSKEYUP, or WM_SYSKEYDOWN message is in the queue.
    /// </summary>
    QS_KEY = 0x0001,
    /// <summary>
    /// A WM_MOUSEMOVE message or mouse-button message (WM_LBUTTONUP, WM_RBUTTONDOWN, and so on).
    /// </summary>
    QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,
    /// <summary>
    /// A mouse-button message (WM_LBUTTONUP, WM_RBUTTONDOWN, and so on).
    /// </summary>
    QS_MOUSEBUTTON = 0x0004,
    /// <summary>
    /// A WM_MOUSEMOVE message is in the queue.
    /// </summary>
    QS_MOUSEMOVE = 0x0002,
    /// <summary>
    /// A WM_PAINT message is in the queue.
    /// </summary>
    QS_PAINT = 0x0020,
    /// <summary>
    /// A posted message (other than those listed here) is in the queue.
    /// </summary>
    QS_POSTMESSAGE = 0x0008,
    /// <summary>
    /// A raw input message is in the queue. For more information, see Raw Input.
    /// Windows 2000:  This flag is not supported.
    /// </summary>
    QS_RAWINPUT = 0x0400,
    /// <summary>
    /// A message sent by another thread or application is in the queue.
    /// </summary>
    QS_SENDMESSAGE = 0x0040,
    /// <summary>
    /// A WM_TIMER message is in the queue.
    /// </summary>
    QS_TIMER = 0x0010,
}
#endregion

#region GetRawInputData_uiCommand
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdata
/// For use with User32 GetRawInputData
/// </summary>
internal enum GetRawInputData_uiCommand
{
    /// <summary>
    /// Get the header information from the RAWINPUT structure.
    /// </summary>
    RID_HEADER = 0x10000005,
    /// <summary>
    /// Get the raw data from the RAWINPUT structure.
    /// </summary>
    RID_INPUT = 0x10000003,
}
#endregion

#region GetSysColor_Index
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsyscolor
/// For use with GetSysColor
/// </summary>
internal enum GetSysColor_Index : int
{
    /// <summary>
    /// Dark shadow for three-dimensional display elements.
    /// </summary>
    COLOR_3DDKSHADOW = 21,
    /// <summary>
    /// Face color for three-dimensional display elements and for dialog box backgrounds.
    /// </summary>
    COLOR_3DFACE = 15,
    /// <summary>
    /// Highlight color for three-dimensional display elements (for edges facing the light source.)
    /// </summary>
    COLOR_3DHIGHLIGHT = 20,
    /// <summary>
    /// Highlight color for three-dimensional display elements (for edges facing the light source.)
    /// </summary>
    COLOR_3DHILIGHT = COLOR_3DHIGHLIGHT,
    /// <summary>
    /// Light color for three-dimensional display elements (for edges facing the light source.)
    /// </summary>
    COLOR_3DLIGHT = 22,
    /// <summary>
    /// Shadow color for three-dimensional display elements (for edges facing away from the light source).
    /// </summary>
    COLOR_3DSHADOW = 16,
    /// <summary>
    /// Active window border.
    /// </summary>
    COLOR_ACTIVEBORDER = 10,
    /// <summary>
    /// Active window title bar.
    /// The associated foreground color is COLOR_CAPTIONTEXT.
    /// Specifies the left side color in the color gradient of an active window's title bar if the gradient effect is enabled.
    /// </summary>
    COLOR_ACTIVECAPTION = 2,
    /// <summary>
    /// Background color of multiple document interface (MDI) applications.
    /// </summary>
    COLOR_APPWORKSPACE = 12,
    /// <summary>
    /// Desktop
    /// </summary>
    COLOR_BACKGROUND = 1,
    /// <summary>
    /// Face color for three-dimensional display elements and for dialog box backgrounds. The associated foreground color is COLOR_BTNTEXT.
    /// </summary>
    COLOR_BTNFACE = COLOR_3DFACE,
    /// <summary>
    /// Highlight color for three-dimensional display elements (for edges facing the light source.)
    /// </summary>
    COLOR_BTNHIGHLIGHT = COLOR_3DHIGHLIGHT,
    /// <summary>
    /// Highlight color for three-dimensional display elements (for edges facing the light source.)
    /// </summary>
    COLOR_BTNHILIGHT = COLOR_3DHIGHLIGHT,
    /// <summary>
    /// Shadow color for three-dimensional display elements (for edges facing away from the light source).
    /// </summary>
    COLOR_BTNSHADOW = COLOR_3DSHADOW,
    /// <summary>
    /// Text on push buttons. The associated background color is COLOR_BTNFACE.
    /// </summary>
    COLOR_BTNTEXT = 18,
    /// <summary>
    /// Text in caption, size box, and scroll bar arrow box. The associated background color is COLOR_ACTIVECAPTION.
    /// </summary>
    COLOR_CAPTIONTEXT = 9,
    /// <summary>
    /// Desktop.
    /// </summary>
    COLOR_DESKTOP = COLOR_BACKGROUND,
    /// <summary>
    /// Right side color in the color gradient of an active window's title bar. COLOR_ACTIVECAPTION specifies the left side color. Use SPI_GETGRADIENTCAPTIONS with the SystemParametersInfo function to determine whether the gradient effect is enabled.
    /// </summary>
    COLOR_GRADIENTACTIVECAPTION = 27,
    /// <summary>
    /// Right side color in the color gradient of an inactive window's title bar. COLOR_INACTIVECAPTION specifies the left side color.
    /// </summary>
    COLOR_GRADIENTINACTIVECAPTION = 28,
    /// <summary>
    /// Grayed (disabled) text. This color is set to 0 if the current display driver does not support a solid gray color.
    /// </summary>
    COLOR_GRAYTEXT = 17,
    /// <summary>
    /// Item(s) selected in a control. The associated foreground color is COLOR_HIGHLIGHTTEXT.
    /// </summary>
    COLOR_HIGHLIGHT = 13,
    /// <summary>
    /// Text of item(s) selected in a control. The associated background color is COLOR_HIGHLIGHT.
    /// </summary>
    COLOR_HIGHLIGHTTEXT = 14,
    /// <summary>
    /// Color for a hyperlink or hot-tracked item. The associated background color is COLOR_WINDOW.
    /// </summary>
    COLOR_HOTLIGHT = 26,
    /// <summary>
    /// Inactive window border.
    /// </summary>
    COLOR_INACTIVEBORDER = 11,
    /// <summary>
    /// Inactive window caption.
    /// The associated foreground color is COLOR_INACTIVECAPTIONTEXT.
    /// Specifies the left side color in the color gradient of an inactive window's title bar if the gradient effect is enabled.
    /// </summary>
    COLOR_INACTIVECAPTION = 3,
    /// <summary>
    /// Color of text in an inactive caption. The associated background color is COLOR_INACTIVECAPTION.
    /// </summary>
    COLOR_INACTIVECAPTIONTEXT = 19,
    /// <summary>
    /// Background color for tooltip controls. The associated foreground color is COLOR_INFOTEXT.
    /// </summary>
    COLOR_INFOBK = 24,
    /// <summary>
    /// Text color for tooltip controls. The associated background color is COLOR_INFOBK.
    /// </summary>
    COLOR_INFOTEXT = 23,
    /// <summary>
    /// Menu background. The associated foreground color is COLOR_MENUTEXT.
    /// </summary>
    COLOR_MENU = 4,
    /// <summary>
    /// The color used to highlight menu items when the menu appears as a flat menu (see SystemParametersInfo). The highlighted menu item is outlined with COLOR_HIGHLIGHT.
    /// Windows 2000:  This value is not supported.
    /// </summary>
    COLOR_MENUHILIGHT = 29,
    /// <summary>
    /// The background color for the menu bar when menus appear as flat menus (see SystemParametersInfo). However, COLOR_MENU continues to specify the background color of the menu popup.
    /// Windows 2000:  This value is not supported.
    /// </summary>
    COLOR_MENUBAR = 30,
    /// <summary>
    /// Text in menus. The associated background color is COLOR_MENU.
    /// </summary>
    COLOR_MENUTEXT = 7,
    /// <summary>
    /// Scroll bar gray area.
    /// </summary>
    COLOR_SCROLLBAR = 0,
    /// <summary>
    /// Window background. The associated foreground colors are COLOR_WINDOWTEXT and COLOR_HOTLITE.
    /// </summary>
    COLOR_WINDOW = 5,
    /// <summary>
    /// Window frame.
    /// </summary>
    COLOR_WINDOWFRAME = 6,
    /// <summary>
    /// Text in windows. The associated background color is COLOR_WINDOW.
    /// </summary>
    COLOR_WINDOWTEXT = 8,
}
#endregion

#region MapVirtualKeyType
/// <summary>
/// For MapVirtualKey
/// </summary>
internal enum MapVirtualKey_uMapType
{
    /// <summary>uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.</summary>
    VirtualKeyToScanCode = 0,
    /// <summary>uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0.</summary>
    ScanCodeToVirtualKey = 1,
    /// <summary>uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.</summary>
    VirtualKeyToCharacter = 2,
    /// <summary>Windows NT/2000/XP: uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0.</summary>
    ScanCodeToVirtualKeyExtended = 3,
    VirtualKeyToScanCodeExtended = 4,
}

#endregion

#region PredefinedCursors
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadcursorw
/// For use with LoadCursor or LoadImage
/// </summary>
public enum PredefinedCursors : int
{
    /// <summary>
    /// Standard arrow and small hourglass
    /// </summary>
    IDC_APPSTARTING = 32650,
    /// <summary>
    /// Standard arrow
    /// </summary>
    IDC_ARROW = 32512,
    /// <summary>
    /// Crosshair
    /// </summary>
    IDC_CROSS = 32515,
    /// <summary>
    /// Hand
    /// </summary>
    IDC_HAND = 32649,
    /// <summary>
    /// Arrow and question mark
    /// </summary>
    IDC_HELP = 32651,
    /// <summary>
    /// I-beam
    /// </summary>
    IDC_IBEAM = 32513,
    /// <summary>
    /// Slashed circle
    /// </summary>
    IDC_NO = 32648,
    /// <summary>
    /// Obsolete for applications marked version 4.0 or later. Use IDC_SIZEALL.
    /// </summary>
    IDC_SIZE = 32640,
    /// <summary>
    /// Four-pointed arrow pointing north, south, east, and west
    /// </summary>
    IDC_SIZEALL = 32646,
    /// <summary>
    /// Double-pointed arrow pointing northeast and southwest
    /// </summary>
    IDC_SIZENESW = 32643,
    /// <summary>
    /// Double-pointed arrow pointing north and south
    /// </summary>
    IDC_SIZENS = 32645,
    /// <summary>
    /// Double-pointed arrow pointing northwest and southeast
    /// </summary>
    IDC_SIZENWSE = 32642,
    /// <summary>
    /// Double-pointed arrow pointing west and east
    /// </summary>
    IDC_SIZEWE = 32644,
    /// <summary>
    /// Vertical arrow
    /// </summary>
    IDC_UPARROW = 32516,
    /// <summary>
    /// Hourglass
    /// </summary>
    IDC_WAIT = 32514
}
#endregion

#region PredefinedIcons
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadiconw
/// For use with LoadIcon / LoadImage
/// </summary>
public enum PredefinedIcons : ushort
{
    /// <summary>
    /// Default application icon.
    /// </summary>
    IDI_APPLICATION = 32512,
    /// <summary>
    /// Asterisk icon. Same as IDI_INFORMATION.
    /// </summary>
    IDI_ASTERISK = 32516,
    /// <summary>
    /// Hand-shaped icon.
    /// </summary>
    IDI_ERROR = 32513,
    /// <summary>
    /// Exclamation point icon. Same as IDI_WARNING.
    /// </summary>
    IDI_EXCLAMATION = 32515,
    /// <summary>
    /// Hand-shaped icon. Same as IDI_ERROR.
    /// </summary>
    IDI_HAND = IDI_ERROR,
    /// <summary>
    /// Asterisk icon.
    /// </summary>
    IDI_INFORMATION = IDI_ASTERISK,
    /// <summary>
    /// Question mark icon.
    /// </summary>
    IDI_QUESTION = 32514,
    /// <summary>
    /// Security Shield icon.
    /// </summary>
    IDI_SHIELD = 32518,
    /// <summary>
    /// Exclamation point icon.
    /// </summary>
    IDI_WARNING = IDI_EXCLAMATION,
    /// <summary>
    /// Default application icon.
    /// Windows 2000:  Windows logo icon.
    /// </summary>
    IDI_WINLOGO = 32517,
}
#endregion

#region RAWINPUTDEVICE
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice
/// Defines information for the raw input devices. For use with User32 RegisterRawInputDevices.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RAWINPUTDEVICE
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-page
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows
    /// Top level collection Usage page for the raw input device. See HID Clients Supported in Windows for details on possible values.
    /// </summary>
    internal RAWINPUTDEVICE_usUsagePage usUsagePage;
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-id
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows
    /// Top level collection Usage ID for the raw input device. See HID Clients Supported in Windows for details on possible values.
    /// </summary>
    internal RAWINPUTDEVICE_usUsage usUsage;
    /// <summary>
    /// Mode flag that specifies how to interpret the information provided by usUsagePage and usUsage. It can be zero (the default) or one of the following values. By default, the operating system sends raw input from devices with the specified top level collection (TLC) to the registered application as long as it has the window focus.
    /// RIDEV_REMOVE: If set, this removes the top level collection from the inclusion list.This tells the operating system to stop reading from a device which matches the top level collection.
    /// RIDEV_EXCLUDE: If set, this specifies the top level collections to exclude when reading a complete usage page.This flag only affects a TLC whose usage page is already specified with RIDEV_PAGEONLY.
    /// RIDEV_PAGEONLY: If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that usUsage must be zero. To exclude a particular top level collection, use RIDEV_EXCLUDE.
    /// RIDEV_NOLEGACY: If set, this prevents any devices specified by usUsagePage or usUsage from generating legacy messages. This is only for the mouse and keyboard. See Remarks.
    /// RIDEV_INPUTSINK: If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that hwndTarget must be specified.
    /// RIDEV_CAPTUREMOUSE: If set, the mouse button click does not activate the other window. RIDEV_CAPTUREMOUSE can be specified only if RIDEV_NOLEGACY is specified for a mouse device.
    /// RIDEV_NOHOTKEYS: If set, the application-defined keyboard device hotkeys are not handled.However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled.By default, all keyboard hotkeys are handled.RIDEV_NOHOTKEYS can be specified even if RIDEV_NOLEGACY is not specified and hwndTarget is NULL.
    /// RIDEV_APPKEYS: If set, the application command keys are handled.RIDEV_APPKEYS can be specified only if RIDEV_NOLEGACY is specified for a keyboard device.
    /// RIDEV_EXINPUTSINK: If set, this enables the caller to receive input in the background only if the foreground application does not process it.In other words, if the foreground application is not registered for raw input, then the background application that is registered will receive the input. This flag is not supported until Windows Vista
    /// RIDEV_DEVNOTIFY: If set, this enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal. Windows XP: This flag is not supported until Windows Vista
    /// </summary>
    internal RAWINPUTDEVICE_dwFlags dwFlags;
    /// <summary>
    /// Handle to the target window. If NULL it follows the keyboard focus.
    /// </summary>
    internal IntPtr hwndTarget;

    internal static readonly uint s_size = (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICE));
}
#endregion

#region RAWINPUTDEVICE_dwFlags
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice
/// Mode flag that specifies how to interpret the information provided by usUsagePage and usUsage. For use with User32 RegisterRawInputDevices.
/// </summary>
/// <remarks>If RIDEV_NOLEGACY is set for a mouse or a keyboard, the system does not generate any legacy message for that device for the application. For example, if the mouse TLC is set with RIDEV_NOLEGACY, WM_LBUTTONDOWN and related legacy mouse messages are not generated. Likewise, if the keyboard TLC is set with RIDEV_NOLEGACY, WM_KEYDOWN and related legacy keyboard messages are not generated.
/// If RIDEV_REMOVE is set and the hwndTarget member is not set to NULL, then RegisterRawInputDevices function will fail.</remarks>
[Flags]
internal enum RAWINPUTDEVICE_dwFlags : int
{
    DEFAULT = 0,
    /// <summary>
    /// If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from a device which matches the top level collection.
    /// </summary>
    RIDEV_REMOVE = 0x00000001,
    /// <summary>
    /// If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC whose usage page is already specified with RIDEV_PAGEONLY.
    /// </summary>
    RIDEV_EXCLUDE = 0x00000010,
    /// <summary>
    /// If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that usUsage must be zero. To exclude a particular top level collection, use RIDEV_EXCLUDE.
    /// </summary>
    RIDEV_PAGEONLY = 0x00000020,
    /// <summary>
    /// If set, this prevents any devices specified by usUsagePage or usUsage from generating legacy messages. This is only for the mouse and keyboard. See Remarks.
    /// </summary>
    RIDEV_NOLEGACY = 0x00000030,
    /// <summary>
    /// If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that hwndTarget must be specified.
    /// </summary>
    RIDEV_INPUTSINK = 0x00000100,
    /// <summary>
    /// If set, the mouse button click does not activate the other window. RIDEV_CAPTUREMOUSE can be specified only if RIDEV_NOLEGACY is specified for a mouse device.
    /// </summary>
    RIDEV_CAPTUREMOUSE = 0x00000200, // effective when mouse nolegacy is specified, otherwise it would be an error
    /// <summary>
    /// If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. RIDEV_NOHOTKEYS can be specified even if RIDEV_NOLEGACY is not specified and hwndTarget is NULL.
    /// </summary>
    RIDEV_NOHOTKEYS = 0x00000200, // effective for keyboard.
    /// <summary>
    /// If set, the application command keys are handled. RIDEV_APPKEYS can be specified only if RIDEV_NOLEGACY is specified for a keyboard device.
    /// </summary>
    RIDEV_APPKEYS = 0x00000400, // effective for keyboard.
    /// <summary>
    /// If set, this enables the caller to receive input in the background only if the foreground application does not process it. In other words, if the foreground application is not registered for raw input, then the background application that is registered will receive the input. This flag is not supported until Windows Vista
    /// </summary>
    RIDEV_EXINPUTSINK = 0x00001000,
    /// <summary>
    /// If set, this enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal. This flag is not supported until Windows Vista
    /// </summary>
    RIDEV_DEVNOTIFY = 0x00002000,
}
#endregion

#region RAWINPUTDEVICE_usUsage
/// <summary>
/// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-id
/// https://github.com/tpn/winsdk-10/blob/master/Include/10.0.10240.0/shared/hidusage.h
/// In the context of a usage page, a valid usage identifier, or usage ID, indicates a usage in a usage page. A usage ID of zero is reserved. A usage ID value is an unsigned 16-bit value.
/// </summary>
internal enum RAWINPUTDEVICE_usUsage : ushort
{
    //
    // Generic Desktop Page (0x01)
    //
    HID_USAGE_GENERIC_POINTER = 0x01,
    HID_USAGE_GENERIC_MOUSE = 0x02,
    HID_USAGE_GENERIC_JOYSTICK = 0x04,
    HID_USAGE_GENERIC_GAMEPAD = 0x05,
    HID_USAGE_GENERIC_KEYBOARD = 0x06,
    HID_USAGE_GENERIC_KEYPAD = 0x07,
    HID_USAGE_GENERIC_PORTABLE_DEVICE_CONTROL = 0x0D,
    HID_USAGE_GENERIC_SYSTEM_CTL = 0x80,

    HID_USAGE_GENERIC_X = 0x30,
    HID_USAGE_GENERIC_Y = 0x31,
    HID_USAGE_GENERIC_Z = 0x32,
    HID_USAGE_GENERIC_RX = 0x33,
    HID_USAGE_GENERIC_RY = 0x34,
    HID_USAGE_GENERIC_RZ = 0x35,
    HID_USAGE_GENERIC_SLIDER = 0x36,
    HID_USAGE_GENERIC_DIAL = 0x37,
    HID_USAGE_GENERIC_WHEEL = 0x38,
    HID_USAGE_GENERIC_HATSWITCH = 0x39,
    HID_USAGE_GENERIC_COUNTED_BUFFER = 0x3A,
    HID_USAGE_GENERIC_BYTE_COUNT = 0x3B,
    HID_USAGE_GENERIC_MOTION_WAKEUP = 0x3C,
    HID_USAGE_GENERIC_VX = 0x40,
    HID_USAGE_GENERIC_VY = 0x41,
    HID_USAGE_GENERIC_VZ = 0x42,
    HID_USAGE_GENERIC_VBRX = 0x43,
    HID_USAGE_GENERIC_VBRY = 0x44,
    HID_USAGE_GENERIC_VBRZ = 0x45,
    HID_USAGE_GENERIC_VNO = 0x46,
    HID_USAGE_GENERIC_RESOLUTION_MULTIPLIER = 0x48,
    HID_USAGE_GENERIC_SYSCTL_POWER = 0x81,
    HID_USAGE_GENERIC_SYSCTL_SLEEP = 0x82,
    HID_USAGE_GENERIC_SYSCTL_WAKE = 0x83,
    HID_USAGE_GENERIC_SYSCTL_CONTEXT_MENU = 0x84,
    HID_USAGE_GENERIC_SYSCTL_MAIN_MENU = 0x85,
    HID_USAGE_GENERIC_SYSCTL_APP_MENU = 0x86,
    HID_USAGE_GENERIC_SYSCTL_HELP_MENU = 0x87,
    HID_USAGE_GENERIC_SYSCTL_MENU_EXIT = 0x88,
    HID_USAGE_GENERIC_SYSCTL_MENU_SELECT = 0x89,
    HID_USAGE_GENERIC_SYSCTL_MENU_RIGHT = 0x8A,
    HID_USAGE_GENERIC_SYSCTL_MENU_LEFT = 0x8B,
    HID_USAGE_GENERIC_SYSCTL_MENU_UP = 0x8C,
    HID_USAGE_GENERIC_SYSCTL_MENU_DOWN = 0x8D,
    HID_USAGE_GENERIC_SYSTEM_DISPLAY_ROTATION_LOCK_BUTTON = 0xC9,
    HID_USAGE_GENERIC_SYSTEM_DISPLAY_ROTATION_LOCK_SLIDER_SWITCH = 0xCA,
    HID_USAGE_GENERIC_CONTROL_ENABLE = 0xCB,

    //
    // Simulation Controls Page (0x02)
    //
    HID_USAGE_SIMULATION_RUDDER = 0xBA,
    HID_USAGE_SIMULATION_THROTTLE = 0xBB,


    //
    // Virtual Reality Controls Page (0x03)
    //


    //
    // Sport Controls Page (0x04)
    //


    //
    // Game Controls Page (0x05)
    //


    //
    // Keyboard/Keypad Page (0x07)
    //

    // Error "keys"
    HID_USAGE_KEYBOARD_NOEVENT = 0x00,
    HID_USAGE_KEYBOARD_ROLLOVER = 0x01,
    HID_USAGE_KEYBOARD_POSTFAIL = 0x02,
    HID_USAGE_KEYBOARD_UNDEFINED = 0x03,

    // Letters
    HID_USAGE_KEYBOARD_aA = 0x04,
    HID_USAGE_KEYBOARD_zZ = 0x1D,

    // Numbers
    HID_USAGE_KEYBOARD_ONE = 0x1E,
    HID_USAGE_KEYBOARD_ZERO = 0x27,

    // Modifier Keys
    HID_USAGE_KEYBOARD_LCTRL = 0xE0,
    HID_USAGE_KEYBOARD_LSHFT = 0xE1,
    HID_USAGE_KEYBOARD_LALT = 0xE2,
    HID_USAGE_KEYBOARD_LGUI = 0xE3,
    HID_USAGE_KEYBOARD_RCTRL = 0xE4,
    HID_USAGE_KEYBOARD_RSHFT = 0xE5,
    HID_USAGE_KEYBOARD_RALT = 0xE6,
    HID_USAGE_KEYBOARD_RGUI = 0xE7,
    HID_USAGE_KEYBOARD_SCROLL_LOCK = 0x47,
    HID_USAGE_KEYBOARD_NUM_LOCK = 0x53,
    HID_USAGE_KEYBOARD_CAPS_LOCK = 0x39,

    // Function keys
    HID_USAGE_KEYBOARD_F1 = 0x3A,
    HID_USAGE_KEYBOARD_F2 = 0x3B,
    HID_USAGE_KEYBOARD_F3 = 0x3C,
    HID_USAGE_KEYBOARD_F4 = 0x3D,
    HID_USAGE_KEYBOARD_F5 = 0x3E,
    HID_USAGE_KEYBOARD_F6 = 0x3F,
    HID_USAGE_KEYBOARD_F7 = 0x40,
    HID_USAGE_KEYBOARD_F8 = 0x41,
    HID_USAGE_KEYBOARD_F9 = 0x42,
    HID_USAGE_KEYBOARD_F10 = 0x43,
    HID_USAGE_KEYBOARD_F11 = 0x44,
    HID_USAGE_KEYBOARD_F12 = 0x45,
    HID_USAGE_KEYBOARD_F13 = 0x68,
    HID_USAGE_KEYBOARD_F14 = 0x69,
    HID_USAGE_KEYBOARD_F15 = 0x6A,
    HID_USAGE_KEYBOARD_F16 = 0x6B,
    HID_USAGE_KEYBOARD_F17 = 0x6C,
    HID_USAGE_KEYBOARD_F18 = 0x6D,
    HID_USAGE_KEYBOARD_F19 = 0x6E,
    HID_USAGE_KEYBOARD_F20 = 0x6F,
    HID_USAGE_KEYBOARD_F21 = 0x70,
    HID_USAGE_KEYBOARD_F22 = 0x71,
    HID_USAGE_KEYBOARD_F23 = 0x72,
    HID_USAGE_KEYBOARD_F24 = 0x73,

    HID_USAGE_KEYBOARD_RETURN = 0x28,
    HID_USAGE_KEYBOARD_ESCAPE = 0x29,
    HID_USAGE_KEYBOARD_DELETE = 0x2A,

    HID_USAGE_KEYBOARD_PRINT_SCREEN = 0x46,
    HID_USAGE_KEYBOARD_DELETE_FORWARD = 0x4C,


    //
    // LED Page (0x08)
    //
    HID_USAGE_LED_NUM_LOCK = 0x01,
    HID_USAGE_LED_CAPS_LOCK = 0x02,
    HID_USAGE_LED_SCROLL_LOCK = 0x03,
    HID_USAGE_LED_COMPOSE = 0x04,
    HID_USAGE_LED_KANA = 0x05,
    HID_USAGE_LED_POWER = 0x06,
    HID_USAGE_LED_SHIFT = 0x07,
    HID_USAGE_LED_DO_NOT_DISTURB = 0x08,
    HID_USAGE_LED_MUTE = 0x09,
    HID_USAGE_LED_TONE_ENABLE = 0x0A,
    HID_USAGE_LED_HIGH_CUT_FILTER = 0x0B,
    HID_USAGE_LED_LOW_CUT_FILTER = 0x0C,
    HID_USAGE_LED_EQUALIZER_ENABLE = 0x0D,
    HID_USAGE_LED_SOUND_FIELD_ON = 0x0E,
    HID_USAGE_LED_SURROUND_FIELD_ON = 0x0F,
    HID_USAGE_LED_REPEAT = 0x10,
    HID_USAGE_LED_STEREO = 0x11,
    HID_USAGE_LED_SAMPLING_RATE_DETECT = 0x12,
    HID_USAGE_LED_SPINNING = 0x13,
    HID_USAGE_LED_CAV = 0x14,
    HID_USAGE_LED_CLV = 0x15,
    HID_USAGE_LED_RECORDING_FORMAT_DET = 0x16,
    HID_USAGE_LED_OFF_HOOK = 0x17,
    HID_USAGE_LED_RING = 0x18,
    HID_USAGE_LED_MESSAGE_WAITING = 0x19,
    HID_USAGE_LED_DATA_MODE = 0x1A,
    HID_USAGE_LED_BATTERY_OPERATION = 0x1B,
    HID_USAGE_LED_BATTERY_OK = 0x1C,
    HID_USAGE_LED_BATTERY_LOW = 0x1D,
    HID_USAGE_LED_SPEAKER = 0x1E,
    HID_USAGE_LED_HEAD_SET = 0x1F,
    HID_USAGE_LED_HOLD = 0x20,
    HID_USAGE_LED_MICROPHONE = 0x21,
    HID_USAGE_LED_COVERAGE = 0x22,
    HID_USAGE_LED_NIGHT_MODE = 0x23,
    HID_USAGE_LED_SEND_CALLS = 0x24,
    HID_USAGE_LED_CALL_PICKUP = 0x25,
    HID_USAGE_LED_CONFERENCE = 0x26,
    HID_USAGE_LED_STAND_BY = 0x27,
    HID_USAGE_LED_CAMERA_ON = 0x28,
    HID_USAGE_LED_CAMERA_OFF = 0x29,
    HID_USAGE_LED_ON_LINE = 0x2A,
    HID_USAGE_LED_OFF_LINE = 0x2B,
    HID_USAGE_LED_BUSY = 0x2C,
    HID_USAGE_LED_READY = 0x2D,
    HID_USAGE_LED_PAPER_OUT = 0x2E,
    HID_USAGE_LED_PAPER_JAM = 0x2F,
    HID_USAGE_LED_REMOTE = 0x30,
    HID_USAGE_LED_FORWARD = 0x31,
    HID_USAGE_LED_REVERSE = 0x32,
    HID_USAGE_LED_STOP = 0x33,
    HID_USAGE_LED_REWIND = 0x34,
    HID_USAGE_LED_FAST_FORWARD = 0x35,
    HID_USAGE_LED_PLAY = 0x36,
    HID_USAGE_LED_PAUSE = 0x37,
    HID_USAGE_LED_RECORD = 0x38,
    HID_USAGE_LED_ERROR = 0x39,
    HID_USAGE_LED_SELECTED_INDICATOR = 0x3A,
    HID_USAGE_LED_IN_USE_INDICATOR = 0x3B,
    HID_USAGE_LED_MULTI_MODE_INDICATOR = 0x3C,
    HID_USAGE_LED_INDICATOR_ON = 0x3D,
    HID_USAGE_LED_INDICATOR_FLASH = 0x3E,
    HID_USAGE_LED_INDICATOR_SLOW_BLINK = 0x3F,
    HID_USAGE_LED_INDICATOR_FAST_BLINK = 0x40,
    HID_USAGE_LED_INDICATOR_OFF = 0x41,
    HID_USAGE_LED_FLASH_ON_TIME = 0x42,
    HID_USAGE_LED_SLOW_BLINK_ON_TIME = 0x43,
    HID_USAGE_LED_SLOW_BLINK_OFF_TIME = 0x44,
    HID_USAGE_LED_FAST_BLINK_ON_TIME = 0x45,
    HID_USAGE_LED_FAST_BLINK_OFF_TIME = 0x46,
    HID_USAGE_LED_INDICATOR_COLOR = 0x47,
    HID_USAGE_LED_RED = 0x48,
    HID_USAGE_LED_GREEN = 0x49,
    HID_USAGE_LED_AMBER = 0x4A,
    HID_USAGE_LED_GENERIC_INDICATOR = 0x4B,

    //
    //  Button Page (0x09)
    //
    //  There is no need to label these usages.
    //


    //
    //  Ordinal Page (0x0A)
    //
    //  There is no need to label these usages.
    //


    //
    //  Telephony Device Page (0x0B)
    //
    HID_USAGE_TELEPHONY_PHONE = 0x01,
    HID_USAGE_TELEPHONY_ANSWERING_MACHINE = 0x02,
    HID_USAGE_TELEPHONY_MESSAGE_CONTROLS = 0x03,
    HID_USAGE_TELEPHONY_HANDSET = 0x04,
    HID_USAGE_TELEPHONY_HEADSET = 0x05,
    HID_USAGE_TELEPHONY_KEYPAD = 0x06,
    HID_USAGE_TELEPHONY_PROGRAMMABLE_BUTTON = 0x07,
    HID_USAGE_TELEPHONY_REDIAL = 0x24,
    HID_USAGE_TELEPHONY_TRANSFER = 0x25,
    HID_USAGE_TELEPHONY_DROP = 0x26,
    HID_USAGE_TELEPHONY_LINE = 0x2A,
    HID_USAGE_TELEPHONY_RING_ENABLE = 0x2D,
    HID_USAGE_TELEPHONY_SEND = 0x31,
    HID_USAGE_TELEPHONY_KEYPAD_0 = 0xB0,
    HID_USAGE_TELEPHONY_KEYPAD_D = 0xBF,
    HID_USAGE_TELEPHONY_HOST_AVAILABLE = 0xF1,


    //
    // Consumer Controls Page (0x0C)
    //
    HID_USAGE_CONSUMERCTRL = 0x01,

    // channel
    HID_USAGE_CONSUMER_CHANNEL_INCREMENT = 0x9C,
    HID_USAGE_CONSUMER_CHANNEL_DECREMENT = 0x9D,

    // transport control
    HID_USAGE_CONSUMER_PLAY = 0xB0,
    HID_USAGE_CONSUMER_PAUSE = 0xB1,
    HID_USAGE_CONSUMER_RECORD = 0xB2,
    HID_USAGE_CONSUMER_FAST_FORWARD = 0xB3,
    HID_USAGE_CONSUMER_REWIND = 0xB4,
    HID_USAGE_CONSUMER_SCAN_NEXT_TRACK = 0xB5,
    HID_USAGE_CONSUMER_SCAN_PREV_TRACK = 0xB6,
    HID_USAGE_CONSUMER_STOP = 0xB7,
    HID_USAGE_CONSUMER_PLAY_PAUSE = 0xCD,

    // audio
    HID_USAGE_CONSUMER_VOLUME = 0xE0,
    HID_USAGE_CONSUMER_BALANCE = 0xE1,
    HID_USAGE_CONSUMER_MUTE = 0xE2,
    HID_USAGE_CONSUMER_BASS = 0xE3,
    HID_USAGE_CONSUMER_TREBLE = 0xE4,
    HID_USAGE_CONSUMER_BASS_BOOST = 0xE5,
    HID_USAGE_CONSUMER_SURROUND_MODE = 0xE6,
    HID_USAGE_CONSUMER_LOUDNESS = 0xE7,
    HID_USAGE_CONSUMER_MPX = 0xE8,
    HID_USAGE_CONSUMER_VOLUME_INCREMENT = 0xE9,
    HID_USAGE_CONSUMER_VOLUME_DECREMENT = 0xEA,

    // supplementary audio
    HID_USAGE_CONSUMER_BASS_INCREMENT = 0x152,
    HID_USAGE_CONSUMER_BASS_DECREMENT = 0x153,
    HID_USAGE_CONSUMER_TREBLE_INCREMENT = 0x154,
    HID_USAGE_CONSUMER_TREBLE_DECREMENT = 0x155,

    // Application Launch
    HID_USAGE_CONSUMER_AL_CONFIGURATION = 0x183,
    HID_USAGE_CONSUMER_AL_EMAIL = 0x18A,
    HID_USAGE_CONSUMER_AL_CALCULATOR = 0x192,
    HID_USAGE_CONSUMER_AL_BROWSER = 0x194,

    // Application Control
    HID_USAGE_CONSUMER_AC_SEARCH = 0x221,
    HID_USAGE_CONSUMER_AC_GOTO = 0x222,
    HID_USAGE_CONSUMER_AC_HOME = 0x223,
    HID_USAGE_CONSUMER_AC_BACK = 0x224,
    HID_USAGE_CONSUMER_AC_FORWARD = 0x225,
    HID_USAGE_CONSUMER_AC_STOP = 0x226,
    HID_USAGE_CONSUMER_AC_REFRESH = 0x227,
    HID_USAGE_CONSUMER_AC_PREVIOUS = 0x228,
    HID_USAGE_CONSUMER_AC_NEXT = 0x229,
    HID_USAGE_CONSUMER_AC_BOOKMARKS = 0x22A,
    HID_USAGE_CONSUMER_AC_PAN = 0x238,

    // Keyboard Extended Attributes (defined on consumer page in HUTRR42)
    HID_USAGE_CONSUMER_EXTENDED_KEYBOARD_ATTRIBUTES_COLLECTION = 0x2C0,
    HID_USAGE_CONSUMER_KEYBOARD_FORM_FACTOR = 0x2C1,
    HID_USAGE_CONSUMER_KEYBOARD_KEY_TYPE = 0x2C2,
    HID_USAGE_CONSUMER_KEYBOARD_PHYSICAL_LAYOUT = 0x2C3,
    HID_USAGE_CONSUMER_VENDOR_SPECIFIC_KEYBOARD_PHYSICAL_LAYOUT = 0x2C4,
    HID_USAGE_CONSUMER_KEYBOARD_IETF_LANGUAGE_TAG_INDEX = 0x2C5,
    HID_USAGE_CONSUMER_IMPLEMENTED_KEYBOARD_INPUT_ASSIST_CONTROLS = 0x2C6,

    //
    // Digitizer Page (0x0D)
    //
    HID_USAGE_DIGITIZER_PEN = 0x02,
    HID_USAGE_DIGITIZER_IN_RANGE = 0x32,
    HID_USAGE_DIGITIZER_TIP_SWITCH = 0x42,
    HID_USAGE_DIGITIZER_BARREL_SWITCH = 0x44,


    //
    // Sensor Page (0x20)
    //


    //
    // Camera Control Page (0x90)
    //
    HID_USAGE_CAMERA_AUTO_FOCUS = 0x20,
    HID_USAGE_CAMERA_SHUTTER = 0x21,

    //
    // Microsoft Bluetooth Handsfree Page (0xFFF3)
    //
    HID_USAGE_MS_BTH_HF_DIALNUMBER = 0x21,
    HID_USAGE_MS_BTH_HF_DIALMEMORY = 0x22,
}
#endregion

#region RAWINPUTDEVICE_usUsagePage
/// <summary>
/// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-page
/// https://github.com/tpn/winsdk-10/blob/master/Include/10.0.10240.0/shared/hidusage.h
/// HID usages are organized into usage pages of related controls. A specific control usage is defined by its usage page, a usage ID, a name, and a description. A usage page value is a 16-bit unsigned value. For use with User32 RegisterRawInputDevices.
/// </summary>
internal enum RAWINPUTDEVICE_usUsagePage : ushort
{
    /// <summary>Unknown usage page.</summary>
    HID_USAGE_PAGE_UNDEFINED = 0x00,
    /// <summary>Generic desktop controls.</summary>
    HID_USAGE_PAGE_GENERIC = 0x01,
    /// <summary>Simulation controls.</summary>
    HID_USAGE_PAGE_SIMULATION = 0x02,
    /// <summary>Virtual reality controls.</summary>
    HID_USAGE_PAGE_VR = 0x03,
    /// <summary>Sports controls.</summary>
    HID_USAGE_PAGE_SPORT = 0x04,
    /// <summary>Games controls.</summary>
    HID_USAGE_PAGE_GAME = 0x05,
    /// <summary>Keyboard controls.</summary>
    HID_USAGE_PAGE_KEYBOARD = 0x07,
    /// <summary>LED controls.</summary>
    HID_USAGE_PAGE_LED = 0x08,
    /// <summary>Button.</summary>
    HID_USAGE_PAGE_BUTTON = 0x09,
    /// <summary>Ordinal.</summary>
    HID_USAGE_PAGE_ORDINAL = 0x0A,
    /// <summary>Telephony.</summary>
    HID_USAGE_PAGE_TELEPHONY = 0x0B,
    /// <summary>Consumer.</summary>
    HID_USAGE_PAGE_CONSUMER = 0x0C,
    /// <summary>Digitizer.</summary>
    HID_USAGE_PAGE_DIGITIZER = 0x0D,
    /// <summary>Physical interface device.</summary>
    HID_USAGE_PAGE_PID = 0x0F,
    /// <summary>Unicode.</summary>
    HID_USAGE_PAGE_UNICODE = 0x10,
    /// <summary>Alphanumeric display.</summary>
    HID_USAGE_PAGE_ALPHANUMERIC = 0x14,
    HID_USAGE_PAGE_SENSOR = 0x20,
    /// <summary>Medical instruments.</summary>
    HID_USAGE_PAGE_MEDICAL = 0x40,
    /// <summary>Monitor page 0.</summary>
    HID_USAGE_PAGE_MONITOR_PAGE_0 = 0x80,
    /// <summary>Monitor page 1.</summary>
    HID_USAGE_PAGE_MONITOR_PAGE_1 = 0x81,
    /// <summary>Monitor page 2.</summary>
    HID_USAGE_PAGE_MONITOR_PAGE_2 = 0x82,
    /// <summary>Monitor page 3.</summary>
    HID_USAGE_PAGE_MONITOR_PAGE_3 = 0x83,
    /// <summary>Power page 0.</summary>
    HID_USAGE_PAGE_POWER_PAGE_0 = 0x84,
    /// <summary>Power page 1.</summary>
    HID_USAGE_PAGE_POWER_PAGE_1 = 0x85,
    /// <summary>Power page 2.</summary>
    HID_USAGE_PAGE_POWER_PAGE_2 = 0x86,
    /// <summary>Power page 3.</summary>
    HID_USAGE_PAGE_POWER_PAGE_3 = 0x87,
    /// <summary>Bar code scanner.</summary>
    HID_USAGE_PAGE_BARCODE_SCANNER = 0x8C,
    /// <summary>Scale page.</summary>
    HID_USAGE_PAGE_WEIGHING_DEVICE = 0x8D,
    /// <summary>Magnetic strip reading devices.</summary>
    HID_USAGE_PAGE_MAGNETIC_STRIPE_READER = 0x8E,
    HID_USAGE_PAGE_CAMERA_CONTROL = 0x90,
    HID_USAGE_PAGE_MICROSOFT_BLUETOOTH_HANDSFREE = 0xFFF3,
    HID_USAGE_PAGE_VENDOR_DEFINED_BEGIN = 0xFF00,
    HID_USAGE_PAGE_VENDOR_DEFINED_END = 0xFFFF,
}
#endregion

#region RawInputDeviceInfo
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rid_device_info
/// Defines the raw input data coming from any device.
/// For use with GetRawInputDeviceInfo.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal class RID_DEVICE_INFO
{
    /// <summary>
    /// The size, in bytes, of the RID_DEVICE_INFO structure.
    /// </summary>
    internal uint cbSize = (uint)Marshal.SizeOf(typeof(RID_DEVICE_INFO));
    /// <summary>
    /// The type of raw input data.
    /// </summary>
    internal RID_DEVICE_INFO_dwType dwType;
    /// <summary>
    /// Container for the relevant device info struct
    /// </summary>
    internal DeviceInfo DUMMYUNIONNAME;

    [StructLayout(LayoutKind.Explicit)]
    internal struct DeviceInfo
    {
        /// <summary>
        /// If dwType is RIM_TYPEMOUSE, this is the RID_DEVICE_INFO_MOUSE structure that defines the mouse.
        /// </summary>
        [FieldOffset(0)]
        internal RID_DEVICE_INFO_MOUSE mouse;
        /// <summary>
        /// If dwType is RIM_TYPEKEYBOARD, this is the RID_DEVICE_INFO_KEYBOARD structure that defines the keyboard.
        /// </summary>
        [FieldOffset(0)]
        internal RID_DEVICE_INFO_KEYBOARD keyboard;
        /// <summary>
        /// If dwType is RIM_TYPEHID, this is the RID_DEVICE_INFO_HID structure that defines the HID device.
        /// </summary>
        [FieldOffset(0)]
        internal RID_DEVICE_INFO_HID hid;
    };
}
#endregion

#region GetRawInputDeviceInfo_uiCommand
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdeviceinfoa
/// For use with User32 GetRawInputDeviceInfo
/// </summary>
internal enum GetRawInputDeviceInfo_uiCommand : uint
{
    /// <summary>
    /// pData is a PHIDP_PREPARSED_DATA pointer to a buffer for a top-level collection's preparsed data.
    /// </summary>
    RIDI_PREPARSEDDATA = 0x20000005,
    /// <summary>
    /// pData points to a string that contains the device interface name.
    /// If this device is opened with Shared Access Mode then you can call CreateFile with this name to open a HID collection and use returned handle for calling ReadFile to read input reports and WriteFile to send output reports.
    /// For more information, see Opening HID Collections and Handling HID Reports.
    /// For this uiCommand only, the value in pcbSize is the character count (not the byte count).
    /// </summary>
    RIDI_DEVICENAME = 0x20000007,
    /// <summary>
    /// pData points to an RID_DEVICE_INFO structure.
    /// </summary>
    RIDI_DEVICEINFO = 0x2000000b
}
#endregion

#region RawInputDeviceType
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rid_device_info
/// For use with RID_DEVICE_INFO
/// </summary>
internal enum RID_DEVICE_INFO_dwType : uint
{
    /// <summary>
    /// Data comes from a mouse.
    /// </summary>
    RIM_TYPEMOUSE = 0,
    /// <summary>
    /// Data comes from a keyboard.
    /// </summary>
    RIM_TYPEKEYBOARD = 1,
    /// <summary>
    /// Data comes from an HID that is not a keyboard or a mouse.
    /// </summary>
    RIM_TYPEHID = 2
}
#endregion

#region RawInputHIDDeviceInfo
/// <summary>
/// Defines the raw input data coming from the specified Human Interface Device (HID).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RID_DEVICE_INFO_HID
{
    /// <summary>
    /// Vendor ID for the HID.
    /// </summary>
    internal int VendorId;
    /// <summary>
    /// Product ID for the HID.
    /// </summary>
    internal int ProductId;
    /// <summary>
    /// Version number for the HID.
    /// </summary>
    internal int VersionNumber;
    /// <summary>
    /// Top-level collection Usage Page for the device.
    /// </summary>
    //internal UInt16 UsagePage;
    internal short UsagePage;
    /// <summary>
    /// Top-level collection Usage for the device.
    /// </summary>
    //internal UInt16 Usage;
    internal short Usage;
}
#endregion

#region RID_DEVICE_INFO_KEYBOARD
/// <summary>
/// Defines the raw input data coming from the specified keyboard.
/// </summary>
/// <remarks>
/// For the keyboard, the Usage Page is 1 and the Usage is 6.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct RID_DEVICE_INFO_KEYBOARD
{
    /// <summary>
    /// Type of the keyboard.
    /// </summary>
    internal int Type;
    /// <summary>
    /// Subtype of the keyboard.
    /// </summary>
    internal int SubType;
    /// <summary>
    /// Scan code mode.
    /// </summary>
    internal int KeyboardMode;
    /// <summary>
    /// Number of function keys on the keyboard.
    /// </summary>
    internal int NumberOfFunctionKeys;
    /// <summary>
    /// Number of LED indicators on the keyboard.
    /// </summary>
    internal int NumberOfIndicators;
    /// <summary>
    /// Total number of keys on the keyboard.
    /// </summary>
    internal int NumberOfKeysTotal;
}

#endregion

#region RID_DEVICE_INFO_MOUSE
/// <summary>
/// Defines the raw input data coming from the specified mouse.
/// </summary>
/// <remarks>
/// For the keyboard, the Usage Page is 1 and the Usage is 2.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct RID_DEVICE_INFO_MOUSE
{
    /// <summary>
    /// ID for the mouse device.
    /// </summary>
    internal int Id;
    /// <summary>
    /// Number of buttons for the mouse.
    /// </summary>
    internal int NumberOfButtons;
    /// <summary>
    /// Number of data points per second. This information may not be applicable for every mouse device.
    /// </summary>
    internal int SampleRate;
    /// <summary>
    /// TRUE if the mouse has a wheel for horizontal scrolling; otherwise, FALSE.
    /// </summary>
    /// <remarks>
    /// This member is only supported under Microsoft Windows Vista and later versions.
    /// </remarks>
    internal bool HasHorizontalWheel;
}

#endregion

#region GWL
/// <summary>
/// The zero-based offset to the value to be set in SetWindowLong. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the following values.
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlonga
/// </summary>
internal enum GWL : int
{
    /// <summary>
    /// Sets a new extended window style.
    /// https://docs.microsoft.com/en-us/windows/win32/winmsg/extended-window-styles
    /// </summary>
    GWL_EXSTYLE = -20,
    /// <summary>
    /// Sets a new application instance handle.
    /// </summary>
    GWL_HINSTANCE = -6,
    /// <summary>
    /// Sets a new identifier of the child window. The window cannot be a top-level window.
    /// </summary>
    GWL_ID = -12,
    /// <summary>
    /// Sets a new window style.
    /// https://docs.microsoft.com/en-us/windows/win32/winmsg/window-styles
    /// </summary>
    GWL_STYLE = -16,
    /// <summary>
    /// Sets the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero.
    /// </summary>
    GWL_USERDATA = -21,
    /// <summary>
    /// Sets a new address for the window procedure.
    /// You cannot change this attribute if the window does not belong to the same process as the calling thread.
    /// </summary>
    GWL_WNDPROC = -4,
}
#endregion

#region ShowWindow_Command
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindow
/// For use with User32 ShowWindow
/// </summary>
internal enum ShowWindow_Command
{
    /// <summary>
    /// Hides the window and activates another window.
    /// </summary>
    SW_HIDE = 0,
    /// <summary>
    /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
    /// </summary>
    SW_SHOWNORMAL = 1,
    /// <summary>
    /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
    /// </summary>
    SW_NORMAL = SW_SHOWNORMAL,
    /// <summary>
    /// Activates the window and displays it as a minimized window.
    /// </summary>
    SW_SHOWMINIMIZED = 2,
    /// <summary>
    /// Activates the window and displays it as a maximized window.
    /// </summary>
    SW_SHOWMAXIMIZED = 3,
    /// <summary>
    /// Activates the window and displays it as a maximized window.
    /// </summary>
    SW_MAXIMIZE = SW_SHOWMAXIMIZED,
    /// <summary>
    /// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
    /// </summary>
    SW_SHOWNOACTIVATE = 4,
    /// <summary>
    /// Activates the window and displays it in its current size and position.
    /// </summary>
    SW_SHOW = 5,
    /// <summary>
    /// Minimizes the specified window and activates the next top-level window in the Z order.
    /// </summary>
    SW_MINIMIZE = 6,
    /// <summary>
    /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
    /// </summary>
    SW_SHOWMINNOACTIVE = 7,
    /// <summary>
    /// Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
    /// </summary>
    SW_SHOWNA = 8,
    /// <summary>
    /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
    /// </summary>
    SW_RESTORE = 9,
    /// <summary>
    /// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
    /// </summary>
    SW_SHOWDEFAULT = 10,
    /// <summary>
    /// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
    /// </summary>
    SW_FORCEMINIMIZE = 11,
}
#endregion

#region WindowMessage
/// <summary>
/// https://docs.microsoft.com/en-gb/windows/win32/winmsg/about-messages-and-message-queues?redirectedfrom=MSDN
/// https://docs.microsoft.com/en-us/windows/win32/winmsg/window-notifications
/// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms633573(v=vs.85)
/// Used in the Windows Procedure (WindowProc) callback function
/// </summary>
internal enum WindowMessage : int
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-null
    /// Performs no operation. An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
    /// </summary>
    WM_NULL = 0x00000000,
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-create
    /// Sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
    /// </summary>
    WM_CREATE = 0x00000001,
    /// <summary>
    /// Sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen.
    /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the processing of the message, it can be assumed that all child windows still exist.
    /// </summary>
    WM_DESTROY = 0x00000002,
    WM_MOVE = 0x00000003,
    WM_SIZE = 0x00000005,
    WM_ACTIVATE = 0x00000006,
    WM_SETFOCUS = 0x00000007,
    WM_KILLFOCUS = 0x00000008,
    WM_ENABLE = 0x0000000A,
    WM_SETREDRAW = 0x0000000B,
    WM_SETTEXT = 0x0000000C,
    WM_GETTEXT = 0x0000000D,
    WM_GETTEXTLENGTH = 0x0000000E,
    WM_PAINT = 0x0000000F,
    WM_CLOSE = 0x00000010,
    WM_QUERYENDSESSION = 0x00000011,
    WM_QUIT = 0x00000012,
    WM_QUERYOPEN = 0x00000013,
    WM_ERASEBKGND = 0x00000014,
    WM_SYSCOLORCHANGE = 0x00000015,
    WM_ENDSESSION = 0x00000016,
    WM_SHOWWINDOW = 0x00000018,
    WM_CTLCOLOR = 0x00000019,
    WM_WININICHANGE = 0x0000001A,
    WM_DEVMODECHANGE = 0x0000001B,
    WM_ACTIVATEAPP = 0x0000001C,
    WM_FONTCHANGE = 0x0000001D,
    WM_TIMECHANGE = 0x0000001E,
    WM_CANCELMODE = 0x0000001F,
    WM_SETCURSOR = 0x00000020,
    WM_MOUSEACTIVATE = 0x00000021,
    WM_CHILDACTIVATE = 0x00000022,
    WM_QUEUESYNC = 0x00000023,
    WM_GETMINMAXINFO = 0x00000024,
    WM_PAINTICON = 0x00000026,
    WM_ICONERASEBKGND = 0x00000027,
    WM_NEXTDLGCTL = 0x00000028,
    WM_SPOOLERSTATUS = 0x0000002A,
    WM_DRAWITEM = 0x0000002B,
    WM_MEASUREITEM = 0x0000002C,
    WM_DELETEITEM = 0x0000002D,
    WM_VKEYTOITEM = 0x0000002E,
    WM_CHARTOITEM = 0x0000002F,
    WM_SETFONT = 0x00000030,
    WM_GETFONT = 0x00000031,
    WM_SETHOTKEY = 0x00000032,
    WM_GETHOTKEY = 0x00000033,
    WM_QUERYDRAGICON = 0x00000037,
    WM_COMPAREITEM = 0x00000039,
    WM_GETOBJECT = 0x0000003D,
    WM_COMPACTING = 0x00000041,
    WM_COMMNOTIFY = 0x00000044,
    WM_WINDOWPOSCHANGING = 0x00000046,
    WM_WINDOWPOSCHANGED = 0x00000047,
    WM_POWER = 0x00000048,
    WM_COPYGLOBALDATA = 0x00000049,
    WM_COPYDATA = 0x0000004A,
    WM_CANCELJOURNAL = 0x0000004B,
    WM_NOTIFY = 0x0000004E,
    WM_INPUTLANGCHANGEREQUEST = 0x00000050,
    WM_INPUTLANGCHANGE = 0x00000051,
    WM_TCARD = 0x00000052,
    WM_HELP = 0x00000053,
    WM_USERCHANGED = 0x00000054,
    WM_NOTIFYFORMAT = 0x00000055,
    WM_CONTEXTMENU = 0x0000007B,
    WM_STYLECHANGING = 0x0000007C,
    WM_STYLECHANGED = 0x0000007D,
    WM_DISPLAYCHANGE = 0x0000007E,
    WM_GETICON = 0x0000007F,
    WM_SETICON = 0x00000080,
    WM_NCCREATE = 0x00000081,
    WM_NCDESTROY = 0x00000082,
    WM_NCCALCSIZE = 0x00000083,
    WM_NCHITTEST = 0x00000084,
    WM_NCPAINT = 0x00000085,
    WM_NCACTIVATE = 0x00000086,
    WM_GETDLGCODE = 0x00000087,
    WM_SYNCPAINT = 0x00000088,
    WM_NCMOUSEMOVE = 0x000000A0,
    WM_NCLBUTTONDOWN = 0x000000A1,
    WM_NCLBUTTONUP = 0x000000A2,
    WM_NCLBUTTONDBLCLK = 0x000000A3,
    WM_NCRBUTTONDOWN = 0x000000A4,
    WM_NCRBUTTONUP = 0x000000A5,
    WM_NCRBUTTONDBLCLK = 0x000000A6,
    WM_NCMBUTTONDOWN = 0x000000A7,
    WM_NCMBUTTONUP = 0x000000A8,
    WM_NCMBUTTONDBLCLK = 0x000000A9,
    WM_NCXBUTTONDOWN = 0x000000AB,
    WM_NCXBUTTONUP = 0x000000AC,
    WM_NCXBUTTONDBLCLK = 0x000000AD,
    WM_DPICHANGED = 0x02E0,
    EM_GETSEL = 0x000000B0,
    EM_SETSEL = 0x000000B1,
    EM_GETRECT = 0x000000B2,
    EM_SETRECT = 0x000000B3,
    EM_SETRECTNP = 0x000000B4,
    EM_SCROLL = 0x000000B5,
    EM_LINESCROLL = 0x000000B6,
    EM_SCROLLCARET = 0x000000B7,
    EM_GETMODIFY = 0x000000B9,
    EM_SETMODIFY = 0x000000BB,
    EM_GETLINECOUNT = 0x000000BC,
    EM_LINEINDEX = 0x000000BD,
    EM_SETHANDLE = 0x000000BE,
    EM_GETHANDLE = 0x000000BF,
    EM_GETTHUMB = 0x000000C0,
    EM_LINELENGTH = 0x000000C1,
    EM_REPLACESEL = 0x000000C2,
    EM_SETFONT = 0x000000C3,
    EM_GETLINE = 0x000000C4,
    EM_LIMITTEXT = 0x000000C5,
    EM_SETLIMITTEXT = 0x000000C5,
    EM_CANUNDO = 0x000000C6,
    EM_UNDO = 0x000000C7,
    EM_FMTLINES = 0x000000C8,
    EM_LINEFROMCHAR = 0x000000C9,
    EM_SETWORDBREAK = 0x000000CA,
    EM_SETTABSTOPS = 0x000000CB,
    EM_SETPASSWORDCHAR = 0x000000CC,
    EM_EMPTYUNDOBUFFER = 0x000000CD,
    EM_GETFIRSTVISIBLELINE = 0x000000CE,
    EM_SETREADONLY = 0x000000CF,
    EM_SETWORDBREAKPROC = 0x000000D1,
    EM_GETWORDBREAKPROC = 0x000000D1,
    EM_GETPASSWORDCHAR = 0x000000D2,
    EM_SETMARGINS = 0x000000D3,
    EM_GETMARGINS = 0x000000D4,
    EM_GETLIMITTEXT = 0x000000D5,
    EM_POSFROMCHAR = 0x000000D6,
    EM_CHARFROMPOS = 0x000000D7,
    EM_SETIMESTATUS = 0x000000D8,
    EM_GETIMESTATUS = 0x000000D9,
    SBM_SETPOS = 0x000000E0,
    SBM_GETPOS = 0x000000E1,
    SBM_SETRANGE = 0x000000E2,
    SBM_GETRANGE = 0x000000E3,
    SBM_ENABLE_ARROWS = 0x000000E4,
    SBM_SETRANGEREDRAW = 0x000000E6,
    SBM_SETSCROLLINFO = 0x000000E9,
    SBM_GETSCROLLINFO = 0x000000EA,
    SBM_GETSCROLLBARINFO = 0x000000EB,
    BM_GETCHECK = 0x000000F0,
    BM_SETCHECK = 0x000000F1,
    BM_GETSTATE = 0x000000F2,
    BM_SETSTATE = 0x000000F3,
    BM_SETSTYLE = 0x000000F4,
    BM_CLICK = 0x000000F5,
    BM_GETIMAGE = 0x000000F6,
    BM_SETIMAGE = 0x000000F7,
    BM_SETDONTCLICK = 0x000000F8,
    WM_INPUT = 0x000000FF,
    WM_KEYDOWN = 0x00000100,
    WM_KEYFIRST = 0x00000100,
    WM_KEYUP = 0x00000101,
    WM_CHAR = 0x00000102,
    WM_DEADCHAR = 0x00000103,
    WM_SYSKEYDOWN = 0x00000104,
    WM_SYSKEYUP = 0x00000105,
    WM_SYSCHAR = 0x00000106,
    WM_SYSDEADCHAR = 0x00000107,
    WM_KEYLAST = 0x00000108,
    WM_UNICHAR = 0x00000109,
    WM_WNT_CONVERTREQUESTEX = 0x00000109,
    WM_CONVERTREQUEST = 0x0000010A,
    WM_CONVERTRESULT = 0x0000010B,
    WM_INTERIM = 0x0000010C,
    WM_IME_STARTCOMPOSITION = 0x0000010D,
    WM_IME_ENDCOMPOSITION = 0x0000010E,
    WM_IME_COMPOSITION = 0x0000010F,
    WM_IME_KEYLAST = 0x0000010F,
    WM_INITDIALOG = 0x00000110,
    WM_COMMAND = 0x00000111,
    WM_SYSCOMMAND = 0x00000112,
    WM_TIMER = 0x00000113,
    WM_HSCROLL = 0x00000114,
    WM_VSCROLL = 0x00000115,
    WM_INITMENU = 0x00000116,
    WM_INITMENUPOPUP = 0x00000117,
    WM_SYSTIMER = 0x00000118,
    WM_MENUSELECT = 0x0000011F,
    WM_MENUCHAR = 0x00000120,
    WM_ENTERIDLE = 0x00000121,
    WM_MENURBUTTONUP = 0x00000122,
    WM_MENUDRAG = 0x00000123,
    WM_MENUGETOBJECT = 0x00000124,
    WM_UNINITMENUPOPUP = 0x00000125,
    WM_MENUCOMMAND = 0x00000126,
    WM_CHANGEUISTATE = 0x00000127,
    WM_UPDATEUISTATE = 0x00000128,
    WM_QUERYUISTATE = 0x00000129,
    WM_CTLCOLORMSGBOX = 0x00000132,
    WM_CTLCOLOREDIT = 0x00000133,
    WM_CTLCOLORLISTBOX = 0x00000134,
    WM_CTLCOLORBTN = 0x00000135,
    WM_CTLCOLORDLG = 0x00000136,
    WM_CTLCOLORSCROLLBAR = 0x00000137,
    WM_CTLCOLORSTATIC = 0x00000138,
    WM_MOUSEFIRST = 0x00000200,
    WM_MOUSEMOVE = 0x00000200,
    WM_LBUTTONDOWN = 0x00000201,
    WM_LBUTTONUP = 0x00000202,
    WM_LBUTTONDBLCLK = 0x00000203,
    WM_RBUTTONDOWN = 0x00000204,
    WM_RBUTTONUP = 0x00000205,
    WM_RBUTTONDBLCLK = 0x00000206,
    WM_MBUTTONDOWN = 0x00000207,
    WM_MBUTTONUP = 0x00000208,
    WM_MBUTTONDBLCLK = 0x00000209,
    WM_MOUSELAST = 0x00000209,
    WM_MOUSEWHEEL = 0x0000020A,
    WM_XBUTTONDOWN = 0x0000020B,
    WM_XBUTTONUP = 0x0000020C,
    WM_XBUTTONDBLCLK = 0x0000020D,
    WM_MOUSEHWHEEL = 0x0000020E,
    WM_PARENTNOTIFY = 0x00000210,
    WM_ENTERMENULOOP = 0x00000211,
    WM_EXITMENULOOP = 0x00000212,
    WM_NEXTMENU = 0x00000213,
    WM_SIZING = 0x00000214,
    WM_CAPTURECHANGED = 0x00000215,
    WM_MOVING = 0x00000216,
    WM_POWERBROADCAST = 0x00000218,
    WM_DEVICECHANGE = 0x00000219,
    WM_MDICREATE = 0x00000220,
    WM_MDIDESTROY = 0x00000221,
    WM_MDIACTIVATE = 0x00000222,
    WM_MDIRESTORE = 0x00000223,
    WM_MDINEXT = 0x00000224,
    WM_MDIMAXIMIZE = 0x00000225,
    WM_MDITILE = 0x00000226,
    WM_MDICASCADE = 0x00000227,
    WM_MDIICONARRANGE = 0x00000228,
    WM_MDIGETACTIVE = 0x00000229,
    WM_MDISETMENU = 0x00000230,
    WM_ENTERSIZEMOVE = 0x00000231,
    WM_EXITSIZEMOVE = 0x00000232,
    WM_DROPFILES = 0x00000233,
    WM_MDIREFRESHMENU = 0x00000234,
    WM_IME_REPORT = 0x00000280,
    WM_IME_SETCONTEXT = 0x00000281,
    WM_IME_NOTIFY = 0x00000282,
    WM_IME_CONTROL = 0x00000283,
    WM_IME_COMPOSITIONFULL = 0x00000284,
    WM_IME_SELECT = 0x00000285,
    WM_IME_CHAR = 0x00000286,
    WM_IME_REQUEST = 0x00000288,
    WM_IMEKEYDOWN = 0x00000290,
    WM_IME_KEYDOWN = 0x00000290,
    WM_IMEKEYUP = 0x00000291,
    WM_IME_KEYUP = 0x00000291,
    WM_NCMOUSEHOVER = 0x000002A0,
    WM_MOUSEHOVER = 0x000002A1,
    WM_NCMOUSELEAVE = 0x000002A2,
    WM_MOUSELEAVE = 0x000002A3,
    WM_CUT = 0x00000300,
    WM_COPY = 0x00000301,
    WM_PASTE = 0x00000302,
    WM_CLEAR = 0x00000303,
    WM_UNDO = 0x00000304,
    WM_RENDERFORMAT = 0x00000305,
    WM_RENDERALLFORMATS = 0x00000306,
    WM_DESTROYCLIPBOARD = 0x00000307,
    WM_DRAWCLIPBOARD = 0x00000308,
    WM_PAINTCLIPBOARD = 0x00000309,
    WM_VSCROLLCLIPBOARD = 0x0000030A,
    WM_SIZECLIPBOARD = 0x0000030B,
    WM_ASKCBFORMATNAME = 0x0000030C,
    WM_CHANGECBCHAIN = 0x0000030D,
    WM_HSCROLLCLIPBOARD = 0x0000030E,
    WM_QUERYNEWPALETTE = 0x0000030F,
    WM_PALETTEISCHANGING = 0x00000310,
    WM_PALETTECHANGED = 0x00000311,
    WM_HOTKEY = 0x00000312,
    WM_PRINT = 0x00000317,
    WM_PRINTCLIENT = 0x00000318,
    WM_APPCOMMAND = 0x00000319,
    WM_HANDHELDFIRST = 0x00000358,
    WM_HANDHELDLAST = 0x0000035F,
    WM_AFXFIRST = 0x00000360,
    WM_AFXLAST = 0x0000037F,
    WM_PENWINFIRST = 0x00000380,
    WM_RCRESULT = 0x00000381,
    WM_HOOKRCRESULT = 0x00000382,
    WM_GLOBALRCCHANGE = 0x00000383,
    WM_PENMISCINFO = 0x00000383,
    WM_SKB = 0x00000384,
    WM_HEDITCTL = 0x00000385,
    WM_PENCTL = 0x00000385,
    WM_PENMISC = 0x00000386,
    WM_CTLINIT = 0x00000387,
    WM_PENEVENT = 0x00000388,
    WM_PENWINLAST = 0x0000038F,
    DDM_SETFMT = 0x00000400,
    DM_GETDEFID = 0x00000400,
    NIN_SELECT = 0x00000400,
    TBM_GETPOS = 0x00000400,
    WM_PSD_PAGESETUPDLG = 0x00000400,
    WM_USER = 0x00000400,
    CBEM_INSERTITEMA = 0x00000401,
    DDM_DRAW = 0x00000401,
    DM_SETDEFID = 0x00000401,
    HKM_SETHOTKEY = 0x00000401,
    PBM_SETRANGE = 0x00000401,
    RB_INSERTBANDA = 0x00000401,
    SB_SETTEXTA = 0x00000401,
    TB_ENABLEBUTTON = 0x00000401,
    TBM_GETRANGEMIN = 0x00000401,
    TTM_ACTIVATE = 0x00000401,
    WM_CHOOSEFONT_GETLOGFONT = 0x00000401,
    WM_PSD_FULLPAGERECT = 0x00000401,
    CBEM_SETIMAGELIST = 0x00000402,
    DDM_CLOSE = 0x00000402,
    DM_REPOSITION = 0x00000402,
    HKM_GETHOTKEY = 0x00000402,
    PBM_SETPOS = 0x00000402,
    RB_DELETEBAND = 0x00000402,
    SB_GETTEXTA = 0x00000402,
    TB_CHECKBUTTON = 0x00000402,
    TBM_GETRANGEMAX = 0x00000402,
    WM_PSD_MINMARGINRECT = 0x00000402,
    CBEM_GETIMAGELIST = 0x00000403,
    DDM_BEGIN = 0x00000403,
    HKM_SETRULES = 0x00000403,
    PBM_DELTAPOS = 0x00000403,
    RB_GETBARINFO = 0x00000403,
    SB_GETTEXTLENGTHA = 0x00000403,
    TBM_GETTIC = 0x00000403,
    TB_PRESSBUTTON = 0x00000403,
    TTM_SETDELAYTIME = 0x00000403,
    WM_PSD_MARGINRECT = 0x00000403,
    CBEM_GETITEMA = 0x00000404,
    DDM_END = 0x00000404,
    PBM_SETSTEP = 0x00000404,
    RB_SETBARINFO = 0x00000404,
    SB_SETPARTS = 0x00000404,
    TB_HIDEBUTTON = 0x00000404,
    TBM_SETTIC = 0x00000404,
    TTM_ADDTOOLA = 0x00000404,
    WM_PSD_GREEKTEXTRECT = 0x00000404,
    CBEM_SETITEMA = 0x00000405,
    PBM_STEPIT = 0x00000405,
    TB_INDETERMINATE = 0x00000405,
    TBM_SETPOS = 0x00000405,
    TTM_DELTOOLA = 0x00000405,
    WM_PSD_ENVSTAMPRECT = 0x00000405,
    CBEM_GETCOMBOCONTROL = 0x00000406,
    PBM_SETRANGE32 = 0x00000406,
    RB_SETBANDINFOA = 0x00000406,
    SB_GETPARTS = 0x00000406,
    TB_MARKBUTTON = 0x00000406,
    TBM_SETRANGE = 0x00000406,
    TTM_NEWTOOLRECTA = 0x00000406,
    WM_PSD_YAFULLPAGERECT = 0x00000406,
    CBEM_GETEDITCONTROL = 0x00000407,
    PBM_GETRANGE = 0x00000407,
    RB_SETPARENT = 0x00000407,
    SB_GETBORDERS = 0x00000407,
    TBM_SETRANGEMIN = 0x00000407,
    TTM_RELAYEVENT = 0x00000407,
    CBEM_SETEXSTYLE = 0x00000408,
    PBM_GETPOS = 0x00000408,
    RB_HITTEST = 0x00000408,
    SB_SETMINHEIGHT = 0x00000408,
    TBM_SETRANGEMAX = 0x00000408,
    TTM_GETTOOLINFOA = 0x00000408,
    CBEM_GETEXSTYLE = 0x00000409,
    CBEM_GETEXTENDEDSTYLE = 0x00000409,
    PBM_SETBARCOLOR = 0x00000409,
    RB_GETRECT = 0x00000409,
    SB_SIMPLE = 0x00000409,
    TB_ISBUTTONENABLED = 0x00000409,
    TBM_CLEARTICS = 0x00000409,
    TTM_SETTOOLINFOA = 0x00000409,
    CBEM_HASEDITCHANGED = 0x0000040A,
    RB_INSERTBANDW = 0x0000040A,
    SB_GETRECT = 0x0000040A,
    TB_ISBUTTONCHECKED = 0x0000040A,
    TBM_SETSEL = 0x0000040A,
    TTM_HITTESTA = 0x0000040A,
    WIZ_QUERYNUMPAGES = 0x0000040A,
    CBEM_INSERTITEMW = 0x0000040B,
    RB_SETBANDINFOW = 0x0000040B,
    SB_SETTEXTW = 0x0000040B,
    TB_ISBUTTONPRESSED = 0x0000040B,
    TBM_SETSELSTART = 0x0000040B,
    TTM_GETTEXTA = 0x0000040B,
    WIZ_NEXT = 0x0000040B,
    CBEM_SETITEMW = 0x0000040C,
    RB_GETBANDCOUNT = 0x0000040C,
    SB_GETTEXTLENGTHW = 0x0000040C,
    TB_ISBUTTONHIDDEN = 0x0000040C,
    TBM_SETSELEND = 0x0000040C,
    TTM_UPDATETIPTEXTA = 0x0000040C,
    WIZ_PREV = 0x0000040C,
    CBEM_GETITEMW = 0x0000040D,
    RB_GETROWCOUNT = 0x0000040D,
    SB_GETTEXTW = 0x0000040D,
    TB_ISBUTTONINDETERMINATE = 0x0000040D,
    TTM_GETTOOLCOUNT = 0x0000040D,
    CBEM_SETEXTENDEDSTYLE = 0x0000040E,
    RB_GETROWHEIGHT = 0x0000040E,
    SB_ISSIMPLE = 0x0000040E,
    TB_ISBUTTONHIGHLIGHTED = 0x0000040E,
    TBM_GETPTICS = 0x0000040E,
    TTM_ENUMTOOLSA = 0x0000040E,
    SB_SETICON = 0x0000040F,
    TBM_GETTICPOS = 0x0000040F,
    TTM_GETCURRENTTOOLA = 0x0000040F,
    RB_IDTOINDEX = 0x00000410,
    SB_SETTIPTEXTA = 0x00000410,
    TBM_GETNUMTICS = 0x00000410,
    TTM_WINDOWFROMPOINT = 0x00000410,
    RB_GETTOOLTIPS = 0x00000411,
    SB_SETTIPTEXTW = 0x00000411,
    TBM_GETSELSTART = 0x00000411,
    TB_SETSTATE = 0x00000411,
    TTM_TRACKACTIVATE = 0x00000411,
    RB_SETTOOLTIPS = 0x00000412,
    SB_GETTIPTEXTA = 0x00000412,
    TB_GETSTATE = 0x00000412,
    TBM_GETSELEND = 0x00000412,
    TTM_TRACKPOSITION = 0x00000412,
    RB_SETBKCOLOR = 0x00000413,
    SB_GETTIPTEXTW = 0x00000413,
    TB_ADDBITMAP = 0x00000413,
    TBM_CLEARSEL = 0x00000413,
    TTM_SETTIPBKCOLOR = 0x00000413,
    RB_GETBKCOLOR = 0x00000414,
    SB_GETICON = 0x00000414,
    TB_ADDBUTTONSA = 0x00000414,
    TBM_SETTICFREQ = 0x00000414,
    TTM_SETTIPTEXTCOLOR = 0x00000414,
    RB_SETTEXTCOLOR = 0x00000415,
    TB_INSERTBUTTONA = 0x00000415,
    TBM_SETPAGESIZE = 0x00000415,
    TTM_GETDELAYTIME = 0x00000415,
    RB_GETTEXTCOLOR = 0x00000416,
    TB_DELETEBUTTON = 0x00000416,
    TBM_GETPAGESIZE = 0x00000416,
    TTM_GETTIPBKCOLOR = 0x00000416,
    RB_SIZETORECT = 0x00000417,
    TB_GETBUTTON = 0x00000417,
    TBM_SETLINESIZE = 0x00000417,
    TTM_GETTIPTEXTCOLOR = 0x00000417,
    RB_BEGINDRAG = 0x00000418,
    TB_BUTTONCOUNT = 0x00000418,
    TBM_GETLINESIZE = 0x00000418,
    TTM_SETMAXTIPWIDTH = 0x00000418,
    RB_ENDDRAG = 0x00000419,
    TB_COMMANDTOINDEX = 0x00000419,
    TBM_GETTHUMBRECT = 0x00000419,
    TTM_GETMAXTIPWIDTH = 0x00000419,
    RB_DRAGMOVE = 0x0000041A,
    TBM_GETCHANNELRECT = 0x0000041A,
    TB_SAVERESTOREA = 0x0000041A,
    TTM_SETMARGIN = 0x0000041A,
    RB_GETBARHEIGHT = 0x0000041B,
    TB_CUSTOMIZE = 0x0000041B,
    TBM_SETTHUMBLENGTH = 0x0000041B,
    TTM_GETMARGIN = 0x0000041B,
    RB_GETBANDINFOW = 0x0000041C,
    TB_ADDSTRINGA = 0x0000041C,
    TBM_GETTHUMBLENGTH = 0x0000041C,
    TTM_POP = 0x0000041C,
    RB_GETBANDINFOA = 0x0000041D,
    TB_GETITEMRECT = 0x0000041D,
    TBM_SETTOOLTIPS = 0x0000041D,
    TTM_UPDATE = 0x0000041D,
    RB_MINIMIZEBAND = 0x0000041E,
    TB_BUTTONSTRUCTSIZE = 0x0000041E,
    TBM_GETTOOLTIPS = 0x0000041E,
    TTM_GETBUBBLESIZE = 0x0000041E,
    RB_MAXIMIZEBAND = 0x0000041F,
    TBM_SETTIPSIDE = 0x0000041F,
    TB_SETBUTTONSIZE = 0x0000041F,
    TTM_ADJUSTRECT = 0x0000041F,
    TBM_SETBUDDY = 0x00000420,
    TB_SETBITMAPSIZE = 0x00000420,
    TTM_SETTITLEA = 0x00000420,
    MSG_FTS_JUMP_VA = 0x00000421,
    TB_AUTOSIZE = 0x00000421,
    TBM_GETBUDDY = 0x00000421,
    TTM_SETTITLEW = 0x00000421,
    RB_GETBANDBORDERS = 0x00000422,
    MSG_FTS_JUMP_QWORD = 0x00000423,
    RB_SHOWBAND = 0x00000423,
    TB_GETTOOLTIPS = 0x00000423,
    MSG_REINDEX_REQUEST = 0x00000424,
    TB_SETTOOLTIPS = 0x00000424,
    MSG_FTS_WHERE_IS_IT = 0x00000425,
    RB_SETPALETTE = 0x00000425,
    TB_SETPARENT = 0x00000425,
    RB_GETPALETTE = 0x00000426,
    RB_MOVEBAND = 0x00000427,
    TB_SETROWS = 0x00000427,
    TB_GETROWS = 0x00000428,
    TB_GETBITMAPFLAGS = 0x00000429,
    TB_SETCMDID = 0x0000042A,
    RB_PUSHCHEVRON = 0x0000042B,
    TB_CHANGEBITMAP = 0x0000042B,
    TB_GETBITMAP = 0x0000042C,
    MSG_GET_DEFFONT = 0x0000042D,
    TB_GETBUTTONTEXTA = 0x0000042D,
    TB_REPLACEBITMAP = 0x0000042E,
    TB_SETINDENT = 0x0000042F,
    TB_SETIMAGELIST = 0x00000430,
    TB_GETIMAGELIST = 0x00000431,
    TB_LOADIMAGES = 0x00000432,
    EM_CANPASTE = 0x00000432,
    TTM_ADDTOOLW = 0x00000432,
    EM_DISPLAYBAND = 0x00000433,
    TB_GETRECT = 0x00000433,
    TTM_DELTOOLW = 0x00000433,
    EM_EXGETSEL = 0x00000434,
    TB_SETHOTIMAGELIST = 0x00000434,
    TTM_NEWTOOLRECTW = 0x00000434,
    EM_EXLIMITTEXT = 0x00000435,
    TB_GETHOTIMAGELIST = 0x00000435,
    TTM_GETTOOLINFOW = 0x00000435,
    EM_EXLINEFROMCHAR = 0x00000436,
    TB_SETDISABLEDIMAGELIST = 0x00000436,
    TTM_SETTOOLINFOW = 0x00000436,
    EM_EXSETSEL = 0x00000437,
    TB_GETDISABLEDIMAGELIST = 0x00000437,
    TTM_HITTESTW = 0x00000437,
    EM_FINDTEXT = 0x00000438,
    TB_SETSTYLE = 0x00000438,
    TTM_GETTEXTW = 0x00000438,
    EM_FORMATRANGE = 0x00000439,
    TB_GETSTYLE = 0x00000439,
    TTM_UPDATETIPTEXTW = 0x00000439,
    EM_GETCHARFORMAT = 0x0000043A,
    TB_GETBUTTONSIZE = 0x0000043A,
    TTM_ENUMTOOLSW = 0x0000043A,
    EM_GETEVENTMASK = 0x0000043B,
    TB_SETBUTTONWIDTH = 0x0000043B,
    TTM_GETCURRENTTOOLW = 0x0000043B,
    EM_GETOLEINTERFACE = 0x0000043C,
    TB_SETMAXTEXTROWS = 0x0000043C,
    EM_GETPARAFORMAT = 0x0000043D,
    TB_GETTEXTROWS = 0x0000043D,
    EM_GETSELTEXT = 0x0000043E,
    TB_GETOBJECT = 0x0000043E,
    EM_HIDESELECTION = 0x0000043F,
    TB_GETBUTTONINFOW = 0x0000043F,
    EM_PASTESPECIAL = 0x00000440,
    TB_SETBUTTONINFOW = 0x00000440,
    EM_REQUESTRESIZE = 0x00000441,
    TB_GETBUTTONINFOA = 0x00000441,
    EM_SELECTIONTYPE = 0x00000442,
    TB_SETBUTTONINFOA = 0x00000442,
    EM_SETBKGNDCOLOR = 0x00000443,
    TB_INSERTBUTTONW = 0x00000443,
    EM_SETCHARFORMAT = 0x00000444,
    TB_ADDBUTTONSW = 0x00000444,
    EM_SETEVENTMASK = 0x00000445,
    TB_HITTEST = 0x00000445,
    EM_SETOLECALLBACK = 0x00000446,
    TB_SETDRAWTEXTFLAGS = 0x00000446,
    EM_SETPARAFORMAT = 0x00000447,
    TB_GETHOTITEM = 0x00000447,
    EM_SETTARGETDEVICE = 0x00000448,
    TB_SETHOTITEM = 0x00000448,
    EM_STREAMIN = 0x00000449,
    TB_SETANCHORHIGHLIGHT = 0x00000449,
    EM_STREAMOUT = 0x0000044A,
    TB_GETANCHORHIGHLIGHT = 0x0000044A,
    EM_GETTEXTRANGE = 0x0000044B,
    TB_GETBUTTONTEXTW = 0x0000044B,
    EM_FINDWORDBREAK = 0x0000044C,
    TB_SAVERESTOREW = 0x0000044C,
    EM_SETOPTIONS = 0x0000044D,
    TB_ADDSTRINGW = 0x0000044D,
    EM_GETOPTIONS = 0x0000044E,
    TB_MAPACCELERATORA = 0x0000044E,
    EM_FINDTEXTEX = 0x0000044F,
    TB_GETINSERTMARK = 0x0000044F,
    EM_GETWORDBREAKPROCEX = 0x00000450,
    TB_SETINSERTMARK = 0x00000450,
    EM_SETWORDBREAKPROCEX = 0x00000451,
    TB_INSERTMARKHITTEST = 0x00000451,
    EM_SETUNDOLIMIT = 0x00000452,
    TB_MOVEBUTTON = 0x00000452,
    TB_GETMAXSIZE = 0x00000453,
    EM_REDO = 0x00000454,
    TB_SETEXTENDEDSTYLE = 0x00000454,
    EM_CANREDO = 0x00000455,
    TB_GETEXTENDEDSTYLE = 0x00000455,
    EM_GETUNDONAME = 0x00000456,
    TB_GETPADDING = 0x00000456,
    EM_GETREDONAME = 0x00000457,
    TB_SETPADDING = 0x00000457,
    EM_STOPGROUPTYPING = 0x00000458,
    TB_SETINSERTMARKCOLOR = 0x00000458,
    EM_SETTEXTMODE = 0x00000459,
    TB_GETINSERTMARKCOLOR = 0x00000459,
    EM_GETTEXTMODE = 0x0000045A,
    TB_MAPACCELERATORW = 0x0000045A,
    EM_AUTOURLDETECT = 0x0000045B,
    TB_GETSTRINGW = 0x0000045B,
    EM_GETAUTOURLDETECT = 0x0000045C,
    TB_GETSTRINGA = 0x0000045C,
    EM_SETPALETTE = 0x0000045D,
    EM_GETTEXTEX = 0x0000045E,
    EM_GETTEXTLENGTHEX = 0x0000045F,
    EM_SHOWSCROLLBAR = 0x00000460,
    EM_SETTEXTEX = 0x00000461,
    TAPI_REPLY = 0x00000463,
    ACM_OPENA = 0x00000464,
    BFFM_SETSTATUSTEXTA = 0x00000464,
    CDM_FIRST = 0x00000464,
    CDM_GETSPEC = 0x00000464,
    EM_SETPUNCTUATION = 0x00000464,
    IPM_CLEARADDRESS = 0x00000464,
    WM_CAP_UNICODE_START = 0x00000464,
    ACM_PLAY = 0x00000465,
    BFFM_ENABLEOK = 0x00000465,
    CDM_GETFILEPATH = 0x00000465,
    EM_GETPUNCTUATION = 0x00000465,
    IPM_SETADDRESS = 0x00000465,
    PSM_SETCURSEL = 0x00000465,
    UDM_SETRANGE = 0x00000465,
    WM_CHOOSEFONT_SETLOGFONT = 0x00000465,
    ACM_STOP = 0x00000466,
    BFFM_SETSELECTIONA = 0x00000466,
    CDM_GETFOLDERPATH = 0x00000466,
    EM_SETWORDWRAPMODE = 0x00000466,
    IPM_GETADDRESS = 0x00000466,
    PSM_REMOVEPAGE = 0x00000466,
    UDM_GETRANGE = 0x00000466,
    WM_CAP_SET_CALLBACK_ERRORW = 0x00000466,
    WM_CHOOSEFONT_SETFLAGS = 0x00000466,
    ACM_OPENW = 0x00000467,
    BFFM_SETSELECTIONW = 0x00000467,
    CDM_GETFOLDERIDLIST = 0x00000467,
    EM_GETWORDWRAPMODE = 0x00000467,
    IPM_SETRANGE = 0x00000467,
    PSM_ADDPAGE = 0x00000467,
    UDM_SETPOS = 0x00000467,
    WM_CAP_SET_CALLBACK_STATUSW = 0x00000467,
    BFFM_SETSTATUSTEXTW = 0x00000468,
    CDM_SETCONTROLTEXT = 0x00000468,
    EM_SETIMECOLOR = 0x00000468,
    IPM_SETFOCUS = 0x00000468,
    PSM_CHANGED = 0x00000468,
    UDM_GETPOS = 0x00000468,
    CDM_HIDECONTROL = 0x00000469,
    EM_GETIMECOLOR = 0x00000469,
    IPM_ISBLANK = 0x00000469,
    PSM_RESTARTWINDOWS = 0x00000469,
    UDM_SETBUDDY = 0x00000469,
    CDM_SETDEFEXT = 0x0000046A,
    EM_SETIMEOPTIONS = 0x0000046A,
    PSM_REBOOTSYSTEM = 0x0000046A,
    UDM_GETBUDDY = 0x0000046A,
    EM_GETIMEOPTIONS = 0x0000046B,
    PSM_CANCELTOCLOSE = 0x0000046B,
    UDM_SETACCEL = 0x0000046B,
    EM_CONVPOSITION = 0x0000046C,
    PSM_QUERYSIBLINGS = 0x0000046C,
    UDM_GETACCEL = 0x0000046C,
    MCIWNDM_GETZOOM = 0x0000046D,
    PSM_UNCHANGED = 0x0000046D,
    UDM_SETBASE = 0x0000046D,
    PSM_APPLY = 0x0000046E,
    UDM_GETBASE = 0x0000046E,
    PSM_SETTITLEA = 0x0000046F,
    UDM_SETRANGE32 = 0x0000046F,
    PSM_SETWIZBUTTONS = 0x00000470,
    UDM_GETRANGE32 = 0x00000470,
    WM_CAP_DRIVER_GET_NAMEW = 0x00000470,
    PSM_PRESSBUTTON = 0x00000471,
    UDM_SETPOS32 = 0x00000471,
    WM_CAP_DRIVER_GET_VERSIONW = 0x00000471,
    PSM_SETCURSELID = 0x00000472,
    UDM_GETPOS32 = 0x00000472,
    PSM_SETFINISHTEXTA = 0x00000473,
    PSM_GETTABCONTROL = 0x00000474,
    PSM_ISDIALOGMESSAGE = 0x00000475,
    MCIWNDM_REALIZE = 0x00000476,
    PSM_GETCURRENTPAGEHWND = 0x00000476,
    MCIWNDM_SETTIMEFORMATA = 0x00000477,
    PSM_INSERTPAGE = 0x00000477,
    EM_SETLANGOPTIONS = 0x00000478,
    MCIWNDM_GETTIMEFORMATA = 0x00000478,
    PSM_SETTITLEW = 0x00000478,
    WM_CAP_FILE_SET_CAPTURE_FILEW = 0x00000478,
    EM_GETLANGOPTIONS = 0x00000479,
    MCIWNDM_VALIDATEMEDIA = 0x00000479,
    PSM_SETFINISHTEXTW = 0x00000479,
    WM_CAP_FILE_GET_CAPTURE_FILEW = 0x00000479,
    EM_GETIMECOMPMODE = 0x0000047A,
    EM_FINDTEXTW = 0x0000047B,
    MCIWNDM_PLAYTO = 0x0000047B,
    WM_CAP_FILE_SAVEASW = 0x0000047B,
    EM_FINDTEXTEXW = 0x0000047C,
    MCIWNDM_GETFILENAMEA = 0x0000047C,
    EM_RECONVERSION = 0x0000047D,
    MCIWNDM_GETDEVICEA = 0x0000047D,
    PSM_SETHEADERTITLEA = 0x0000047D,
    WM_CAP_FILE_SAVEDIBW = 0x0000047D,
    EM_SETIMEMODEBIAS = 0x0000047E,
    MCIWNDM_GETPALETTE = 0x0000047E,
    PSM_SETHEADERTITLEW = 0x0000047E,
    EM_GETIMEMODEBIAS = 0x0000047F,
    MCIWNDM_SETPALETTE = 0x0000047F,
    PSM_SETHEADERSUBTITLEA = 0x0000047F,
    MCIWNDM_GETERRORA = 0x00000480,
    PSM_SETHEADERSUBTITLEW = 0x00000480,
    PSM_HWNDTOINDEX = 0x00000481,
    PSM_INDEXTOHWND = 0x00000482,
    MCIWNDM_SETINACTIVETIMER = 0x00000483,
    PSM_PAGETOINDEX = 0x00000483,
    PSM_INDEXTOPAGE = 0x00000484,
    DL_BEGINDRAG = 0x00000485,
    MCIWNDM_GETINACTIVETIMER = 0x00000485,
    PSM_IDTOINDEX = 0x00000485,
    DL_DRAGGING = 0x00000486,
    PSM_INDEXTOID = 0x00000486,
    DL_DROPPED = 0x00000487,
    PSM_GETRESULT = 0x00000487,
    DL_CANCELDRAG = 0x00000488,
    PSM_RECALCPAGESIZES = 0x00000488,
    MCIWNDM_GET_SOURCE = 0x0000048C,
    MCIWNDM_PUT_SOURCE = 0x0000048D,
    MCIWNDM_GET_DEST = 0x0000048E,
    MCIWNDM_PUT_DEST = 0x0000048F,
    MCIWNDM_CAN_PLAY = 0x00000490,
    MCIWNDM_CAN_WINDOW = 0x00000491,
    MCIWNDM_CAN_RECORD = 0x00000492,
    MCIWNDM_CAN_SAVE = 0x00000493,
    MCIWNDM_CAN_EJECT = 0x00000494,
    MCIWNDM_CAN_CONFIG = 0x00000495,
    IE_GETINK = 0x00000496,
    IE_MSGFIRST = 0x00000496,
    MCIWNDM_PALETTEKICK = 0x00000496,
    IE_SETINK = 0x00000497,
    IE_GETPENTIP = 0x00000498,
    IE_SETPENTIP = 0x00000499,
    IE_GETERASERTIP = 0x0000049A,
    IE_SETERASERTIP = 0x0000049B,
    IE_GETBKGND = 0x0000049C,
    IE_SETBKGND = 0x0000049D,
    IE_GETGRIDORIGIN = 0x0000049E,
    IE_SETGRIDORIGIN = 0x0000049F,
    IE_GETGRIDPEN = 0x000004A0,
    IE_SETGRIDPEN = 0x000004A1,
    IE_GETGRIDSIZE = 0x000004A2,
    IE_SETGRIDSIZE = 0x000004A3,
    IE_GETMODE = 0x000004A4,
    IE_SETMODE = 0x000004A5,
    IE_GETINKRECT = 0x000004A6,
    WM_CAP_SET_MCI_DEVICEW = 0x000004A6,
    WM_CAP_GET_MCI_DEVICEW = 0x000004A7,
    WM_CAP_PAL_OPENW = 0x000004B4,
    WM_CAP_PAL_SAVEW = 0x000004B5,
    IE_GETAPPDATA = 0x000004B8,
    IE_SETAPPDATA = 0x000004B9,
    IE_GETDRAWOPTS = 0x000004BA,
    IE_SETDRAWOPTS = 0x000004BB,
    IE_GETFORMAT = 0x000004BC,
    IE_SETFORMAT = 0x000004BD,
    IE_GETINKINPUT = 0x000004BE,
    IE_SETINKINPUT = 0x000004BF,
    IE_GETNOTIFY = 0x000004C0,
    IE_SETNOTIFY = 0x000004C1,
    IE_GETRECOG = 0x000004C2,
    IE_SETRECOG = 0x000004C3,
    IE_GETSECURITY = 0x000004C4,
    IE_SETSECURITY = 0x000004C5,
    IE_GETSEL = 0x000004C6,
    IE_SETSEL = 0x000004C7,
    CDM_LAST = 0x000004C8,
    EM_SETBIDIOPTIONS = 0x000004C8,
    IE_DOCOMMAND = 0x000004C8,
    MCIWNDM_NOTIFYMODE = 0x000004C8,
    EM_GETBIDIOPTIONS = 0x000004C9,
    IE_GETCOMMAND = 0x000004C9,
    EM_SETTYPOGRAPHYOPTIONS = 0x000004CA,
    IE_GETCOUNT = 0x000004CA,
    EM_GETTYPOGRAPHYOPTIONS = 0x000004CB,
    IE_GETGESTURE = 0x000004CB,
    MCIWNDM_NOTIFYMEDIA = 0x000004CB,
    EM_SETEDITSTYLE = 0x000004CC,
    IE_GETMENU = 0x000004CC,
    EM_GETEDITSTYLE = 0x000004CD,
    IE_GETPAINTDC = 0x000004CD,
    MCIWNDM_NOTIFYERROR = 0x000004CD,
    IE_GETPDEVENT = 0x000004CE,
    IE_GETSELCOUNT = 0x000004CF,
    IE_GETSELITEMS = 0x000004D0,
    IE_GETSTYLE = 0x000004D1,
    MCIWNDM_SETTIMEFORMATW = 0x000004DB,
    EM_OUTLINE = 0x000004DC,
    MCIWNDM_GETTIMEFORMATW = 0x000004DC,
    EM_GETSCROLLPOS = 0x000004DD,
    EM_SETSCROLLPOS = 0x000004DE,
    EM_SETFONTSIZE = 0x000004DF,
    EM_GETZOOM = 0x000004E0,
    MCIWNDM_GETFILENAMEW = 0x000004E0,
    EM_SETZOOM = 0x000004E1,
    MCIWNDM_GETDEVICEW = 0x000004E1,
    EM_GETVIEWKIND = 0x000004E2,
    EM_SETVIEWKIND = 0x000004E3,
    EM_GETPAGE = 0x000004E4,
    MCIWNDM_GETERRORW = 0x000004E4,
    EM_SETPAGE = 0x000004E5,
    EM_GETHYPHENATEINFO = 0x000004E6,
    EM_SETHYPHENATEINFO = 0x000004E7,
    EM_GETPAGEROTATE = 0x000004EB,
    EM_SETPAGEROTATE = 0x000004EC,
    EM_GETCTFMODEBIAS = 0x000004ED,
    EM_SETCTFMODEBIAS = 0x000004EE,
    EM_GETCTFOPENSTATUS = 0x000004F0,
    EM_SETCTFOPENSTATUS = 0x000004F1,
    EM_GETIMECOMPTEXT = 0x000004F2,
    EM_ISIME = 0x000004F3,
    EM_GETIMEPROPERTY = 0x000004F4,
    EM_GETQUERYRTFOBJ = 0x0000050D,
    EM_SETQUERYRTFOBJ = 0x0000050E,
    FM_GETFOCUS = 0x00000600,
    FM_GETDRIVEINFOA = 0x00000601,
    FM_GETSELCOUNT = 0x00000602,
    FM_GETSELCOUNTLFN = 0x00000603,
    FM_GETFILESELA = 0x00000604,
    FM_GETFILESELLFNA = 0x00000605,
    FM_REFRESH_WINDOWS = 0x00000606,
    FM_RELOAD_EXTENSIONS = 0x00000607,
    FM_GETDRIVEINFOW = 0x00000611,
    FM_GETFILESELW = 0x00000614,
    FM_GETFILESELLFNW = 0x00000615,
    WLX_WM_SAS = 0x00000659,
    SM_GETSELCOUNT = 0x000007E8,
    UM_GETSELCOUNT = 0x000007E8,
    WM_CPL_LAUNCH = 0x000007E8,
    SM_GETSERVERSELA = 0x000007E9,
    UM_GETUSERSELA = 0x000007E9,
    WM_CPL_LAUNCHED = 0x000007E9,
    SM_GETSERVERSELW = 0x000007EA,
    UM_GETUSERSELW = 0x000007EA,
    SM_GETCURFOCUSA = 0x000007EB,
    UM_GETGROUPSELA = 0x000007EB,
    SM_GETCURFOCUSW = 0x000007EC,
    UM_GETGROUPSELW = 0x000007EC,
    SM_GETOPTIONS = 0x000007ED,
    UM_GETCURFOCUSA = 0x000007ED,
    UM_GETCURFOCUSW = 0x000007EE,
    UM_GETOPTIONS = 0x000007EF,
    UM_GETOPTIONS2 = 0x000007F0,
    LVM_FIRST = 0x00001000,
    LVM_GETBKCOLOR = 0x00001000,
    LVM_SETBKCOLOR = 0x00001001,
    LVM_GETIMAGELIST = 0x00001002,
    LVM_SETIMAGELIST = 0x00001003,
    LVM_GETITEMCOUNT = 0x00001004,
    LVM_GETITEMA = 0x00001005,
    LVM_SETITEMA = 0x00001006,
    LVM_INSERTITEMA = 0x00001007,
    LVM_DELETEITEM = 0x00001008,
    LVM_DELETEALLITEMS = 0x00001009,
    LVM_GETCALLBACKMASK = 0x0000100A,
    LVM_SETCALLBACKMASK = 0x0000100B,
    LVM_GETNEXTITEM = 0x0000100C,
    LVM_FINDITEMA = 0x0000100D,
    LVM_GETITEMRECT = 0x0000100E,
    LVM_SETITEMPOSITION = 0x0000100F,
    LVM_GETITEMPOSITION = 0x00001010,
    LVM_GETSTRINGWIDTHA = 0x00001011,
    LVM_HITTEST = 0x00001012,
    LVM_ENSUREVISIBLE = 0x00001013,
    LVM_SCROLL = 0x00001014,
    LVM_REDRAWITEMS = 0x00001015,
    LVM_ARRANGE = 0x00001016,
    LVM_EDITLABELA = 0x00001017,
    LVM_GETEDITCONTROL = 0x00001018,
    LVM_GETCOLUMNA = 0x00001019,
    LVM_SETCOLUMNA = 0x0000101A,
    LVM_INSERTCOLUMNA = 0x0000101B,
    LVM_DELETECOLUMN = 0x0000101C,
    LVM_GETCOLUMNWIDTH = 0x0000101D,
    LVM_SETCOLUMNWIDTH = 0x0000101E,
    LVM_GETHEADER = 0x0000101F,
    LVM_CREATEDRAGIMAGE = 0x00001021,
    LVM_GETVIEWRECT = 0x00001022,
    LVM_GETTEXTCOLOR = 0x00001023,
    LVM_SETTEXTCOLOR = 0x00001024,
    LVM_GETTEXTBKCOLOR = 0x00001025,
    LVM_SETTEXTBKCOLOR = 0x00001026,
    LVM_GETTOPINDEX = 0x00001027,
    LVM_GETCOUNTPERPAGE = 0x00001028,
    LVM_GETORIGIN = 0x00001029,
    LVM_UPDATE = 0x0000102A,
    LVM_SETITEMSTATE = 0x0000102B,
    LVM_GETITEMSTATE = 0x0000102C,
    LVM_GETITEMTEXTA = 0x0000102D,
    LVM_SETITEMTEXTA = 0x0000102E,
    LVM_SETITEMCOUNT = 0x0000102F,
    LVM_SORTITEMS = 0x00001030,
    LVM_SETITEMPOSITION32 = 0x00001031,
    LVM_GETSELECTEDCOUNT = 0x00001032,
    LVM_GETITEMSPACING = 0x00001033,
    LVM_GETISEARCHSTRINGA = 0x00001034,
    LVM_SETICONSPACING = 0x00001035,
    LVM_SETEXTENDEDLISTVIEWSTYLE = 0x00001036,
    LVM_GETEXTENDEDLISTVIEWSTYLE = 0x00001037,
    LVM_GETSUBITEMRECT = 0x00001038,
    LVM_SUBITEMHITTEST = 0x00001039,
    LVM_SETCOLUMNORDERARRAY = 0x0000103A,
    LVM_GETCOLUMNORDERARRAY = 0x0000103B,
    LVM_SETHOTITEM = 0x0000103C,
    LVM_GETHOTITEM = 0x0000103D,
    LVM_SETHOTCURSOR = 0x0000103E,
    LVM_GETHOTCURSOR = 0x0000103F,
    LVM_APPROXIMATEVIEWRECT = 0x00001040,
    LVM_SETWORKAREAS = 0x00001041,
    LVM_GETSELECTIONMARK = 0x00001042,
    LVM_SETSELECTIONMARK = 0x00001043,
    LVM_SETBKIMAGEA = 0x00001044,
    LVM_GETBKIMAGEA = 0x00001045,
    LVM_GETWORKAREAS = 0x00001046,
    LVM_SETHOVERTIME = 0x00001047,
    LVM_GETHOVERTIME = 0x00001048,
    LVM_GETNUMBEROFWORKAREAS = 0x00001049,
    LVM_SETTOOLTIPS = 0x0000104A,
    LVM_GETITEMW = 0x0000104B,
    LVM_SETITEMW = 0x0000104C,
    LVM_INSERTITEMW = 0x0000104D,
    LVM_GETTOOLTIPS = 0x0000104E,
    LVM_FINDITEMW = 0x00001053,
    LVM_GETSTRINGWIDTHW = 0x00001057,
    LVM_GETCOLUMNW = 0x0000105F,
    LVM_SETCOLUMNW = 0x00001060,
    LVM_INSERTCOLUMNW = 0x00001061,
    LVM_GETITEMTEXTW = 0x00001073,
    LVM_SETITEMTEXTW = 0x00001074,
    LVM_GETISEARCHSTRINGW = 0x00001075,
    LVM_EDITLABELW = 0x00001076,
    LVM_GETBKIMAGEW = 0x0000108B,
    LVM_SETSELECTEDCOLUMN = 0x0000108C,
    LVM_SETTILEWIDTH = 0x0000108D,
    LVM_SETVIEW = 0x0000108E,
    LVM_GETVIEW = 0x0000108F,
    LVM_INSERTGROUP = 0x00001091,
    LVM_SETGROUPINFO = 0x00001093,
    LVM_GETGROUPINFO = 0x00001095,
    LVM_REMOVEGROUP = 0x00001096,
    LVM_MOVEGROUP = 0x00001097,
    LVM_MOVEITEMTOGROUP = 0x0000109A,
    LVM_SETGROUPMETRICS = 0x0000109B,
    LVM_GETGROUPMETRICS = 0x0000109C,
    LVM_ENABLEGROUPVIEW = 0x0000109D,
    LVM_SORTGROUPS = 0x0000109E,
    LVM_INSERTGROUPSORTED = 0x0000109F,
    LVM_REMOVEALLGROUPS = 0x000010A0,
    LVM_HASGROUP = 0x000010A1,
    LVM_SETTILEVIEWINFO = 0x000010A2,
    LVM_GETTILEVIEWINFO = 0x000010A3,
    LVM_SETTILEINFO = 0x000010A4,
    LVM_GETTILEINFO = 0x000010A5,
    LVM_SETINSERTMARK = 0x000010A6,
    LVM_GETINSERTMARK = 0x000010A7,
    LVM_INSERTMARKHITTEST = 0x000010A8,
    LVM_GETINSERTMARKRECT = 0x000010A9,
    LVM_SETINSERTMARKCOLOR = 0x000010AA,
    LVM_GETINSERTMARKCOLOR = 0x000010AB,
    LVM_SETINFOTIP = 0x000010AD,
    LVM_GETSELECTEDCOLUMN = 0x000010AE,
    LVM_ISGROUPVIEWENABLED = 0x000010AF,
    LVM_GETOUTLINECOLOR = 0x000010B0,
    LVM_SETOUTLINECOLOR = 0x000010B1,
    LVM_CANCELEDITLABEL = 0x000010B3,
    LVM_MAPINDEXTOID = 0x000010B4,
    LVM_MAPIDTOINDEX = 0x000010B5,
    LVM_ISITEMVISIBLE = 0x000010B6,
    OCM__BASE = 0x00002000,
    LVM_SETUNICODEFORMAT = 0x00002005,
    LVM_GETUNICODEFORMAT = 0x00002006,
    OCM_CTLCOLOR = 0x00002019,
    OCM_DRAWITEM = 0x0000202B,
    OCM_MEASUREITEM = 0x0000202C,
    OCM_DELETEITEM = 0x0000202D,
    OCM_VKEYTOITEM = 0x0000202E,
    OCM_CHARTOITEM = 0x0000202F,
    OCM_COMPAREITEM = 0x00002039,
    OCM_NOTIFY = 0x0000204E,
    OCM_COMMAND = 0x00002111,
    OCM_HSCROLL = 0x00002114,
    OCM_VSCROLL = 0x00002115,
    OCM_CTLCOLORMSGBOX = 0x00002132,
    OCM_CTLCOLOREDIT = 0x00002133,
    OCM_CTLCOLORLISTBOX = 0x00002134,
    OCM_CTLCOLORBTN = 0x00002135,
    OCM_CTLCOLORDLG = 0x00002136,
    OCM_CTLCOLORSCROLLBAR = 0x00002137,
    OCM_CTLCOLORSTATIC = 0x00002138,
    OCM_PARENTNOTIFY = 0x00002210,
    WM_APP = 0x00008000,
    WM_RASDIALEVENT = 0x0000CCCD,
}
#endregion

/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-sizing
/// The edge of the window that is being sized. Provided by wParam within a WM_SIZING message.
/// </summary>
internal enum WM_SIZING_wParam
{
    /// <summary>
    /// Bottom edge
    /// </summary>
    WMSZ_BOTTOM = 6,
    /// <summary>
    ///Bottom-left corner
    /// </summary>
    WMSZ_BOTTOMLEFT = 7,
    /// <summary>
    /// Bottom-right corner
    /// </summary>
    WMSZ_BOTTOMRIGHT = 8,
    /// <summary>
    /// Left edge
    /// </summary>
    WMSZ_LEFT = 1,
    /// <summary>
    /// Right edge
    /// </summary>
    WMSZ_RIGHT = 2,
    /// <summary>
    /// Top edge
    /// </summary>
    WMSZ_TOP = 3,
    /// <summary>
    /// Top-left corner
    /// </summary>
    WMSZ_TOPLEFT = 4,
    /// <summary>
    /// Top-right corner
    /// </summary>
    WMSZ_TOPRIGHT = 5,
    //9 seems to be generated if the window gets resized by dragging the title bar when maximised
}

#region WindowStyle
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/winmsg/window-styles
/// </summary>
[Flags]
internal enum WindowStyle : uint
{
    /// <summary>
    /// The window has a thin-line border.
    /// </summary>
    WS_BORDER = 0x00800000,
    /// <summary>
    /// The window has a title bar (includes the WS_BORDER style).
    /// </summary>
    WS_CAPTION = 0x00C00000,
    /// <summary>
    /// The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.
    /// </summary>
    WS_CHILD = 0x40000000,
    /// <summary>
    /// Same as the WS_CHILD style.
    /// </summary>
    WS_CHILDWINDOW = WS_CHILD,
    /// <summary>
    /// Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.
    /// </summary>
    WS_CLIPCHILDREN = 0x02000000,
    /// <summary>
    /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
    /// </summary>
    WS_CLIPSIBLINGS = 0x04000000,
    /// <summary>
    /// The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.
    /// </summary>
    WS_DISABLED = 0x08000000,
    /// <summary>
    /// The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
    /// </summary>
    WS_DLGFRAME = 0x00400000,
    /// <summary>
    /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style. The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
    /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
    /// </summary>
    WS_GROUP = 0x00020000,
    /// <summary>
    /// The window has a horizontal scroll bar.
    /// </summary>
    WS_HSCROLL = 0x00100000,
    /// <summary>
    /// The window is initially minimized. Same as the WS_MINIMIZE style.
    /// </summary>
    WS_ICONIC = 0x20000000,
    /// <summary>
    /// The window is initially maximized.
    /// </summary>
    WS_MAXIMIZE = 0x01000000,
    /// <summary>
    /// The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
    /// </summary>
    WS_MAXIMIZEBOX = 0x00010000,
    /// <summary>
    /// The window is initially minimized. Same as the WS_ICONIC style.
    /// </summary>
    WS_MINIMIZE = WS_ICONIC,
    /// <summary>
    /// The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
    /// </summary>
    WS_MINIMIZEBOX = 0x00020000,
    /// <summary>
    /// The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_TILED style.
    /// </summary>
    WS_OVERLAPPED = 0x00000000,
    /// <summary>
    /// The window is an overlapped window. Same as the WS_TILEDWINDOW style.
    /// </summary>
    WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
    /// <summary>
    /// The window is a pop-up window. This style cannot be used with the WS_CHILD style.
    /// </summary>
    WS_POPUP = 0x80000000,
    /// <summary>
    /// The window is a pop-up window. The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.
    /// </summary>
    WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
    /// <summary>
    /// The window has a sizing border. Same as the WS_THICKFRAME style.
    /// </summary>
    WS_SIZEBOX = 0x00040000,
    /// <summary>
    /// The window has a window menu on its title bar. The WS_CAPTION style must also be specified.
    /// </summary>
    WS_SYSMENU = 0x00080000,
    /// <summary>
    /// The window is a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.
    /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function. For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
    /// </summary>
    WS_TABSTOP = 0x00010000,
    /// <summary>
    /// The window has a sizing border. Same as the WS_SIZEBOX style.
    /// </summary>
    WS_THICKFRAME = WS_SIZEBOX,
    /// <summary>
    /// The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_OVERLAPPED style.
    /// </summary>
    WS_TILED = WS_OVERLAPPED,
    /// <summary>
    /// The window is an overlapped window. Same as the WS_OVERLAPPEDWINDOW style.
    /// </summary>
    WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
    /// <summary>
    /// The window is initially visible.
    /// This style can be turned on and off by using the ShowWindow or SetWindowPos function.
    /// </summary>
    WS_VISIBLE = 0x10000000,
    /// <summary>
    /// The window has a vertical scroll bar.
    /// </summary>
    WS_VSCROLL = 0x00200000,
}
#endregion
#endregion

#region Structs
#region DEV_BROADCAST_DEVICEINTERFACE
#pragma warning disable 0649, 0169, IDE0044, IDE0051
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerdevicenotificationa
/// https://docs.microsoft.com/en-us/windows/win32/api/dbt/ns-dbt-dev_broadcast_deviceinterface_a
/// https://docs.microsoft.com/en-us/windows/win32/api/dbt/ns-dbt-dev_broadcast_hdr
/// For use with User32 RegisterDeviceNotification
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct DEV_BROADCAST_DEVICEINTERFACE
{
    /// <summary>
    /// The size of this structure, in bytes. This is the size of the members plus the actual length of the dbcc_name string (the null character is accounted for by the declaration of dbcc_name as a one-character array.)
    /// </summary>
    internal int dbch_size;
    /// <summary>
    /// Set to DBT_DEVTYP_DEVICEINTERFACE.
    /// </summary>
    internal DEV_BROADCAST_HDR_dbch_devicetype dbch_devicetype;
    /// <summary>
    /// Reserved; do not use.
    /// </summary>
    private int dbcc_reserved;
    /// <summary>
    /// The GUID for the interface device class.
    /// </summary>
    internal Guid dbcc_classguid;
    /// <summary>
    /// A null-terminated string that specifies the name of the device.
    /// When this structure is returned to a window through the WM_DEVICECHANGE message, the dbcc_name string is converted to ANSI as appropriate. Services always receive a Unicode string, whether they call RegisterDeviceNotificationW or RegisterDeviceNotificationA.
    /// </summary>
    internal char dbcc_name;
}
#pragma warning restore 0649, 0169, IDE0044, IDE0051
#endregion

#region DEV_BROADCAST_HDR
#pragma warning disable 0649, 0169, IDE0044, IDE0051
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerdevicenotificationa
/// https://docs.microsoft.com/en-us/windows/win32/api/dbt/ns-dbt-dev_broadcast_hdr
/// For use with User32 RegisterDeviceNotification
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct DEV_BROADCAST_HDR
{
    /// <summary>
    /// The size of this structure, in bytes.
    /// If this is a user-defined event, this member must be the size of this header, plus the size of the variable-length data in the _DEV_BROADCAST_USERDEFINED structure.
    /// </summary>
    internal int dbch_size;
    /// <summary>
    /// The device type, which determines the event-specific information that follows the first three members. This member can be one of the following values.
    /// DBT_DEVTYP_DEVICEINTERFACE: Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.
    /// DBT_DEVTYP_HANDLE: File system handle.This structure is a DEV_BROADCAST_HANDLE structure.
    /// DBT_DEVTYP_OEM: OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.
    /// DBT_DEVTYP_PORT: Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.
    /// DBT_DEVTYP_VOLUME: Logical volume.This structure is a DEV_BROADCAST_VOLUME structure.
    /// </summary>
    private DEV_BROADCAST_HDR_dbch_devicetype dbch_devicetype;
    /// <summary>
    /// Reserved; do not use.
    /// </summary>
    private int dbcc_reserved;
}
#pragma warning restore 0649, 0169, IDE0044, IDE0051
#endregion

#region MINMAXINFO
[StructLayout(LayoutKind.Sequential)]
internal struct MINMAXINFO
{
    private POINT ptReserved;
    public POINT ptMaxSize;
    public POINT ptMaxPosition;
    public POINT ptMinTrackSize;
    public POINT ptMaxTrackSize;
}
#endregion

#region MSG
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msg
/// Contains message information from a thread's message queue.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct MSG
{
    /// <summary>
    /// A handle to the window whose window procedure receives the message. This member is NULL when the message is a thread message.
    /// </summary>
    internal IntPtr hwnd;
    /// <summary>
    /// The message identifier. Applications can only use the low word; the high word is reserved by the system.
    /// </summary>
    internal WindowMessage message;
    /// <summary>
    /// Additional information about the message. The exact meaning depends on the value of the message member.
    /// </summary>
    internal IntPtr wParam;
    /// <summary>
    /// Additional information about the message. The exact meaning depends on the value of the message member.
    /// </summary>
    internal IntPtr lParam;
    /// <summary>
    /// The time at which the message was posted.
    /// </summary>
    internal uint time;
    /// <summary>
    /// The cursor position, in screen coordinates, when the message was posted.
    /// </summary>
    internal POINT pt;
    internal uint lPrivate;
}
#endregion

#region RECT
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect
/// The RECT structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RECT
{
    public int left, top, right, bottom;
    public int Width => right - left;
    public int Height => bottom - top;
    public POINT Centre => new() { X = (right + left) / 2, Y = (bottom + top) / 2 };
    public static int UnmanagedSize => Marshal.SizeOf(default(RECT));
}
#endregion

#region POINT
/// <summary>
/// https://docs.microsoft.com/en-us/previous-versions/dd162805(v=vs.85)
/// The POINT structure defines the x- and y- coordinates of a point.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct POINT
{
    internal int X;
    internal int Y;
}
#endregion

#region PeekMessage_Flags
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-peekmessagew
/// Specifies how messages are to be handled, for use with PeekMessage.
/// By default, all message types are processed. To specify that only certain message should be processed, specify one or more of the PM_QS values.
/// </summary>
[Flags]
internal enum PeekMessage_Flags : uint
{
    /// <summary>
    /// Messages are not removed from the queue after processing by PeekMessage.
    /// </summary>
    PM_NOREMOVE = 0x0000,
    /// <summary>
    /// Messages are removed from the queue after processing by PeekMessage.
    /// </summary>
    PM_REMOVE = 0x0001,
    /// <summary>
    /// Prevents the system from releasing any thread that is waiting for the caller to go idle (see WaitForInputIdle).
    /// Combine this value with either PM_NOREMOVE or PM_REMOVE.
    /// </summary>
    PM_NOYIELD = 0x0002,
    /// <summary>
    /// Process mouse and keyboard messages.
    /// </summary>
    PM_QS_INPUT = GetQueueStatus_Flags.QS_INPUT << 16,
    /// <summary>
    /// Process paint messages.
    /// </summary>
    PM_QS_PAINT = GetQueueStatus_Flags.QS_PAINT << 16,
    /// <summary>
    /// Process all posted messages, including timers and hotkeys.
    /// </summary>
    PM_QS_POSTMESSAGE = (GetQueueStatus_Flags.QS_POSTMESSAGE | GetQueueStatus_Flags.QS_HOTKEY | GetQueueStatus_Flags.QS_TIMER) << 16,
    /// <summary>
    /// Process all sent messages.
    /// </summary>
    PM_QS_SENDMESSAGE = GetQueueStatus_Flags.QS_SENDMESSAGE << 16,
}
#endregion

#region WINDOWINFO
//https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowinfo
[StructLayout(LayoutKind.Sequential)]
struct WINDOWINFO
{
    public uint cbSize;
    public RECT rcWindow;
    public RECT rcClient;
    public uint dwStyle;
    public uint dwExStyle;
    public uint dwWindowStatus;
    public uint cxWindowBorders;
    public uint cyWindowBorders;
    public ushort atomWindowType;
    public ushort wCreatorVersion;

    public WINDOWINFO(object? filler) : this()
    {
        cbSize = (uint)Marshal.SizeOf(typeof(WINDOWINFO));
    }

}
#endregion

#region WNDCLASSEXW
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-wndclassexw
/// Contains window class information. It is used with the RegisterClassEx and GetClassInfoEx  functions.
/// The WNDCLASSEX structure is similar to the WNDCLASS structure.There are two differences.WNDCLASSEX includes the cbSize member, which specifies the size of the structure, and the hIconSm member, which contains a handle to a small icon associated with the window class.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal struct WNDCLASSEX
{
    /// <summary>
    /// The size, in bytes, of this structure. Set this member to sizeof(WNDCLASSEX). Be sure to set this member before calling the GetClassInfoEx function.
    /// </summary>
    internal uint cbSize;
    /// <summary>
    /// The class style(s). This member can be any combination of the Class Styles.
    /// </summary>
    internal WindowClassStyle style;
    /// <summary>
    /// A pointer to the window procedure. You must use the CallWindowProc function to call the window procedure. For more information, see WindowProc.
    /// </summary>
    [MarshalAs(UnmanagedType.FunctionPtr)]
    internal WNDPROC lpfnWndProc;
    /// <summary>
    /// The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.
    /// </summary>
    internal int cbClsExtra;
    /// <summary>
    /// The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero. If an application uses WNDCLASSEX to register a dialog box created by using the CLASS directive in the resource file, it must set this member to DLGWINDOWEXTRA.
    /// </summary>
    internal int cbWndExtra;
    /// <summary>
    /// A handle to the instance that contains the window procedure for the class.
    /// </summary>
    internal IntPtr hInstance;
    /// <summary>
    /// A handle to the class icon. This member must be a handle to an icon resource. If this member is NULL, the system provides a default icon.
    /// </summary>
    internal IntPtr hIcon;
    /// <summary>
    /// A handle to the class cursor. This member must be a handle to a cursor resource. If this member is NULL, an application must explicitly set the cursor shape whenever the mouse moves into the application's window.
    /// </summary>
    internal IntPtr hCursor;
    /// <summary>
    /// A handle to the class background brush. This member can be a handle to the brush to be used for painting the background, or it can be a color value. A color value must be one of the following standard system colors (the value 1 must be added to the chosen color). The system automatically deletes class background brushes when the class is unregistered by using UnregisterClass. An application should not delete these brushes. When this member is NULL, an application must paint its own background whenever it is requested to paint in its client area.To determine whether the background must be painted, an application can either process the WM_ERASEBKGND message or test the fErase member of the PAINTSTRUCT structure filled by the BeginPaint function.
    /// </summary>
    internal IntPtr hbrBackground;
    /// <summary>
    /// Pointer to a null-terminated character string that specifies the resource name of the class menu, as the name appears in the resource file. If you use an integer to identify the menu, use the MAKEINTRESOURCE macro. If this member is NULL, windows belonging to this class have no default menu.
    /// </summary>
    internal IntPtr lpszMenuName;
    /// <summary>
    /// A pointer to a null-terminated string or is an atom. If this parameter is an atom, it must be a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpszClassName; the high-order word must be zero.
    /// If lpszClassName is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
    /// The maximum length for lpszClassName is 256. If lpszClassName is greater than the maximum length, the RegisterClassEx function will fail.
    /// </summary>
    internal IntPtr lpszClassName;
    /// <summary>
    /// A handle to a small icon that is associated with the window class. If this member is NULL, the system searches the icon resource specified by the hIcon member for an icon of the appropriate size to use as the small icon.
    /// </summary>
    internal IntPtr hIconSm;
}

#endregion
#endregion

#region Delegates
#region WindowProc
/// <summary>
/// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms633573(v=vs.85)
/// An application-defined function that processes messages sent to a window. The WNDPROC type defines a pointer to this callback function.
/// </summary>
/// <param name="hwnd"></param>
/// <param name="uMsg"></param>
/// <param name="wParam"></param>
/// <param name="lParam"></param>
/// <returns></returns>
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate IntPtr WNDPROC(IntPtr hwnd, WindowMessage uMsg, IntPtr wParam, IntPtr lParam);
#endregion
#endregion

// * * * CLEANED UP ABOVE THIS LINE * * *

#region ABE
internal enum ABE : uint
{
    Left = 0,
    Top = 1,
    Right = 2,
    Bottom = 3
}
#endregion

#region ABM
internal enum ABM : uint
{
    New = 0x00000000,
    Remove = 0x00000001,
    QueryPos = 0x00000002,
    SetPos = 0x00000003,
    GetState = 0x00000004,
    GetTaskbarPos = 0x00000005,
    Activate = 0x00000006,
    GetAutoHideBar = 0x00000007,
    SetAutoHideBar = 0x00000008,
    WindowPosChanged = 0x00000009,
    SetState = 0x0000000A,
}
#endregion

#region ABS
[Flags]
internal enum ABS : int
{
    Autohide = 0x0000001,
    AlwaysOnTop = 0x0000002
}
#endregion

#region APPBARDATA
[StructLayout(LayoutKind.Sequential)]
internal struct APPBARDATA
{
    public uint cbSize;
    public IntPtr hWnd;
    public uint uCallbackMessage;
    public ABE uEdge;
    public RECT rc;
    public int lParam;
}
#endregion

#region ChangeDisplaySettingsEnum
[Flags]
internal enum ChangeDisplaySettingsEnum
{
    // ChangeDisplaySettings types (found in winuser.h)
    UpdateRegistry = 0x00000001,
    Test = 0x00000002,
    Fullscreen = 0x00000004,
}
#endregion

#region CreateStruct
internal struct CreateStruct
{
    internal IntPtr lpCreateParams;
    /// <summary>
    /// Handle to the module that owns the new window.
    /// </summary>
    internal IntPtr hInstance;
    /// <summary>
    /// Handle to the menu to be used by the new window.
    /// </summary>
    internal IntPtr hMenu;
    /// <summary>
    /// Handle to the parent window, if the window is a child window.
    /// If the window is owned, this member identifies the owner window.
    /// If the window is not a child or owned window, this member is NULL.
    /// </summary>
    internal IntPtr hwndParent;
    /// <summary>
    /// Specifies the height of the new window, in pixels.
    /// </summary>
    internal int cy;
    /// <summary>
    /// Specifies the width of the new window, in pixels.
    /// </summary>
    internal int cx;
    /// <summary>
    /// Specifies the y-coordinate of the upper left corner of the new window.
    /// If the new window is a child window, coordinates are relative to the parent window.
    /// Otherwise, the coordinates are relative to the screen origin.
    /// </summary>
    internal int y;
    /// <summary>
    /// Specifies the x-coordinate of the upper left corner of the new window.
    /// If the new window is a child window, coordinates are relative to the parent window.
    /// Otherwise, the coordinates are relative to the screen origin.
    /// </summary>
    internal int x;
    /// <summary>
    /// Specifies the style for the new window.
    /// </summary>
    internal int style;
    /// <summary>
    /// Pointer to a null-terminated string that specifies the name of the new window.
    /// </summary>
    [MarshalAs(UnmanagedType.LPTStr)]
    internal string lpszName;
    /// <summary>
    /// Either a pointer to a null-terminated string or an atom that specifies the class name
    /// of the new window.
    /// <remarks>
    /// Note  Because the lpszClass member can contain a pointer to a local (and thus inaccessable) atom,
    /// do not obtain the class name by using this member. Use the GetClassName function instead.
    /// </remarks>
    /// </summary>
    [MarshalAs(UnmanagedType.LPTStr)]
    internal string lpszClass;
    /// <summary>
    /// Specifies the extended window style for the new window.
    /// </summary>
    internal int dwExStyle;
}
#endregion

#region COLORREF
[StructLayout(LayoutKind.Sequential)]
internal struct COLORREF
{
    public byte R;
    public byte G;
    public byte B;
}
#endregion

#region CONSOLE_SCREEN_BUFFER_INFO
[StructLayout(LayoutKind.Sequential)]
internal struct CONSOLE_SCREEN_BUFFER_INFO
{
    public COORD dwSize;
    public COORD dwCursorPosition;
    public short wAttributes;
    public SMALL_RECT srWindow;
    public COORD dwMaximumWindowSize;
}
#endregion

#region COORD
#pragma warning disable 0649
internal struct COORD
{
    public short X;
    public short Y;
};
#pragma warning disable 0649
#endregion

#region CURSORINFO
/// <summary>
/// Used in GetCursorInfo call to query if the cursor is shown or hidden
/// </summary>
[StructLayout(LayoutKind.Sequential)]
struct CURSORINFO
{
    public int cbSize;        // Specifies the size, in bytes, of the structure.
                                // The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
    public int flags;         // Specifies the cursor state. This parameter can be one of the following values:
                                //    0             The cursor is hidden.
                                //    CURSOR_SHOWING    The cursor is showing.
    public IntPtr hCursor;          // Handle to the cursor.
    public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor.
}
#endregion

#region DesiredAccess
[Flags]
internal enum DesiredAccess : uint
{
    GenericRead = 0x80000000,
    GenericWrite = 0x40000000,
    GenericExecute = 0x20000000,
    GenericAll = 0x10000000
}
#endregion

#region DevBroadcastHDR
#pragma warning disable 0649, 0169
internal struct DevBroadcastHDR
{
    internal int Size;
    internal DeviceBroadcastType DeviceType;
    int dbcc_reserved;
    internal Guid ClassGuid;
    internal char dbcc_name;
}
#pragma warning restore 0649, 0169
#endregion

#region DeviceBroadcastType
internal enum DeviceBroadcastType
{
    OEM = 0,
    VOLUME = 2,
    PORT = 3,
    INTERFACE = 5,
    HANDLE = 6,
}
#endregion

#region DeviceCaps
internal enum DeviceCaps : int
{
    /// <summary>
    /// DRIVERVERSION: Device driver version
    /// </summary>
    DriverVersion = 0,
    /// <summary>
    /// TECHNOLOGY: Device classification
    /// </summary>
    Technology = 2,
    /// <summary>
    /// HORZSIZE: Horizontal size in millimeters
    /// </summary>
    HorzSize = 4,
    /// <summary>
    /// VERTSIZE: Vertical size in millimeters
    /// </summary>
    VertSize = 6,
    /// <summary>
    /// HORZRES: Horizontal width in pixels
    /// </summary>
    HorzRes = 8,
    /// <summary>
    /// VERTRES: Vertical height in pixels
    /// </summary>
    VertRes = 10,
    /// <summary>
    /// BITSPIXEL: Number of bits per pixel
    /// </summary>
    BitsPixel = 12,
    /// <summary>
    /// PLANES: Number of planes
    /// </summary>
    Planes = 14,
    /// <summary>
    /// NUMBRUSHES: Number of brushes the device has
    /// </summary>
    NumBrushes = 16,
    /// <summary>
    /// NUMPENS: Number of pens the device has
    /// </summary>
    NumPens = 18,
    /// <summary>
    /// NUMMARKERS: Number of markers the device has
    /// </summary>
    NumMarkers = 20,
    /// <summary>
    /// NUMFONTS: Number of fonts the device has
    /// </summary>
    NumFonts = 22,
    /// <summary>
    /// NUMCOLORS: Number of colors the device supports
    /// </summary>
    NumColours = 24,
    /// <summary>
    /// PDEVICESIZE: Size required for device descriptor
    /// </summary>
    PDeviceSize = 26,
    /// <summary>
    /// CURVECAPS: Curve capabilities
    /// </summary>
    CurveCaps = 28,
    /// <summary>
    /// LINECAPS: Line capabilities
    /// </summary>
    LineCaps = 30,
    /// <summary>
    /// POLYGONALCAPS: Polygonal capabilities
    /// </summary>
    Polygonalcaps = 32,
    /// <summary>
    /// TEXTCAPS: Text capabilities
    /// </summary>
    TextCaps = 34,
    /// <summary>
    /// CLIPCAPS: Clipping capabilities
    /// </summary>
    ClipCaps = 36,
    /// <summary>
    /// RASTERCAPS: Bitblt capabilities
    /// </summary>
    RasterCaps = 38,
    /// <summary>
    /// ASPECTX: Length of the X leg
    /// </summary>
    AspectX = 40,
    /// <summary>
    /// ASPECTY: Length of the Y leg
    /// </summary>
    AspectY = 42,
    /// <summary>
    /// ASPECTXY: Length of the hypotenuse
    /// </summary>
    AspectXY = 44,
    /// <summary>
    /// SHADEBLENDCAPS: Shading and Blending caps
    /// </summary>
    ShadeBlendCaps = 45,

    /// <summary>
    /// LOGPIXELSX: Logical pixels inch in X
    /// </summary>
    LogPixelsX = 88,
    /// <summary>
    /// LOGPIXELSY: Logical pixels inch in Y
    /// </summary>
    LogPixelsY = 90,

    /// <summary>
    /// SIZEPALETTE: Number of entries in physical palette
    /// </summary>
    SizePalette = 104,
    /// <summary>
    /// NUMRESERVED: Number of reserved entries in palette
    /// </summary>
    NumReserved = 106,
    /// <summary>
    /// COLORRES: Actual color resolution
    /// </summary>
    ColourRes = 108,

    /// <summary>
    /// PHYSICALWIDTH: Physical Width in device units
    /// </summary>
    PhysicalWidth = 110,
    /// <summary>
    /// PHYSICALHEIGHT: Physical Height in device units
    /// </summary>
    PhysicalHeight = 111,
    /// <summary>
    /// PHYSICALOFFSETX: Physical Printable Area x margin
    /// </summary>
    PhysicalOffsetX = 112,
    /// <summary>
    /// PHYSICALOFFSETY: Physical Printable Area y margin
    /// </summary>
    PhysicalOffsetY = 113,
    /// <summary>
    /// SCALINGFACTORX: Scaling factor x
    /// </summary>
    ScalingFactorX = 114,
    /// <summary>
    /// SCALINGFACTORY: Scaling factor y
    /// </summary>
    ScalingFactorY = 115,

    /// <summary>
    /// VREFRESH: Current vertical refresh rate of the display device (for displays only) in Hz
    /// </summary>
    VRefresh = 116,
    /// <summary>
    /// DESKTOPVERTRES: Vertical height of entire desktop in pixels
    /// </summary>
    DesktopVertRes = 117,
    /// <summary>
    /// DESKTOPHORZRES: Horizontal width of entire desktop in pixels
    /// </summary>
    DesktopHorzRes = 118,
    /// <summary>
    /// BLTALIGNMENT: Preferred blt alignment
    /// </summary>
    BLTAlignment = 119
}
#endregion

#region DeviceMode
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal class DeviceMode
{
    internal DeviceMode()
    {
        Size = (short)Marshal.SizeOf(this);
    }

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    internal string DeviceName;
    internal short SpecVersion;
    internal short DriverVersion;
    private short Size;
    internal short DriverExtra;
    internal DeviceModeEnum Fields;

    //internal short Orientation;
    //internal short PaperSize;
    //internal short PaperLength;
    //internal short PaperWidth;
    //internal short Scale;
    //internal short Copies;
    //internal short DefaultSource;
    //internal short PrintQuality;

    internal POINT Position;
    internal int DisplayOrientation;
    internal int DisplayFixedOutput;

    internal short Color;
    internal short Duplex;
    internal short YResolution;
    internal short TTOption;
    internal short Collate;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    internal string FormName;
    internal short LogPixels;
    internal int BitsPerPel;
    internal int PelsWidth;
    internal int PelsHeight;
    internal int DisplayFlags;
    internal int DisplayFrequency;
    internal int ICMMethod;
    internal int ICMIntent;
    internal int MediaType;
    internal int DitherType;
    internal int Reserved1;
    internal int Reserved2;
    internal int PanningWidth;
    internal int PanningHeight;
}

#endregion DeviceMode class

#region DeviceModeFields
[Flags]
internal enum DeviceModeEnum : int
{
    DM_LOGPIXELS = 0x00020000,
    DM_BITSPERPEL = 0x00040000,
    DM_PELSWIDTH = 0x00080000,
    DM_PELSHEIGHT = 0x00100000,
    DM_DISPLAYFLAGS = 0x00200000,
    DM_DISPLAYFREQUENCY = 0x00400000,
}
#endregion

#region DeviceNotifications
internal enum DeviceNotification
{
    WINDOW_HANDLE = 0x00000000,
    SERVICE_HANDLE = 0x00000001,
    ALL_INTERFACE_CLASSES = 0x00000004,
}
#endregion

#region DISPLAY_DEVICE
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal class DISPLAY_DEVICE
{
    internal DISPLAY_DEVICE()
    {
        size = (short)Marshal.SizeOf(this);
    }
    readonly int size;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    internal string DeviceName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    internal string DeviceString;
    internal DisplayDeviceStateFlags StateFlags;    // Int32
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    internal string DeviceID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    internal string DeviceKey;
}
#endregion

#region DisplayDeviceSettingsChangedResult
public enum DisplayDeviceSettingsChangedResult : int
{
    DISP_CHANGE_SUCCESSFUL = 0,
    DISP_CHANGE_RESTART = 1,
    DISP_CHANGE_FAILED = -1,
}
#endregion

#region DisplayDeviceStateFlags
[Flags]
internal enum DisplayDeviceStateFlags
{
    None = 0x00000000,
    AttachedToDesktop = 0x00000001,
    MultiDriver = 0x00000002,
    PrimaryDevice = 0x00000004,
    MirroringDriver = 0x00000008,
    VgaCompatible = 0x00000010,
    Removable = 0x00000020,
    ModesPruned = 0x08000000,
    Remote = 0x04000000,
    Disconnect = 0x02000000,

    // Child device state
    Active = 0x00000001,
    Attached = 0x00000002,
}
#endregion

#region DisplayModeSettingsEnum
internal enum DisplayModeSettingsEnum
{
    CurrentSettings = -1,
    RegistrySettings = -2
}
#endregion

#region GetMouseMovePointResolution
internal enum GetMouseMovePointResolution : uint
{
    GMMP_USE_DISPLAY_POINTS = 1,
    GMMP_USE_HIGH_RESOLUTION_POINTS = 2,
}
#endregion

#region GetRawInputDataEnum
internal enum GetRawInputDataEnum
{
    INPUT = 0x10000003,
    HEADER = 0x10000005
}
#endregion

#region HandleType
internal enum HandleType
{
    STD_INPUT_HANDLE = -10,
    STD_OUTPUT_HANDLE = -11,
    STD_ERROR_HANDLE = -12
}
#endregion

#region IconInfo
[StructLayout(LayoutKind.Sequential)]
internal struct IconInfo
{
    public bool IsIcon;
    public int xHotspot;
    public int yHotspot;
    public IntPtr MaskBitmap;
    public IntPtr ColorBitmap;
};
#endregion

#region JoyCaps
internal struct JoyCaps
{
    public ushort Mid;
    public ushort ProductId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string ProductName;
    public int XMin;
    public int XMax;
    public int YMin;
    public int YMax;
    public int ZMin;
    public int ZMax;
    public int NumButtons;
    public int PeriodMin;
    public int PeriodMax;
    public int RMin;
    public int RMax;
    public int UMin;
    public int UMax;
    public int VMin;
    public int VMax;
    public JoystCapsFlags Capabilities;
    public int MaxAxes;
    public int NumAxes;
    public int MaxButtons;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string RegKey;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string OemVxD;

    public static readonly int SizeInBytes;

    static JoyCaps()
    {
        SizeInBytes = Marshal.SizeOf(default(JoyCaps));
    }

    public int GetMin(int i)
    {
        switch (i)
        {
            case 0: return XMin;
            case 1: return YMin;
            case 2: return ZMin;
            case 3: return RMin;
            case 4: return UMin;
            case 5: return VMin;
            default: return 0;
        }
    }

    public int GetMax(int i)
    {
        switch (i)
        {
            case 0: return XMax;
            case 1: return YMax;
            case 2: return ZMax;
            case 3: return RMax;
            case 4: return UMax;
            case 5: return VMax;
            default: return 0;
        }
    }
}
#endregion

#region JoystCapsFlags
[Flags]
internal enum JoystCapsFlags
{
    HasZ = 0x1,
    HasR = 0x2,
    HasU = 0x4,
    HasV = 0x8,
    HasPov = 0x16,
    HasPov4Dir = 0x32,
    HasPovContinuous = 0x64
}
#endregion

#region JoyInfo
internal struct JoyInfo
{
    public int XPos;
    public int YPos;
    public int ZPos;
    public uint Buttons;

    public int GetAxis(int i)
    {
        switch (i)
        {
            case 0: return XPos;
            case 1: return YPos;
            case 2: return ZPos;
            default: return 0;
        }
    }
}
#endregion

#region JoyInfoEx
internal struct JoyInfoEx
{
    public int Size;
    [MarshalAs(UnmanagedType.I4)]
    public JoystickFlags Flags;
    public int XPos;
    public int YPos;
    public int ZPos;
    public int RPos;
    public int UPos;
    public int VPos;
    public uint Buttons;
    public uint ButtonNumber;
    public int Pov;
#pragma warning disable 0169
    uint Reserved1;
    uint Reserved2;
#pragma warning restore 0169

    public static readonly int SizeInBytes;

    static JoyInfoEx()
    {
        SizeInBytes = Marshal.SizeOf(default(JoyInfoEx));
    }

    public int GetAxis(int i)
    {
        switch (i)
        {
            case 0: return XPos;
            case 1: return YPos;
            case 2: return ZPos;
            case 3: return RPos;
            case 4: return UPos;
            case 5: return VPos;
            default: return 0;
        }
    }
}
#endregion

#region JoystickError
internal enum JoystickError : uint
{
    NoError = 0,
    InvalidParameters = 165,
    NoCanDo = 166,
    Unplugged = 167
    //MM_NoDriver = 6,
    //MM_InvalidParameter = 11
}
#endregion

#region JoystickFlags
[Flags]
enum JoystickFlags
{
    X = 0x1,
    Y = 0x2,
    Z = 0x4,
    R = 0x8,
    U = 0x10,
    V = 0x20,
    Pov = 0x40,
    Buttons = 0x80,
    All = X | Y | Z | R | U | V | Pov | Buttons
}
#endregion

#region MapVirtualKeyType
/// <summary>
/// For MapVirtualKey
/// </summary>
internal enum MapVirtualKeyType
{
    /// <summary>uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.</summary>
    VirtualKeyToScanCode = 0,
    /// <summary>uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0.</summary>
    ScanCodeToVirtualKey = 1,
    /// <summary>uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.</summary>
    VirtualKeyToCharacter = 2,
    /// <summary>Windows NT/2000/XP: uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0.</summary>
    ScanCodeToVirtualKeyExtended = 3,
    VirtualKeyToScanCodeExtended = 4,
}

#endregion

#region MonitorFrom
internal enum MonitorFrom
{
    /// <summary>
    /// MONITOR_DEFAULTTONULL: Returns NULL.
    /// </summary>
    Null = 0,
    /// <summary>
    /// MONITOR_DEFAULTTOPRIMARY: Returns a handle to the primary display monitor.
    /// </summary>
    Primary = 1,
    /// <summary>
    /// MONITOR_DEFAULTTONEAREST: Returns a handle to the display monitor that is nearest to the window.
    /// </summary>
    Nearest = 2,
}
#endregion

#region MonitorInfo
#pragma warning disable 0649
internal struct MonitorInfo
{
    internal int Size;
    internal RECT Monitor;
    internal RECT Work;
    internal int Flags;

    internal static readonly int UnmanagedSize = Marshal.SizeOf(default(MonitorInfo));
}
#pragma warning restore 0649
#endregion

#region MouseMovePoint
[StructLayout(LayoutKind.Sequential)]
public struct MouseMovePoint
{
    /// <summary>
    /// The x-coordinate of the mouse.
    /// </summary>
    public int X;
    /// <summary>
    /// The y-coordinate of the mouse.
    /// </summary>
    public int Y;
    /// <summary>
    /// The time stamp of the mouse coordinate.
    /// </summary>
    public int Time;
    /// <summary>
    /// Additional information associated with this coordinate.
    /// </summary>
    public IntPtr ExtraInfo;

    /// <summary>
    /// Returns the size of a MouseMovePoint in bytes.
    /// </summary>
    public static readonly int SizeInBytes = Marshal.SizeOf(default(MouseMovePoint));
}
#endregion

#region NIndex
/// <summary>
/// Used with SetWindowLong call
/// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633588(v=vs.85).aspx
/// </summary>
internal enum NIndex : int
{
    CBCLSExtra = -20,
    CBWNDExtra = -18,
    HBrBackground = -10,
    HCursor = -12,
    HIcon = -14,
    HIconSm = -34,
    HModule = -16,
    MenuName = -8,
    Style = -26,
    WndProc = -24 
}
#endregion

//todo: merge these two
#region PixelFormatDescriptor
[StructLayout(LayoutKind.Sequential)]
internal struct PixelFormatDescriptor
{
    internal short Size;
    internal short Version;
    internal FLAGS Flags;
    internal TYPE PixelType;
    internal byte ColorBits;
    internal byte RedBits;
    internal byte RedShift;
    internal byte GreenBits;
    internal byte GreenShift;
    internal byte BlueBits;
    internal byte BlueShift;
    internal byte AlphaBits;
    internal byte AlphaShift;
    internal byte AccumBits;
    internal byte AccumRedBits;
    internal byte AccumGreenBits;
    internal byte AccumBlueBits;
    internal byte AccumAlphaBits;
    internal byte DepthBits;
    internal byte StencilBits;
    internal byte AuxBuffers;
    internal byte LayerType;
    private byte Reserved;
    internal int LayerMask;
    internal int VisibleMask;
    internal int DamageMask;

    internal static int SizeInBytes = Marshal.SizeOf(typeof(PixelFormatDescriptor));

    [Flags]
    internal enum FLAGS : int
    {
        // PixelFormatDescriptor flags
        DOUBLEBUFFER = 0x01,
        STEREO = 0x02,
        DRAW_TO_WINDOW = 0x04,
        DRAW_TO_BITMAP = 0x08,
        SUPPORT_GDI = 0x10,
        SUPPORT_OPENGL = 0x20,
        GENERIC_FORMAT = 0x40,
        NEED_PALETTE = 0x80,
        NEED_SYSTEM_PALETTE = 0x100,
        SWAP_EXCHANGE = 0x200,
        SWAP_COPY = 0x400,
        SWAP_LAYER_BUFFERS = 0x800,
        GENERIC_ACCELERATED = 0x1000,
        SUPPORT_DIRECTDRAW = 0x2000,
        SUPPORT_COMPOSITION = 0x8000,

        // PixelFormatDescriptor flags for use in ChoosePixelFormat only
        DEPTH_DONTCARE = unchecked(0x20000000),
        DOUBLEBUFFER_DONTCARE = unchecked(0x40000000),
        STEREO_DONTCARE = unchecked((int)0x80000000)
    }

    internal enum TYPE : byte
    {
        RGBA = 0,
        INDEXED = 1
    }
}
#endregion

#region PIXELFORMATDESCRIPTOR
/// <summary>
/// The PIXELFORMATDESCRIPTOR structure describes the pixel format of a drawing surface
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal class PIXELFORMATDESCRIPTOR
{
    internal enum LAYER_TYPE : byte { MAIN_PLANE = 0, OVERLAY_PLANE = 1, UDERLAY_PLANE = 255 };
    internal enum PIXEL_TYPE : byte { RGBA = 0, COLORINDEX = 1 };
    internal enum FLAGS : uint
    {
        DOUBLEBUFFER = 0x00000001, STEREO = 0x00000002, DRAW_TO_WINDOW = 0x00000004, DRAW_TO_BITMAP = 0x00000008,
        SUPPORT_GDI = 0x00000010, SUPPORT_OPENGL = 0x00000020, GENERIC_FORMAT = 0x00000040,
        NEED_PALETTE = 0x00000080, NEED_SYSTEM_PALETTE = 0x00000100,
        SWAP_EXCHANGE = 0x00000200, SWAP_COPY = 0x00000400, SWAP_LAYER_BUFFERS = 0x00000800,
        GENERIC_ACCELERATED = 0x00001000, SUPPORT_DIRECTDRAW = 0x00002000,
        SUPPORT_COMPOSITION = 0x00008000,
        DEPTH_DONTCARE = 0x20000000, DOUBLEBUFFER_DONTCARE = 0x40000000, STEREO_DONTCARE = 0x80000000
    };

    internal PIXELFORMATDESCRIPTOR()
    {
    }
    internal PIXELFORMATDESCRIPTOR(FLAGS flags, PIXEL_TYPE pixelType, byte colourBits, byte alphaBits, byte depthBits, byte stencilBits, LAYER_TYPE layerType)
    {
        Flags = flags;
        PixelType = pixelType;
        ColorBits = colourBits;
        AlphaBits = alphaBits;
        DepthBits = depthBits;
        StencilBits = stencilBits;
        LayerType = layerType;
    }

    internal short Size = SizeInBytes;
    internal short Version = 1;
    internal FLAGS Flags = FLAGS.DOUBLEBUFFER | FLAGS.DRAW_TO_WINDOW | FLAGS.SUPPORT_OPENGL;
    internal PIXEL_TYPE PixelType;
    internal byte ColorBits;
    internal byte RedBits;
    internal byte RedShift;
    internal byte GreenBits;
    internal byte GreenShift;
    internal byte BlueBits;
    internal byte BlueShift;
    internal byte AlphaBits;
    internal byte AlphaShift;
    internal byte AccumBits;
    internal byte AccumRedBits;
    internal byte AccumGreenBits;
    internal byte AccumBlueBits;
    internal byte AccumAlphaBits;
    internal byte DepthBits;
    internal byte StencilBits;
    internal byte AuxBuffers;
    internal LAYER_TYPE LayerType;
    internal byte Reserved;
    internal int dwLayerMask;
    internal int dwVisibleMask;
    internal int dwDamageMask;

    internal static short SizeInBytes = (short)Marshal.SizeOf(default(PIXELFORMATDESCRIPTOR));
}
#endregion

#region PM
[Flags]
internal enum PM : int
{
    NOREMOVE = 0x0000,
    REMOVE = 0x0001,
    NOYIELD = 0x0002
}
#endregion

#region RawHID
[StructLayout(LayoutKind.Explicit)]
internal struct RawHID
{
}
#endregion

#region RawInput
#pragma warning disable 0649
internal struct RawInput
{
    internal RawInputHeader Header;
    internal RawInputData Data;
}
#pragma warning restore 0649
#endregion

#region RawInputData
[StructLayout(LayoutKind.Explicit)]
internal struct RawInputData
{
    [FieldOffset(0)]
    internal RawMouse Mouse;
    [FieldOffset(0)]
    internal RawKeyboard Keyboard;
    [FieldOffset(0)]
    internal RawHID HID;
}
#endregion

#region RawInputDevice
/// <summary>
/// Defines information for the raw input devices.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RawInputDevice
{
    /// <summary>
    /// Top level collection Usage page for the raw input device.
    /// </summary>
    //internal UInt16 UsagePage;
    internal short UsagePage;
    /// <summary>
    /// Top level collection Usage for the raw input device.
    /// </summary>
    //internal UInt16 Usage;
    internal short Usage;
    /// <summary>
    /// Mode flag that specifies how to interpret the information provided by UsagePage and Usage.
    /// It can be zero (the default) or one of the following values.
    /// By default, the operating system sends raw input from devices with the specified top level collection (TLC)
    /// to the registered application as long as it has the window focus. 
    /// </summary>
    internal RawInputDeviceFlags Flags;
    /// <summary>
    /// Handle to the target window. If NULL it follows the keyboard focus.
    /// </summary>
    internal IntPtr Target;

    internal static readonly int Size = Marshal.SizeOf(typeof(RawInputDevice));
}
#endregion

#region RawInputDeviceFlags
[Flags]
internal enum RawInputDeviceFlags : int
{
    /// <summary>
    /// If set, this removes the top level collection from the inclusion list.
    /// This tells the operating system to stop reading from a device which matches the top level collection.
    /// </summary>
    REMOVE = 0x00000001,
    /// <summary>
    /// If set, this specifies the top level collections to exclude when reading a complete usage page.
    /// This flag only affects a TLC whose usage page is already specified with RawInputDeviceEnum.PAGEONLY. 
    /// </summary>
    EXCLUDE = 0x00000010,
    /// <summary>
    /// If set, this specifies all devices whose top level collection is from the specified UsagePage.
    /// Note that usUsage must be zero. To exclude a particular top level collection, use EXCLUDE.
    /// </summary>
    PAGEONLY = 0x00000020,
    /// <summary>
    /// If set, this prevents any devices specified by UsagePage or Usage from generating legacy messages.
    /// This is only for the mouse and keyboard. See RawInputDevice Remarks.
    /// </summary>
    NOLEGACY = 0x00000030,
    /// <summary>
    /// If set, this enables the caller to receive the input even when the caller is not in the foreground.
    /// Note that Target must be specified in RawInputDevice.
    /// </summary>
    INPUTSINK = 0x00000100,
    /// <summary>
    /// If set, the mouse button click does not activate the other window.
    /// </summary>
    CAPTUREMOUSE = 0x00000200, // effective when mouse nolegacy is specified, otherwise it would be an error
    /// <summary>
    /// If set, the application-defined keyboard device hotkeys are not handled.
    /// However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled.
    /// By default, all keyboard hotkeys are handled.
    /// NOHOTKEYS can be specified even if NOLEGACY is not specified and Target is NULL in RawInputDevice.
    /// </summary>
    NOHOTKEYS = 0x00000200, // effective for keyboard.
    /// <summary>
    /// Microsoft Windows XP Service Pack 1 (SP1): If set, the application command keys are handled. APPKEYS can be specified only if NOLEGACY is specified for a keyboard device.
    /// </summary>
    APPKEYS = 0x00000400, // effective for keyboard.
    /// <summary>
    /// If set, this enables the caller to receive input in the background only if the foreground application
    /// does not process it. In other words, if the foreground application is not registered for raw input,
    /// then the background application that is registered will receive the input.
    /// </summary>
    EXINPUTSINK = 0x00001000,
    DEVNOTIFY = 0x00002000,
    //EXMODEMASK      = 0x000000F0
}
#endregion

#region RawInputDeviceInfo
/// <summary>
/// Defines the raw input data coming from any device.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal class RawInputDeviceInfo
{
    /// <summary>
    /// Size, in bytes, of the RawInputDeviceInfo structure.
    /// </summary>
    internal int Size = Marshal.SizeOf(typeof(RawInputDeviceInfo));
    /// <summary>
    /// Type of raw input data.
    /// </summary>
    internal RawInputDeviceType Type;
    internal DeviceStruct Device;
    [StructLayout(LayoutKind.Explicit)]
    internal struct DeviceStruct
    {
        [FieldOffset(0)]
        internal RawInputMouseDeviceInfo Mouse;
        [FieldOffset(0)]
        internal RawInputKeyboardDeviceInfo Keyboard;
        [FieldOffset(0)]
        internal RawInputHIDDeviceInfo HID;
    };
}
#endregion

#region RawInputDeviceInfoEnum
internal enum RawInputDeviceInfoEnum
{
    PREPARSEDDATA = 0x20000005,
    DEVICENAME = 0x20000007,  // the return valus is the character length, not the byte size
    DEVICEINFO = 0x2000000b
}
#endregion

#region RawInputDeviceList
/// <summary>
/// Contains information about a raw input device.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RawInputDeviceList
{
    /// <summary>
    /// Handle to the raw input device.
    /// </summary>
    internal IntPtr Device;
    /// <summary>
    /// Type of device.
    /// </summary>
    internal RawInputDeviceType Type;

    internal static readonly int Size = Marshal.SizeOf(typeof(RawInputDeviceList));
}
#endregion

#region RawInputDeviceType
internal enum RawInputDeviceType : int
{
    MOUSE = 0,
    KEYBOARD = 1,
    HID = 2
}
#endregion

#region RawInputHeader
[StructLayout(LayoutKind.Sequential)]
internal struct RawInputHeader
{
    /// <summary>
    /// Type of raw input.
    /// </summary>
    internal RawInputDeviceType Type;
    /// <summary>
    /// Size, in bytes, of the entire input packet of data. This includes the RawInput struct plus possible extra input reports in the RAWHID variable length array.
    /// </summary>
    internal int Size;
    /// <summary>
    /// Handle to the device generating the raw input data.
    /// </summary>
    internal IntPtr Device;
    /// <summary>
    /// Value passed in the wParam parameter of the WM_INPUT message.
    /// </summary>
    internal IntPtr Param;

    internal static int SIZE = Marshal.SizeOf(typeof(RawInputHeader));
}
#endregion

#region RawInputHIDDeviceInfo
/// <summary>
/// Defines the raw input data coming from the specified Human Interface Device (HID).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RawInputHIDDeviceInfo
{
    /// <summary>
    /// Vendor ID for the HID.
    /// </summary>
    internal int VendorId;
    /// <summary>
    /// Product ID for the HID.
    /// </summary>
    internal int ProductId;
    /// <summary>
    /// Version number for the HID.
    /// </summary>
    internal int VersionNumber;
    /// <summary>
    /// Top-level collection Usage Page for the device.
    /// </summary>
    //internal UInt16 UsagePage;
    internal short UsagePage;
    /// <summary>
    /// Top-level collection Usage for the device.
    /// </summary>
    //internal UInt16 Usage;
    internal short Usage;
}
#endregion

#region RawInputKeyboardDataFlags
internal enum RawInputKeyboardDataFlags : short
{
    MAKE = 0,
    BREAK = 1,
    E0 = 2,
    E1 = 4,
    TERMSRV_SET_LED = 8,
    TERMSRV_SHADOW = 0x10
}

#endregion

#region RawInputKeyboardDeviceInfo
/// <summary>
/// Defines the raw input data coming from the specified keyboard.
/// </summary>
/// <remarks>
/// For the keyboard, the Usage Page is 1 and the Usage is 6.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct RawInputKeyboardDeviceInfo
{
    /// <summary>
    /// Type of the keyboard.
    /// </summary>
    internal int Type;
    /// <summary>
    /// Subtype of the keyboard.
    /// </summary>
    internal int SubType;
    /// <summary>
    /// Scan code mode.
    /// </summary>
    internal int KeyboardMode;
    /// <summary>
    /// Number of function keys on the keyboard.
    /// </summary>
    internal int NumberOfFunctionKeys;
    /// <summary>
    /// Number of LED indicators on the keyboard.
    /// </summary>
    internal int NumberOfIndicators;
    /// <summary>
    /// Total number of keys on the keyboard.
    /// </summary>
    internal int NumberOfKeysTotal;
}

#endregion

#region RawInputMouseDeviceInfo
/// <summary>
/// Defines the raw input data coming from the specified mouse.
/// </summary>
/// <remarks>
/// For the keyboard, the Usage Page is 1 and the Usage is 2.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct RawInputMouseDeviceInfo
{
    /// <summary>
    /// ID for the mouse device.
    /// </summary>
    internal int Id;
    /// <summary>
    /// Number of buttons for the mouse.
    /// </summary>
    internal int NumberOfButtons;
    /// <summary>
    /// Number of data points per second. This information may not be applicable for every mouse device.
    /// </summary>
    internal int SampleRate;
    /// <summary>
    /// TRUE if the mouse has a wheel for horizontal scrolling; otherwise, FALSE.
    /// </summary>
    /// <remarks>
    /// This member is only supported under Microsoft Windows Vista and later versions.
    /// </remarks>
    internal bool HasHorizontalWheel;
}

#endregion

#region RawInputMouseState
[Flags]
internal enum RawInputMouseState : ushort
{
    LEFT_BUTTON_DOWN = 0x0001,  // Left Button changed to down.
    LEFT_BUTTON_UP = 0x0002,  // Left Button changed to up.
    RIGHT_BUTTON_DOWN = 0x0004,  // Right Button changed to down.
    RIGHT_BUTTON_UP = 0x0008,  // Right Button changed to up.
    MIDDLE_BUTTON_DOWN = 0x0010,  // Middle Button changed to down.
    MIDDLE_BUTTON_UP = 0x0020,  // Middle Button changed to up.

    BUTTON_1_DOWN = LEFT_BUTTON_DOWN,
    BUTTON_1_UP = LEFT_BUTTON_UP,
    BUTTON_2_DOWN = RIGHT_BUTTON_DOWN,
    BUTTON_2_UP = RIGHT_BUTTON_UP,
    BUTTON_3_DOWN = MIDDLE_BUTTON_DOWN,
    BUTTON_3_UP = MIDDLE_BUTTON_UP,

    BUTTON_4_DOWN = 0x0040,
    BUTTON_4_UP = 0x0080,
    BUTTON_5_DOWN = 0x0100,
    BUTTON_5_UP = 0x0200,

    WHEEL = 0x0400,
    HWHEEL = 0x0800,
}

#endregion

#region RawKeyboard
[StructLayout(LayoutKind.Sequential)]
internal struct RawKeyboard
{
    /// <summary>
    /// Scan code from the key depression. The scan code for keyboard overrun is KEYBOARD_OVERRUN_MAKE_CODE.
    /// </summary>
    //internal UInt16 MakeCode;
    internal short MakeCode;
    /// <summary>
    /// Flags for scan code information. It can be one or more of the following.
    /// RI_KEY_MAKE
    /// RI_KEY_BREAK
    /// RI_KEY_E0
    /// RI_KEY_E1
    /// RI_KEY_TERMSRV_SET_LED
    /// RI_KEY_TERMSRV_SHADOW
    /// </summary>
    internal RawInputKeyboardDataFlags Flags;
    /// <summary>
    /// Reserved; must be zero.
    /// </summary>
    ushort Reserved;
    /// <summary>
    /// Microsoft Windows message compatible virtual-key code. For more information, see Virtual-Key Codes.
    /// </summary>
    //internal UInt16 VKey;
    internal VirtualKeys VKey;
    /// <summary>
    /// Corresponding window message, for example WM_KEYDOWN, WM_SYSKEYDOWN, and so forth.
    /// </summary>
    //internal UInt32 Message;
    internal int Message;
    /// <summary>
    /// Device-specific additional information for the event.
    /// </summary>
    //internal ULONG ExtraInformation;
    internal int ExtraInformation;
}
#endregion

#region RawMouse
[StructLayout(LayoutKind.Explicit)]
internal struct RawMouse
{
    /// <summary>
    /// Mouse state. This member can be any reasonable combination of the following. 
    /// MOUSE_ATTRIBUTES_CHANGED
    /// Mouse attributes changed; application needs to query the mouse attributes.
    /// MOUSE_MOVE_RELATIVE
    /// Mouse movement data is relative to the last mouse position.
    /// MOUSE_MOVE_ABSOLUTE
    /// Mouse movement data is based on absolute position.
    /// MOUSE_VIRTUAL_DESKTOP
    /// Mouse coordinates are mapped to the virtual desktop (for a multiple monitor system).
    /// </summary>
    [FieldOffset(0)]
    internal RawMouseFlags Flags;  // UInt16 in winuser.h, but only Int32 works -- UInt16 returns 0.

    [FieldOffset(4)]
    internal RawInputMouseState ButtonFlags;

    /// <summary>
    /// If usButtonFlags is RI_MOUSE_WHEEL, this member is a signed value that specifies the wheel delta.
    /// </summary>
    [FieldOffset(6)]
    internal ushort ButtonData;

    /// <summary>
    /// Raw state of the mouse buttons.
    /// </summary>
    [FieldOffset(8)]
    internal uint RawButtons;

    /// <summary>
    /// Motion in the X direction. This is signed relative motion or absolute motion, depending on the value of usFlags.
    /// </summary>
    [FieldOffset(12)]
    internal int LastX;

    /// <summary>
    /// Motion in the Y direction. This is signed relative motion or absolute motion, depending on the value of usFlags.
    /// </summary>
    [FieldOffset(16)]
    internal int LastY;

    /// <summary>
    /// Device-specific additional information for the event.
    /// </summary>
    [FieldOffset(20)]
    internal uint ExtraInformation;
}
#endregion

#region RawMouseFlags

/// <summary>
/// Mouse indicator flags (found in winuser.h).
/// </summary>
[Flags]
internal enum RawMouseFlags : ushort
{
    /// <summary>
    /// LastX/Y indicate relative motion.
    /// </summary>
    MOUSE_MOVE_RELATIVE = 0x00,
    /// <summary>
    /// LastX/Y indicate absolute motion.
    /// </summary>
    MOUSE_MOVE_ABSOLUTE = 0x01,
    /// <summary>
    /// The coordinates are mapped to the virtual desktop.
    /// </summary>
    MOUSE_VIRTUAL_DESKTOP = 0x02,
    /// <summary>
    /// Requery for mouse attributes.
    /// </summary>
    MOUSE_ATTRIBUTES_CHANGED = 0x04,
}

#endregion

#region SetWindowPosFlags
[Flags]
internal enum SetWindowPosFlags : int
{
    /// <summary>
    /// Retains the current size (ignores the cx and cy parameters).
    /// </summary>
    NOSIZE = 0x0001,
    /// <summary>
    /// Retains the current position (ignores the x and y parameters).
    /// </summary>
    NOMOVE = 0x0002,
    /// <summary>
    /// Retains the current Z order (ignores the hwndInsertAfter parameter).
    /// </summary>
    NOZORDER = 0x0004,
    /// <summary>
    /// Does not redraw changes. If this flag is set, no repainting of any kind occurs.
    /// This applies to the client area, the nonclient area (including the title bar and scroll bars),
    /// and any part of the parent window uncovered as a result of the window being moved.
    /// When this flag is set, the application must explicitly invalidate or redraw any parts
    /// of the window and parent window that need redrawing.
    /// </summary>
    NOREDRAW = 0x0008,
    /// <summary>
    /// Does not activate the window. If this flag is not set,
    /// the window is activated and moved to the top of either the topmost or non-topmost group
    /// (depending on the setting of the hwndInsertAfter member).
    /// </summary>
    NOACTIVATE = 0x0010,
    /// <summary>
    /// Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed.
    /// If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
    /// </summary>
    FRAMECHANGED = 0x0020, /* The frame changed: send WM_NCCALCSIZE */
    /// <summary>
    /// Displays the window.
    /// </summary>
    SHOWWINDOW = 0x0040,
    /// <summary>
    /// Hides the window.
    /// </summary>
    HIDEWINDOW = 0x0080,
    /// <summary>
    /// Discards the entire contents of the client area. If this flag is not specified,
    /// the valid contents of the client area are saved and copied back into the client area 
    /// after the window is sized or repositioned.
    /// </summary>
    NOCOPYBITS = 0x0100,
    /// <summary>
    /// Does not change the owner window's position in the Z order.
    /// </summary>
    NOOWNERZORDER = 0x0200, /* Don't do owner Z ordering */
    /// <summary>
    /// Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
    /// </summary>
    NOSENDCHANGING = 0x0400, /* Don't send WM_WINDOWPOSCHANGING */

    /// <summary>
    /// Draws a frame (defined in the window's class description) around the window.
    /// </summary>
    DRAWFRAME = FRAMECHANGED,
    /// <summary>
    /// Same as the NOOWNERZORDER flag.
    /// </summary>
    NOREPOSITION = NOOWNERZORDER,

    DEFERERASE = 0x2000,
    ASYNCWINDOWPOS = 0x4000
}

#endregion

#region ShowWindowCommand
internal enum ShowWindowCommand
{
    /// <summary>
    /// Hides the window and activates another window.
    /// </summary>
    HIDE = 0,
    /// <summary>
    /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
    /// </summary>
    SHOWNORMAL = 1,
    NORMAL = 1,
    /// <summary>
    /// Activates the window and displays it as a minimized window.
    /// </summary>
    SHOWMINIMIZED = 2,
    /// <summary>
    /// Activates the window and displays it as a maximized window.
    /// </summary>
    SHOWMAXIMIZED = 3,
    MAXIMIZE = 3,
    /// <summary>
    /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
    /// </summary>
    SHOWNOACTIVATE = 4,
    /// <summary>
    /// Activates the window and displays it in its current size and position.
    /// </summary>
    SHOW = 5,
    /// <summary>
    /// Minimizes the specified window and activates the next top-level window in the Z order.
    /// </summary>
    MINIMIZE = 6,
    /// <summary>
    /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
    /// </summary>
    SHOWMINNOACTIVE = 7,
    /// <summary>
    /// Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.
    /// </summary>
    SHOWNA = 8,
    /// <summary>
    /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
    /// </summary>
    RESTORE = 9,
    /// <summary>
    /// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
    /// </summary>
    SHOWDEFAULT = 10,
    /// <summary>
    /// Windows 2000/XP: Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
    /// </summary>
    FORCEMINIMIZE = 11,
    //MAX             = 11,

    // Old ShowWindow() Commands
    //HIDE_WINDOW        = 0,
    //SHOW_OPENWINDOW    = 1,
    //SHOW_ICONWINDOW    = 2,
    //SHOW_FULLSCREEN    = 3,
    //SHOW_OPENNOACTIVATE= 4,
}
#endregion

#region SizeMessage
internal enum SizeMessage
{
    MAXHIDE = 4,
    MAXIMIZED = 2,
    MAXSHOW = 3,
    MINIMIZED = 1,
    RESTORED = 0
}
#endregion

#region SMALL_RECT
[StructLayout(LayoutKind.Sequential)]
internal struct SMALL_RECT
{
    public short Left, Top, Right, Bottom;
    internal int Width => Right - Left;
    internal int Height => Bottom - Top;
}
#endregion

#region StyleStruct
internal struct StyleStruct
{
    public WindowStyle Old;
    public WindowStyle New;
}
#endregion

#region ExtendedStyleStruct
internal struct ExtendedStyleStruct
{
    public ExtendedWindowStyle Old;
    public ExtendedWindowStyle New;
}
#endregion

//todo: complete this
internal enum SystemErrorCode : uint
{
    /// <summary>
    /// The operation completed successfully.
    /// </summary>
    ERROR_SUCCESS = 0,
    /// <summary>
    /// The handle is invalid.
    /// </summary>
    ERROR_INVALID_HANDLE = 6,
    /// <summary>
    /// The point passed to GetMouseMovePoints is not in the buffer.
    /// </summary>
    ERROR_POINT_NOT_FOUND = 1171,
    /// <summary>
    /// The pixel format is invalid.
    /// </summary>
    ERROR_INVALID_PIXEL_FORMAT = 2000
}

#region TimerProc
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void TimerProc(IntPtr hwnd, WindowMessage uMsg, UIntPtr idEvent, int dwTime);
#endregion

#region TrackMouseEventFlags
[Flags]
internal enum TrackMouseEventFlags : uint
{
    HOVER = 0x00000001,
    LEAVE = 0x00000002,
    NONCLIENT = 0x00000010,
    QUERY = 0x40000000,
    CANCEL = 0x80000000,
}
#endregion

#region TrackMouseEventStructure
#pragma warning disable 0649
internal struct TrackMouseEventStructure
{
    internal int Size;
    internal TrackMouseEventFlags Flags;
    internal IntPtr TrackWindowHandle;
    internal int HoverTime;

    internal static readonly int SizeInBytes = Marshal.SizeOf(typeof(TrackMouseEventStructure));
}
#pragma warning restore 0649
#endregion

#region VirtualKeys
internal enum VirtualKeys : short
{
    /*
        * Virtual Key, Standard Set
        */
    LBUTTON = 0x01,
    RBUTTON = 0x02,
    CANCEL = 0x03,
    MBUTTON = 0x04,   /* NOT contiguous with L & RBUTTON */

    XBUTTON1 = 0x05,   /* NOT contiguous with L & RBUTTON */
    XBUTTON2 = 0x06,   /* NOT contiguous with L & RBUTTON */

    /*
        * 0x07 : unassigned
        */

    BACK = 0x08,
    TAB = 0x09,

    /*
        * 0x0A - 0x0B : reserved
        */

    CLEAR = 0x0C,
    RETURN = 0x0D,

    SHIFT = 0x10,
    CONTROL = 0x11,
    MENU = 0x12,
    PAUSE = 0x13,
    CAPITAL = 0x14,

    KANA = 0x15,
    HANGUL = 0x15,
    JUNJA = 0x17,
    FINAL = 0x18,
    HANJA = 0x19,
    KANJI = 0x19,

    ESCAPE = 0x1B,

    CONVERT = 0x1C,
    NONCONVERT = 0x1D,
    ACCEPT = 0x1E,
    MODECHANGE = 0x1F,

    SPACE = 0x20,
    PRIOR = 0x21,
    NEXT = 0x22,
    END = 0x23,
    HOME = 0x24,
    LEFT = 0x25,
    UP = 0x26,
    RIGHT = 0x27,
    DOWN = 0x28,
    SELECT = 0x29,
    PRINT = 0x2A,
    EXECUTE = 0x2B,
    SNAPSHOT = 0x2C,
    INSERT = 0x2D,
    DELETE = 0x2E,
    HELP = 0x2F,

    NUM0 = 0x30,
    NUM1 = 0x31,
    NUM2 = 0x32,
    NUM3 = 0x33,
    NUM4 = 0x34,
    NUM5 = 0x35,
    NUM6 = 0x36,
    NUM7 = 0x37,
    NUM8 = 0x38,
    NUM9 = 0x39,

    A = 0x41,
    B = 0x42,
    C = 0x43,
    D = 0x44,
    E = 0x45,
    F = 0x46,
    G = 0x47,
    H = 0x48,
    I = 0x49,
    J = 0x4A,
    K = 0x4B,
    L = 0x4C,
    M = 0x4D,
    N = 0x4E,
    O = 0x4F,
    P = 0x50,
    Q = 0x51,
    R = 0x52,
    S = 0x53,
    T = 0x54,
    U = 0x55,
    V = 0x56,
    W = 0x57,
    X = 0x58,
    Y = 0x59,
    Z = 0x5A,

    LWIN = 0x5B,
    RWIN = 0x5C,
    APPS = 0x5D,

    /*
        * 0x5E : reserved
        */

    SLEEP = 0x5F,

    NUMPAD0 = 0x60,
    NUMPAD1 = 0x61,
    NUMPAD2 = 0x62,
    NUMPAD3 = 0x63,
    NUMPAD4 = 0x64,
    NUMPAD5 = 0x65,
    NUMPAD6 = 0x66,
    NUMPAD7 = 0x67,
    NUMPAD8 = 0x68,
    NUMPAD9 = 0x69,
    MULTIPLY = 0x6A,
    ADD = 0x6B,
    SEPARATOR = 0x6C,
    SUBTRACT = 0x6D,
    DECIMAL = 0x6E,
    DIVIDE = 0x6F,
    F1 = 0x70,
    F2 = 0x71,
    F3 = 0x72,
    F4 = 0x73,
    F5 = 0x74,
    F6 = 0x75,
    F7 = 0x76,
    F8 = 0x77,
    F9 = 0x78,
    F10 = 0x79,
    F11 = 0x7A,
    F12 = 0x7B,
    F13 = 0x7C,
    F14 = 0x7D,
    F15 = 0x7E,
    F16 = 0x7F,
    F17 = 0x80,
    F18 = 0x81,
    F19 = 0x82,
    F20 = 0x83,
    F21 = 0x84,
    F22 = 0x85,
    F23 = 0x86,
    F24 = 0x87,

    /*
        * 0x88 - 0x8F : unassigned
        */

    NUMLOCK = 0x90,
    SCROLL = 0x91,

    /*
        * NEC PC-9800 kbd definitions
        */
    OEM_NEC_EQUAL = 0x92,  // '=' key on numpad

    /*
        * Fujitsu/OASYS kbd definitions
        */
    OEM_FJ_JISHO = 0x92,  // 'Dictionary' key
    OEM_FJ_MASSHOU = 0x93,  // 'Unregister word' key
    OEM_FJ_TOUROKU = 0x94,  // 'Register word' key
    OEM_FJ_LOYA = 0x95,  // 'Left OYAYUBI' key
    OEM_FJ_ROYA = 0x96,  // 'Right OYAYUBI' key

    /*
        * 0x97 - 0x9F : unassigned
        */

    /*
        * L* & R* - left and right Alt, Ctrl and Shift virtual keys.
        * Used only as parameters to GetAsyncKeyState() and GetKeyState().
        * No other API or message will distinguish left and right keys in this way.
        */
    LSHIFT = 0xA0,
    RSHIFT = 0xA1,
    LCONTROL = 0xA2,
    RCONTROL = 0xA3,
    LMENU = 0xA4,
    RMENU = 0xA5,

    BROWSER_BACK = 0xA6,
    BROWSER_FORWARD = 0xA7,
    BROWSER_REFRESH = 0xA8,
    BROWSER_STOP = 0xA9,
    BROWSER_SEARCH = 0xAA,
    BROWSER_FAVORITES = 0xAB,
    BROWSER_HOME = 0xAC,

    VOLUME_MUTE = 0xAD,
    VOLUME_DOWN = 0xAE,
    VOLUME_UP = 0xAF,
    MEDIA_NEXT_TRACK = 0xB0,
    MEDIA_PREV_TRACK = 0xB1,
    MEDIA_STOP = 0xB2,
    MEDIA_PLAY_PAUSE = 0xB3,
    LAUNCH_MAIL = 0xB4,
    LAUNCH_MEDIA_SELECT = 0xB5,
    LAUNCH_APP1 = 0xB6,
    LAUNCH_APP2 = 0xB7,

    /*
        * 0xB8 - 0xB9 : reserved
        */

    OEM_1 = 0xBA,   // ';:' for US
    OEM_PLUS = 0xBB,   // '+' any country
    OEM_COMMA = 0xBC,   // ',' any country
    OEM_MINUS = 0xBD,   // '-' any country
    OEM_PERIOD = 0xBE,   // '.' any country
    OEM_2 = 0xBF,   // '/?' for US
    OEM_3 = 0xC0,   // '`~' for US

    /*
        * 0xC1 - 0xD7 : reserved
        */

    /*
        * 0xD8 - 0xDA : unassigned
        */

    OEM_4 = 0xDB,  //  '[{' for US
    OEM_5 = 0xDC,  //  '\|' for US
    OEM_6 = 0xDD,  //  ']}' for US
    OEM_7 = 0xDE,  //  ''"' for US
    OEM_8 = 0xDF,

    /*
        * 0xE0 : reserved
        */

    /*
        * Various extended or enhanced keyboards
        */
    OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
    OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
    ICO_HELP = 0xE3,  //  Help key on ICO
    ICO_00 = 0xE4,  //  00 key on ICO

    PROCESSKEY = 0xE5,

    ICO_CLEAR = 0xE6,


    PACKET = 0xE7,

    /*
        * 0xE8 : unassigned
        */

    /*
        * Nokia/Ericsson definitions
        */
    OEM_RESET = 0xE9,
    OEM_JUMP = 0xEA,
    OEM_PA1 = 0xEB,
    OEM_PA2 = 0xEC,
    OEM_PA3 = 0xED,
    OEM_WSCTRL = 0xEE,
    OEM_CUSEL = 0xEF,
    OEM_ATTN = 0xF0,
    OEM_FINISH = 0xF1,
    OEM_COPY = 0xF2,
    OEM_AUTO = 0xF3,
    OEM_ENLW = 0xF4,
    OEM_BACKTAB = 0xF5,

    ATTN = 0xF6,
    CRSEL = 0xF7,
    EXSEL = 0xF8,
    EREOF = 0xF9,
    PLAY = 0xFA,
    ZOOM = 0xFB,
    NONAME = 0xFC,
    PA1 = 0xFD,
    OEM_CLEAR = 0xFE,

    Last
}
#endregion

#region WindowPosition
[StructLayout(LayoutKind.Sequential)]
internal struct WindowPosition
{
    /// <summary>
    /// Handle to the window.
    /// </summary>
    internal IntPtr hwnd;
    /// <summary>
    /// Specifies the position of the window in Z order (front-to-back position).
    /// This member can be a handle to the window behind which this window is placed,
    /// or can be one of the special values listed with the SetWindowPos function.
    /// </summary>
    internal IntPtr hwndInsertAfter;
    /// <summary>
    /// Specifies the position of the left edge of the window.
    /// </summary>
    internal int x;
    /// <summary>
    /// Specifies the position of the top edge of the window.
    /// </summary>
    internal int y;
    /// <summary>
    /// Specifies the window width, in pixels.
    /// </summary>
    internal int cx;
    /// <summary>
    /// Specifies the window height, in pixels.
    /// </summary>
    internal int cy;
    /// <summary>
    /// Specifies the window position.
    /// </summary>
    [MarshalAs(UnmanagedType.U4)]
    internal SetWindowPosFlags flags;
}
#endregion