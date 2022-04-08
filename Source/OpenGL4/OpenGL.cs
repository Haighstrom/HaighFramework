using System.Text;
using HaighFramework.Win32API;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace HaighFramework.OpenGL4;

public static class OpenGL
{
    #region --- Haigh Functions ---
    #region GetProcAddress
    private static void GetProcAddress<T>(string functionName, out T functionPointer)
    {
        IntPtr procAddress = OpenGL32.wglGetProcAddress(functionName);
        if (procAddress == IntPtr.Zero)
            throw new HException("Failed to load entrypoint for {0}.", functionName);
        functionPointer = (T)(object)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T));
    }
    #endregion

    #region LoadWGLExtensions
    public static void LoadWGLExtensions()
    {
        GetProcAddress("wglGetExtensionsStringARB", out _wglGetExtensionsStringARB);
        GetProcAddress("wglCreateContextAttribsARB", out _wglCreateContextAttribsARB);
        GetProcAddress("wglSwapIntervalEXT", out _wglSwapIntervalEXT);
        GetProcAddress("wglGetSwapIntervalEXT", out _wglGetSwapIntervalEXT);
        GetProcAddress("wglChoosePixelFormatARB", out _wglChoosePixelFormatARB);
        GetProcAddress("wglGetPixelFormatAttribivARB", out _wglGetPixelFormatAttribivARB);
    }
    #endregion

    #region LoadOpenGL3Extensions
    /// <summary>
    /// This needs to be called after an OpenGL4 render context has been created and before any of these functions are called
    /// </summary>
    public static void LoadOpenGL3Extensions()
    {
        GetProcAddress("glActiveTexture", out _glActiveTexture);
        GetProcAddress("glAttachShader", out _glAttachShader);
        GetProcAddress("glBindBuffer", out _glBindBuffer);
        GetProcAddress("glBindFramebuffer", out _glBindFramebuffer);
        GetProcAddress("glBindSampler", out _glBindSampler);
        GetProcAddress("glBlendFuncSeparate", out glBlendFuncSeparate);
        GetProcAddress("glBufferData", out _glBufferData); 
        GetProcAddress("glCompileShader", out _glCompileShader);
        GetProcAddress("glCreateProgram", out _glCreateProgram);
        GetProcAddress("glCreateShader", out _glCreateShader);
        GetProcAddress("glDebugMessageCallback", out _glDebugMessageCallback);
        GetProcAddress("glDebugMessageControl", out _glDebugMessageControl);
        GetProcAddress("glDeleteBuffers", out _glDeleteBuffers);
        GetProcAddress("glDeleteFramebuffers", out _glDeleteFramebuffers);
        GetProcAddress("glDeleteProgram", out _glDeleteProgram);
        GetProcAddress("glDeleteShader", out _glDeleteShader);
        GetProcAddress("glDetachShader", out _glDetachShader);
        GetProcAddress("glDisableVertexAttribArray", out _glDisableVertexAttribArray);
        GetProcAddress("glEnableVertexAttribArray", out _glEnableVertexAttribArray);
        GetProcAddress("glFramebufferTexture2D", out _glFramebufferTexture2D);
        GetProcAddress("glGenBuffers", out _glGenBuffers);
        GetProcAddress("glGenFramebuffers", out _glGenFramebuffers);
        GetProcAddress("glGetAttribLocation", out _glGetAttribLocation);
        GetProcAddress("glGetProgramInfoLog", out _glGetProgramInfoLog);
        GetProcAddress("glGetShaderInfoLog", out _glGetShaderInfoLog);
        GetProcAddress("glGetShaderiv", out _glGetShaderiv);
        GetProcAddress("glGetUniformLocation", out _glGetUniformLocation);
        GetProcAddress("glLinkProgram", out _glLinkProgram);
        GetProcAddress("glShaderSource", out _glShaderSource);
        GetProcAddress("glTexImage2DMultisample", out _glTexImage2DMultisample);
        GetProcAddress("glTexStorage2D", out _glTexStorage2D);
        GetProcAddress("glUniform1f", out _glUniform1f);
        GetProcAddress("glUniform1i", out _glUniform1i);
        GetProcAddress("glUniform2f", out _glUniform2f);
        GetProcAddress("glUniform3f", out _glUniform3f);
        GetProcAddress("glUniform4f", out _glUniform4f);
        GetProcAddress("glUniformMatrix3fv", out _glUniformMatrix3fv);
        GetProcAddress("glUniformMatrix4fv", out _glUniformMatrix4fv);
        GetProcAddress("glUseProgram", out _glUseProgram);
        GetProcAddress("glValidateProgram", out _glValidateProgram);
        GetProcAddress("glVertexAttribPointer", out _glVertexAttribPointer);
    }
    #endregion

    #region PremultiplyAlpha
    public unsafe static Bitmap PremultiplyAlpha(Bitmap bitmap)
    {
        // Lock the entire bitmap for Read/Write access as we'll be reading the pixel
        // colour values and altering them in-place.
        var bmlock = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                     ImageLockMode.ReadWrite, bitmap.PixelFormat);

        // This code only works with 32bit argb images - assume no alpha if not this format
        if (bmlock.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            throw new HException("Unsupported pixel format {0}. Should be Formar32bppArgb to use TexturePremultiplier", bmlock.PixelFormat);

        var ptr = (byte*)bmlock.Scan0.ToPointer();

        for (var y = 0; y < bmlock.Height; y++)
        {
            for (var x = 0; x < bmlock.Width; x++)
            {
                // Obtain the memory location where our pixel data resides and cast it
                // into a struct to improve sanity.
                var color = (RgbaColor*)(ptr + (y * bmlock.Stride) + (x * sizeof(RgbaColor)));

                var alphaFloat = (*color).Alpha / 255.0f;

                (*color).Red = Convert.ToByte(alphaFloat * (*color).Red);
                (*color).Green = Convert.ToByte(alphaFloat * (*color).Green);
                (*color).Blue = Convert.ToByte(alphaFloat * (*color).Blue);
            }
        }

        // The bitmap lock is freed here
        bitmap.UnlockBits(bmlock);

        return bitmap;
    }
    #endregion

    #region GetAvailableExtensions
    public static List<string> GetAvailableExtensions()
    {
        string s = GetExtensionsStringARB(User32.GetDC(IntPtr.Zero));

        return s == null ? new List<string>() : s.Split(' ').ToList();
    }
    #endregion
    #endregion

    #region --- OpenGL Core Functions ---
    #region AlphaFunc
    public static void AlphaFunc(AlphaFunction func, float @ref)
    {
        OpenGL32.glAlphaFunc((int)func, @ref);
    }
    #endregion

    #region BindTexture
    public static void BindTexture(TextureTarget target, uint texture)
    {
        OpenGL32.glBindTexture((int)target, texture);
    }
    #endregion

    #region BlendFunc
    public static void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor)
    {
        OpenGL32.glBlendFunc((int)sfactor, (int)dfactor);
    }
    #endregion

    #region Clear
    public static void Clear(ClearBufferMask mask)
    {
        OpenGL32.glClear((uint)mask);
    }
    #endregion

    #region ClearColour
    /// <summary>
    /// Components in [0,255]
    /// </summary>
    public static void ClearColour(byte red, byte green, byte blue, byte alpha = 255)
    {
        OpenGL32.glClearColor(((float)red)/255, ((float)green) / 255, ((float)blue) / 255, ((float)alpha) / 255);
    }

    public static void ClearColour(Colour colour)
    {
        OpenGL32.glClearColor(((float)colour.R)/255, ((float)colour.G) / 255, ((float)colour.B) / 255, ((float)colour.A) / 255);
    }
    #endregion

    #region Colour
    public static void Colour(Colour colour)
    {
        OpenGL32.glColor4f(((float)colour.R) / 255, ((float)colour.G) / 255, ((float)colour.B) / 255, ((float)colour.A) / 255);
    }
    public static void Colour(byte red, byte green, byte blue)
    {
        OpenGL32.glColor3f(((float)red) / 255, ((float)green) / 255, ((float)blue) / 255);
    }

    public static void Colour(byte red, byte green, byte blue, byte alpha)
    {
        OpenGL32.glColor4f(((float)red) / 255, ((float)green) / 255, ((float)blue) / 255, ((float)alpha) / 255);
    }
    #endregion               

    #region DeleteTexture(s)
    public static void DeleteTexture(uint texture)
    {
        uint[] textures = new uint[1];

        OpenGL32.glDeleteTextures(1, textures);
    }
    public static void DeleteTexture(uint[] textures)
    {
        int n = textures.Length;

        OpenGL32.glDeleteTextures(n, textures);
    }
    #endregion

    #region DepthMask
    public static void DepthMask(bool flag)
    {
        OpenGL32.glDepthMask(flag);
    }
    #endregion

    #region Disable
    public static void Disable(EnableCap cap)
    {
        OpenGL32.glDisable((int)cap);
    }
    #endregion

    #region DisableClientState
    public static void DisableClientState(VertexArray array)
    {
        OpenGL32.glDisableClientState((uint)array);
    }
    #endregion

    #region DrawArrays
    public static void DrawArrays(PrimitiveType mode, int first, int count)
    {
        OpenGL32.glDrawArrays((int)mode, first, count);
    }
    #endregion

    #region Enable
    public static void Enable(EnableCap cap)
    {
        OpenGL32.glEnable((int)cap);
    }
    #endregion

    #region EnableClientState
    public static void EnableClientState(VertexArray array)
    {
        OpenGL32.glEnableClientState((uint)array);
    }
    #endregion

    #region Flush
    public static void Flush()
    {
        OpenGL32.glFlush();
    }
    #endregion

    #region FrontFace
    public static void FrontFace(FrontFaceDirection mode)
    {
        OpenGL32.glFrontFace((int)mode);
    }
    #endregion

    #region GenTexture(s)
    public static uint GenTexture()
    {
        uint[] textures = new uint[1];

        OpenGL32.glGenTextures(1, textures);

        return textures[0];
    }
    public static uint[] GenTextures(int n)
    {
        uint[] textures = new uint[n];

        OpenGL32.glGenTextures(n, textures);

        return textures;
    }
    #endregion

    #region GetBool
    public static bool[] GetBool(GLEnumPName pname)
    {
        bool[] bools;

        OpenGL32.glGetBooleanv((int)pname, out bools);

        return bools;
    }
    #endregion

    #region GetInt
    public static int GetInt(GLEnumPName pname)
    {
        OpenGL32.glGetIntegerv((int)pname, out int i);

        return i;
    }
    #endregion

    #region GetViewport
    public static Rect GetViewport()
    {
        int[] ints = new int[4];
        OpenGL32.glGetIntegerv((int)GLEnumPName.Viewport, ints);
        return new Rect(ints[0], ints[1], ints[2], ints[3]);
    }
    #endregion

    #region GetError
    public static OpenGLErrorCode GetError()
    {
        return (OpenGLErrorCode)OpenGL32.glGetError();
    }
    #endregion

    #region GetString
    public static string GetString(GetStringEnum name)
    {
        unsafe
        {
            return new string(OpenGL32.glGetString((uint)name));
        }
    }
    #endregion

    #region GetTexImage
    public static void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, IntPtr pixels)
    {
        OpenGL32.glGetTexImage((int)target, level, (int)format, (int)type, pixels);
    }
    public static void GetTexImage<T>(TextureTarget target, int level, PixelFormat format, PixelType type, T[] pixels)
    {
        GCHandle pinnedArray = GCHandle.Alloc(pixels, GCHandleType.Pinned);

        IntPtr pointer = pinnedArray.AddrOfPinnedObject();

        OpenGL32.glGetTexImage((int)target, level, (int)format, (int)type, pointer);

        pinnedArray.Free();
    }
    #endregion

    #region IsEnabled
    public static bool IsEnabled(EnableCap cap)
    {
        return OpenGL32.glIsEnabled((int)cap) == 1;
    }
    #endregion

    #region Light
    public static void Light(LightName light, LightParameter pname, float[] @params)
    {
        OpenGL32.glLightfv((int)light, (int)pname, @params);
    }
    #endregion

    #region LineWidth
    public static void LineWidth(float width)
    {
        OpenGL32.glLineWidth(width);
    }
    #endregion

    #region LoadIdentity
    public static void LoadIdentity()
    {
        OpenGL32.glLoadIdentity();
    }
    #endregion

    #region Material
    public static void Material(MaterialFace face, MaterialParameter pname, float[] @params)
    {
        OpenGL32.glMaterialfv((int)face, (int)pname, @params);
    }
    #endregion

    #region MatrixMode
    public static void MatrixMode(MatrixMode mode)
    {
        OpenGL32.glMatrixMode((int)mode);
    }
    #endregion

    #region Normal
    public static void Normal(float nx, float ny, float nz)
    {
        OpenGL32.glNormal3f(nx, ny, nz);
    }
    #endregion

    #region Ortho
    public static void Ortho(double left, double right, double bottom, double top, double zNear, double zFar)
    {
        OpenGL32.glOrtho(left, right, bottom, top, zNear, zFar);
    }
    #endregion

    #region PixelStore
    public static void PixelStore(PixelStoreParameter pname, int param)
    {
        OpenGL32.glPixelStorei((int)pname, param);
    }
    #endregion

    #region PointSize
    public static void PointSize(float size)
    {
        OpenGL32.glPointSize(size);
    }
    #endregion

    #region PolygonMode
    public static void PolygonMode(MaterialFace face, PolygonMode mode)
    {
        OpenGL32.glPolygonMode((int)face, (int)mode);
    }
    #endregion

    #region PopMatrix
    public static void PopMatrix()
    {
        OpenGL32.glPopMatrix();
    }
    #endregion

    #region PushMatrix
    public static void PushMatrix()
    {
        OpenGL32.glPushMatrix();
    }
    #endregion

    #region ReadPixels
    public static void ReadPixels(int x, int y, int w, int h, PixelFormat format, PixelType type, IntPtr data)
    {
        OpenGL32.glReadPixels(x, y, w, h, (int)format, (int)type, data);
    }
    #endregion

    #region Rotate
    public static void Rotate(float angle, float x, float y, float z)
    {
        OpenGL32.glRotatef(angle, x, y, z);
    }
    #endregion

    #region Scale
    public static void Scale(float x, float y, float z)
    {
        OpenGL32.glScalef(x, y, z);
    }
    #endregion

    #region ShadeModel
    public static void ShadeModel(ShadingModel mode)
    {
        OpenGL32.glShadeModel((int)mode);
    }
    #endregion

    #region TexCoord
    public static void TexCoord(float s, float t)
    {
        OpenGL32.glTexCoord2f(s, t);
    }
    #endregion

    #region TexImage1D
    public static void TexImage1D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int border, PixelFormat format, PixelType type, IntPtr pixels)
    {
        OpenGL32.glTexImage1D((int)target, level, (int)internalFormat, width, border, (int)format, (int)type, pixels);
    }
    #endregion

    #region TexImage2D
    public static void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
    {
        OpenGL32.glTexImage2D((int)target, level, (int)internalFormat, width, height, border, (int)format, (int)type, pixels);
    }
    public static void TexImage2D<T>(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, T[] pixels)
    {
        GCHandle pinnedArray = GCHandle.Alloc(pixels, GCHandleType.Pinned);

        IntPtr pointer = pinnedArray.AddrOfPinnedObject();

        OpenGL32.glTexImage2D((int)target, level, (int)internalFormat, width, height, border, (int)format, (int)type, pointer);

        pinnedArray.Free();
    }
    public static void TexImage2D<T>(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, T[,] pixels)
    {
        GCHandle pinnedArray = GCHandle.Alloc(pixels, GCHandleType.Pinned);

        IntPtr pointer = pinnedArray.AddrOfPinnedObject();

        OpenGL32.glTexImage2D((int)target, level, (int)internalFormat, width, height, border, (int)format, (int)type, pointer);

        pinnedArray.Free();
    }
    #endregion

    #region TexSubImage2D
    public static void TexSubImage2D(TextureTarget target, int level, int xOffset, int yOffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
    {
        OpenGL32.glTexSubImage2D((int)target, level, xOffset, yOffset, width, height, (int)format, (int)type, pixels);
    }
    #endregion

    #region TexParameter
    public static void TexParameter(TextureTarget target, TextureParameterName pname, TextureParameter param)
    {
        OpenGL32.glTexParameteri((int)target, (int)pname, (int)param);
    }
    #endregion

    #region Translate
    public static void Translate(float x, float y, float z)
    {
        OpenGL32.glTranslatef(x, y, z);
    }
    #endregion

    #region Vertex
    public static void Vertex(float x, float y)
    {
        OpenGL32.glVertex2f(x, y);
    }

    public static void Vertex(float x, float y, float z)
    {
        OpenGL32.glVertex3f(x, y, z);
    }
    #endregion

    #region VertexPointer
    public static void VertexPointer(int size, DataType type, int stride, float[] pointer)
    {
        OpenGL32.glVertexPointer(size, (uint)type, stride, pointer);
    }
    #endregion

    #region Viewport
    public static void Viewport(int x, int y, int w, int h)
    {
        OpenGL32.glViewport(x, y, w, h);
    }
    public static void Viewport(IRect viewport)
    {
        OpenGL32.glViewport((int)viewport.X, (int)viewport.Y, (int)viewport.W, (int)viewport.H);
    }
    #endregion
    #endregion

    #region --- WGL Extension Functions        
    #region wglGetExtensionsStringARB
    private delegate string wglGetExtensionsStringARB(IntPtr hDc);
    private static wglGetExtensionsStringARB _wglGetExtensionsStringARB;
    /// <summary>
    /// wglGetExtensionStringARB
    /// </summary>
    public static string GetExtensionsStringARB(IntPtr hDc) => _wglGetExtensionsStringARB(hDc);
    #endregion

    #region wglGetPixelFormatAttribivARB
    private delegate bool wglGetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, [Out] int[] piValues);
    private static wglGetPixelFormatAttribivARB _wglGetPixelFormatAttribivARB;
    public static bool GetPixelFormatAttribivARB(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, [Out] int[] piValues)
        => _wglGetPixelFormatAttribivARB(hdc, iPixelFormat, iLayerPlane, nAttributes, piAttributes, piValues);
    #endregion

    #region wglChoosePixelFormatARB
    private delegate bool wglChoosePixelFormatARB(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, [Out] int[] piFormats, out int nNumFormats);
    private static wglChoosePixelFormatARB _wglChoosePixelFormatARB;
    public static bool ChoosePixelFormatARB(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, [Out] int[] piFormats, out int nNumFormats)
        => _wglChoosePixelFormatARB(hdc, piAttribIList, pfAttribFList, nMaxFormats, piFormats, out nNumFormats);
    #endregion

    #region wglCreateContextAttribsARB
    //note that this is necessarily created before LoadOpenGLExtensions is called
    private delegate IntPtr wglCreateContextAttribsARB(IntPtr hDc, IntPtr sharedContext, int[] attribList);
    private static wglCreateContextAttribsARB _wglCreateContextAttribsARB;

    public static IntPtr CreateContextAttribsARB(IntPtr hDc, IntPtr sharedContext, int[] attribList) 
        => _wglCreateContextAttribsARB(hDc, sharedContext, attribList);
    #endregion

    #region wglSwapIntervalEXT
    private delegate bool wglSwapIntervalEXT(int value);
    private static wglSwapIntervalEXT _wglSwapIntervalEXT;
    /// <summary>
    /// Set VSync options, -1, 0 or 1
    /// https://stackoverflow.com/questions/589064/how-to-enable-vertical-sync-in-opengl
    /// </summary>
    /// <param name="value"></param>
    public static bool SwapIntervalEXT(int value) => _wglSwapIntervalEXT(value);
    #endregion

    #region wglGetSwapIntervalEXT
    private delegate int wglGetSwapIntervalEXT();
    private static wglGetSwapIntervalEXT _wglGetSwapIntervalEXT;
    public static int GetSwapIntervalEXT() => _wglGetSwapIntervalEXT();
    #endregion
    #endregion

    #region --- OpenGL 3.0 Extension Functions ---
    #region ActiveTexture / glActiveTexture
    private delegate void DEL_glActiveTexture(int unit);
    private static DEL_glActiveTexture _glActiveTexture;
    /// <summary>
    /// glActiveTexture
    /// </summary>
    public static void ActiveTexture(TextureUnit unit)
    {
        _glActiveTexture((int)unit);
    }
    #endregion

    #region AttachShader / glAttachShader
    private delegate void DEL_glAttachShader(uint program, int shader);
    private static DEL_glAttachShader _glAttachShader;
    /// <summary>
    /// glAttachShader
    /// </summary>
    public static void AttachShader(uint program, int shader)
    {
        _glAttachShader(program, shader);
    }
    #endregion

    #region BindBuffer / glBindBuffer
    private delegate void DEL_glBindBuffer(int target, uint buffer);
    private static DEL_glBindBuffer _glBindBuffer;
    /// <summary>
    /// glBindBuffer
    /// </summary>
    public static void BindBuffer(BufferTarget target, uint buffer)
    {
        _glBindBuffer((int)target, buffer);
    }
    #endregion

    #region BindFramebuffer / glBindFramebuffer
    private delegate void DEL_glBindFramebuffer(int target, uint frameBuffer);
    private static DEL_glBindFramebuffer _glBindFramebuffer;
    /// <summary>
    /// glBindFramebuffer
    /// </summary>
    public static void BindFramebuffer(FramebufferTarget target, uint frameBuffer)
    {
        _glBindFramebuffer((int)target, frameBuffer);
    }
    #endregion

    #region BindSampler / glBindSampler
    private delegate void DEL_glBindSampler(int unit, int sampler);
    private static DEL_glBindSampler _glBindSampler;
    /// <summary>
    /// glBindSampler
    /// </summary>
    public static void BindSampler(TextureUnit unit, int sampler)
    {
        _glBindSampler((int)unit, sampler);
    }
    #endregion

    #region BlendFuncSeperate
    private delegate void DEL_glBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);
    private static DEL_glBlendFuncSeparate glBlendFuncSeparate;

    public static void BlendFuncSeperate(BlendingFactorSrc srcRGB, BlendingFactorDest dstRGB, BlendingFactorSrc srcAlpha, BlendingFactorDest dstAlpha)
    {
        glBlendFuncSeparate((int)srcRGB, (int)dstRGB, (int)srcAlpha, (int)dstAlpha);
    }
    #endregion

    #region BufferData / glBufferData
    private delegate void DEL_glBufferData(int target, IntPtr size, IntPtr data, int usage);
    private static DEL_glBufferData _glBufferData;
    /// <summary>
    /// glBufferData
    /// </summary>
    public static void BufferData<T>(BufferTarget target, int size, T[] data, BufferUsageHint usage) where T : struct
    {
        GCHandle pinnedArray = GCHandle.Alloc(data, GCHandleType.Pinned);

        IntPtr pointer = pinnedArray.AddrOfPinnedObject();

        _glBufferData((int)target, (IntPtr)size, pointer, (int)usage);

        pinnedArray.Free();
    }
    #endregion

    #region CompileShader / glCompileShader
    private delegate void DEL_glCompileShader(int program);
    private static DEL_glCompileShader _glCompileShader;
    /// <summary>
    /// glCompileShader
    /// </summary>
    public static void CompileShader(int program)
    {
        _glCompileShader(program);
    }
    #endregion

    #region CreateProgram / glCreateProgram
    private delegate uint DEL_glCreateProgram();
    private static DEL_glCreateProgram _glCreateProgram;
    /// <summary>
    /// glCreateProgram
    /// </summary>
    public static uint CreateProgram()
    {
        return _glCreateProgram();
    }
    #endregion

    #region CreateShader / glCreateShader
    private delegate int DEL_glCreateShader(int shaderType);
    private static DEL_glCreateShader _glCreateShader;
    /// <summary>
    /// glCreateShader
    /// </summary>
    public static int CreateShader(ShaderType shaderType)
    {
        return _glCreateShader((int)shaderType);
    }
    #endregion

    #region DebugMessageCallback
    private delegate void DEL_glDebugMessageCallback(IntPtr callback, IntPtr userParam);
    private static DEL_glDebugMessageCallback _glDebugMessageCallback;
    public static void DebugMessageCallback(DebugMessageDelegate callbackFunction)
    {
        _glDebugMessageCallback(Marshal.GetFunctionPointerForDelegate(callbackFunction), IntPtr.Zero);
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DebugMessageDelegate(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
    #endregion

    #region DebugMessageControl
    private delegate void DEL_glDebugMessageControl(int source, int type, int severity, int count, uint[] ids, bool enabled);
    private static DEL_glDebugMessageControl _glDebugMessageControl;

    public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled)
    {
        _glDebugMessageControl((int)source, (int)type, (int)severity, count, ids, enabled);
    }

    public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, bool enabled)
    {
        DebugMessageControl(source, type, severity, 0, null, enabled);
    }
    #endregion

    #region DeleteBuffer(s) / glDeleteBuffers
    private delegate void DEL_glDeleteBuffers(int n, uint[] buffers);
    private static DEL_glDeleteBuffers _glDeleteBuffers;
    /// <summary>
    /// glDeleteBuffers
    /// </summary>
    public static void DeleteBuffers(uint[] buffers)
    {
        int n = buffers.Length;

        _glDeleteBuffers(n, buffers);
    }
    /// <summary>
    /// glDeleteBuffers
    /// </summary>
    public static void DeleteBuffer(uint buffer)
    {
        uint[] buffers = { buffer };

        _glDeleteBuffers(1, buffers);
    }
    #endregion

    #region DeleteFramebuffers(s) / glDeleteFramebuffers
    private delegate void DEL_glDeleteFramebuffers(int n, uint[] framebuffers);
    private static DEL_glDeleteFramebuffers _glDeleteFramebuffers;
    /// <summary>
    /// glDeleteFramebuffers
    /// </summary>
    public static void DeleteFramebuffers(uint[] framebuffers)
    {
        int n = framebuffers.Length;

        _glDeleteFramebuffers(n, framebuffers);
    }
    /// <summary>
    /// glDeleteFramebuffers
    /// </summary>
    public static void DeleteFramebuffer(uint framebuffer)
    {
        uint[] framebuffers = { framebuffer };

        _glDeleteFramebuffers(1, framebuffers);
    }
    #endregion

    #region DeleteShader / glDeleteShader
    private delegate void DEL_glDeleteShader(int shader);
    private static DEL_glDeleteShader _glDeleteShader;
    /// <summary>
    /// glDeleteShader
    /// </summary>
    public static void DeleteShader(int shader)
    {
        _glDeleteShader(shader);
    }
    #endregion

    #region DeleteProgram / glDeleteProgram
    private delegate void DEL_glDeleteProgram(uint program);
    private static DEL_glDeleteProgram _glDeleteProgram;
    /// <summary>
    /// glDeleteProgram
    /// </summary>
    public static void DeleteProgram(uint program)
    {
        _glDeleteProgram(program);
    }
    #endregion

    #region DetachShader / glDetachShader
    private delegate void DEL_glDetachShader(uint program, int shader);
    private static DEL_glDetachShader _glDetachShader;
    /// <summary>
    /// glDetachShader
    /// </summary>
    public static void DetachShader(uint program, int shader)
    {
        _glDetachShader(program, shader);
    }
    #endregion

    #region DisableVertexAttribArray / glDisableVertexAttribArray
    private delegate void DEL_glDisableVertexAttribArray(uint index);
    private static DEL_glDisableVertexAttribArray _glDisableVertexAttribArray;
    /// <summary>
    /// glDisableVertexAttribArray
    /// </summary>
    public static void DisableVertexAttribArray(int index)
    {
        _glDisableVertexAttribArray((uint)index);
    }
    #endregion

    #region EnableVertexArray / glEnableVertexAttribArray
    private delegate void DEL_glEnableVertexAttribArray(uint index);
    private static DEL_glEnableVertexAttribArray _glEnableVertexAttribArray;
    /// <summary>
    /// glEnableVertexAttribArray
    /// </summary>
    public static void EnableVertexAttribArray(int index)
    {
        _glEnableVertexAttribArray((uint)index);
    }
    #endregion

    #region FramebufferTexture2D / glFramebufferTexture2D
    private delegate void DEL_glFramebufferTexture2D(int target, int attachment, int texTarget, uint texture, int level);
    private static DEL_glFramebufferTexture2D _glFramebufferTexture2D;
    /// <summary>
    /// glFramebufferTexture2D
    /// </summary>
    public static void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget texTarget, uint texture, int level)
    {
        _glFramebufferTexture2D((int)target, (int)attachment, (int)texTarget, texture, level);
    }
    #endregion

    #region GenBuffer(s) / glGenBuffers
    private delegate void DEL_glGenBuffers(int n, uint[] buffers);
    private static DEL_glGenBuffers _glGenBuffers;
    /// <summary>
    /// glGenBuffers
    /// </summary>
    public static uint[] GenBuffers(int n)
    {
        uint[] buffers = new uint[n];

        _glGenBuffers(n, buffers);

        return buffers;
    }
    /// <summary>
    /// glGenBuffers
    /// </summary>
    public static uint GenBuffer()
    {
        uint[] buffers = new uint[1];

        _glGenBuffers(1, buffers);

        return buffers[0];
    }
    #endregion

    #region GenFramebuffer(s) / glGenFramebuffers
    private delegate void DEL_glGenFrameBuffers(int n, uint[] buffers);
    private static DEL_glGenFrameBuffers _glGenFramebuffers;

    public static uint[] GenFramebuffers(int n)
    {
        uint[] buffers = new uint[n];

        _glGenFramebuffers(1, buffers);

        return buffers;
    }
    public static uint GenFramebuffer()
    {
        uint[] buffers = new uint[1];

        _glGenFramebuffers(1, buffers);

        return buffers[0];
    }
    #endregion

    #region GetAttribLocation / glGetAttribLocation
    private delegate int DEL_glGetAttribLocation(uint programObj, string name);
    private static DEL_glGetAttribLocation _glGetAttribLocation;
    /// <summary>
    /// glGetAttribLocation
    /// </summary>
    public static int GetAttribLocation(uint program, string name)
    {
        return _glGetAttribLocation(program, name);
    }
    #endregion

    #region GetProgramInfoLog / glGetProgramInfoLog
    private unsafe delegate void DEL_glGetProgramInfoLog(uint program, int bufSize, out int length, StringBuilder infoLog);
    private static DEL_glGetProgramInfoLog _glGetProgramInfoLog;
    /// <summary>
    /// glGetProgramInfoLog
    /// </summary>
    public static string GetProgramInfoLog(uint program)
    {
        StringBuilder stringPtr = new(255);
        int count;
        _glGetProgramInfoLog(program, 255, out count, stringPtr);

        return stringPtr.ToString();
    }
    #endregion

    #region GetShader / glGetShaderiv
    private unsafe delegate void DEL_glGetShaderiv(uint shader, int pname, int* @params);
    private static DEL_glGetShaderiv _glGetShaderiv;
    /// <summary>
    /// glGetShaderiv
    /// </summary>
    public static int GetShader(uint shader, ShaderParameter pname)
    {
        unsafe
        {
            int i;
            _glGetShaderiv(shader, (int)pname, &i);
            return i;
        }
    }
    #endregion

    #region GetShaderInfoLog / glGetShaderInfoLog
    private unsafe delegate void DEL_glGetShaderInfoLog(uint shader, int bufSize, out int length, StringBuilder infoLog);
    private static DEL_glGetShaderInfoLog _glGetShaderInfoLog;
    /// <summary>
    /// glGetShaderInfoLog
    /// </summary>
    public static string GetShaderInfoLog(int shader)
    {
        StringBuilder stringPtr = new(255);
        int count;
        _glGetShaderInfoLog((uint)shader, 255, out count, stringPtr);

        return stringPtr.ToString();
    }
    #endregion

    #region GetUniformLocation / glGetUniformLocation
    private delegate int DEL_glGetUniformLocation(uint program, string name);
    private static DEL_glGetUniformLocation _glGetUniformLocation;
    /// <summary>
    /// glGetUniformLocation
    /// </summary>
    public static int GetUniformLocation(uint program, string name)
    {
        return _glGetUniformLocation(program, name);
    }
    #endregion

    #region LinkProgram / glLinkProgram
    private delegate void DEL_glLinkProgram(uint program);
    private static DEL_glLinkProgram _glLinkProgram;
    /// <summary>
    /// glLinkProgram
    /// </summary>
    public static void LinkProgram(uint program)
    {
        _glLinkProgram(program);
    }
    #endregion

    #region ShaderSource / glShaderSource
    private delegate int DEL_glShaderSource(int shader, int count, string[] strings, int[] lengths);
    private static DEL_glShaderSource _glShaderSource;
    /// <summary>
    /// glShaderSource
    /// </summary>
    public static int ShaderSource(int shader, string source)
    {
        string[] strings = new string[1] { source };

        return _glShaderSource(shader, 1, strings, null);
    }
    #endregion

    #region TexImage2DMultisample / glTexImage2DMultisample
    private delegate int DEL_glTexImage2DMultisample(int target, int samples, int internalformat, int width, int height, bool fixedsamplelocations);
    private static DEL_glTexImage2DMultisample _glTexImage2DMultisample;
    /// <summary>
    /// glTexImage2DMultisample
    /// </summary>
    public static void TexImage2DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalFormat, int width, int height, bool fixedSampleLocations)
    {
        _glTexImage2DMultisample((int)target, samples, (int)internalFormat, width, height, fixedSampleLocations);
    }
    /// <summary>
    /// glTexImage2DMultisample
    /// </summary>
    public static void TexImage2DMultisample(TextureTargetMultisample target, MSAA_Samples samples, PixelInternalFormat internalFormat, int width, int height, bool fixedSampleLocations) => TexImage2DMultisample(target, (int)samples, internalFormat, width, height, fixedSampleLocations);
    #endregion

    #region TexStorage2D / glTexStorage2D
    private delegate void DEL_glTexStorage2D(uint target, int levels, int internalFormat, int width, int height);
    private static DEL_glTexStorage2D _glTexStorage2D;

    public static void TexStorage2D(TextureTarget target, int levels, TexInternalFormat internalFormat, int width, int height)
    {
        _glTexStorage2D((uint)target, levels, (int)internalFormat, width, height);
    }
    #endregion

    #region Uniform / glUniform1f / glUniform1i
    private delegate void DEL_glUniform1f(int location, float v0);
    private static DEL_glUniform1f _glUniform1f;

    private delegate void DEL_glUniform1i(int location, int v0);
    private static DEL_glUniform1i _glUniform1i;

    /// <summary>
    /// glUniform1f
    /// </summary>
    public static void Uniform(int location, float value)
    {
        _glUniform1f(location, value);
    }
    /// <summary>
    /// glUniform1i
    /// </summary>
    public static void Uniform(int location, int value)
    {
        _glUniform1i(location, value);
    }
    #endregion

    #region Uniform2 / glUniform2f / glUniform2i
    private delegate void DEL_glUniform2f(int location, float v0, float v1);
    private static DEL_glUniform2f _glUniform2f;

    private delegate void DEL_glUniform2i(int location, int v0, int v1);
    private static DEL_glUniform2i _glUniform2i;

    /// <summary>
    /// glUniform2f
    /// </summary>
    public static void Uniform2(int location, Point value)
    {
        _glUniform2f(location, value.X, value.Y);
    }
    #endregion

    #region Uniform3 / glUniform3f / glUniform3i
    private delegate void DEL_glUniform3f(int location, float v0, float v1, float v2);
    private static DEL_glUniform3f _glUniform3f;

    private delegate void DEL_glUniform3i(int location, int v0, int v1, int v2);
    private static DEL_glUniform3i _glUniform3i;

    /// <summary>
    /// glUniform3f
    /// </summary>
    public static void Uniform3(int location, Point3 value)
    {
        _glUniform3f(location, value.x, value.y, value.z);
    }
    #endregion

    #region Uniform4 / glUniform4f / glUniform4i
    private delegate void DEL_glUniform4f(int location, float v0, float v1, float v2, float v3);
    private static DEL_glUniform4f _glUniform4f;

    private delegate void DEL_glUniform4i(int location, int v0, int v1, int v2, int v3);
    private static DEL_glUniform4i _glUniform4i;

    /// <summary>
    /// glUniform4f
    /// </summary>
    public static void Uniform4(int location, Point4 value)
    {
        _glUniform4f(location, value.x, value.y, value.z, value.w);
    }
    public static void Uniform4(int location, Colour value)
    {
        _glUniform4f(location, value.R / 255f, value.G / 255f, value.B / 255f, value.A / 255f);
    }
    #endregion

    #region UniformMatrix3 / glUniformMatrix3fv
    private unsafe delegate void DEL_glUniformMatrix3fv(int location, int count, bool transpose, float* value);
    private static DEL_glUniformMatrix3fv _glUniformMatrix3fv;
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix3(int location, int count, bool transpose, float[] values)
    {
        unsafe
        {
            fixed (float* valuePointer = values)
            {
                _glUniformMatrix3fv(location, count, transpose, valuePointer);
            }
        }
    }
    /// <summary>
    /// glUniformMatrix3fv
    /// </summary>
    public static void UniformMatrix3(int location, float[] values) => UniformMatrix3(location, 1, false, values);
    /// <summary>
    /// glUniformMatrix3fv
    /// </summary>
    public static void UniformMatrix3(int location, ref Matrix4 matrix) => UniformMatrix3(location, 1, false, matrix.Values);
    #endregion

    #region UniformMatrix4 / glUniformMatrix4fv
    private unsafe delegate void DEL_glUniformMatrix4fv(int location, int count, bool transpose, float* value);
    private static DEL_glUniformMatrix4fv _glUniformMatrix4fv;
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix4(int location, int count, bool transpose, float[] values)
    {
        unsafe
        {
            fixed (float* valuePointer = values)
            {
                _glUniformMatrix4fv(location, count, transpose, valuePointer);
            }
        }
    }
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix4(int location, float[] values) => UniformMatrix4(location, 1, false, values);
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix4(int location, ref Matrix4 matrix) => UniformMatrix4(location, 1, false, matrix.Values);
    #endregion

    #region UseProgram / glUseProgram
    private delegate void DEL_glUseProgram(uint program);
    private static DEL_glUseProgram _glUseProgram;
    /// <summary>
    /// glUseProgram
    /// </summary>
    public static void UseProgram(uint program)
    {
        _glUseProgram(program);
    }
    #endregion

    #region ValidateProgram / glValidateProgram
    private delegate void DEL_glValidateProgram(uint program);
    private static DEL_glValidateProgram _glValidateProgram;
    /// <summary>
    /// glValidateProgram
    /// </summary>
    public static void ValidateProgram(uint program)
    {
        _glValidateProgram(program);
    }
    #endregion

    #region VertexAttribPointer / glVertexAttribPointer
    private delegate void DEL_glVertexAttribPointer(uint index, int size, int type, bool normalized, int stride, IntPtr pointer);
    private static DEL_glVertexAttribPointer _glVertexAttribPointer;
    /// <summary>
    /// glVertexAttribPointer
    /// </summary>
    public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalised, int stride, int offset)
    {
        _glVertexAttribPointer((uint)index, size, (int)type, normalised, stride, new IntPtr(offset));
    }
    #endregion
    #endregion

    #region --- WGL Functions ---
    #region WGLCreateContext
    public static IntPtr WGLCreateContext(IntPtr deviceContext) => OpenGL32.wglCreateContext(deviceContext);
    #endregion

    public static bool WGLShareLists(IntPtr renderContext1, IntPtr renderContext2) => OpenGL32.wglShareLists(renderContext1, renderContext2);

    public static bool WGLDeleteContext(IntPtr renderContext) => OpenGL32.wglDeleteContext(renderContext);

    #region WGLDescribePixelFormat
    internal static int WGLDescribePixelFormat(IntPtr hdc, int ipfd, uint cjpfd, PIXELFORMATDESCRIPTOR ppfd)
    {
        return OpenGL32.wglDescribePixelFormat(hdc, ipfd, cjpfd, ppfd);
    }
    #endregion

    public static IntPtr WGLGetCurrentContext() => OpenGL32.wglGetCurrentContext();

    #region WGLGetProcAddress
    internal static IntPtr WGLGetProcAddress(string lpszProc)
    {
        return OpenGL32.wglGetProcAddress(lpszProc);
    }
    #endregion

    #region WGLMakeCurrent
    public static void WGLMakeCurrent(IntPtr deviceContext, IntPtr renderContext)
    {
        if (!OpenGL32.wglMakeCurrent(deviceContext, renderContext))
            throw new HException("Failed to make render context current: {0}", Marshal.GetLastWin32Error());
    }
    #endregion
    #endregion

    #region --- GDI32 Functions ---
    #region GDISwapBuffers
    public static void GDISwapBuffers(IntPtr deviceContext)
    {
        GDI32.SwapBuffers(deviceContext);
    }
    #endregion
    #endregion

    #region --- GLU32 Functions ---
    #region GLUBuild2DMipmaps
    public static int GLUBuild2DMipmaps(TextureTarget target, int internalFormat, int width, int height, PixelFormat pixelFormat, PixelType type, IntPtr data)
    {
        return GLU32.gluBuild2DMipmaps((int)target, internalFormat, width, height, (int)pixelFormat, (int)type, data);
    }
    #endregion

    #region GLULookAt
    public static void GLULookAt(double eyex, double eyey, double eyez, double centrex, double centrey, double centrez, double upx, double upy, double upz)
    {
        GLU32.gluLookAt(eyex, eyey, eyez, centrex, centrey, centrez, upx, upy, upz);
    }
    #endregion

    #region GLUPerspective
    public static void GLUPerspective(double fovy, double aspect, double zNear, double zFar)
    {
        GLU32.gluPerspective(fovy, aspect, zNear, zFar);
    }
    #endregion
    #endregion

    #region --- OpenGL Immediate Mode Functions (Deprecated) ---
    public static class ImmediateMode
    {
        #region Begin
        public static void Begin(PrimitiveType mode)
        {
            OpenGL32.glBegin((int)mode);
        }
        #endregion

        #region End
        public static void End()
        {
            OpenGL32.glEnd();
        }
        #endregion
    }
    #endregion
}
