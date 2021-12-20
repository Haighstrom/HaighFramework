using System;
using System.Runtime.InteropServices;
using HaighFramework;
using HaighFramework.Win32API;
using HaighFramework.OpenGL4;
using HaighFramework.DisplayDevices;

namespace HaighFramework.Window
{
    public class HaighWindow : IWindow
    {
        #region Static
        protected static readonly object _syncRoot = new object();
        #endregion

        #region Constants
        private const WindowStyle DEFAULT_STYLE = WindowStyle.WS_OVERLAPPEDWINDOW | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS;
        private const ExtendedWindowStyle DEFAULT_STYLE_EX = ExtendedWindowStyle.WS_EX_APPWINDOW | ExtendedWindowStyle.WS_EX_WINDOWEDGE;
        private const WindowClassStyle DEFAULT_CLASS_STYLE = WindowClassStyle.CS_DBLCLKS;
        #endregion

        #region Fields
        private readonly IntPtr _instance = Marshal.GetHINSTANCE(typeof(HaighWindow).Module);
        private readonly IntPtr _className = Marshal.StringToHGlobalAuto(Guid.NewGuid().ToString());
        private bool _classRegistered;
        private readonly WNDPROC _wndProc; //only store this so it doesn't get garbage collected...
        private MSG _msg;
        private IRect<float> _windowPosition, _clientPosition;
        private WindowStyle _style;
        private ExtendedWindowStyle _exStyle;
        private bool _disposed = false;
        private BorderStyle _windowBorder;
        private WindowState _windowState;
        private Cursor _cursor;
        private bool _cursorVisible = true;
        private bool _cursorLockedToWindow = false;
        private bool _mouseOutsideWindow = true; //true so that OnMouseEnter fires the first time the mouse is moved even if on the window initially
        private bool _invisible_since_creation = true;
        private VSyncMode _vSyncMode = VSyncMode.On;
        #endregion

        #region Constructors
        public HaighWindow(int x, int y, int width, int height, string title, bool resizable, int openGLMajorVersion = 4, int openGLMinorVersion = 0, WindowCreationFlags windowCreationFlags = WindowCreationFlags.None)
        {
            _wndProc = StandardWindowProcedure;

            WindowHandle = CreateWindow(x, y, width, height, title, resizable, IntPtr.Zero);
            ChildWindowHandle = CreateWindow(x, y, width, height, title, resizable, WindowHandle);

            OpenGLMajorVersion = openGLMajorVersion;
            OpenGLMinorVersion = openGLMinorVersion;

            DeviceContext = User32.GetDC(ChildWindowHandle);

            if (DeviceContext == IntPtr.Zero)
                throw new Exception(String.Format("Failed to create device context: {0}", Marshal.GetLastWin32Error()));

            RenderContext = CreateRenderContext(openGLMajorVersion, openGLMinorVersion);

            OpenGL.WGLMakeCurrent(DeviceContext, RenderContext);

            string version = OpenGL.GetString(GetStringEnum.Version).Remove(9);
            HConsole.Log("Successfully set up OpenGL v:{0}, GLSL: {1}", version, OpenGL.GetString(GetStringEnum.ShadingLanguageVersion));
            HConsole.Log("Graphics Vendor: {0}", OpenGL.GetString(GetStringEnum.Vendor));
            HConsole.Log("Graphics Card: {0}", OpenGL.GetString(GetStringEnum.Renderer));

            VSyncMode = VSyncMode.Off;

            if (!windowCreationFlags.HasFlag(WindowCreationFlags.InvisibleOnCreation))
            {
                _invisible_since_creation = false;
                User32.ShowWindow(WindowHandle, ShowWindowCommand.SHOW);
            }
            else
            {
                Visible = false;
                _clientPosition = new Rect(x, y, width, height);
            }

            User32.UpdateWindow(WindowHandle);
        }

        #endregion

        #region Properties
        public IntPtr WindowHandle { get; private set; }
        public IntPtr ChildWindowHandle { get; private set; }
        public IntPtr DeviceContext { get; private set; }
        public IntPtr RenderContext { get; private set; }

        public bool IsRunning { get; private set; }
        internal static int OpenGLMajorVersion { get; private set; }
        internal static int OpenGLMinorVersion { get; private set; }

