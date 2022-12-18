﻿using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace HaighFramework.WinAPI;

#region Enums
/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/winmsg/window-class-styles
/// The class styles define additional elements of the window class. Two or more styles can be combined by using the bitwise OR (|) operator. To assign a style to a window class, assign the style to the style member of the WNDCLASSEX structure.
/// </summary>
[Flags]
internal enum CLASSSTLYE : uint
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
/// For use in <see cref="User32.LoadImage"/>
/// </summary>
internal enum IMAGE_FLAG : uint
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

/// <summary>
/// The type of image to be loaded in <see cref="User32.LoadImage"/>
/// </summary>
internal enum IMAGE_TYPE : uint
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
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawinputdevice
    /// Mode flag that specifies how to interpret the information provided by usUsagePage and usUsage. For use with User32 RegisterRawInputDevices.
    /// </summary>
    /// <remarks>If RIDEV_NOLEGACY is set for a mouse or a keyboard, the system does not generate any legacy message for that device for the application. For example, if the mouse TLC is set with RIDEV_NOLEGACY, WM_LBUTTONDOWN and related legacy mouse messages are not generated. Likewise, if the keyboard TLC is set with RIDEV_NOLEGACY, WM_KEYDOWN and related legacy keyboard messages are not generated.
    /// If RIDEV_REMOVE is set and the hwndTarget member is not set to NULL, then RegisterRawInputDevices function will fail.</remarks>
    [Flags]
    public enum FLAGS : int
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
    /// </summary>
    public enum USAGE : ushort
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
    internal enum USAGEPAGE : ushort
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
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-page
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows
    /// Top level collection Usage page for the raw input device. See HID Clients Supported in Windows for details on possible values.
    /// </summary>
    internal USAGEPAGE usUsagePage;

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-id
    /// https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows
    /// Top level collection Usage ID for the raw input device. See HID Clients Supported in Windows for details on possible values.
    /// </summary>
    internal USAGE usUsage;

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
    internal FLAGS dwFlags;

    /// <summary>
    /// Handle to the target window. If NULL it follows the keyboard focus.
    /// </summary>
    internal IntPtr hwndTarget;
}

/// <summary>
/// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsyscolor
/// For use with <see cref="User32.GetSysColor"/>.
/// </summary>
internal enum SYSCOLORINDEX : int
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

/// <summary>
/// Windows management functions for message handling, timers, menus, and communications.
/// </summary>
[SuppressUnmanagedCodeSecurity]
internal static class User32
{
    private const string Library = "User32.dll";

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-adjustwindowrect
    /// Calculates the required size of the window rectangle, based on the desired client-rectangle size. The window rectangle can then be passed to the CreateWindow function to create a window whose client area is the desired size.
    ///To specify an extended window style, use the AdjustWindowRectEx function.
    /// </summary>
    /// <param name="lpRect">A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners of the desired client area. When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to accommodate the desired client area.</param>
    /// <param name="dwStyle">The window style of the window whose required size is to be calculated. Note that you cannot specify the WS_OVERLAPPED style.</param>
    /// <param name="bMenu">Indicates whether the window has a menu.</param>
    ///<returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool AdjustWindowRect(ref RECT lpRect, WINDOWSTYLE dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu);

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-adjustwindowrectex
    /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle. The window rectangle can then be passed to the CreateWindowEx function to create a window whose client area is the desired size.
    /// </summary>
    /// <param name="lpRect">A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners of the desired client area. When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to accommodate the desired client area.</param>
    /// <param name="dwStyle">The window style of the window whose required size is to be calculated. Note that you cannot specify the WS_OVERLAPPED style.</param>
    /// <param name="bMenu">Indicates whether the window has a menu.</param>
    /// <param name="dwExStyle">The extended window style of the window whose required size is to be calculated.</param>
    /// <returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool AdjustWindowRectEx(ref RECT lpRect, WINDOWSTYLE dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, WINDOWSTYLEEX dwExStyle);

    /// <summary>
    /// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated. If the window is a child window, the top-level parent window associated with the child window is activated.
    /// </summary>
    /// <param name="hWnd">A handle to the window to bring to the top of the Z order.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool BringWindowToTop(IntPtr hWnd);

    /// <summary>
    /// Passes message information to the specified window procedure.
    /// </summary>
    /// <param name="lpPrevWndFunc">The previous window procedure. If this value is obtained by calling the GetWindowLong function with the nIndex parameter set to GWL_WNDPROC or DWL_DLGPROC, it is actually either the address of a window or dialog box procedure, or a special internal value meaningful only to CallWindowProc.</param>
    /// <param name="hWnd">A handle to the window procedure to receive the message.</param>
    /// <param name="Msg">The message.</param>
    /// <param name="wParam">Additional message-specific information. The contents of this parameter depend on the value of the Msg parameter.</param>
    /// <param name="lParam">Additional message-specific information. The contents of this parameter depend on the value of the Msg parameter.</param>
    /// <returns>The return value specifies the result of the message processing and depends on the message sent.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, WINDOWMESSAGE Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// The ChangeDisplaySettings function changes the settings of the default display device to the specified graphics mode.
    /// </summary>
    /// <param name="lpDevMode">Pointer to a <see cref="DEVMODE"/> structure that describes the new graphics mode. If lpDevMode is NULL, all the values currently in the registry will be used for the display setting. Passing NULL for the lpDevMode parameter and 0 for the dwFlags parameter is the easiest way to return to the default mode after a dynamic mode change.</param>
    /// <param name="dwFlags">Indicates how the graphics mode should be changed.</param>
    /// <returns>Returns a <see cref="DISPCHANGERESULT"/> to indicate the result.</returns>
    /// <remarks>To change the settings of a specified display device, use the ChangeDisplaySettingsEx function. To ensure that the DEVMODE structure passed to ChangeDisplaySettings is valid and contains only values supported by the display driver, use the DEVMODE returned by the EnumDisplaySettings function. When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications. </remarks>
    [DllImport(Library, SetLastError = true)]
    public static extern DISPCHANGERESULT ChangeDisplaySettings(DEVMODE lpDevMode, CHANGEDISPLAYSETTINGSFLAGS dwFlags);

    /// <summary>
    /// The ChangeDisplaySettings function changes the settings of the default display device to the specified graphics mode.
    /// </summary>
    /// <param name="lpDevMode">Pointer to a <see cref="DEVMODE"/> structure that describes the new graphics mode. If lpDevMode is NULL, all the values currently in the registry will be used for the display setting. Passing NULL for the lpDevMode parameter and 0 for the dwFlags parameter is the easiest way to return to the default mode after a dynamic mode change.</param>
    /// <param name="dwFlags">Indicates how the graphics mode should be changed.</param>
    /// <returns>Returns a <see cref="DISPCHANGERESULT"/> to indicate the result.</returns>
    /// <remarks>To change the settings of a specified display device, use the ChangeDisplaySettingsEx function. To ensure that the DEVMODE structure passed to ChangeDisplaySettings is valid and contains only values supported by the display driver, use the DEVMODE returned by the EnumDisplaySettings function. When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications. </remarks>
    [DllImport(Library, SetLastError = true)]
    public static extern DISPCHANGERESULT ChangeDisplaySettings(IntPtr lpDevMode, CHANGEDISPLAYSETTINGSFLAGS dwFlags);

