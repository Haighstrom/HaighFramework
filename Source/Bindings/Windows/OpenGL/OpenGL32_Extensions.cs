using System.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using HaighFramework.WinAPI;

namespace HaighFramework.OpenGL;

[SuppressUnmanagedCodeSecurity]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "OpenGL functions have dumb naming conventions but I'm keeping these APIs pure.")]
public static partial class OpenGL32
{
    #region Delegates
    private delegate void Delegate_glActiveTexture(TEXTURE_UNIT unit);
    private delegate void Delegate_glAttachShader(uint program, int shader);
    private delegate void Delegate_glBindBuffer(BUFFER_TARGET target, uint buffer);
    private delegate void Delegate_glBindFramebuffer(FramebufferTarget target, uint frameBuffer);
    private delegate void Delegate_glBindSampler(int unit, int sampler);
    private delegate void Delegate_glBlendFuncSeparate(BLEND_SCALE_FACTOR srcRGB, BLEND_SCALE_FACTOR dstRGB, BLEND_SCALE_FACTOR srcAlpha, BLEND_SCALE_FACTOR dstAlpha);
    private delegate void Delegate_glBufferData(BUFFER_TARGET target, IntPtr size, IntPtr data, USAGE_PATTERN usage);
    private delegate void Delegate_glCompileShader(int program);
    private delegate uint Delegate_glCreateProgram();
    private delegate int Delegate_glCreateShader(int shaderType);
    private delegate void Delegate_glDebugMessageCallback(IntPtr callback, IntPtr userParam);
    private delegate void Delegate_glDebugMessageControl(int source, int type, int severity, int count, uint[] ids, bool enabled);
    private delegate void Delegate_glDeleteBuffers(int n, uint[] buffers);
    private delegate void Delegate_glDeleteFramebuffers(int n, uint[] framebuffers);
    private delegate void Delegate_glDeleteProgram(uint program);
    private delegate void Delegate_glDeleteShader(int shader);
    private delegate void Delegate_glDetachShader(uint program, int shader);
    private delegate void Delegate_glDisableVertexAttribArray(uint index);
    private delegate void Delegate_glEnableVertexAttribArray(uint index);
    private delegate void Delegate_glFramebufferTexture2D(int target, int attachment, int texTarget, uint texture, int level);
    private delegate void Delegate_glGenBuffers(int n, uint[] buffers);
    private delegate void Delegate_glGenFrameBuffers(int n, uint[] buffers);
    private delegate int Delegate_glGetAttribLocation(uint programObj, string name);
    private unsafe delegate void Delegate_glGetProgramInfoLog(uint program, int bufSize, out int length, StringBuilder infoLog);
    private unsafe delegate void Delegate_glGetShaderiv(uint shader, int pname, int* @params);
    private unsafe delegate void Delegate_glGetShaderInfoLog(uint shader, int bufSize, out int length, StringBuilder infoLog);
    private delegate int Delegate_glGetUniformLocation(uint program, string name);
    private delegate void Delegate_glLinkProgram(uint program);
    private delegate int Delegate_glShaderSource(int shader, int count, string[] strings, int[] lengths);
    private delegate int Delegate_glTexImage2DMultisample(int target, int samples, int internalformat, int width, int height, bool fixedsamplelocations);
    private delegate void Delegate_glTexStorage2D(uint target, int levels, int internalFormat, int width, int height);
    private delegate void Delegate_glUniform1f(int location, float v0);
    private delegate void Delegate_glUniform1i(int location, int v0);
    private delegate void Delegate_glUniform2f(int location, float v0, float v1);
    private delegate void Delegate_glUniform2i(int location, int v0, int v1);
    private delegate void Delegate_glUniform3f(int location, float v0, float v1, float v2);
    private delegate void Delegate_glUniform3i(int location, int v0, int v1, int v2);
    private delegate void Delegate_glUniform4f(int location, float v0, float v1, float v2, float v3);
    private delegate void Delegate_glUniform4i(int location, int v0, int v1, int v2, int v3);
    private unsafe delegate void Delegate_glUniformMatrix3fv(int location, int count, bool transpose, float* value);
    private unsafe delegate void Delegate_glUniformMatrix4fv(int location, int count, bool transpose, float* value);
    private delegate void Delegate_glUseProgram(uint program);
    private delegate void Delegate_glVertexAttribPointer(uint index, int size, int type, bool normalized, int stride, IntPtr pointer);
    private delegate void Delegate_glValidateProgram(uint program);