        #region Title
        /// <summary>
        /// Title of the Window, shown in the menu bar at the top
        /// </summary>
        public string Title
        {
            get
            {
                System.Text.StringBuilder sb_title = new System.Text.StringBuilder(256);
                sb_title.Remove(0, sb_title.Length);
                if (User32.GetWindowText(WindowHandle, sb_title, sb_title.Capacity) == 0)
                    HConsole.Warning("Failed to retrieve window title (window:{0}, reason:{1}).", WindowHandle, Marshal.GetLastWin32Error());

                return sb_title.ToString();
            }
            set
            {
                if (Title != value)
                {
                    if (!User32.SetWindowText(WindowHandle, value))
                        HConsole.Warning("Failed to change window title (window:{0}, new title:{1}, reason:{2}).", WindowHandle, value, Marshal.GetLastWin32Error());
                }
            }
        }
        #endregion

        #region VSyncMode
        public VSyncMode VSyncMode
        {
            get => _vSyncMode;
            set
            {
                OpenGL.SwapIntervalEXT((int)value);
                _vSyncMode = value;
            }
        }
        #endregion

        #region Position
        public IRect<float> Position
        {
            get => _windowPosition;
            set
            {
                var r = new RECT() { left = (int)value.X, right = (int)value.Right, top = (int)value.Y, bottom = (int)value.Bottom };
                User32.SetWindowPos(WindowHandle, new IntPtr(0), r.left, r.top, r.Width, r.Height, SetWindowPosFlags.NOREDRAW);

                _windowPosition = value;

                //compute just the border size (from a zero client), and subtract this from the requested value to get the client value
                r = new RECT();
                User32.AdjustWindowRectEx(ref r, _style, false, _exStyle);

                _clientPosition = new Rect<float>(value.X - r.left, value.Y - r.top, value.W - r.Width, value.H - r.Height);
            }
        }
        #endregion

        #region ClientPosition
        public IRect<float> ClientPosition
        {
            get => _clientPosition;
            set
            {
                var r = new RECT() { left = (int)value.X, right = (int)value.Right, top = (int)value.Y, bottom = (int)value.Bottom };
                User32.AdjustWindowRectEx(ref r, _style, false, _exStyle);
                User32.SetWindowPos(WindowHandle, new IntPtr(0), r.left, r.top, r.Width, r.Height, SetWindowPosFlags.NOREDRAW);
                _clientPosition = value;
                _windowPosition = new Rect<float>(r.left, r.top, r.Width, r.Height);
            }
        }
        #endregion

        public IRect<float> ClientZeroed => ClientPosition.Zeroed;

        #region ClientSize
        public IPoint<float> ClientSize
        {
            get => _clientPosition.Size;
            set => ClientPosition = new Rect<float>(X, Y, value.X, value.Y);
        }
        #endregion

        #region X
        public int X
        {
            get => (int)_clientPosition.X;
            set => ClientPosition = new Rect(value, Y, Width, Height);
        }
        #endregion

        #region Y
        public int Y
        {
            get
            {
                return (int)_clientPosition.Y;
            }

            set
            {
                ClientPosition = new Rect<float>(X, value, Width, Height);
            }
        }
        #endregion

        #region Width
        public int Width
        {
            get
            {
                return (int)_clientPosition.W;
            }

            set
            {
                ClientPosition = new Rect(X, Y, value, Height);
            }
        }
        #endregion

        #region Height
        public int Height
        {
            get
            {
                return (int)_clientPosition.H;
            }

            set
            {
                ClientPosition = new Rect(X, Y, Width, value);
            }
        }
        #endregion

        public int MinHeight { get; set; } = 0;
        public int MaxHeight { get; set; } = 0;
        public int MinWidth { get; set; } = 0;
        public int MaxWidth { get; set; } = 0;

        #region IsFocussed
        public bool IsFocussed { get; private set; }
        #endregion

        #region CursorVisible
        /// <summary>
        /// Is the windows cursor associated with this Window visible? Gets or Sets.
        /// </summary>
        public bool CursorVisible
        {
            get => _cursorVisible;
            set
            {
                //Check if cursor is currently visible. Show Cursor increments or decrements an int rather than setting a bool, so we dont want to call it erroneously
                if (_cursorVisible != value)
                    User32.ShowCursor(value);

                _cursorVisible = value;
            }
        }
        #endregion

        #region Cursor
        public Cursor Cursor
        {
            get => _cursor;
            set
            {
                if (value == _cursor)
                    return;

                var old = _cursor;

                if (value == null)
                    CursorVisible = false;
                else
                {
                    CursorVisible = true;

                    User32.SetCursor(value.HCursor);
                    User32.SetClassLong(WindowHandle, NIndex.HCursor, value.HCursor);
                }

                if (old != Cursor.Default)
                    old.Dispose();

                _cursor = value;
            }
        }
        #endregion

