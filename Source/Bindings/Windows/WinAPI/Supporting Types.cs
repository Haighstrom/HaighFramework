using System.Runtime.InteropServices;

namespace HaighFramework.Win32API;

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

internal enum User32Icons : ushort
{
    APPLICATION = 100,
    EXCLAMATION = 101,
    QUESTION = 102,
    ERROR = 103,
    INFORMATION = 104,
    SHIELD = 106,
}



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

//https://docs.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute
internal enum DWMWINDOWATTRIBUTE : uint
{
    /// <summary>
    /// Use with DwmGetWindowAttribute. Discovers whether non-client rendering is enabled. The retrieved value is of type BOOL. TRUE if non-client rendering is enabled; otherwise, FALSE.
    /// </summary>
    DWMWA_NCRENDERING_ENABLED = 1,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Sets the non-client rendering policy. The pvAttribute parameter points to a value from the DWMNCRENDERINGPOLICY enumeration.
    /// </summary>
    DWMWA_NCRENDERING_POLICY,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Enables or forcibly disables DWM transitions. The pvAttribute parameter points to a value of type BOOL. TRUE to disable transitions, or FALSE to enable transitions.
    /// </summary>
    DWMWA_TRANSITIONS_FORCEDISABLED,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Enables content rendered in the non-client area to be visible on the frame drawn by DWM. The pvAttribute parameter points to a value of type BOOL. TRUE to enable content rendered in the non-client area to be visible on the frame; otherwise, FALSE.
    /// </summary>
    DWMWA_ALLOW_NCPAINT,
    /// <summary>
    /// Use with DwmGetWindowAttribute. Retrieves the bounds of the caption button area in the window-relative space. The retrieved value is of type RECT. If the window is minimized or otherwise not visible to the user, then the value of the RECT retrieved is undefined. You should check whether the retrieved RECT contains a boundary that you can work with, and if it doesn't then you can conclude that the window is minimized or otherwise not visible.
    /// </summary>
    DWMWA_CAPTION_BUTTON_BOUNDS,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Specifies whether non-client content is right-to-left (RTL) mirrored. The pvAttribute parameter points to a value of type BOOL. TRUE if the non-client content is right-to-left (RTL) mirrored; otherwise, FALSE.
    /// </summary>
    DWMWA_NONCLIENT_RTL_LAYOUT,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Forces the window to display an iconic thumbnail or peek representation (a static bitmap), even if a live or snapshot representation of the window is available. This value is normally set during a window's creation, and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of type BOOL. TRUE to require a iconic thumbnail or peek representation; otherwise, FALSE.
    /// </summary>
    DWMWA_FORCE_ICONIC_REPRESENTATION,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Sets how Flip3D treats the window. The pvAttribute parameter points to a value from the DWMFLIP3DWINDOWPOLICY enumeration.
    /// </summary>
    DWMWA_FLIP3D_POLICY,
    /// <summary>
    /// Use with DwmGetWindowAttribute. Retrieves the extended frame bounds rectangle in screen space. The retrieved value is of type RECT.
    /// </summary>
    DWMWA_EXTENDED_FRAME_BOUNDS,
    /// <summary>
    /// Use with DwmSetWindowAttribute. The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window. DWMWA_HAS_ICONIC_BITMAP can be specified with DWMWA_FORCE_ICONIC_REPRESENTATION. DWMWA_HAS_ICONIC_BITMAP normally is set during a window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of type BOOL. TRUE to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise, FALSE.
    /// Windows Vista and earlier: This value is not supported.
    /// </summary>
    DWMWA_HAS_ICONIC_BITMAP,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Do not show peek preview for the window. The peek view shows a full-sized preview of the window when the mouse hovers over the window's thumbnail in the taskbar. If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses peek (in case another window in the group has a peek preview showing). The pvAttribute parameter points to a value of type BOOL. TRUE to prevent peek functionality, or FALSE to allow it.
    /// Windows Vista and earlier: This value is not supported.
    /// </summary>
    DWMWA_DISALLOW_PEEK,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Prevents a window from fading to a glass sheet when peek is invoked. The pvAttribute parameter points to a value of type BOOL. TRUE to prevent the window from fading during another window's peek, or FALSE for normal behavior.
    /// Windows Vista and earlier: This value is not supported.
    /// </summary>
    DWMWA_EXCLUDED_FROM_PEEK,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Cloaks the window such that it is not visible to the user. The window is still composed by DWM.
    /// Using with DirectComposition: Use the DWMWA_CLOAK flag to cloak the layered child window when animating a representation of the window's content via a DirectComposition visual that has been associated with the layered child window. For more details on this usage case, see How to animate the bitmap of a layered child window.
    /// Windows 7 and earlier: This value is not supported.
    /// </summary>
    DWMWA_CLOAK,
    /// <summary>
    /// Use with DwmGetWindowAttribute. If the window is cloaked, provides one of the following values explaining why.
    /// DWM_CLOAKED_APP (value 0x0000001). The window was cloaked by its owner application.
    /// DWM_CLOAKED_SHELL (value 0x0000002). The window was cloaked by the Shell.
    /// DWM_CLOAKED_INHERITED (value 0x0000004). The cloak value was inherited from its owner window.
    /// Windows 7 and earlier: This value is not supported.
    /// </summary>
    DWMWA_CLOAKED,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Freeze the window's thumbnail image with its current visuals. Do no further live updates on the thumbnail image to match the window's contents.
    /// Windows 7 and earlier: This value is not supported.
    /// </summary>
    DWMWA_FREEZE_REPRESENTATION,
    /// <summary>
    /// [Documentation is blank for this value at time of writing]
    /// </summary>
    DWMWA_PASSIVE_UPDATE_MODE,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Enables a non-UWP window to use host backdrop brushes. If this flag is set, then a Win32 app that calls Windows::UI::Composition APIs can build transparency effects using the host backdrop brush (see Compositor.CreateHostBackdropBrush). The pvAttribute parameter points to a value of type BOOL. TRUE to enable host backdrop brushes for the window, or FALSE to disable it.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_USE_HOSTBACKDROPBRUSH,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Allows the window frame for this window to be drawn in dark mode colors when the dark mode system setting is enabled. For compatibility reasons, all windows default to light mode regardless of the system setting. The pvAttribute parameter points to a value of type BOOL. TRUE to honor dark mode for the window, FALSE to always use light mode.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Specifies the rounded corner preference for a window. The pvAttribute parameter points to a value of type DWM_WINDOW_CORNER_PREFERENCE.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_WINDOW_CORNER_PREFERENCE = 33,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Specifies the color of the window border. The pvAttribute parameter points to a value of type COLORREF. The app is responsible for changing the border color according to state changes, such as a change in window activation.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_BORDER_COLOR,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Specifies the color of the caption. The pvAttribute parameter points to a value of type COLORREF.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_CAPTION_COLOR,
    /// <summary>
    /// Use with DwmSetWindowAttribute. Specifies the color of the caption text. The pvAttribute parameter points to a value of type COLORREF.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_TEXT_COLOR,
    /// <summary>
    /// Use with DwmGetWindowAttribute. Retrieves the width of the outer border that the DWM would draw around this window. The value can vary depending on the DPI of the window. The pvAttribute parameter points to a value of type UINT.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
    /// <summary>
    /// IMPORTANT. This value is available in pre-release versions of the Windows Insider Preview.
    /// Use with DwmGetWindowAttribute or DwmSetWindowAttribute. Retrieves or specifies the system-drawn backdrop material of a window, including behind the non-client area. The pvAttribute parameter points to a value of type DWM_SYSTEMBACKDROP_TYPE.
    /// This value is supported starting with Windows 11 Build 22621.
    /// </summary>
    DWMWA_SYSTEMBACKDROP_TYPE,
    /// <summary>
    /// The maximum recognized DWMWINDOWATTRIBUTE value, used for validation purposes.
    /// </summary>
    DWMWA_LAST
}

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