    /// <summary>
    /// Delegate for use with <see cref="glDebugMessageCallback"/>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="severity"></param>
    /// <param name="length"></param>
    /// <param name="message"></param>
    /// <param name="userParam"></param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DebugMessageDelegate(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
    #endregion

    #region Entry Points
    private static Delegate_glActiveTexture? _glActiveTexture;
    private static Delegate_glAttachShader? _glAttachShader;
    private static Delegate_glBindBuffer? _glBindBuffer;
    private static Delegate_glBindFramebuffer? _glBindFramebuffer;
    private static Delegate_glBindSampler? _glBindSampler;
    private static Delegate_glBlendFuncSeparate? _glBlendFuncSeparate;
    private static Delegate_glBufferData? _glBufferData;
    private static Delegate_glCompileShader? _glCompileShader;
    private static Delegate_glCreateProgram? _glCreateProgram;
    private static Delegate_glCreateShader? _glCreateShader;
    private static Delegate_glDebugMessageCallback? _glDebugMessageCallback;
    private static Delegate_glDebugMessageControl? _glDebugMessageControl;
    private static Delegate_glDeleteBuffers? _glDeleteBuffers;
    private static Delegate_glDeleteFramebuffers? _glDeleteFramebuffers;
    private static Delegate_glDeleteShader? _glDeleteShader;
    private static Delegate_glDeleteProgram? _glDeleteProgram;
    private static Delegate_glDisableVertexAttribArray? _glDisableVertexAttribArray;
    private static Delegate_glDetachShader? _glDetachShader;
    private static Delegate_glEnableVertexAttribArray? _glEnableVertexAttribArray;
    private static Delegate_glFramebufferTexture2D? _glFramebufferTexture2D;
    private static Delegate_glGenBuffers? _glGenBuffers;
    private static Delegate_glGenFrameBuffers? _glGenFramebuffers;
    private static Delegate_glGetAttribLocation? _glGetAttribLocation;
    private static Delegate_glGetProgramInfoLog? _glGetProgramInfoLog;
    private static Delegate_glGetShaderiv? _glGetShaderiv;
    private static Delegate_glGetShaderInfoLog? _glGetShaderInfoLog;
    private static Delegate_glGetUniformLocation? _glGetUniformLocation;
    private static Delegate_glLinkProgram? _glLinkProgram;
    private static Delegate_glShaderSource? _glShaderSource;
    private static Delegate_glTexImage2DMultisample? _glTexImage2DMultisample;
    private static Delegate_glTexStorage2D? _glTexStorage2D;
    private static Delegate_glUniform1f? _glUniform1f;
    private static Delegate_glUniform1i? _glUniform1i;
    private static Delegate_glUniform2f? _glUniform2f;
    private static Delegate_glUniform2i? _glUniform2i;
    private static Delegate_glUniform3f? _glUniform3f;
    private static Delegate_glUniform3i? _glUniform3i;
    private static Delegate_glUniform4f? _glUniform4f;
    private static Delegate_glUniform4i? _glUniform4i;
    private static Delegate_glUniformMatrix3fv? _glUniformMatrix3fv;
    private static Delegate_glUniformMatrix4fv? _glUniformMatrix4fv;
    private static Delegate_glUseProgram? _glUseProgram;
    private static Delegate_glValidateProgram? _glValidateProgram;
    private static Delegate_glVertexAttribPointer? _glVertexAttribPointer;
    #endregion