    /// <summary>
    /// The ChangeDisplaySettingsEx function changes the settings of the specified display device to the specified graphics mode.
    /// </summary>
    /// <param name="lpszDeviceName">A pointer to a null-terminated string that specifies the display device whose graphics mode will change. Only display device names as returned by EnumDisplayDevices are valid. See EnumDisplayDevices for further information on the names associated with these display devices. The lpszDeviceName parameter can be NULL.A NULL value specifies the default display device. The default device can be determined by calling EnumDisplayDevices and checking for the DISPLAY_DEVICE_PRIMARY_DEVICE flag.</param>
    /// <param name="lpDevMode">A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is NULL, all the values currently in the registry will be used for the display setting. Passing NULL for the lpDevMode parameter and 0 for the dwFlags parameter is the easiest way to return to the default mode after a dynamic mode change.</param>
    /// <param name="hwnd">Reserved; must be NULL.</param>
    /// <param name="dwflags">Indicates how the graphics mode should be changed.</param>
    /// <param name="lParam">If dwFlags is CDS_VIDEOPARAMETERS, lParam is a pointer to a VIDEOPARAMETERS structure. Otherwise lParam must be NULL.</param>
    /// <returns>Returns a <see cref="DISPCHANGERESULT"/> to indicate the result.</returns>
    /// <remarks>To ensure that the DEVMODE structure passed to ChangeDisplaySettings is valid and contains only values supported by the display driver, use the DEVMODE returned by the EnumDisplaySettings function. When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications.</remarks>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern DISPCHANGERESULT ChangeDisplaySettingsEx([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, DEVMODE lpDevMode, IntPtr hwnd, CHANGEDISPLAYSETTINGSFLAGS dwflags, IntPtr lParam);

    /// <summary>
    /// Converts the client-area coordinates of a specified point to screen coordinates.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose client area is used for the conversion.</param>
    /// <param name="point">A pointer to a POINT structure that contains the client coordinates to be converted. The new screen coordinates are copied into this structure if the function succeeds.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

    /// <summary>
    /// Confines the cursor to a rectangular area on the screen. If a subsequent cursor position (set by the SetCursorPos function or the mouse) lies outside the rectangle, the system automatically adjusts the position to keep the cursor inside the rectangular area.
    /// </summary>
    /// <param name="rcClip">A pointer to the structure that contains the screen coordinates of the upper-left and lower-right corners of the confining rectangle. If this parameter is NULL, the cursor is free to move anywhere on the screen.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, CharSet = CharSet.Auto)]
    public static extern bool ClipCursor(ref RECT rcClip);

    /// <summary>
    /// Confines the cursor to a rectangular area on the screen. If a subsequent cursor position (set by the SetCursorPos function or the mouse) lies outside the rectangle, the system automatically adjusts the position to keep the cursor inside the rectangular area.
    /// </summary>
    /// <param name="rcClip">A pointer to the structure that contains the screen coordinates of the upper-left and lower-right corners of the confining rectangle. If this parameter is NULL, the cursor is free to move anywhere on the screen.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, CharSet = CharSet.Auto)]
    public static extern bool ClipCursor(IntPtr rcClip);

    /// <summary>
    /// Creates an icon or cursor from an ICONINFO structure.
    /// </summary>
    /// <param name="piconinfo">A pointer to an ICONINFO structure the function uses to create the icon or cursor.</param>
    /// <returns>If the function succeeds, the return value is a handle to the icon or cursor that is created. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr CreateIconIndirect(ref ICONINFO piconinfo);