internal enum PROCESS_DPI_AWARENESS
{
    Process_DPI_Unaware = 0,
    Process_System_DPI_Aware = 1,
    Process_Per_Monitor_DPI_Aware = 2
}

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

/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsyscolor
/// For use with GetSysColor
/// </summary>
internal enum GetSysColor_nIndex : int
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

/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadcursorw
/// For use with LoadCursor or LoadImage
/// </summary>
public enum PredefinedCursors : ushort
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
    internal RAWINPUTDEVICEUSAGEPAGE usUsagePage;
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
    internal RAWINPUTDEVICEFLAGS dwFlags;
    /// <summary>
    /// Handle to the target window. If NULL it follows the keyboard focus.
    /// </summary>
    internal IntPtr hwndTarget;
}

/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice
/// Mode flag that specifies how to interpret the information provided by usUsagePage and usUsage. For use with User32 RegisterRawInputDevices.
/// </summary>
/// <remarks>If RIDEV_NOLEGACY is set for a mouse or a keyboard, the system does not generate any legacy message for that device for the application. For example, if the mouse TLC is set with RIDEV_NOLEGACY, WM_LBUTTONDOWN and related legacy mouse messages are not generated. Likewise, if the keyboard TLC is set with RIDEV_NOLEGACY, WM_KEYDOWN and related legacy keyboard messages are not generated.
/// If RIDEV_REMOVE is set and the hwndTarget member is not set to NULL, then RegisterRawInputDevices function will fail.</remarks>
[Flags]
internal enum RAWINPUTDEVICEFLAGS : int
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

/// <summary>
/// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-page
/// https://github.com/tpn/winsdk-10/blob/master/Include/10.0.10240.0/shared/hidusage.h
/// HID usages are organized into usage pages of related controls. A specific control usage is defined by its usage page, a usage ID, a name, and a description. A usage page value is a 16-bit unsigned value. For use with User32 RegisterRawInputDevices.
/// </summary>
internal enum RAWINPUTDEVICEUSAGEPAGE : ushort
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