    /// <summary>
    /// Selects which texture unit subsequent texture state calls will affect.
    /// </summary>
    /// <param name="texture">Specifies which texture unit to make active. The number of texture units is implementation dependent, but must be at least 80. texture must be one of GL_TEXTUREi, where i ranges from zero to the value of GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS minus one. The initial value is GL_TEXTURE0.</param>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public static void glActiveTexture(TEXTURE_UNIT texture)
    {
        if (_glActiveTexture is null)
            throw new EntryPointNotFoundException($"{nameof(_glActiveTexture)} was called but the entrypoint was not loaded.");

        _glActiveTexture(texture);
    }

    /// <summary>
    /// Attaches a shader object to a program object
    /// </summary>
    /// <param name="program">Specifies the program object to which a shader object will be attached.</param>
    /// <param name="shader">Specifies the shader object that is to be attached.</param>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public static void glAttachShader(uint program, int shader)
    {
        if (_glAttachShader is null)
            throw new EntryPointNotFoundException($"{nameof(_glAttachShader)} was called but the entrypoint was not loaded.");

        _glAttachShader(program, shader);
    }

    /// <summary>
    /// Binds a buffer object to the specified buffer binding point. When a buffer object is bound to a target, the previous binding for that target is automatically broken.
    /// </summary>
    /// <param name="target">Specifies the target to which the buffer object is bound.</param>
    /// <param name="buffer">Specifies the name of a buffer object.</param>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public static void glBindBuffer(BUFFER_TARGET target, uint buffer)
    {
        if (_glBindBuffer is null)
            throw new EntryPointNotFoundException($"{nameof(_glBindBuffer)} was called but the entrypoint was not loaded.");

        _glBindBuffer(target, buffer);
    }


    //----Fully Updated above this line----


    public static void glBindFramebuffer(FramebufferTarget target, uint frameBuffer)
    {
        if (_glBindFramebuffer is null)
            throw new EntryPointNotFoundException($"{nameof(_glBindFramebuffer)} was called but the entrypoint was not loaded.");

        _glBindFramebuffer(target, frameBuffer);
    }

    public static void glBindSampler(TEXTURE_UNIT unit, int sampler)
    {
        if (_glBindSampler is null)
            throw new EntryPointNotFoundException($"{nameof(_glBindSampler)} was called but the entrypoint was not loaded.");

        _glBindSampler((int)unit, sampler);
    }

    public static void glBlendFuncSeperate(BLEND_SCALE_FACTOR srcRGB, BLEND_SCALE_FACTOR dstRGB, BLEND_SCALE_FACTOR srcAlpha, BLEND_SCALE_FACTOR dstAlpha)
    {
        if (_glBlendFuncSeparate is null)
            throw new EntryPointNotFoundException($"{nameof(_glBlendFuncSeparate)} was called but the entrypoint was not loaded.");

        _glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
    }

    public static void glBufferData(BUFFER_TARGET target, IntPtr size, IntPtr data, USAGE_PATTERN usage)
    {
        if (_glBufferData is null)
            throw new EntryPointNotFoundException($"{nameof(_glBufferData)} was called but the entrypoint was not loaded.");

        _glBufferData(target, size, data, usage);
    }

    //----Naming finalised, comments still to be added above this line----