        #region Icon
        public System.Drawing.Icon Icon
        {
            set
            {
                User32.SendMessage(WindowHandle, WindowMessage.WM_SETICON, (IntPtr)0, value == null ? IntPtr.Zero : value.Handle);
                User32.SendMessage(WindowHandle, WindowMessage.WM_SETICON, (IntPtr)1, value == null ? IntPtr.Zero : value.Handle);
            }
        }
        #endregion

        #region Visible
        public bool Visible
        {
            get
            {
                return User32.IsWindowVisible(WindowHandle);
            }
            set
            {
                if (value != Visible)   //Only do anything if there is a change in the visible value
                {
                    if (value)
                    {
                        User32.ShowWindow(WindowHandle, ShowWindowCommand.SHOW);

                        if (_invisible_since_creation)
                        {
                            User32.BringWindowToTop(WindowHandle);
                            User32.SetForegroundWindow(WindowHandle);
                        }
                    }
                    else if (!value)
                    {
                        User32.ShowWindow(WindowHandle, ShowWindowCommand.HIDE);
                    }

                    //Trigger Visible Changed event
                    VisibleChanged?.Invoke(this, new BoolEventArgs(value));
                }
            }
        }
        #endregion

        #region CursorLockedToWindow
        public bool CursorLockedToWindow
        {
            get => _cursorLockedToWindow;
            set
            {
                if (CursorLockedToWindow == value)
                    return;

                if (value)
                {
                    if (WindowBorder == BorderStyle.SizingBorder)
                    {
                        WindowBorder = BorderStyle.Border;
                        HConsole.Warning("Cursor locking incompatible with Resizeable window, changing to Fixed.");
                    }

                    RECT r = new() { left = (int)_clientPosition.X, top = (int)_clientPosition.Y, right = (int)_clientPosition.Right, bottom = (int)_clientPosition.Bottom };
                    User32.ClipCursor(ref r);
                }
                else
                {
                    User32.ClipCursor(IntPtr.Zero);
                }
                _cursorLockedToWindow = value;
            }
        }
        #endregion

        #region WindowBorder
        public BorderStyle WindowBorder
        {
            get => _windowBorder;
            set
            {
                //Return if nothing has changed
                if (_windowBorder == value)
                    return;

                // Do not allow border changes during fullscreen mode.
                if (WindowState == WindowState.Fullscreen)
                    throw new HException("To keep things simple, it is not allowed to change border style while in Fullscreen WindowState");

                // To ensure maximized/minimized windows work correctly, reset state to normal,
                // change the border, then go back to maximized/minimized.
                WindowState state = WindowState;
                WindowState = WindowState.Normal;

                WindowStyle new_style = (WindowStyle)User32.GetWindowLong(WindowHandle, GWL.GWL_STYLE);

                switch (value)
                {
                    case BorderStyle.SizingBorder:
                        new_style |= WindowStyle.WS_OVERLAPPEDWINDOW;
                        break;

                    case BorderStyle.Border:
                        new_style &= ~(WindowStyle.WS_THICKFRAME | WindowStyle.WS_MAXIMIZEBOX | WindowStyle.WS_SIZEBOX);
                        break;

                    case BorderStyle.NoBorder:
                        new_style &= ~(WindowStyle.WS_CAPTION | WindowStyle.WS_THICKFRAME | WindowStyle.WS_MINIMIZE | WindowStyle.WS_MAXIMIZE | WindowStyle.WS_SYSMENU);
                        break;
                }

                // Make sure client size doesn't change when changing the border style.
                RECT rect = new() { right = (int)ClientSize.X, bottom = (int)ClientSize.Y };
                User32.AdjustWindowRectEx(ref rect, new_style, false, ExtendedWindowStyle.WS_EX_WINDOWEDGE | ExtendedWindowStyle.WS_EX_APPWINDOW);


                //Visible = false;
                User32.SetWindowLong(WindowHandle, GWL.GWL_STYLE, new IntPtr((int)new_style));
                User32.SetWindowPos(WindowHandle, IntPtr.Zero, 0, 0, rect.Width, rect.Height, SetWindowPosFlags.NOMOVE | SetWindowPosFlags.NOZORDER | SetWindowPosFlags.FRAMECHANGED);

                //Visible = true;

                WindowState = state;

                //Trigger BorderChanged event
                BorderChanged?.Invoke(this, new BorderChangeEventArgs(value, _windowBorder));

                //Assign private property to new value
                _windowBorder = value;
            }
        }
        #endregion

        #region WindowState
        public WindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                if (_windowState == value)
                    return;