[StructLayout(LayoutKind.Sequential)]
internal struct MINMAXINFO
{
    private POINT ptReserved;
    public POINT ptMaxSize;
    public POINT ptMaxPosition;
    public POINT ptMinTrackSize;
    public POINT ptMaxTrackSize;
}

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
internal delegate IntPtr WNDPROC(IntPtr hwnd, WINDOWMESSAGE uMsg, IntPtr wParam, IntPtr lParam);



[Flags]
public enum ABS : int
{
    Autohide = 0x0000001,
    AlwaysOnTop = 0x0000002
}

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

[StructLayout(LayoutKind.Sequential)]
internal struct COLORREF
{
    public byte R;
    public byte G;
    public byte B;
}






[Flags]
internal enum DesiredAccess : uint
{
    GenericRead = 0x80000000,
    GenericWrite = 0x40000000,
    GenericExecute = 0x20000000,
    GenericAll = 0x10000000
}

internal struct DevBroadcastHDR
{
    internal int Size;
    internal DeviceBroadcastType DeviceType;
    int dbcc_reserved;
    internal Guid ClassGuid;
    internal char dbcc_name;
}

internal enum DeviceBroadcastType
{
    OEM = 0,
    VOLUME = 2,
    PORT = 3,
    INTERFACE = 5,
    HANDLE = 6,
}


[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal class DEVMODE
{
    public DEVMODE()
    {
        Size = (short)Marshal.SizeOf(this);
    }

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string DeviceName;
    public short SpecVersion;
    public short DriverVersion;
    private short Size;
    public short DriverExtra;
    public DeviceModeEnum Fields;

    //internal short Orientation;
    //internal short PaperSize;
    //internal short PaperLength;
    //internal short PaperWidth;
    //internal short Scale;
    //internal short Copies;
    //internal short DefaultSource;
    //internal short PrintQuality;

    public POINT Position;
    public int DisplayOrientation;
    public int DisplayFixedOutput;

    public short Color;
    public short Duplex;
    public short YResolution;
    public short TTOption;
    public short Collate;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string FormName;
    public short LogPixels;
    public int BitsPerPel;
    public int PelsWidth;
    public int PelsHeight;
    public int DisplayFlags;
    public int DisplayFrequency;
    public int ICMMethod;
    public int ICMIntent;
    public int MediaType;
    public int DitherType;
    public int Reserved1;
    public int Reserved2;
    public int PanningWidth;
    public int PanningHeight;
}

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
    internal DisplayDeviceStateFlags StateFlags;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    internal string DeviceID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    internal string DeviceKey;
}

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

internal enum DisplayModeSettingsEnum
{
    CurrentSettings = -1,
    RegistrySettings = -2
}



[StructLayout(LayoutKind.Sequential)]
internal struct ICONINFO
{
    public bool IsIcon;
    public int xHotspot;
    public int yHotspot;
    public IntPtr MaskBitmap;
    public IntPtr ColorBitmap;
};



internal struct MONITORINFO
{
    public int Size;
    public RECT Monitor;
    public RECT Work;
    public int Flags;

    public static readonly int UnmanagedSize = Marshal.SizeOf(default(MONITORINFO));
}

[StructLayout(LayoutKind.Sequential)]
public struct MOUSEMOVEPOINT
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
    public static readonly int SizeInBytes = Marshal.SizeOf(default(MOUSEMOVEPOINT));
}

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



[StructLayout(LayoutKind.Explicit)]
internal struct RawHID
{
}

#pragma warning disable 0649
internal struct RawInput
{
    internal RawInputHeader Header;
    internal RawInputData Data;
}
#pragma warning restore 0649

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



/// <summary>
/// Contains information about a raw input device.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct RAWINPUTDEVICELIST
{
    /// <summary>
    /// Handle to the raw input device.
    /// </summary>
    internal IntPtr Device;
    /// <summary>
    /// Type of device.
    /// </summary>
    internal RawInputDeviceType Type;

    internal static readonly int Size = Marshal.SizeOf(typeof(RAWINPUTDEVICELIST));
}

internal enum RawInputDeviceType : int
{
    MOUSE = 0,
    KEYBOARD = 1,
    HID = 2
}

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

internal enum RawInputKeyboardDataFlags : short
{
    MAKE = 0,
    BREAK = 1,
    E0 = 2,
    E1 = 4,
    TERMSRV_SET_LED = 8,
    TERMSRV_SHADOW = 0x10
}

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
    internal VIRTUALKEYCODE VKey;
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

[Flags]
internal enum SETWINDOWPOSFLAGS : int
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

internal enum SizeMessage
{
    MAXHIDE = 4,
    MAXIMIZED = 2,
    MAXSHOW = 3,
    MINIMIZED = 1,
    RESTORED = 0
}

internal struct StyleStruct
{
    public WINDOWSTYLE Old;
    public WINDOWSTYLE New;
}

internal struct ExtendedStyleStruct
{
    public WINDOWSTYLEEX Old;
    public WINDOWSTYLEEX New;
}

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

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void TimerProc(IntPtr hwnd, WINDOWMESSAGE uMsg, UIntPtr idEvent, int dwTime);

internal enum VIRTUALKEYCODE : short
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
    internal SETWINDOWPOSFLAGS flags;
}