    /// <summary>
    /// This needs to be called after an OpenGL4 render context has been created and before any of these functions are called
    /// </summary>
    public static void LoadOpenGL3Extensions()
    {
        GL.GetProcAddress("glActiveTexture", out _glActiveTexture);
        GL.GetProcAddress("glAttachShader", out _glAttachShader);
        GL.GetProcAddress("glBindBuffer", out _glBindBuffer);
        GL.GetProcAddress("glBindFramebuffer", out _glBindFramebuffer);
        GL.GetProcAddress("glBindSampler", out _glBindSampler);
        GL.GetProcAddress("glBlendFuncSeparate", out _glBlendFuncSeparate);
        GL.GetProcAddress("glBufferData", out _glBufferData);
        GL.GetProcAddress("glCompileShader", out _glCompileShader);
        GL.GetProcAddress("glCreateProgram", out _glCreateProgram);
        GL.GetProcAddress("glCreateShader", out _glCreateShader);
        GL.GetProcAddress("glDebugMessageCallback", out _glDebugMessageCallback);
        GL.GetProcAddress("glDebugMessageControl", out _glDebugMessageControl);
        GL.GetProcAddress("glDeleteBuffers", out _glDeleteBuffers);
        GL.GetProcAddress("glDeleteFramebuffers", out _glDeleteFramebuffers);
        GL.GetProcAddress("glDeleteProgram", out _glDeleteProgram);
        GL.GetProcAddress("glDeleteShader", out _glDeleteShader);
        GL.GetProcAddress("glDetachShader", out _glDetachShader);
        GL.GetProcAddress("glDisableVertexAttribArray", out _glDisableVertexAttribArray);
        GL.GetProcAddress("glEnableVertexAttribArray", out _glEnableVertexAttribArray);
        GL.GetProcAddress("glFramebufferTexture2D", out _glFramebufferTexture2D);
        GL.GetProcAddress("glGenBuffers", out _glGenBuffers);
        GL.GetProcAddress("glGenFramebuffers", out _glGenFramebuffers);
        GL.GetProcAddress("glGetAttribLocation", out _glGetAttribLocation);
        GL.GetProcAddress("glGetProgramInfoLog", out _glGetProgramInfoLog);
        GL.GetProcAddress("glGetShaderInfoLog", out _glGetShaderInfoLog);
        GL.GetProcAddress("glGetShaderiv", out _glGetShaderiv);
        GL.GetProcAddress("glGetUniformLocation", out _glGetUniformLocation);
        GL.GetProcAddress("glLinkProgram", out _glLinkProgram);
        GL.GetProcAddress("glShaderSource", out _glShaderSource);
        GL.GetProcAddress("glTexImage2DMultisample", out _glTexImage2DMultisample);
        GL.GetProcAddress("glTexStorage2D", out _glTexStorage2D);
        GL.GetProcAddress("glUniform1f", out _glUniform1f);
        GL.GetProcAddress("glUniform1i", out _glUniform1i);
        GL.GetProcAddress("glUniform2f", out _glUniform2f);
        GL.GetProcAddress("glUniform3f", out _glUniform3f);
        GL.GetProcAddress("glUniform4f", out _glUniform4f);
        GL.GetProcAddress("glUniformMatrix3fv", out _glUniformMatrix3fv);
        GL.GetProcAddress("glUniformMatrix4fv", out _glUniformMatrix4fv);
        GL.GetProcAddress("glUseProgram", out _glUseProgram);
        GL.GetProcAddress("glValidateProgram", out _glValidateProgram);
        GL.GetProcAddress("glVertexAttribPointer", out _glVertexAttribPointer);
    }


    /// <summary>
    /// glCompileShader
    /// </summary>
    public static void CompileShader(int program)
    {
        if (_glCompileShader is null)
            throw new EntryPointNotFoundException($"{nameof(_glCompileShader)} was called but the entrypoint was not loaded.");

        _glCompileShader(program);
    }

    /// <summary>
    /// glCreateProgram
    /// </summary>
    public static uint CreateProgram()
    {
        if (_glCreateProgram is null)
            throw new EntryPointNotFoundException($"{nameof(_glCreateProgram)} was called but the entrypoint was not loaded.");

        return _glCreateProgram();
    }

    /// <summary>
    /// glCreateShader
    /// </summary>
    public static int CreateShader(ShaderType shaderType)
    {
        if (_glCreateShader is null)
            throw new EntryPointNotFoundException($"{nameof(_glCreateShader)} was called but the entrypoint was not loaded.");

        return _glCreateShader((int)shaderType);
    }

    public static void glDebugMessageCallback(DebugMessageDelegate callbackFunction)
    {
        if (_glDebugMessageCallback is null)
            throw new EntryPointNotFoundException($"{nameof(_glDebugMessageCallback)} was called but the entrypoint was not loaded.");

        _glDebugMessageCallback(Marshal.GetFunctionPointerForDelegate(callbackFunction), IntPtr.Zero);
    }