                switch (value)
                {
                    case WindowState.Normal:
                        User32.ShowWindow(WindowHandle, ShowWindowCommand.RESTORE);
                        break;

                    case WindowState.Maximized:
                        // Note: if we use the MAXIMIZE command and the window border is Hidden (i.e. WS_POPUP),
                        // we will enter fullscreen mode - we don't want that! As a workaround, we'll resize the window
                        // manually to cover the whole working area of the current monitor.

                        // Reset state to avoid strange interactions with fullscreen/minimized windows.
                        WindowState = WindowState.Normal;
                        User32.ShowWindow(WindowHandle, ShowWindowCommand.MAXIMIZE);
                        break;

                    case WindowState.Minimized:
                        User32.ShowWindow(WindowHandle, ShowWindowCommand.MINIMIZE);
                        break;

                    case WindowState.Fullscreen:
                        // We achieve fullscreen by hiding the window border and sending the MAXIMIZE command.
                        // We cannot use the WindowState.Maximized directly, as that will not send the MAXIMIZE
                        // command for windows with hidden borders.

                        // Reset state to avoid strange side-effects from maximized/minimized windows.
                        WindowState = WindowState.Normal;

                        WindowBorder = BorderStyle.NoBorder;
                        User32.ShowWindow(WindowHandle, ShowWindowCommand.MAXIMIZE);

                        User32.SetForegroundWindow(WindowHandle);

                        break;

                    default:
                        throw new NotImplementedException("Unsupported WindowState type " + value);
                }

                //Trigger StateChanged Event
                StateChanged?.Invoke(this, new WindowStateChangeEventArgs(value, _windowState));