    /// <summary>
    /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function. For more information about creating a window and for full descriptions of the other parameters of CreateWindowEx, see CreateWindow.
    /// </summary>
    /// <param name="dwExStyle">The extended window style of the window being created. For a list of possible values, see Extended Window Styles.</param>
    /// <param name="lpClassName">A null-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, provided that the module that registers the class is also the module that creates the window. The class name can also be any of the predefined system class names.</param>
    /// <param name="lpWindowName">The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the text of the control. When creating a static control with the SS_ICON style, use lpWindowName to specify the icon name or identifier. To specify an identifier, use the syntax "#num".</param>
    /// <param name="dwStyle">The style of the window being created. This parameter can be a combination of the window style values, plus the control styles indicated in the Remarks section.</param>
    /// <param name="X">The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area. If x is set to CW_USEDEFAULT, the system selects the default position for the window's upper-left corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.</param>
    /// <param name="Y">The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area. For a list box y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area.
    /// If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter is set to CW_USEDEFAULT, then the y parameter determines how the window is shown.If the y parameter is CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW flag after the window has been created. If the y parameter is some other value, then the window manager calls ShowWindow with that value as the nCmdShow parameter.</param>
    /// <param name="nWidth">The width, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT, the system selects a default width and height for the window; the default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.</param>
    /// <param name="nHeight">The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If the nWidth parameter is set to CW_USEDEFAULT, the system ignores nHeight.</param>
    /// <param name="hWndParent">A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle. This parameter is optional for pop-up windows.
    /// To create a message-only window, supply HWND_MESSAGE or a handle to an existing message-only window.</param>
    /// <param name="hMenu">A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu identifies the menu to be used with the window; it can be NULL if the class menu is to be used. For a child window, hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The application determines the child-window identifier; it must be unique for all child windows with the same parent window.</param>
    /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
    /// <param name="lpParam">Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by this function before it returns.
    /// If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure.If an MDI client window calls CreateWindow to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure.lpParam may be NULL if no additional data is needed.</param>
    /// <returns>If the function succeeds, the return value is a handle to the new window.
    /// If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr CreateWindowEx(WINDOWSTYLEEX dwExStyle, IntPtr lpClassName, IntPtr lpWindowName, WINDOWSTYLE dwStyle, int X, int Y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    /// <summary>
    /// Calls the default window procedure to provide default processing for any window messages that an application does not process. This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
    /// </summary>
    /// <param name="hWnd">A handle to the window procedure that received the message.</param>
    /// <param name="msg">The message.</param>
    /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
    /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
    /// <returns>The return value is the result of the message processing and depends on the message.</returns>
    [DllImport(Library, CharSet = CharSet.Auto)]
    public static extern IntPtr DefWindowProc(IntPtr hWnd, WINDOWMESSAGE msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Destroys a cursor and frees any memory the cursor occupied. Do not use this function to destroy a shared cursor.
    /// </summary>
    /// <param name="hCursor">A handle to the cursor to be destroyed. The cursor must not be in use.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool DestroyCursor(IntPtr hCursor);

    /// <summary>
    /// Destroys an icon and frees any memory the icon occupied.
    /// </summary>
    /// <param name="hIcon">A handle to the icon to be destroyed. The icon must not be in use.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool DestroyIcon(IntPtr hIcon);

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroywindow
    /// Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to deactivate it and remove the keyboard focus from it. The function also destroys the window's menu, flushes the thread message queue, destroys timers, removes clipboard ownership, and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
    /// If the specified window is a parent or owner window, DestroyWindow automatically destroys the associated child or owned windows when it destroys the parent or owner window. The function first destroys child or owned windows, and then it destroys the parent or owner window.
    /// </summary>
    /// <param name="hWnd"></param>
    /// <returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library)]
    public static extern bool DestroyWindow(IntPtr hWnd);

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dispatchmessage
    /// Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage function.
    /// </summary>
    /// <param name="lpMsg">A pointer to a structure that contains the message.</param>
    /// <returns>The return value specifies the value returned by the window procedure. Although its meaning depends on the message being dispatched, the return value generally is ignored.</returns>
    [DllImport(Library)]
    public static extern IntPtr DispatchMessage(ref MSG lpMsg);

    /// <summary>
    /// The EnumDisplayDevices function lets you obtain information about the display devices in the current session.
    /// </summary>
    /// <param name="lpDevice">A pointer to the device name. If NULL, function returns information for the display adapter(s) on the machine, based on iDevNum.</param>
    /// <param name="iDevNum">An index value that specifies the display device of interest. The operating system identifies each display device in the current session with an index value.The index values are consecutive integers, starting at 0. If the current session has three display devices, for example, they are specified by the index values 0, 1, and 2.</param>
    /// <param name="lpDisplayDevice">A pointer to a DISPLAY_DEVICE structure that receives information about the display device specified by iDevNum. Before calling EnumDisplayDevices, you must initialize the cb member of DISPLAY_DEVICE to the size, in bytes, of DISPLAY_DEVICE.</param>
    /// <param name="dwFlags">Set this flag to EDD_GET_DEVICE_INTERFACE_NAME (0x00000001) to retrieve the device interface name for GUID_DEVINTERFACE_MONITOR, which is registered by the operating system on a per monitor basis. The value is placed in the DeviceID member of the DISPLAY_DEVICE structure returned in lpDisplayDevice. The resulting device interface name can be used with SetupAPI functions and serves as a link between GDI monitor devices and SetupAPI monitor devices.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. The function fails if iDevNum is greater than the largest device index.</returns>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumDisplayDevices(IntPtr lpDevice, int iDevNum, [In, Out] DISPLAY_DEVICE lpDisplayDevice, ENUMDISPLAYDEVICEFLAG dwFlags);

    /// <summary>
    /// The EnumDisplaySettingsEx function retrieves information about one of the graphics modes for a display device. To retrieve information for all the graphics modes for a display device, make a series of calls to this function. This function differs from EnumDisplaySettings in that there is a dwFlags parameter.
    /// </summary>
    /// <param name="lpszDeviceName">A pointer to a null-terminated string that specifies the display device about which graphics mode the function will obtain information. This parameter is either NULL or a DISPLAY_DEVICE.DeviceName returned from EnumDisplayDevices.A NULL value specifies the current display device on the computer that the calling thread is running on.</param>
    /// <param name="iModeNum">Indicates the type of information to be retrieved. This value can be a graphics mode index or one of the <see cref="DisplayModeSettingsEnum"/> values.</param>
    /// <param name="lpDevMode">A pointer to a <see cref="DEVMODE"/> structure into which the function stores information about the specified graphics mode. Before calling EnumDisplaySettingsEx, set the dmSize member to sizeof (DEVMODE), and set the dmDriverExtra member to indicate the size, in bytes, of the additional space available to receive private driver data.</param>
    /// <param name="dwFlags">This parameter can be the following value.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
    [DllImport(Library, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumDisplaySettingsEx([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, DisplayModeSettingsEnum iModeNum, [In, Out] DEVMODE lpDevMode, ENUMDISPLAYSETTINGSFLAG dwFlags);

    /// <summary>
    /// The EnumDisplaySettingsEx function retrieves information about one of the graphics modes for a display device. To retrieve information for all the graphics modes for a display device, make a series of calls to this function. This function differs from EnumDisplaySettings in that there is a dwFlags parameter.
    /// </summary>
    /// <param name="lpszDeviceName">A pointer to a null-terminated string that specifies the display device about which graphics mode the function will obtain information. This parameter is either NULL or a DISPLAY_DEVICE.DeviceName returned from EnumDisplayDevices.A NULL value specifies the current display device on the computer that the calling thread is running on.</param>
    /// <param name="iModeNum">Indicates the type of information to be retrieved. This value can be a graphics mode index or one of the <see cref="DisplayModeSettingsEnum"/> values.</param>
    /// <param name="lpDevMode">A pointer to a <see cref="DEVMODE"/> structure into which the function stores information about the specified graphics mode. Before calling EnumDisplaySettingsEx, set the dmSize member to sizeof (DEVMODE), and set the dmDriverExtra member to indicate the size, in bytes, of the additional space available to receive private driver data.</param>
    /// <param name="dwFlags">This parameter can be the following value.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool EnumDisplaySettingsEx([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, int iModeNum, [In, Out] DEVMODE lpDevMode, ENUMDISPLAYSETTINGSFLAG dwFlags);

    /// <summary>
    /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search. To search child windows, beginning with a specified child window, use the FindWindowEx function.
    /// </summary>
    /// <param name="lpClassName">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names. If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.</param>
    /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
    /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr FindWindow(string? lpClassName, string? lpWindowName);

    /// <summary>
    /// Retrieves a handle to the window (if any) that has captured the mouse. Only one window at a time can capture the mouse; this window receives mouse input whether or not the cursor is within its borders.
    /// </summary>
    /// <returns>The return value is a handle to the capture window associated with the current thread. If no window in the thread has captured the mouse, the return value is NULL.</returns>
    [DllImport(Library)]
    public static extern IntPtr GetCapture();

    /// <summary>
    /// The GetClientRect function retrieves the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the client area. Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
    /// </summary>
    /// <param name="windowHandle">A handle to the window whose client coordinates are to be retrieved.</param>
    /// <param name="clientRectangle">A pointer to a <see cref="RECT"/> structure that receives the client coordinates. The left and top members are zero. The right and bottom members contain the width and height of the window.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool GetClientRect(IntPtr windowHandle, out RECT clientRectangle);

    /// <summary>
    /// Retrieves a handle to the current cursor.
    /// </summary>
    /// <returns>
    /// The return value is the handle to the current cursor. If there is no cursor, the return value is null.
    /// </returns>
    [DllImport(Library)]
    public static extern IntPtr GetCursor();

    /// <summary>
    /// Retrieves information about the global cursor.
    /// </summary>
    /// <param name="pci">A pointer to a <see cref="CURSORINFO"/> structure that receives the information.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool GetCursorInfo(ref CURSORINFO pci);

    /// <summary>
    /// Retrieves the position of the mouse cursor, in screen coordinates. https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorpos
    /// </summary>
    /// <param name="point">Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
    /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool GetCursorPos(ref POINT lpPoint);

    /// <summary>
    /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
    /// </summary>
    /// <param name="hwnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
    /// <returns>If the function succeeds, the return value is a handle to the DC for the specified window's client area. If the function fails, the return value is NULL.</returns>
    [DllImport(Library)]
    public static extern IntPtr GetDC(IntPtr hwnd);

    /// <summary>
    /// Retrieves the current double-click time for the mouse. A double-click is a series of two clicks of the mouse button, the second occurring within a specified time after the first. The double-click time is the maximum number of milliseconds that may occur between the first and second click of a double-click. The maximum double-click time is 5000 milliseconds.
    /// </summary>
    /// <returns>The return value specifies the current double-click time, in milliseconds. The maximum return value is 5000 milliseconds.</returns>
    [DllImport(Library)]
    public static extern int GetDoubleClickTime();

    /// <summary>
    /// Returns the dots per inch (dpi) value for the specified window.
    /// </summary>
    /// <param name="hWnd">The window that you want to get information about.</param>
    /// <returns>The DPI for the window, which depends on the DPI_AWARENESS of the window. See the Remarks section for more information. An invalid hwnd value will result in a return value of 0.</returns>
    [DllImport(Library)]
    public static extern int GetDpiForWindow(IntPtr hWnd);

    /// <summary>
    /// Retrieves information about the specified icon or cursor.
    /// </summary>
    /// <param name="hIcon">A handle to the icon or cursor.</param>
    /// <param name="pIconInfo">A pointer to an ICONINFO structure. The function fills in the structure's members.</param>
    /// <returns>If the function succeeds, the return value is nonzero and the function fills in the members of the specified ICONINFO structure. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetIconInfo(IntPtr hIcon, ref ICONINFO pIconInfo);

    /// <summary>
    /// Retrieves a string that represents the name of a key. https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeynametexta
    /// </summary>
    /// <param name="lParam">The second parameter of the keyboard message (such as WM_KEYDOWN) to be processed. The function interprets the following bit positions in the lParam.
    /// 16-23	Scan code.
    /// 24	Extended-key flag. Distinguishes some keys on an enhanced keyboard.
    /// 25	"Do not care" bit. The application calling this function sets this bit to indicate that the function should not distinguish between left and right CTRL and SHIFT keys, for example.</param>
    /// <param name="lpString">The buffer that will receive the key name.</param>
    /// <param name="cchSize">The maximum length, in characters, of the key name, including the terminating null character. (This parameter should be equal to the size of the buffer pointed to by the lpString parameter.)</param>
    /// <returns>If the function succeeds, a null-terminated string is copied into the specified buffer, and the return value is the length of the string, in characters, not counting the terminating null character. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern int GetKeyNameText(int lParam, [Out] StringBuilder lpString, int cchSize);

    /// <summary>
    /// Retrieves a string that represents the name of a key. https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeynametexta
    /// </summary>
    /// <param name="extendedScanCode"></param>
    /// <returns>If the function succeeds, a null-terminated string is copied into the specified buffer, and the return value is the length of the string, in characters, not counting the terminating null character. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    public static string GetKeyNameText(uint extendedScanCode)
    {
        int StringMaxLength = 512;
        int key = (int)extendedScanCode;
        StringBuilder s = new(StringMaxLength);
        _ = GetKeyNameText(key, s, StringMaxLength);

        return s.ToString();
    }

    /// <summary>
    /// Retrieves a string that represents the name of a key. https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeynametexta
    /// </summary>
    /// <param name="scanCode"></param>
    /// <param name="isE0"></param>
    /// <returns>If the function succeeds, a null-terminated string is copied into the specified buffer, and the return value is the length of the string, in characters, not counting the terminating null character. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    public static string GetKeyNameText(uint scanCode, bool isE0)
    {
        int StringMaxLength = 512;
        int key = (int)((scanCode << 16) | ((isE0 ? 1 : (uint)0) << 24));
        StringBuilder s = new(StringMaxLength);
        _ = GetKeyNameText(key, s, StringMaxLength);

        return s.ToString();
    }

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessage
    /// Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a posted message is available for retrieval.
    /// Unlike GetMessage, the PeekMessage function does not wait for a message to be posted before returning.
    /// </summary>
    /// <param name="lpMsg">A pointer to an MSG structure that receives message information from the thread's message queue.</param>
    /// <param name="hWnd">A handle to the window whose messages are to be retrieved. The window must belong to the current thread
    /// If hWnd is NULL, GetMessage retrieves messages for any window that belongs to the current thread, and any messages on the current thread's message queue whose hwnd value is NULL (see the MSG structure). Therefore if hWnd is NULL, both window messages and thread messages are processed.
    /// If hWnd is -1, GetMessage retrieves only messages on the current thread's message queue whose hwnd value is NULL, that is, thread messages as posted by PostMessage (when the hWnd parameter is NULL) or PostThreadMessage.</param>
    /// <param name="wMsgFilterMin">The integer value of the lowest message value to be retrieved. Use WM_KEYFIRST (0x0100) to specify the first keyboard message or WM_MOUSEFIRST (0x0200) to specify the first mouse message.
    /// Use WM_INPUT here and in wMsgFilterMax to specify only the WM_INPUT messages.
    /// If wMsgFilterMin and wMsgFilterMax are both zero, GetMessage returns all available messages(that is, no range filtering is performed).</param>
    /// <param name="wMsgFilterMax">The integer value of the highest message value to be retrieved. Use WM_KEYLAST to specify the last keyboard message or WM_MOUSELAST to specify the last mouse message.
    /// Use WM_INPUT here and in wMsgFilterMin to specify only the WM_INPUT messages.
    /// If wMsgFilterMin and wMsgFilterMax are both zero, GetMessage returns all available messages(that is, no range filtering is performed).</param>
    /// <returns>If the function retrieves a message other than WM_QUIT, the return value is nonzero. If the function retrieves the WM_QUIT message, the return value is zero. If there is an error, the return value is -1. For example, the function fails if hWnd is an invalid window handle or lpMsg is an invalid pointer.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern int GetMessage(ref MSG lpMsg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax);

    /// <summary>
    /// The GetMonitorInfo function retrieves information about a display monitor.
    /// </summary>
    /// <param name="hMonitor">A handle to the display monitor of interest.</param>
    /// <param name="lpmi">A pointer to a MONITORINFO or MONITORINFOEX structure that receives information about the specified display monitor.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
    [DllImport(Library)]
    public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

    /// <summary>
    /// Retrieves a history of up to 64 previous coordinates of the mouse or pen.
    /// </summary>
    /// <param name="cbSize">The size, in bytes, of the MOUSEMOVEPOINT structure.</param>
    /// <param name="pointsIn">A pointer to a MOUSEMOVEPOINT structure containing valid mouse coordinates (in screen coordinates). It may also contain a time stamp. The GetMouseMovePointsEx function searches for the point in the mouse coordinates history.If the function finds the point, it returns the last nBufPoints prior to and including the supplied point. If your application supplies a time stamp, the GetMouseMovePointsEx function will use it to differentiate between two equal points that were recorded at different times. An application should call this function using the mouse coordinates received from the WM_MOUSEMOVE message and convert them to screen coordinates.</param>
    /// <param name="pointsBufferOut">A pointer to a buffer that will receive the points. It should be at least cbSize* nBufPoints in size.</param>
    /// <param name="nBufPoints">The number of points to be retrieved.</param>
    /// <param name="resolution">The resolution desired.</param>
    /// <returns>If the function succeeds, the return value is the number of points in the buffer. Otherwise, the function returns –1. For extended error information, your application can call GetLastError.</returns>
    [DllImport(Library, CharSet = CharSet.Auto, SetLastError = true)]
    unsafe public static extern int GetMouseMovePointsEx(uint cbSize, MOUSEMOVEPOINT* lppt, MOUSEMOVEPOINT* lpptBuf, int nBufPoints, GMMP_RESOLUTION resolution);

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getqueuestatus
    /// Retrieves the type of messages found in the calling thread's message queue.
    /// </summary>
    /// <param name="flags">The types of messages for which to check.</param>
    /// <returns>The high-order word of the return value indicates the types of messages currently in the queue. The low-order word indicates the types of messages that have been added to the queue and that are still in the queue since the last call to the GetQueueStatus, GetMessage, or PeekMessage function.</returns>
    [DllImport(Library)]
    public static extern uint GetQueueStatus(QUEUESTATUSFLAGS flags);

    /// <summary>
    /// Retrieves the raw input from the specified device.
    /// </summary>
    /// <param name="hRawInput">A handle to the RAWINPUT structure. This comes from the lParam in WM_INPUT.</param>
    /// <param name="uiCommand">The command flag.</param>
    /// <param name="pData">A pointer to the data that comes from the RAWINPUT structure. This depends on the value of uiCommand. If pData is NULL, the required size of the buffer is returned in *pcbSize.</param>
    /// <param name="pcbSize">The size, in bytes, of the data in pData.</param>
    /// <param name="cbSizeHeader">The size, in bytes, of the RAWINPUTHEADER structure..</param>
    /// <returns>If pData is NULL and the function is successful, the return value is 0. If pData is not NULL and the function is successful, the return value is the number of bytes copied into pData. If there is an error, the return value is (UINT)-1.</returns>
    [DllImport(Library)]
    public static extern int GetRawInputData(IntPtr hRawInput, RAWINPUTDATAFLAG uiCommand, [Out] IntPtr pData, [In, Out] ref int pcbSize, int cbSizeHeader);

    /// <summary>
    /// Retrieves the raw input from the specified device.
    /// </summary>
    /// <param name="hRawInput">A handle to the RAWINPUT structure. This comes from the lParam in WM_INPUT.</param>
    /// <param name="uiCommand">The command flag.</param>
    /// <param name="pData">A pointer to the data that comes from the RAWINPUT structure. This depends on the value of uiCommand. If pData is NULL, the required size of the buffer is returned in *pcbSize.</param>
    /// <param name="pcbSize">The size, in bytes, of the data in pData.</param>
    /// <param name="cbSizeHeader">The size, in bytes, of the RAWINPUTHEADER structure..</param>
    /// <returns>If pData is NULL and the function is successful, the return value is 0. If pData is not NULL and the function is successful, the return value is the number of bytes copied into pData. If there is an error, the return value is (UINT)-1.</returns>
    [DllImport(Library)]
    public static extern int GetRawInputData(IntPtr hRawInput, RAWINPUTDATAFLAG uiCommand, [Out] out RawInput pData, [In, Out] ref int pcbSize, int cbSizeHeader);

    /// <summary>
    /// Retrieves information about the raw input device.
    /// </summary>
    /// <param name="hDevice">A handle to the raw input device. This comes from the hDevice member of RAWINPUTHEADER or from GetRawInputDeviceList.</param>
    /// <param name="uiCommand">Specifies what data will be returned in pData.</param>
    /// <param name="pData">A pointer to a buffer that contains the information specified by uiCommand. If uiCommand is RIDI_DEVICEINFO, set the cbSize member of RID_DEVICE_INFO to sizeof(RID_DEVICE_INFO) before calling GetRawInputDeviceInfo.</param>
    /// <param name="pcbSize">The size, in bytes, of the data in pData.</param>
    /// <returns>If successful, this function returns a non-negative number indicating the number of bytes copied to pData. If pData is not large enough for the data, the function returns -1. If pData is NULL, the function returns a value of zero.In both of these cases, pcbSize is set to the minimum size required for the pData buffer. Call GetLastError to identify any other errors.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern uint GetRawInputDeviceInfo(IntPtr hDevice, [MarshalAs(UnmanagedType.U4)] RAWINPUTDEVICEINFOFLAG uiCommand, [In, Out] IntPtr pData, [In, Out] ref uint pcbSize);

    /// <summary>
    /// Retrieves information about the raw input device.
    /// </summary>
    /// <param name="hDevice">A handle to the raw input device. This comes from the hDevice member of RAWINPUTHEADER or from GetRawInputDeviceList.</param>
    /// <param name="uiCommand">Specifies what data will be returned in pData.</param>
    /// <param name="pData">A pointer to a buffer that contains the information specified by uiCommand. If uiCommand is RIDI_DEVICEINFO, set the cbSize member of RID_DEVICE_INFO to sizeof(RID_DEVICE_INFO) before calling GetRawInputDeviceInfo.</param>
    /// <param name="pcbSize">The size, in bytes, of the data in pData.</param>
    /// <returns>If successful, this function returns a non-negative number indicating the number of bytes copied to pData. If pData is not large enough for the data, the function returns -1. If pData is NULL, the function returns a value of zero.In both of these cases, pcbSize is set to the minimum size required for the pData buffer. Call GetLastError to identify any other errors.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern int GetRawInputDeviceInfo(IntPtr hDevice, [MarshalAs(UnmanagedType.U4)] RAWINPUTDEVICEINFOFLAG uiCommand, [In, Out] RawInputDeviceInfo pData, [In, Out] ref int pcbSize);

    /// <summary>
    /// Enumerates the raw input devices attached to the system.
    /// </summary>
    /// <param name="pRawInputDeviceList">An array of RAWINPUTDEVICELIST structures for the devices attached to the system. If NULL, the number of devices are returned in *puiNumDevices.</param>
    /// <param name="puiNumDevices">If pRawInputDeviceList is NULL, the function populates this variable with the number of devices attached to the system; otherwise, this variable specifies the number of RAWINPUTDEVICELIST structures that can be contained in the buffer to which pRawInputDeviceList points. If this value is less than the number of devices attached to the system, the function returns the actual number of devices in this variable and fails with ERROR_INSUFFICIENT_BUFFER. If this value is greater than or equal to the number of devices attached to the system, then the value is unchanged, and the number of devices is reported as the return value.</param>
    /// <param name="cbSize">The size of a RAWINPUTDEVICELIST structure, in bytes.</param>
    /// <returns>If the function is successful, the return value is the number of devices stored in the buffer pointed to by pRawInputDeviceList. On any other error, the function returns (UINT)-1 and GetLastError returns the error indication.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern int GetRawInputDeviceList([In, Out] RAWINPUTDEVICELIST[] pRawInputDeviceList, [In, Out] ref int puiNumDevices, int cbSize);

    /// <summary>
    /// Retrieves the current color of the specified display element. Display elements are the parts of a window and the display that appear on the system display screen. https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsyscolor
    /// </summary>
    /// <param name="nIndex">The display element whose color is to be retrieved.</param>
    /// <returns>The function returns the red, green, blue (RGB) color value of the given element.
    /// If the nIndex parameter is out of range, the return value is zero.Because zero is also a valid RGB value, you cannot use GetSysColor to determine whether a system color is supported by the current platform.Instead, use the GetSysColorBrush function, which returns NULL if the color is not supported.</returns>
    [DllImport(Library)]
    public static extern uint GetSysColor(SYSCOLORINDEX nIndex);

    /// <summary>
    /// The GetSysColorBrush function retrieves a handle identifying a logical brush that corresponds to the specified color index. https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsyscolorbrush
    /// </summary>
    /// <param name="nIndex">A color index. This value corresponds to the color used to paint one of the window elements. See GetSysColor for system color index values.</param>
    /// <returns>The return value identifies a logical brush if the nIndex parameter is supported by the current platform. Otherwise, it returns NULL.</returns>
    [DllImport(Library)]
    public static extern uint GetSysColorBrush(uint nIndex);

    /// <summary>
    /// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory. 
    /// Note: To write code that is compatible with both 32-bit and 64-bit versions of Windows, use GetWindowLongPtr (instead of GetWindowLong). When compiling for 32-bit Windows, GetWindowLongPtr is defined as a call to the GetWindowLong function.
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">The zero-based offset to the value to be retrieved.</param>
    /// <returns>If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get extended error information, call GetLastError. If SetWindowLong or SetWindowLongPtr has not been called previously, GetWindowLongPtr returns zero for values in the extra window or class memory.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern UIntPtr GetWindowLongPtr(IntPtr hWnd, GWL nIndex);

    /// <summary>
    /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="lpRect">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    /// <summary>
    /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control containing the text.</param>
    /// <param name="lpString">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
    /// <param name="nMaxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
    /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the return value is zero. To get extended error information, call GetLastError. This function cannot retrieve the text of an edit control in another application.</returns>
    [DllImport(Library, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    /// <summary>
    /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). If the specified window is a control, the function retrieves the length of the text within the control. However, GetWindowTextLength cannot retrieve the length of the text of an edit control in another application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control.</param>
    /// <returns>If the function succeeds, the return value is the length, in characters, of the text. Under certain conditions, this value might be greater than the length of the text (see Remarks). If the window has no text, the return value is zero. Function failure is indicated by a return value of zero and a GetLastError result that is nonzero.</returns>
    [DllImport(Library, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    /// <summary>
    /// Determines the visibility state of the specified window.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be tested.</param>
    /// <returns>If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero. Because the return value specifies whether the window has the WS_VISIBLE style, it may be nonzero even if the window is totally obscured by other windows.</returns>
    [DllImport(Library)]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    /// <summary>
    /// Destroys the specified timer.
    /// </summary>
    /// <param name="hWnd">A handle to the window associated with the specified timer. This value must be the same as the hWnd value passed to the SetTimer function that created the timer.</param>
    /// <param name="uIDEvent">The timer to be destroyed. If the window handle passed to SetTimer is valid, this parameter must be the same as the nIDEvent value passed to SetTimer.If the application calls SetTimer with hWnd set to NULL, this parameter must be the timer identifier returned by SetTimer.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool KillTimer(IntPtr hWnd, UIntPtr uIDEvent);

    /// <summary>
    /// Creates a cursor based on data contained in a file.
    /// </summary>
    /// <param name="lpFileName">The source of the file data to be used to create the cursor. The data in the file must be in either .CUR or .ANI format. If the high-order word of lpFileName is nonzero, it is a pointer to a string that is a fully qualified name of a file containing cursor data.</param>
    /// <returns>If the function is successful, the return value is a handle to the new cursor. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr LoadCursorFromFile(string lpFileName);

    /// <summary>
    /// Loads an icon, cursor, animated cursor, or bitmap.
    /// </summary>
    /// <param name="hInst">A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see GetModuleHandle. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed by system function call of WinMain, and a module handle (HMODULE) are the same thing.
    /// To load an OEM image, set this parameter to NULL.
    /// To load a stand-alone resource (icon, cursor, or bitmap file) — for example, c:\myimage.bmp — set this parameter to NULL.</param>
    /// <param name="name"></param>
    /// <param name="type">The type of image to be loaded.</param>
    /// <param name="cx">The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used, the function uses the actual resource width.</param>
    /// <param name="cy">The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not used, the function uses the actual resource height.</param>
    /// <param name="fuLoad"></param>
    /// <returns>If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr LoadImage(IntPtr hInst, ushort name, IMAGE_TYPE type, int cx, int cy, IMAGE_FLAG fuLoad);

    /// <summary>
    /// Loads a standard windows icon.
    /// </summary>
    /// <param name="icon">The icon to use</param>
    /// <returns>If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    public static IntPtr LoadImage(PredefinedIcons icon) => LoadImage(IntPtr.Zero, (ushort)icon, IMAGE_TYPE.IMAGE_ICON, 0, 0, IMAGE_FLAG.LR_SHARED);

    /// <summary>
    /// Loads a standard windows cursor.
    /// </summary>
    /// <param name="cursor">The cursor to use</param>
    /// <returns>If the function succeeds, the return value is the handle of the newly loaded image. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    public static IntPtr LoadImage(PredefinedCursors cursor) => LoadImage(IntPtr.Zero, (ushort)cursor, IMAGE_TYPE.IMAGE_CURSOR, 0, 0, IMAGE_FLAG.LR_SHARED);

    /// <summary>
    /// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
    /// To specify a handle to the keyboard layout to use for translating the specified code, use the MapVirtualKeyEx function.
    /// </summary>
    /// <param name="uCode">The virtual key code or scan code for a key. How this value is interpreted depends on the value of the uMapType parameter.
    /// Starting with Windows Vista, the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code.</param>
    /// <param name="uMapType">The translation to be performed.</param>
    /// <returns>The return value is either a scan code, a virtual-key code, or a character value, depending on the value of uCode and uMapType. If there is no translation, the return value is zero.</returns>
    [DllImport(Library)]
    public static extern uint MapVirtualKey(VIRTUALKEYCODE uCode, VIRTUALKEYMAPTYPE uMapType);

    /// <summary>
    /// The MonitorFromWindow function retrieves a handle to the display monitor that has the largest area of intersection with the bounding rectangle of a specified window.
    /// </summary>
    /// <param name="hwnd">A handle to the window of interest.</param>
    /// <param name="dwFlags">Determines the function's return value if the window does not intersect any display monitor.</param>
    /// <returns>If the window intersects one or more display monitor rectangles, the return value is an HMONITOR handle to the display monitor that has the largest area of intersection with the window. If the window does not intersect a display monitor, the return value depends on the value of dwFlags.</returns>
    [DllImport(Library)]
    public static extern IntPtr MonitorFromWindow(IntPtr hwnd, MONITORFROMWINDOWFLAGS dwFlags);

    /// <summary>
    /// Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="X">The new position of the left side of the window.</param>
    /// <param name="Y">The new position of the top of the window.</param>
    /// <param name="nWidth">The new width of the window.</param>
    /// <param name="nHeight">The new height of the window.</param>
    /// <param name="bRepaint">Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    /// <summary>
    /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
    /// </summary>
    /// <param name="lpMsg">A pointer to an MSG structure that receives message information.</param>
    /// <param name="hWnd">A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
    /// If hWnd is NULL, PeekMessage retrieves messages for any window that belongs to the current thread, and any messages on the current thread's message queue whose hwnd value is NULL (see the MSG structure). Therefore if hWnd is NULL, both window messages and thread messages are processed.
    /// If hWnd is -1, PeekMessage retrieves only messages on the current thread's message queue whose hwnd value is NULL, that is, thread messages as posted by PostMessage (when the hWnd parameter is NULL) or PostThreadMessage.</param>
    /// <param name="wMsgFilterMin">The value of the first message in the range of messages to be examined. Use WM_KEYFIRST (0x0100) to specify the first keyboard message or WM_MOUSEFIRST (0x0200) to specify the first mouse message.
    /// If wMsgFilterMin and wMsgFilterMax are both zero, PeekMessage returns all available messages(that is, no range filtering is performed).</param>
    /// <param name="wMsgFilterMax">The value of the last message in the range of messages to be examined. Use WM_KEYLAST to specify the last keyboard message or WM_MOUSELAST to specify the last mouse message.
    /// If wMsgFilterMin and wMsgFilterMax are both zero, PeekMessage returns all available messages(that is, no range filtering is performed).</param>
    /// <param name="wRemoveMsg">Specifies how messages are to be handled.</param>
    /// <returns>If a message is available, the return value is nonzero. If no messages are available, the return value is zero.</returns>
    [DllImport(Library)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PeekMessage(ref MSG lpMsg, IntPtr hWnd, WINDOWMESSAGE wMsgFilterMin, WINDOWMESSAGE wMsgFilterMax, PEEKMESSAGEFLAGS wRemoveMsg);

    /// <summary>
    /// Places (posts) a message in the message queue associated with the thread that created the specified window and returns without waiting for the thread to process the message.
    /// To post a message in the message queue associated with a thread, use the PostThreadMessage function.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure is to receive the message.</param>
    /// <param name="Msg">The message to be posted. For lists of the system-provided messages, see System-Defined Messages.
    /// https://docs.microsoft.com/en-us/windows/win32/winmsg/about-messages-and-message-queues </param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.GetLastError returns ERROR_NOT_ENOUGH_QUOTA when the limit is hit.</returns>
    [DllImport(Library, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PostMessage(IntPtr hWnd, WINDOWMESSAGE Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Indicates to the system that a thread has made a request to terminate (quit). It is typically used in response to a WM_DESTROY message.
    /// </summary>
    /// <param name="nExitCode">The application exit code. This value is used as the wParam parameter of the WM_QUIT message.</param>
    [DllImport(Library)]
    public static extern void PostQuitMessage(int nExitCode);

    /// <summary>
    /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
    /// </summary>
    /// <param name="unnamedParam1">A pointer to a WNDCLASSEX structure. You must fill the structure with the appropriate class attributes before passing it to the function.</param>
    /// <returns>If the function succeeds, the return value is a class atom that uniquely identifies the class being registered. This atom can only be used by the CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, FindWindow, FindWindowEx, and UnregisterClass functions and the IActiveIMMap::FilterClientWindows method.
    /// If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern ushort RegisterClassEx(ref WNDCLASSEX unnamedParam1);

    /// <summary>
    /// Registers the device or type of device for which a window will receive notifications.
    /// </summary>
    /// <param name="hRecipient">A handle to the window or service that will receive device events for the devices specified in the NotificationFilter parameter. The same window handle can be used in multiple calls to RegisterDeviceNotification.
    /// Services can specify either a window handle or service status handle.</param>
    /// <param name="NotificationFilter">A pointer to a block of data that specifies the type of device for which notifications should be sent. This block always begins with the DEV_BROADCAST_HDR structure. The data following this header is dependent on the value of the dbch_devicetype member, which can be DBT_DEVTYP_DEVICEINTERFACE or DBT_DEVTYP_HANDLE. For more information, see Remarks.</param>
    /// <param name="Flags">This parameter can be one of the following values:
    /// DEVICE_NOTIFY_WINDOW_HANDLE: The hRecipient parameter is a window handle.
    /// DEVICE_NOTIFY_SERVICE_HANDLE: The hRecipient parameter is a service status handle.
    /// DEVICE_NOTIFY_ALL_INTERFACE_CLASSES: Notifies the recipient of device interface events for all device interface classes. (The dbcc_classguid member is ignored.) This value can be used only if the dbch_devicetype member is DBT_DEVTYP_DEVICEINTERFACE.
    /// </param>
    /// <returns>If the function succeeds, the return value is a device notification handle. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</remarks>
    [DllImport(Library)]
    public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, DEVICENOTIFYFLAGS Flags);

    /// <summary>
    /// Registers the devices that supply the raw input data.
    /// </summary>
    /// <param name="pRawInputDevices">An array of RAWINPUTDEVICE structures that represent the devices that supply the raw input.</param>
    /// <param name="uiNumDevices">The number of RAWINPUTDEVICE structures pointed to by pRawInputDevices.</param>
    /// <param name="cbSize">The size, in bytes, of a RAWINPUTDEVICE structure.</param>
    /// <returns>TRUE if the function succeeds; otherwise, FALSE. If the function fails, call GetLastError for more information.</returns>
    /// <remarks>To receive WM_INPUT messages, an application must first register the raw input devices using RegisterRawInputDevices. By default, an application does not receive raw input.
    /// To receive WM_INPUT_DEVICE_CHANGE messages, an application must specify the RIDEV_DEVNOTIFY flag for each device class that is specified by the usUsagePage and usUsage fields of the RAWINPUTDEVICE structure.By default, an application does not receive WM_INPUT_DEVICE_CHANGE notifications for raw input device arrival and removal.
    /// If a RAWINPUTDEVICE structure has the RIDEV_REMOVE flag set and the hwndTarget parameter is not set to NULL, then parameter validation will fail.
    /// Only one window per raw input device class may be registered to receive raw input within a process(the window passed in the last call to RegisterRawInputDevices). Because of this, RegisterRawInputDevices should not be used from a library, as it may interfere with any raw input processing logic already present in applications that load it</remarks>
    [DllImport(Library, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);

    /// <summary>
    /// Releases the mouse capture from a window in the current thread and restores normal mouse input processing. A window that has captured the mouse receives all mouse input, regardless of the position of the cursor, except when a mouse button is clicked while the cursor hot spot is in the window of another thread.
    /// </summary>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool ReleaseCapture();

    /// <summary>
    /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications. The effect of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
    /// <param name="hDC">A handle to the DC to be released.</param>
    /// <returns>The return value indicates whether the DC was released. If the DC was released, the return value is 1. If the DC was not released, the return value is zero.</returns>
    [DllImport(Library)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    /// <summary>
    /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message. To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function.To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows. Message sending is subject to UIPI.The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.</param>
    /// <param name="Msg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    [DllImport(Library, CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, WINDOWMESSAGE Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Sets the mouse capture to the specified window belonging to the current thread. SetCapture captures mouse input either when the mouse is over the capturing window, or when the mouse button was pressed while the mouse was over the capturing window and the button is still down. Only one window at a time can capture the mouse.
    /// If the mouse cursor is over a window created by another thread, the system will dRect mouse input to the specified window only if a mouse button is down.
    /// </summary>
    /// <param name="hWnd">A handle to the window in the current thread that is to capture the mouse.</param>
    /// <returns>The return value is a handle to the window that had previously captured the mouse. If there is no such window, the return value is NULL.</returns>
    [DllImport(Library)]
    public static extern IntPtr SetCapture(IntPtr hWnd);

    /// <summary>
    /// Sets the cursor shape.
    /// </summary>
    /// <param name="hCursor">
    /// A handle to the cursor. The cursor must have been created by the 
    /// CreateCursor function or loaded by the LoadCursor or LoadImage 
    /// function. If this parameter is IntPtr.Zero, the cursor is removed 
    /// from the screen.
    /// </param>
    /// <returns>The return value is the handle to the previous cursor, if there was one. If there was no previous cursor, the return value is null.</returns>
    /// <remarks>
    /// The cursor is set only if the new cursor is different from the 
    /// previous cursor; otherwise, the function returns immediately.
    /// 
    /// The cursor is a shared resource. A window should set the cursor 
    /// shape only when the cursor is in its client area or when the window 
    /// is capturing mouse input. In systems without a mouse, the window 
    /// should restore the previous cursor before the cursor leaves the 
    /// client area or before it relinquishes control to another window.
    /// 
    /// If your application must set the cursor while it is in a window, 
    /// make sure the class cursor for the specified window's class is set 
    /// to NULL. If the class cursor is not NULL, the system restores the 
    /// class cursor each time the mouse is moved.
    /// 
    /// The cursor is not shown on the screen if the internal cursor 
    /// display count is less than zero. This occurs if the application 
    /// uses the ShowCursor function to hide the cursor more times than to 
    /// show the cursor.
    /// </remarks>
    [DllImport(Library)]
    public static extern IntPtr SetCursor(IntPtr hCursor);

    /// <summary>
    /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
    /// </summary>
    /// <param name="X">The new x-coordinate of the cursor, in screen coordinates.</param>
    /// <param name="Y">The new y-coordinate of the cursor, in screen coordinates.</param>
    /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool SetCursorPos(int X, int Y);

    /// <summary>
    /// Sets the keyboard focus to the specified window. The window must be attached to the calling thread's message queue.
    /// </summary>
    /// <param name="hWnd">A handle to the window that will receive the keyboard input. If this parameter is NULL, keystrokes are ignored.</param>
    /// <returns>If the function succeeds, the return value is the handle to the window that previously had the keyboard focus. If the hWnd parameter is invalid or the window is not attached to the calling thread's message queue, the return value is NULL. To get extended error information, call GetLastError function. Extended error ERROR_INVALID_PARAMETER(0x57) means that window is in disabled state.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr SetFocus(IntPtr hWnd);

    /// <summary>
    /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
    /// </summary>
    /// <param name="hWnd">A handle to the window that should be activated and brought to the foreground.</param>
    /// <returns>If the window was brought to the foreground, the return value is nonzero. If the window was not brought to the foreground, the return value is zero.</returns>
    /// <remarks>The system restricts which processes can set the foreground window. An application cannot force a window to the foreground while the user is working with another window. Instead, Windows flashes the taskbar button of the window to notify the user. A process can set the foreground window only if one of the following conditions is true:
    /// <para>The process is the foreground process.</para>
    /// <para>The process was started by the foreground process.</para>
    /// <para>The process received the last input event.</para>
    /// <para>There is no foreground process.</para>
    /// <para>The process is being debugged.</para>
    /// <para>The foreground process is not a Modern Application or the Start Screen.</para>
    /// <para>The foreground is not locked (see LockSetForegroundWindow).</para>
    /// <para>The foreground lock time-out has expired(see SPI_GETFOREGROUNDLOCKTIMEOUT in SystemParametersInfo).</para>
    /// <para>No menus are active.</para></remarks>
    [DllImport(Library)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Changes the parent window of the specified child window.
    /// </summary>
    /// <param name="child">A handle to the child window.</param>
    /// <param name="newParent">A handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window. If this parameter is HWND_MESSAGE, the child window becomes a message-only window.</param>
    /// <returns>If the function succeeds, the return value is a handle to the previous parent window. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    /// <summary>
    /// Sets the process-default DPI awareness to system-DPI awareness. This is equivalent to calling SetProcessDpiAwarenessContext with a DPI_AWARENESS_CONTEXT value of DPI_AWARENESS_CONTEXT_SYSTEM_AWARE.
    /// </summary>
    /// <returns>If the function succeeds, the return value is nonzero. Otherwise, the return value is zero.</returns>
    [DllImport(Library)]
    public static extern bool SetProcessDPIAware();

    /// <summary>
    /// It is recommended that you set the process-default DPI awareness via application manifest. See Setting the default DPI awareness for a process for more information. Setting the process-default DPI awareness via API call can lead to unexpected application behavior. Sets the current process to a specified dots per inch(dpi) awareness context. The DPI awareness contexts are from the DPI_AWARENESS_CONTEXT value.
    /// </summary>
    /// <param name="value">A DPI_AWARENESS_CONTEXT handle to set.</param>
    /// <returns>This function returns TRUE if the operation was successful, and FALSE otherwise. To get extended error information, call GetLastError. Possible errors are ERROR_INVALID_PARAMETER for an invalid input, and ERROR_ACCESS_DENIED if the default API awareness mode for the process has already been set(via a previous API call or within the application manifest).</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool SetProcessDpiAwarenessContext(IntPtr value);

    /// <summary>
    /// It is recommended that you set the process-default DPI awareness via application manifest. See Setting the default DPI awareness for a process for more information. Setting the process-default DPI awareness via API call can lead to unexpected application behavior. Sets the current process to a specified dots per inch(dpi) awareness context. The DPI awareness contexts are from the DPI_AWARENESS_CONTEXT value.
    /// </summary>
    /// <param name="value">A DPI_AWARENESS_CONTEXT handle to set.</param>
    /// <returns>This function returns TRUE if the operation was successful, and FALSE otherwise. To get extended error information, call GetLastError. Possible errors are ERROR_INVALID_PARAMETER for an invalid input, and ERROR_ACCESS_DENIED if the default API awareness mode for the process has already been set(via a previous API call or within the application manifest).</returns>
    public static bool SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT value) => SetProcessDpiAwarenessContext(new IntPtr((int)value));

    /// <summary>
    /// Set the DPI awareness for the current thread to the provided value.
    /// </summary>
    /// <param name="dpiContext">The new DPI_AWARENESS_CONTEXT for the current thread. This context includes the DPI_AWARENESS value.</param>
    /// <returns>The old DPI_AWARENESS_CONTEXT for the thread. If the dpiContext is invalid, the thread will not be updated and the return value will be NULL. You can use this value to restore the old DPI_AWARENESS_CONTEXT after overriding it with a predefined value.</returns>
    [DllImport(Library)]
    public static extern IntPtr SetThreadDpiAwarenessContext(IntPtr dpiContext);

    /// <summary>
    /// Set the DPI awareness for the current thread to the provided value.
    /// </summary>
    /// <param name="dpiContext">The new DPI_AWARENESS_CONTEXT for the current thread. This context includes the DPI_AWARENESS value.</param>
    /// <returns>The old DPI_AWARENESS_CONTEXT for the thread. If the dpiContext is invalid, the thread will not be updated and the return value will be NULL. You can use this value to restore the old DPI_AWARENESS_CONTEXT after overriding it with a predefined value.</returns>
    public static IntPtr SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT dpiContext) => SetThreadDpiAwarenessContext(new IntPtr((int)dpiContext));

    /// <summary>
    /// Creates a timer with the specified time-out value.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be associated with the timer. This window must be owned by the calling thread. If a NULL value for hWnd is passed in along with an nIDEvent of an existing timer, that timer will be replaced in the same way that an existing non-NULL hWnd timer will be.</param>
    /// <param name="nIDEvent">A nonzero timer identifier. If the hWnd parameter is NULL, and the nIDEvent does not match an existing timer then it is ignored and a new timer ID is generated. If the hWnd parameter is not NULL and the window specified by hWnd already has a timer with the value nIDEvent, then the existing timer is replaced by the new timer. When SetTimer replaces a timer, the timer is reset. Therefore, a message will be sent after the current time-out value elapses, but the previously set time-out value is ignored. If the call is not intended to replace an existing timer, nIDEvent should be 0 if the hWnd is NULL.</param>
    /// <param name="uElapse">The time-out value, in milliseconds. If uElapse is less than USER_TIMER_MINIMUM(0x0000000A), the timeout is set to USER_TIMER_MINIMUM.If uElapse is greater than USER_TIMER_MAXIMUM(0x7FFFFFFF), the timeout is set to USER_TIMER_MAXIMUM.</param>
    /// <param name="lpTimerFunc">A pointer to the function to be notified when the time-out value elapses. For more information about the function, see TimerProc. If lpTimerFunc is NULL, the system posts a WM_TIMER message to the application queue. The hwnd member of the message's MSG structure contains the value of the hWnd parameter.</param>
    /// <returns>If the function succeeds and the hWnd parameter is NULL, the return value is an integer identifying the new timer. An application can pass this value to the KillTimer function to destroy the timer. If the function succeeds and the hWnd parameter is not NULL, then the return value is a nonzero integer.An application can pass the value of the nIDEvent parameter to the KillTimer function to destroy the timer. If the function fails to create a timer, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, TimerProc lpTimerFunc);

    /// <summary>
    /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order.</param>
    /// <param name="X">The new position of the left side of the window, in client coordinates.</param>
    /// <param name="Y">The new position of the top of the window, in client coordinates.</param>
    /// <param name="cx">The new width of the window, in pixels.</param>
    /// <param name="cy">The new height of the window, in pixels.</param>
    /// <param name="uFlags">The window sizing and positioning flags.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SETWINDOWPOSFLAGS uFlags);

    /// <summary>
    /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, the text of the control is changed. However, SetWindowText cannot change the text of a control in another application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
    /// <param name="lpString">The new title or control text.</param>
    /// <returns> If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    /// <remarks>If the target window is owned by the current process, SetWindowText causes a WM_SETTEXT message to be sent to the specified window or control. If the control is a list box control created with the WS_CAPTION style, however, SetWindowText sets the text for the control, not for the list box entries. 
    /// To set the text of a control in another process, send the WM_SETTEXT message directly instead of calling SetWindowText.
    /// The SetWindowText function does not expand tab characters (ASCII code 0x09). Tab characters are displayed as vertical bar(|) characters.</remarks>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool SetWindowText(IntPtr hWnd, string lpString);

    /// <summary>
    /// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory. 
    /// Note: To write code that is compatible with both 32-bit and 64-bit versions of Windows, use SetWindowLongPtr. When compiling for 32-bit Windows, SetWindowLongPtr is defined as a call to the SetWindowLong function.
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.</param>
    /// <param name="nIndex">The zero-based offset to the value to be set.</param>
    /// <param name="dwNewLong">The replacement value.</param>
    /// <returns>If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value is zero.To get extended error information, call GetLastError. If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call SetWindowLongPtr.Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, GWL nIndex, IntPtr dwNewLong);

    /// <summary>
    /// Displays or hides the cursor.
    /// </summary>
    /// <param name="show">If bShow is TRUE, the display count is incremented by one. If bShow is FALSE, the display count is decremented by one.</param>
    /// <returns>The return value specifies the new display counter.</returns>
    /// <remarks>This function sets an internal display counter that determines whether the cursor should be displayed. The cursor is displayed only if the display count is greater than or equal to 0. If a mouse is installed, the initial display count is 0. If no mouse is installed, the display count is –1.</remarks>
    [DllImport(Library)]
    public static extern int ShowCursor(bool show);

    /// <summary>
    /// Sets the specified window's show state.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="nCmdShow">Controls how the window is to be shown. This parameter is ignored the first time an application calls ShowWindow, if the program that launched the application provides a STARTUPINFO structure. Otherwise, the first time ShowWindow is called, the value should be the value obtained by the WinMain function in its nCmdShow parameter.</param>
    /// <returns>If the window was previously visible, the return value is nonzero. If the window was previously hidden, the return value is zero.</returns>
    [DllImport(Library)]
    public static extern bool ShowWindow(IntPtr hWnd, SHOWWINDOWCOMMAND nCmdShow);

    /// <summary>
    /// Translates virtual-key messages into character messages. The character messages are posted to the calling thread's message queue, to be read the next time the thread calls the GetMessage or PeekMessage function.
    /// </summary>
    /// <param name="lpMsg">A pointer to an MSG structure that contains message information retrieved from the calling thread's message queue by using the GetMessage or PeekMessage function.</param>
    /// <returns>If the message is translated (that is, a character message is posted to the thread's message queue), the return value is nonzero.
    /// If the message is WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, the return value is nonzero, regardless of the translation.
    /// If the message is not translated (that is, a character message is not posted to the thread's message queue), the return value is zero.</returns>
    [DllImport(Library)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool TranslateMessage(ref MSG lpMsg);

    /// <summary>
    /// Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time.
    /// </summary>
    /// <param name="lpEventTrack">A pointer to a TRACKMOUSEEVENT structure that contains tracking information.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

    /// <summary>
    /// Unregisters a window class, freeing the memory required for the class.
    /// </summary>
    /// <param name="className">A null-terminated string or a class atom. If lpClassName is a string, it specifies the window class name. This class name must have been registered by a previous call to the RegisterClass or RegisterClassEx function. System classes, such as dialog box controls, cannot be unregistered. If this parameter is an atom, it must be a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.</param>
    /// <param name="instance">A handle to the instance of the module that created the class.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the class could not be found or if a window still exists that was created with the class, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern short UnregisterClass(IntPtr className, IntPtr instance);

    /// <summary>
    /// Closes the specified device notification handle.
    /// </summary>
    /// <param name="handle">Device notification handle returned by the RegisterDeviceNotification function.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool UnregisterDeviceNotification(IntPtr handle);

    /// <summary>
    /// The UpdateWindow function updates the client area of the specified window by sending a WM_PAINT message to the window if the window's update region is not empty. The function sends a WM_PAINT message directly to the window procedure of the specified window, bypassing the application queue. If the update region is empty, no message is sent.
    /// </summary>
    /// <param name="hWnd">Handle to the window to be updated.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
    [DllImport(Library)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UpdateWindow(IntPtr hWnd);
}