    public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled)
    {
        if (_glDebugMessageControl is null)
            throw new EntryPointNotFoundException($"{nameof(_glDebugMessageControl)} was called but the entrypoint was not loaded.");

        _glDebugMessageControl((int)source, (int)type, (int)severity, count, ids, enabled);
    }

    public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, bool enabled)
    {
        if (_glActiveTexture is null)
            throw new EntryPointNotFoundException($"{nameof(_glActiveTexture)} was called but the entrypoint was not loaded.");

        DebugMessageControl(source, type, severity, 0, null, enabled);
    }

    /// <summary>
    /// glDeleteBuffers
    /// </summary>
    public static void DeleteBuffers(uint[] buffers)
    {
        if (_glDeleteBuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glDeleteBuffers)} was called but the entrypoint was not loaded.");

        int n = buffers.Length;

        _glDeleteBuffers(n, buffers);
    }
    /// <summary>
    /// glDeleteBuffers
    /// </summary>
    public static void DeleteBuffer(uint buffer)
    {
        if (_glDeleteBuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glDeleteBuffers)} was called but the entrypoint was not loaded.");

        uint[] buffers = { buffer };

        _glDeleteBuffers(1, buffers);
    }

    /// <summary>
    /// glDeleteFramebuffers
    /// </summary>
    public static void DeleteFramebuffers(uint[] framebuffers)
    {
        if (_glDeleteFramebuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glDeleteFramebuffers)} was called but the entrypoint was not loaded.");

        int n = framebuffers.Length;

        _glDeleteFramebuffers(n, framebuffers);
    }

    /// <summary>
    /// glDeleteFramebuffers
    /// </summary>
    public static void DeleteFramebuffer(uint framebuffer)
    {
        if (_glDeleteFramebuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glDeleteFramebuffers)} was called but the entrypoint was not loaded.");

        uint[] framebuffers = { framebuffer };

        _glDeleteFramebuffers(1, framebuffers);
    }

    /// <summary>
    /// glDeleteShader
    /// </summary>
    public static void DeleteShader(int shader)
    {
        if (_glDeleteShader is null)
            throw new EntryPointNotFoundException($"{nameof(_glDeleteShader)} was called but the entrypoint was not loaded.");

        _glDeleteShader(shader);
    }

    /// <summary>
    /// glDeleteProgram
    /// </summary>
    public static void DeleteProgram(uint program)
    {
        if (_glDeleteProgram is null)
            throw new EntryPointNotFoundException($"{nameof(_glDeleteProgram)} was called but the entrypoint was not loaded.");

        _glDeleteProgram(program);
    }

    /// <summary>
    /// glDetachShader
    /// </summary>
    public static void DetachShader(uint program, int shader)
    {
        if (_glDetachShader is null)
            throw new EntryPointNotFoundException($"{nameof(_glDetachShader)} was called but the entrypoint was not loaded.");

        _glDetachShader(program, shader);
    }

    /// <summary>
    /// glDisableVertexAttribArray
    /// </summary>
    public static void DisableVertexAttribArray(int index)
    {
        if (_glDisableVertexAttribArray is null)
            throw new EntryPointNotFoundException($"{nameof(_glDisableVertexAttribArray)} was called but the entrypoint was not loaded.");

        _glDisableVertexAttribArray((uint)index);
    }

    /// <summary>
    /// glEnableVertexAttribArray
    /// </summary>
    public static void EnableVertexAttribArray(int index)
    {
        if (_glEnableVertexAttribArray is null)
            throw new EntryPointNotFoundException($"{nameof(_glEnableVertexAttribArray)} was called but the entrypoint was not loaded.");

        _glEnableVertexAttribArray((uint)index);
    }

    /// <summary>
    /// glFramebufferTexture2D
    /// </summary>
    public static void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TEXTURE_TARGET texTarget, uint texture, int level)
    {
        if (_glFramebufferTexture2D is null)
            throw new EntryPointNotFoundException($"{nameof(_glFramebufferTexture2D)} was called but the entrypoint was not loaded.");

        _glFramebufferTexture2D((int)target, (int)attachment, (int)texTarget, texture, level);
    }

    /// <summary>
    /// glGenBuffers
    /// </summary>
    public static uint[] GenBuffers(int n)
    {
        if (_glGenBuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glGenBuffers)} was called but the entrypoint was not loaded.");

        uint[] buffers = new uint[n];

        _glGenBuffers(n, buffers);

        return buffers;
    }

    /// <summary>
    /// glGenBuffers
    /// </summary>
    public static uint GenBuffer()
    {
        if (_glGenBuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glGenBuffers)} was called but the entrypoint was not loaded.");

        uint[] buffers = new uint[1];

        _glGenBuffers(1, buffers);

        return buffers[0];
    }

    public static uint[] GenFramebuffers(int n)
    {
        if (_glGenFramebuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glGenFramebuffers)} was called but the entrypoint was not loaded.");

        uint[] buffers = new uint[n];

        _glGenFramebuffers(1, buffers);

        return buffers;
    }
    public static uint GenFramebuffer()
    {
        if (_glGenFramebuffers is null)
            throw new EntryPointNotFoundException($"{nameof(_glGenFramebuffers)} was called but the entrypoint was not loaded.");

        uint[] buffers = new uint[1];

        _glGenFramebuffers(1, buffers);

        return buffers[0];
    }

    /// <summary>
    /// glGetAttribLocation
    /// </summary>
    public static int GetAttribLocation(uint program, string name)
    {
        if (_glGetAttribLocation is null)
            throw new EntryPointNotFoundException($"{nameof(_glGetAttribLocation)} was called but the entrypoint was not loaded.");

        return _glGetAttribLocation(program, name);
    }

    /// <summary>
    /// glGetProgramInfoLog
    /// </summary>
    public static string GetProgramInfoLog(uint program)
    {
        if (_glGetProgramInfoLog is null)
            throw new EntryPointNotFoundException($"{nameof(_glGetProgramInfoLog)} was called but the entrypoint was not loaded.");

        StringBuilder stringPtr = new(255);
        int count;
        _glGetProgramInfoLog(program, 255, out count, stringPtr);

        return stringPtr.ToString();
    }

    /// <summary>
    /// glGetShaderiv
    /// </summary>
    public static int GetShader(uint shader, ShaderParameter pname)
    {
        if (_glGetShaderiv is null)
            throw new EntryPointNotFoundException($"{nameof(_glGetShaderiv)} was called but the entrypoint was not loaded.");

        unsafe
        {
            int i;
            _glGetShaderiv(shader, (int)pname, &i);
            return i;
        }
    }

    /// <summary>
    /// glGetShaderInfoLog
    /// </summary>
    public static string GetShaderInfoLog(int shader)
    {
        if (_glGetShaderInfoLog is null)
            throw new EntryPointNotFoundException($"{nameof(_glGetShaderInfoLog)} was called but the entrypoint was not loaded.");

        StringBuilder stringPtr = new(255);
        int count;
        _glGetShaderInfoLog((uint)shader, 255, out count, stringPtr);

        return stringPtr.ToString();
    }

    /// <summary>
    /// glGetUniformLocation
    /// </summary>
    public static int GetUniformLocation(uint program, string name)
    {
        if (_glGetUniformLocation is null)
            throw new EntryPointNotFoundException($"{nameof(_glGetUniformLocation)} was called but the entrypoint was not loaded.");

        return _glGetUniformLocation(program, name);
    }

    /// <summary>
    /// glLinkProgram
    /// </summary>
    public static void LinkProgram(uint program)
    {
        if (_glLinkProgram is null)
            throw new EntryPointNotFoundException($"{nameof(_glLinkProgram)} was called but the entrypoint was not loaded.");

        _glLinkProgram(program);
    }

    /// <summary>
    /// glShaderSource
    /// </summary>
    public static int ShaderSource(int shader, string source)
    {
        if (_glShaderSource is null)
            throw new EntryPointNotFoundException($"{nameof(_glShaderSource)} was called but the entrypoint was not loaded.");

        string[] strings = new string[1] { source };

        return _glShaderSource(shader, 1, strings, null);
    }
    
    /// <summary>
    /// glTexImage2DMultisample
    /// </summary>
    public static void TexImage2DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalFormat, int width, int height, bool fixedSampleLocations)
    {
        if (_glTexImage2DMultisample is null)
            throw new EntryPointNotFoundException($"{nameof(_glTexImage2DMultisample)} was called but the entrypoint was not loaded.");

        _glTexImage2DMultisample((int)target, samples, (int)internalFormat, width, height, fixedSampleLocations);
    }

    /// <summary>
    /// glTexImage2DMultisample
    /// </summary>
    public static void TexImage2DMultisample(TextureTargetMultisample target, MSAA_Samples samples, PixelInternalFormat internalFormat, int width, int height, bool fixedSampleLocations) => TexImage2DMultisample(target, (int)samples, internalFormat, width, height, fixedSampleLocations);
    
    public static void TexStorage2D(TEXTURE_TARGET target, int levels, TexInternalFormat internalFormat, int width, int height)
    {
        if (_glTexStorage2D is null)
            throw new EntryPointNotFoundException($"{nameof(_glTexStorage2D)} was called but the entrypoint was not loaded.");

        _glTexStorage2D((uint)target, levels, (int)internalFormat, width, height);
    }
    
    /// <summary>
    /// glUniform1f
    /// </summary>
    public static void Uniform(int location, float value)
    {
        if (_glUniform1f is null)
            throw new EntryPointNotFoundException($"{nameof(_glUniform1f)} was called but the entrypoint was not loaded.");

        _glUniform1f(location, value);
    }

    /// <summary>
    /// glUniform1i
    /// </summary>
    public static void Uniform(int location, int value)
    {
        if (_glUniform1i is null)
            throw new EntryPointNotFoundException($"{nameof(_glUniform1i)} was called but the entrypoint was not loaded.");

        _glUniform1i(location, value);
    }

    public static void glUniform2f(int location, float v0, float v1)
    {
        if (_glUniform2f is null)
            throw new EntryPointNotFoundException($"{nameof(_glUniform2f)} was called but the entrypoint was not loaded.");

        _glUniform2f(location, v0, v1);
    }
    
    /// <summary>
    /// glUniform4f
    /// </summary>
    public static void glUniform4f(int location, float v0, float v1, float v2, float v3)
    {
        if (_glUniform4f is null)
            throw new EntryPointNotFoundException($"{nameof(_glUniform4f)} was called but the entrypoint was not loaded.");

        _glUniform4f(location, v0, v1, v2, v3);
    }

    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix3(int location, int count, bool transpose, float[] values)
    {
        if (_glUniformMatrix3fv is null)
            throw new EntryPointNotFoundException($"{nameof(_glUniformMatrix3fv)} was called but the entrypoint was not loaded.");

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
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix4(int location, int count, bool transpose, float[] values)
    {
        if (_glUniformMatrix4fv is null)
            throw new EntryPointNotFoundException($"{nameof(_glUniformMatrix4fv)} was called but the entrypoint was not loaded.");

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
    /// glUseProgram
    /// </summary>
    public static void UseProgram(uint program)
    {
        if (_glUseProgram is null)
            throw new EntryPointNotFoundException($"{nameof(_glUseProgram)} was called but the entrypoint was not loaded.");

        _glUseProgram(program);
    }

    /// <summary>
    /// glValidateProgram
    /// </summary>
    public static void ValidateProgram(uint program)
    {
        if (_glValidateProgram is null)
            throw new EntryPointNotFoundException($"{nameof(_glValidateProgram)} was called but the entrypoint was not loaded.");

        _glValidateProgram(program);
    }
    
    /// <summary>
    /// glVertexAttribPointer
    /// </summary>
    public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalised, int stride, int offset)
    {
        if (_glVertexAttribPointer is null)
            throw new EntryPointNotFoundException($"{nameof(_glVertexAttribPointer)} was called but the entrypoint was not loaded.");

        _glVertexAttribPointer((uint)index, size, (int)type, normalised, stride, new IntPtr(offset));
    }
}