                _windowState = value;
            }
        }
        #endregion

        public bool CloseWhenXPressed { get; set; } = true;
        #endregion

        #region Methods
        #region CreateWindow
        private IntPtr CreateWindow(int x, int y, int width, int height, string title, bool resizable, IntPtr parent)
        {
            //remember some construction code occurs in WM_CREATE

            RECT rect = new RECT()
            {
                left = x,
                top = y,
                right = x + width,
                bottom = y + height
            };
            if (!_classRegistered)
            {
                WNDCLASSEX wc = new()
                {
                    cbSize = (uint)Marshal.SizeOf(default(WNDCLASSEX)),
                    style = DEFAULT_CLASS_STYLE,
                    lpfnWndProc = _wndProc,
                    hInstance = _instance,
                    hIcon = User32.LoadImage(PredefinedIcons.IDI_APPLICATION),
                    hCursor = User32.LoadImage(PredefinedCursors.IDC_ARROW),
                    lpszClassName = _className,
                    hIconSm = User32.LoadImage(PredefinedIcons.IDI_WINLOGO)
                };
                if (User32.RegisterClassEx(ref wc) == 0)
                    throw new HException("Failed to register window class. Error: {0}", Marshal.GetLastWin32Error());

                _classRegistered = true;
            }

            WindowStyle style;
            ExtendedWindowStyle exStyle;

            if (parent == IntPtr.Zero)
            {
                if (resizable)
                {
                    style = DEFAULT_STYLE;
                    _windowBorder = BorderStyle.SizingBorder;
                }
                else
                {
                    style = WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS;
                    style |= WindowStyle.WS_OVERLAPPEDWINDOW & ~(WindowStyle.WS_THICKFRAME | WindowStyle.WS_MAXIMIZEBOX | WindowStyle.WS_SIZEBOX);
                    _windowBorder = BorderStyle.Border;
                }
                _style = style;
                _exStyle = exStyle = DEFAULT_STYLE_EX;
            }
            else
            {
                style = WindowStyle.WS_VISIBLE | WindowStyle.WS_CHILD | WindowStyle.WS_CLIPSIBLINGS;
                exStyle = 0;
            }

            //make the size specified EXCLUDE windows borders etc (automatically compensated for appropriately by the flags for parent/child)
            User32.AdjustWindowRectEx(ref rect, style, false, exStyle);

            IntPtr windowName = Marshal.StringToHGlobalAuto(title);

            IntPtr handle = User32.CreateWindowEx(exStyle, _className, windowName, style, rect.left, rect.top, rect.Width, rect.Height, parent, IntPtr.Zero, _instance, IntPtr.Zero);

            if (handle == IntPtr.Zero)
                throw new HException("Failed to create window. Error: {0}", Marshal.GetLastWin32Error());

            return handle;
        }
        #endregion

        #region CreateRenderContext
        public IntPtr CreateRenderContext(int major, int minor)
        {
            IntPtr renderContext;

            if (major < 1 || minor < 0)
                throw new HException("invalid GL version to create: {0}.{1}.", major, minor);

            lock (_syncRoot)
            {
                HConsole.Log("Creating GL Context: Requested Version {0}.{1}", major, minor);

                SetUpPixelFormat(DeviceContext);

                //create temp context to be able to call wglGetProcAddress
                IntPtr tempContext = OpenGL32.wglCreateContext(DeviceContext);
                if (tempContext == IntPtr.Zero)
                    throw new Exception("tempContext failed to create.");
                if (!OpenGL32.wglMakeCurrent(DeviceContext, tempContext))
                    throw new Exception("wglMakeCurrent Failed");

                OpenGL.LoadWGLExtensions();

                int[] attribs = {
                    (int)ArbCreateContext.MajorVersion, major,
                    (int)ArbCreateContext.MinorVersion, minor,
                    (int)ArbCreateContext.ProfileMask, (int)ArbCreateContext.ForwardCompatibleBit,
                    0 };

                renderContext = OpenGL.CreateContextAttribsARB(DeviceContext, IntPtr.Zero, attribs);
                if (renderContext == IntPtr.Zero)
                    throw new HException("Something went wrong with wglCreateContextAttribsARB: {0}", Marshal.GetLastWin32Error());

                OpenGL.LoadOpenGL3Extensions();

                OpenGL32.wglDeleteContext(tempContext);
            }

            return renderContext;
        }
        #endregion

        #region MakeFocussed
        public void MakeFocussed()
        {
            if (!IsFocussed)
            {
                User32.SetFocus(WindowHandle);
                User32.BringWindowToTop(WindowHandle);
                User32.SetForegroundWindow(WindowHandle);
            }
            else
                HConsole.Warning("Tried to focus the window when it was already focussed.");
        }
        #endregion

        #region SetIcon 
        /// <summary>
        /// Set the Icon that will appear at the top left of the window menu bar, and also on the windows taskbar.
        /// </summary>
        /// <param name="path">Path, including extension</param>
        public void SetIcon(string path)
        {
            //Verify file exists at this path
            if (!System.IO.File.Exists(path))
                throw new HException("Icon file at {0} does not exist", path);

            //Verify the file is an .ico file
            if (System.IO.Path.GetExtension(path) != ".ico")
                throw new HException("SetIcon only supports .ico files, recieved {0}", path);

            //Create a System Drawing Icon object from the file
            System.Drawing.Icon icon = new System.Drawing.Icon(path);

            //Send messages to the windows procedure to associate that icon with this window. This seems to somehow apply it to the console window too, which is a boon
            User32.SendMessage(WindowHandle, WindowMessage.WM_SETICON, (IntPtr)0, icon.Handle);
            User32.SendMessage(WindowHandle, WindowMessage.WM_SETICON, (IntPtr)1, icon.Handle);
        }
        #endregion

        #region SetRenderContext
        /// <summary>
        /// Assign a new render context to this window. It is reccomended to then make it current on the window thread. Returns the current Render cotnext so that it can be deleted if desired.
        /// </summary>
        /// <param name="newContext"></param>
        /// <returns></returns>
        public IntPtr SetRenderContext(IntPtr newContext)
        {
            IntPtr oldContext = RenderContext;
            RenderContext = newContext;
            return oldContext;
        }
        #endregion

        #region SetUpPixelFormat
        private static void SetUpPixelFormat(IntPtr deviceContextHandle)
        {
            PixelFormatDescriptor pfd = new PixelFormatDescriptor();
            pfd.Flags = PixelFormatDescriptor.FLAGS.SUPPORT_OPENGL |
             PixelFormatDescriptor.FLAGS.DRAW_TO_WINDOW |
             PixelFormatDescriptor.FLAGS.DOUBLEBUFFER;
            pfd.PixelType = PixelFormatDescriptor.TYPE.RGBA;
            pfd.ColorBits = 24;
            pfd.AlphaBits = 8;
            pfd.DepthBits = 24;
            pfd.StencilBits = 8;
            pfd.LayerType = (byte)PIXELFORMATDESCRIPTOR.LAYER_TYPE.MAIN_PLANE;

            int pixelFormat = GDI32.ChoosePixelFormat(deviceContextHandle, pfd);

            if (!GDI32.SetPixelFormat(deviceContextHandle, pixelFormat, ref pfd))
                throw new Exception(String.Format("Failed to set pixel format: {0}", Marshal.GetLastWin32Error()));
        }
        #endregion

        #region StandardWindowProcedure
        internal IntPtr StandardWindowProcedure(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
        {
            IntPtr? result = null;

            switch (message)
            {
                #region CREATE/CLOSE/DESTROY

                case WindowMessage.WM_CREATE:
                    IsRunning = true;
                    break;

                case WindowMessage.WM_DESTROY:
                case WindowMessage.WM_CLOSE: //recieved when Window X is pressed
                    Closing(this, EventArgs.Empty);

                    if (CloseWhenXPressed)
                        Close();

                    return IntPtr.Zero;
                #endregion

                #region Input
                case WindowMessage.WM_CHAR:
                    OnCharEntered(handle, message, wParam, lParam);
                    break;

                case WindowMessage.WM_KEYDOWN:
                case WindowMessage.WM_SYSKEYDOWN:
                    OnKeyDown(handle, message, wParam, lParam);
                    return IntPtr.Zero;
                case WindowMessage.WM_KEYUP:
                case WindowMessage.WM_SYSKEYUP:
                    OnKeyUp(handle, message, wParam, lParam);
                    return IntPtr.Zero;
                case WindowMessage.WM_MOUSEMOVE:   //This only triggers when mouse is over the window, so we can cleverly trigger OnMouseEntered off of this - See OnMouseMove
                    OnMouseMove();
                    break;
                case WindowMessage.WM_MOUSELEAVE:  //Note this guy doesn't actually get thrown by the windows procedure unless we've called EnableMouseTracking - See OnMouseMove
                    OnMouseLeave();
                    break;
                case WindowMessage.WM_LBUTTONDOWN:
                    break;
                case WindowMessage.WM_LBUTTONUP:
                    break;
                #region LBUTTONDBLCLK
                case WindowMessage.WM_LBUTTONDBLCLK:
                    MouseLeftDoubleClicked?.Invoke(this, EventArgs.Empty);
                    break;
                #endregion
                #endregion

                #region MOVE
                case WindowMessage.WM_MOVE:
                    SetWindowRects();
                    OnMoved();
                    break;
                #endregion

                #region SIZE
                case WindowMessage.WM_SIZE:
                    SetWindowRects();
                    int width = unchecked((short)(long)lParam);
                    int height = unchecked((short)((long)lParam >> 16));
                    OnResize(width, height);
                    break;
                #endregion

                #region SETFOCUS / KILLFOCUS
                case WindowMessage.WM_SETFOCUS:
                    OnFocusChanged(true);
                    break;
                case WindowMessage.WM_KILLFOCUS:
                    OnFocusChanged(false);
                    break;
                    #endregion
            }

            if (result.HasValue)
                return result.Value;
            else
                return User32.DefWindowProc(handle, message, wParam, lParam);
        }
        #endregion

        #region SetWindowRects
        private void SetWindowRects()
        {
            User32.GetWindowRect(WindowHandle, out RECT r);
            _windowPosition = new Rect(r.left, r.top, r.Width, r.Height);

            User32.GetClientRect(WindowHandle, out r);
            System.Drawing.Point p = new System.Drawing.Point();
            User32.ClientToScreen(WindowHandle, ref p);
            _clientPosition = new Rect(p.X, p.Y, r.Width, r.Height);
        }
        #endregion

        #region OnCharEntered
        private void OnCharEntered(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
        {
            char c;
            if (IntPtr.Size == 4)
                c = (char)wParam.ToInt32();
            else
                c = (char)wParam.ToInt64();

            if (!Char.IsControl(c))
            {
                CharEntered?.Invoke(this, new Input.KeyboardCharEventArgs(c));
            }
        }
        #endregion

        #region OnClosed
        private void OnClosed()
        {
            Closed(this, EventArgs.Empty);
        }
        #endregion

        #region OnFocusChanged
        protected void OnFocusChanged(bool focussed)
        {
            IsFocussed = focussed;

            if (_cursorLockedToWindow)
            {
                if (focussed)
                {
                    RECT r = new() { left = (int)_clientPosition.X, top = (int)_clientPosition.Y, right = (int)_clientPosition.Right, bottom = (int)_clientPosition.Bottom };
                    User32.ClipCursor(ref r);
                }
                else
                    User32.ClipCursor(IntPtr.Zero);
            }

            FocusChanged(this, new BoolEventArgs(focussed));
        }
        #endregion

        #region OnKeyDown
        private void OnKeyDown(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
        {
            bool extended = (lParam.ToInt64() & 1 << 24) != 0;
            short scancode = (short)((lParam.ToInt64() >> 16) & 0xff);
            VirtualKeys vkey = (VirtualKeys)wParam;

            Input.Key key = Input.KeyMap.TranslateKey(scancode, vkey, extended);

            if (key != Input.Key.Unknown)
                KeyDown(this, new Input.KeyboardKeyEventArgs(key));
        }
        #endregion

        #region OnKeyUp
        private void OnKeyUp(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
        {
            bool extended = (lParam.ToInt64() & 1 << 24) != 0;      //TODO - theres something called extended1 as well...
            short scancode = (short)((lParam.ToInt64() >> 16) & 0xff);
            VirtualKeys vkey = (VirtualKeys)wParam;

            Input.Key key = Input.KeyMap.TranslateKey(scancode, vkey, extended);

            if (key != Input.Key.Unknown)
                KeyUp(this, new Input.KeyboardKeyEventArgs(key));
        }
        #endregion

        #region OnMouseEnter
        private void OnMouseEnter()
        {
            MouseEntered(this, EventArgs.Empty);
        }
        #endregion

        #region OnMouseLeave
        private void OnMouseLeave()
        {
            _mouseOutsideWindow = true;

            MouseLeft(this, EventArgs.Empty);
        }
        #endregion

        #region OnMouseMove
        private void OnMouseMove()
        {
            if (_mouseOutsideWindow)
            {
                // Once we receive a mouse move event, it means that the mouse has re-entered the window.
                _mouseOutsideWindow = false;

                //Tell windows to keep an eye on the mouse and throw us MouseLeave messages in the WndProc - it won't without this call
                EnableMouseTracking();

                //Throw the OnMouseEnter event from here - the windows procedure just doesn't do this for some reason
                OnMouseEnter();
            }

            //Throw the actual MouseMoved event
            MouseMoved(this, EventArgs.Empty);

            //Tell windows to keep an eye on the mouse and throw us MouseLeave messages in the WndProc - it won't without this call
            void EnableMouseTracking()
            {
                TrackMouseEventStructure me = new TrackMouseEventStructure()
                {
                    Size = TrackMouseEventStructure.SizeInBytes,
                    TrackWindowHandle = WindowHandle,
                    Flags = TrackMouseEventFlags.LEAVE
                };

                if (!User32.TrackMouseEvent(ref me))
                    HConsole.Warning("Failed to enable mouse tracking, error: {0}.", Marshal.GetLastWin32Error());
            }
        }
        #endregion

        #region OnMoved
        private void OnMoved()
        {
            Moved(this, EventArgs.Empty);
        }
        #endregion        

        #region OnResize
        protected void OnResize(int width, int height)
        {
            int clampedWidth = Math.Max(Math.Min(width, MaxWidth > 0 ? MaxWidth : width), MinWidth);
            int clampedHeight = Math.Max(Math.Min(height, MaxHeight > 0 ? MaxHeight : height), MinHeight);

            if (width != clampedWidth || height != clampedHeight)
                ClientSize = new Point(clampedWidth, clampedHeight);

            RECT rect;
            User32.GetClientRect(WindowHandle, out rect);
            _clientPosition = new Rect(rect);

            var point = new System.Drawing.Point();
            User32.ClientToScreen(ChildWindowHandle, ref point);
            _clientPosition.X = point.X;
            _clientPosition.Y = point.Y;

            User32.SetWindowPos(ChildWindowHandle, IntPtr.Zero, 0, 0, (int)ClientPosition.W, (int)ClientPosition.H,
                SetWindowPosFlags.NOZORDER | SetWindowPosFlags.NOOWNERZORDER | SetWindowPosFlags.NOACTIVATE | SetWindowPosFlags.NOSENDCHANGING);

            if (_cursorLockedToWindow)
            {
                RECT r = new() { left = (int)_clientPosition.X, top = (int)_clientPosition.Y, right = (int)_clientPosition.Right, bottom = (int)_clientPosition.Bottom };
                User32.ClipCursor(ref r);
            }

            Resize(this, new SizeEventArgs(clampedWidth, clampedHeight));
        }
        #endregion

        #region ProcessEvents
        public void ProcessEvents()
        {
            while (User32.PeekMessage(ref _msg, WindowHandle, 0, 0, PM.REMOVE))
            {
                User32.TranslateMessage(ref _msg);
                User32.DispatchMessage(ref _msg);
            }
        }
        #endregion

        #region ShareRenderContexts
        /// <summary>
        /// Share textures, buffers etc between two OpenGL render contexts
        /// </summary>
        public void ShareRenderContexts(IntPtr renderContext1, IntPtr renderContext2)
        {
            OpenGL32.wglShareLists(renderContext1, renderContext2);
        }
        #endregion

        #region SwapBuffers
        public void SwapBuffers()
        {
            GDI32.SwapBuffers(DeviceContext);
        }
        #endregion

        #region Centre()
        public void Centre()
        {
            IntPtr monitor = User32.MonitorFromWindow(WindowHandle, MonitorFrom.Nearest);

            var mInfo = new MonitorInfo() { Size = MonitorInfo.UnmanagedSize };

            User32.GetMonitorInfo(monitor, ref mInfo);

            int x = Math.Max(0, (int)(mInfo.Work.Centre.X - 0.5f * Width));
            int y = Math.Max(0, (int)(mInfo.Work.Centre.Y - 0.5f * Height));

            ClientPosition = new Rect(x, y, Width, Height);
        }
        #endregion

        #region Close()
        public void Close()
        {
            HConsole.Log("Destroying Window: {0}", WindowHandle.ToString());

            OpenGL32.wglMakeCurrent(DeviceContext, IntPtr.Zero);
            OpenGL32.wglDeleteContext(RenderContext);
            IsRunning = false;
            User32.PostQuitMessage(0);
            OnClosed();
        }
        #endregion

        #region DestroyContext
        public void DestroyContext(IntPtr renderContext)
        {
            OpenGL32.wglDeleteContext(renderContext);
        }
        #endregion
        #endregion

        #region Events
        /// <summary>
        /// Called when Window is resized
        /// </summary>
        public event EventHandler<SizeEventArgs> Resize = delegate { };

        /// <summary>
        /// Called when the window gains or loses mouse focus
        /// </summary>
        public event EventHandler<BoolEventArgs> FocusChanged = delegate { };

        /// <summary>
        /// Called when the Visible state of the Window is changed
        /// </summary>
        public event EventHandler<BoolEventArgs> VisibleChanged = delegate { };

        /// <summary>
        /// Called when the Border type - fixed, resizable, borderless etc, is changed. Note this is tied into WindowState - eg fullscreen windows are borderless
        /// </summary>
        public event EventHandler<BorderChangeEventArgs> BorderChanged = delegate { };

        /// <summary>
        /// Called when the WindowState of the Window (eg fullscreen, maximised, normal..) is changed. Note this is tied into the BorderType and BorderChanged event, as these are linked
        /// </summary>
        public event EventHandler<WindowStateChangeEventArgs> StateChanged = delegate { };

        /// <summary>
        /// Called whenever a character, text number or symbol, is input by the keyboard. Will not record modifier keys like shift and alt.
        /// This reflects the actual character input, ie takes into account caps lock, shift keys, numlock etc etc and will catch rapid-fire inputs from a key held down for an extended time. 
        /// Use for eg text box input, rather than for controlling a game character (Use Input.GetKeyboardState)
        /// </summary>
        public event EventHandler<Input.KeyboardCharEventArgs> CharEntered = delegate { };

        /// <summary>
        /// Called whenever a keyboard key is released
        /// </summary>
        public event EventHandler<Input.KeyboardKeyEventArgs> KeyUp = delegate { };

        /// <summary>
        /// Called whenever a keybaord key is depressed
        /// </summary>
        public event EventHandler<Input.KeyboardKeyEventArgs> KeyDown = delegate { };

        /// <summary>
        /// Called when the mouse enters the game window
        /// </summary>
        public event EventHandler MouseEntered = delegate { };

        /// <summary>
        /// Called when the mouse leaves the game window
        /// </summary>
        public event EventHandler MouseLeft = delegate { };

        /// <summary>
        /// Called whenever the mouse is moved while over the window.
        /// </summary>
        public event EventHandler MouseMoved = delegate { };

        /// <summary>
        /// Called whenever the mouse left button is double clicked.
        /// </summary>
        public event EventHandler MouseLeftDoubleClicked;

        /// <summary>
        /// Called whenever the window is moved.
        /// </summary>
        public event EventHandler Moved = delegate { };

        /// <summary>
        /// Called after the window had initiated destruction.
        /// </summary>
        public event EventHandler Closed = delegate { };

        /// <summary>
        /// Called when the WM_CLOSE message has been received, usually by the user pressing the window X button.
        /// </summary>
        public event EventHandler Closing = delegate { };
        #endregion

        #region IDisposable
        public virtual void Dispose()
        {
            if (_disposed)
                throw new HException("You tried to dispose the same window twice.");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HaighWindow()
        {
            HConsole.Log("Destructor of Window was called, did you forget to call dispose?");
            Dispose(false);
        }

        private void Dispose(bool correctDisposal)
        {
            if (!_disposed)
            {
                if (correctDisposal)
                {
                    DestroyContext(RenderContext);  //I, Coak added this here 8th August because it wasnt getting called anywhere
                    User32.ReleaseDC(WindowHandle, DeviceContext);
                    Cursor?.Dispose();
                }
                else
                {
                    HConsole.Warning("Window did not dispose correctly.");
                }
                _disposed = true;
            }
        }
        #endregion
    }
}